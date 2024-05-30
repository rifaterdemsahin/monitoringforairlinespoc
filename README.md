# Last-Minute Flight Deals Monitor

This project is a C# console application that monitors the last-minute flight deals on the Virgin Atlantic website. It checks the specified URL every 5 minutes to see if there are any deals for London. If no deals for London are found, it sends an email notification to a specified address.

## Features

- Headless browser navigation using Selenium WebDriver.
- Periodic checking every 5 minutes.
- Email notification if deals for London are not found.

## Prerequisites

- .NET Core SDK
- ChromeDriver
- NuGet packages: `Selenium.WebDriver`, `Selenium.WebDriver.ChromeDriver`, `System.Net.Mail`

## Setup Instructions

1. **Clone the repository**
    ```sh
    git clone https://github.com/yourusername/LastMinuteFlightDealsMonitor.git
    cd LastMinuteFlightDealsMonitor
    ```

2. **Install NuGet packages**
    ```sh
    dotnet add package Selenium.WebDriver
    dotnet add package Selenium.WebDriver.ChromeDriver
    dotnet add package System.Net.Mail
    ```

3. **Download and install ChromeDriver**
    - Ensure ChromeDriver executable is in your PATH or specify its location in the code.

4. **Configure email settings**
    - Replace `"your-email@example.com"`, `"your-email-password"`, and `"smtp.example.com"` in the `SendEmail` method with your email credentials and SMTP server details.

## Usage

1. **Build the project**
    ```sh
    dotnet build
    ```

2. **Run the project**
    ```sh
    dotnet run
    ```

The application will start monitoring the specified URL and check for London deals every 5 minutes. If no deals for London are found, an email notification will be sent to `monitoring_flights@virgin.co.uk`.

## License

This project is licensed under the MIT License. See the [LICENSE](LICENSE) file for details.

## Contributing

Contributions are welcome! Please feel free to submit a pull request or open an issue if you have any suggestions or improvements.

## Author

Your Name

## Acknowledgements

- [Selenium](https://www.selenium.dev/)
- [NuGet](https://www.nuget.org/)

