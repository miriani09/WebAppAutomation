using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.Interactions;
using OpenQA.Selenium.Remote;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace WebAppAutomation
{
    internal class TheInternet
    {
        IWebDriver driver;

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
                IWebElement txt = driver.FindElement(By.XPath("//*[@id='content']/div/h3"));
                if (txt.Text == "File Uploaded!")
                {
                    Console.WriteLine("Test Passed!");
                }
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
                Thread.Sleep(2000);

                driver.Navigate().Back();
                driver.FindElement(By.LinkText("Example 2: An image")).Click();


                driver.FindElement(By.XPath("//*[@id='content']/div/p[3]/a")).Click();

                string imgPixel = driver.FindElement(By.XPath("//*[@id='content']/div/img")).GetCssValue("left");
                Console.WriteLine(imgPixel);

                if (imgPixel == "-100px" || imgPixel == "0px")
                {
                    Console.WriteLine("Test Passed");
                }
                Thread.Sleep(2000);
                driver.Navigate().GoToUrl("https://the-internet.herokuapp.com/");
            }
            catch (Exception)
            {
                Console.WriteLine("Test Failed");
            }
        }

        public void ChallengingDOM()
        {
            try
            {
                driver.FindElement(By.LinkText("Challenging DOM")).Click();
                int rowsCount = driver.FindElements(By.XPath("//*[@id='content']/div/div/div/div[2]/table/tbody/tr")).Count;
                Console.WriteLine("All rows: " + rowsCount);

                int count = 0;
                for (int i = 1; i <= rowsCount; i++)
                {
                    IWebElement elemTable = driver.FindElement(By.XPath($"//*[@id='content']/div/div/div/div[2]/table/tbody/tr[{i}]/td[1]"));

                    string texts = elemTable.Text;
                    if (texts.EndsWith("0"))
                    {
                        count += 1;
                        Console.WriteLine($"In First Column are {count}-Texts Wich Ends Zero And This Texts are '{texts}'");
                    }
                    else
                    {
                        Console.WriteLine($"This '{texts}' - texts does not end in zero");
                    }
                }
                Console.WriteLine("Test Passed");
                Thread.Sleep(2000);
                driver.Navigate().GoToUrl("https://the-internet.herokuapp.com/");
            }
            catch (Exception)
            {
                Console.WriteLine("Test Failed");
            }
        }

        public void MultipleWindows()
        {
            try
            {
                driver.FindElement(By.LinkText("Multiple Windows")).Click();
                driver.FindElement(By.XPath("//*[@id='content']/div/a")).Click();

                driver.SwitchTo().Window(driver.WindowHandles[1]);

                driver.Navigate().GoToUrl("https://the-internet.herokuapp.com/windows/new");
                IWebElement title = driver.FindElement(By.XPath("/html/body/div/h3"));

                if (title.Text.Contains("New Window"))
                {
                    Console.WriteLine("Test Passed");
                }
            }
            catch (Exception )
            {
                Console.WriteLine("Test Failed");
            }
        }

        public void closeBrowser()
        {
            driver.Quit();
        }

    }
}
