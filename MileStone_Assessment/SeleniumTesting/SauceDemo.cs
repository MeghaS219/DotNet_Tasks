using OpenQA.Selenium.Chrome;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SeleniumTesting
{
    internal class SauceDemo
    {
        public static void Main(string[] args)
        {
            // Initialize the Chrome driver
            IWebDriver driver = new ChromeDriver();
            Console.WriteLine("Navigating to Sauce Demo site...");
            driver.Navigate().GoToUrl("https://www.saucedemo.com/");
            driver.Manage().Window.Maximize();

            // Create an instance of the LoginPage
            LoginPage loginPage = new LoginPage(driver);

            // Use the login method
            try
            {
                Console.WriteLine("Attempting to log in...");
                loginPage.Login("standard_user", "secret_sauce");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"An error occurred: {ex.Message}");
            }

            // Verify successful login
            string currentUrl = driver.Url;
            if (currentUrl == "https://www.saucedemo.com/inventory.html")
            {
                Console.WriteLine($"Login successful. Current URL: {currentUrl}");
            }
            else
            {
                Console.WriteLine("Login failed.");
            }


            driver.Quit();

        }
    }
}
