using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.Remote;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebAppAutomation
{
    internal class TheInternet
    {
        IWebDriver driver;
        IWebElement ele;

        [SetUp]
        public void startBrowser()
        {
            driver = new FirefoxDriver("C:/Program Files/Mozilla Firefox");
        }

        [Test]
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

                Console.WriteLine("Successfuly Uploaded!");
            }
            catch (Exception)
            {
                Console.WriteLine("Error");
            }

        }

        [TearDown]
        public void closeBrowser()
        {
        }

    }
}
