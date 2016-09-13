using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;
using System;

namespace AtlassianSiteTests
{
    public class AtlassianSite
    {
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
            IWebElement regCompleted = wait.Until(drv => drv.FindElement(By.Id("WelcometoConfluence")));
        }

        public void LoginOffConfluence(ChromeDriver driver)
        {
            driver.FindElementById("user-menu-link").Click();
            driver.FindElementById("logout-link").Click();
            driver.FindElementById("logout").Click();

            var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(3));
            IWebElement regCompleted = wait.Until(drv => drv.FindElement(By.Id("logged-out")));
        }

        public void SetRestrictions(ChromeDriver driver)
        {
            driver.FindElementById("space-menu-link").Click();
            driver.FindElementById("view-all-spaces-link").Click();
            driver.FindElementByLinkText("https://pagepage.atlassian.net/wiki/display/NEW").Click();
            //*[@id="action-menu-link"]/span/span
            
            driver.FindElementByXPath("*[@id='action - menu - link']/span/span").Click();
            driver.FindElementById("action - page - permissions - link").Click();
            
            //*[@id="recent-spaces-section"]/ul/li[1]/a
            //var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(3));
            //IWebElement regCompleted = wait.Until(drv => drv.FindElement(By.XPath("//*[contains(text(), 'Welcome to Confluence')]")));
        }

        public void CreatePage(ChromeDriver driver)
        {
            //click 3 dots
            driver.FindElementById("create-page-button").Click();

            var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(3));
            IWebElement regCompleted = wait.Until(drv => drv.FindElement(By.Id("create-dialog")));

            //click blank page
            driver.FindElementByXPath("//*[@data-content-blueprint-id='00000000-0000-0000-0000-000000000000']").Click();
            //click CREATE button
            driver.FindElementByXPath("//*[contains(@class,'create-dialog-create-button aui-button aui-button-primary')]").Click();

            regCompleted = wait.Until(drv => drv.FindElement(By.Id("wysiwyg")));

            //write page title
            driver.FindElementById("content-title").SendKeys("Test page");

            //click SAVE button
            driver.FindElementById("rte-button-publish").Click();
        }
    }
}
