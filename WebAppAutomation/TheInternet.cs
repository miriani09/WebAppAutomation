using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.Interactions;
using OpenQA.Selenium.Remote;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace WebAppAutomation
{
    internal class TheInternet
    {
        IWebDriver driver;
        IWebElement ele;

        public void startBrowser()
        {
            driver = new FirefoxDriver("C:\\Program Files\\Mozilla Firefox");
        }

        public void openBrowser()
        {
            driver.Url = "https://the-internet.herokuapp.com/";
        }
        public void fileUpload()
        {
            try
            {
                driver.FindElement(By.LinkText("File Upload")).Click();

                string file = "C:\\Users\\Miria\\Desktop\\file.txt";
                driver.FindElement(By.Id("file-upload")).SendKeys(file);

                driver.FindElement(By.Id("file-submit")).Click();

                Console.WriteLine("Test Passed!");
                Thread.Sleep(2000);
                driver.Navigate().GoToUrl("https://the-internet.herokuapp.com/");
            }
            catch (Exception)
            {
                Console.WriteLine("Test Failed");
            }
        }

        public void shiftingContent()
        {
            try
            {
                driver.FindElement(By.LinkText("Shifting Content")).Click();
                driver.FindElement(By.LinkText("Example 1: Menu Element")).Click();

                IWebElement element = driver.FindElement(By.LinkText("Home"));
                Actions action = new Actions(driver);
                action.MoveToElement(element).Perform();
                Thread.Sleep(3000);

                driver.Navigate().Back();
                driver.FindElement(By.LinkText("Example 2: An image")).Click();

                for (int i = 0; i < 4; i++)
                {
                    driver.FindElement(By.CssSelector("[href*='?pixel_shift=100']")).Click();
                    Console.WriteLine("Photo Changed!");
                }

                Console.WriteLine("Test Passed");

            }
            catch (Exception)
            {
                Console.WriteLine("Test Failed");
            }
        }

        public void ChalengingDOM()
        {

        }

        public void closeBrowser()
        {
        }

    }
}
