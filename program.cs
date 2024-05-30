using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Threading;
using System.Threading.Tasks;

class Program
{
    static async Task Main(string[] args)
    {
        var url = "https://flights.virginatlantic.com/en-gb/last-minute-deals?cta=VA_OHP_hero_lastminute";
        var recipientEmail = "monitoring_flights@virgin.co.uk";

        while (true)
        {
            bool isLondonPresent = CheckForLondonInDeals(url);

            if (!isLondonPresent)
            {
                SendEmail(recipientEmail);
            }

            await Task.Delay(TimeSpan.FromMinutes(5));
        }
    }

    static bool CheckForLondonInDeals(string url)
    {
        var options = new ChromeOptions();
        options.AddArgument("--headless");
        options.AddArgument("--disable-gpu");
        options.AddArgument("--no-sandbox");

        using (IWebDriver driver = new ChromeDriver(options))
        {
            driver.Navigate().GoToUrl(url);
            var bodyText = driver.FindElement(By.TagName("body")).Text;
            return bodyText.Contains("London", StringComparison.OrdinalIgnoreCase);
        }
    }

    static void SendEmail(string recipientEmail)
    {
        var fromAddress = new MailAddress("your-email@example.com", "Flight Monitor");
        var toAddress = new MailAddress(recipientEmail);
        const string fromPassword = "your-email-password";
        const string subject = "London Deals Not Found";
        const string body = "The last-minute deals page does not contain any deals for London.";

        var smtp = new SmtpClient
        {
            Host = "smtp.example.com",
            Port = 587,
            EnableSsl = true,
            DeliveryMethod = SmtpDeliveryMethod.Network,
            UseDefaultCredentials = false,
            Credentials = new NetworkCredential(fromAddress.Address, fromPassword)
        };
        using (var message = new MailMessage(fromAddress, toAddress)
        {
            Subject = subject,
            Body = body
        })
        {
            smtp.Send(message);
        }
    }
}
