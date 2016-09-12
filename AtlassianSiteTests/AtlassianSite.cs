using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;
using System;

namespace AtlassianSiteTests
{
    public class AtlassianSite
    {
        string firstName = "Adam";
        string lastName = "Kowalski";

        public void OpenMainPage(ChromeDriver driver)
        {
            driver.Navigate().GoToUrl("https://pagepage.atlassian.net/");
            driver.Manage().Timeouts().ImplicitlyWait(TimeSpan.FromSeconds(30));
        }

        public void LoginToConfluence(ChromeDriver driver)
        {
            driver.FindElementById("username").SendKeys("the.hanging.gardens@gmail.com");
            driver.FindElementById("password").SendKeys("dupa1234");
            driver.FindElementById("login").Click();
            
            var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(3));
            IWebElement regCompleted = wait.Until(drv => drv.FindElement(By.XPath("//*[contains(text(), 'Welcome to Confluence')]")));
        }

        public void LoginOffConfluence(ChromeDriver driver)
        {
            driver.FindElementById("user-menu-link").Click();
            driver.FindElementById("logout-link").Click();
            driver.FindElementById("logout").Click();

            var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(3));
            IWebElement regCompleted = wait.Until(drv => drv.FindElement(By.XPath("//*[contains(text(), 'You are logged out of this Atlassian Cloud instance')]")));
        }


        public void SetRestrictions(ChromeDriver driver)
        {
            //driver.FindElementById("username").SendKeys("the.hanging.gardens@gmail.com");
            //driver.FindElementById("password").SendKeys("dupa1234");
            //driver.FindElementById("login").Click();

            //var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(3));
            //IWebElement regCompleted = wait.Until(drv => drv.FindElement(By.XPath("//*[contains(text(), 'Welcome to Confluence')]")));
        }

    }
}
