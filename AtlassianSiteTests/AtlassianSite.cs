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

        /// <summary>
        /// Open site main page
        /// </summary>
        public void OpenMainPage(ChromeDriver driver)
        {
            driver.Navigate().GoToUrl("https://www.atlassian.com/software/confluence/try");
            driver.Manage().Timeouts().ImplicitlyWait(TimeSpan.FromSeconds(30));
        }

        /// <summary>
        /// Create new page
        /// </summary>
        public void CreateNewPage(ChromeDriver driver)
        {
            Random random = new Random();
            string randomString = random.Next(999, 99999).ToString();
            string email = firstName + randomString + "." + lastName + "@nowa.lepsza.poczta.pl";

            FindElementByCssSelectorAndClick(driver,
                "a[href=\"https://www.atlassian.com/ondemand/signup/form?product=confluence.ondemand,jira-software.ondemand,jira-servicedesk.ondemand\"]");
            FindElementByIdAndFillData(driver, "accountName", firstName + randomString);
            FindElementByIdAndFillData(driver, "firstName", firstName + randomString);
            FindElementByIdAndFillData(driver, "lastName", lastName);
            FindElementByIdAndFillData(driver, "email", email);
            FindElementByIdAndFillData(driver, "aod-password", "haslo1234");
            FindElementByXPathAndClick(driver, "//*[contains(text(), 'Start now')]");
            WaitForElementByXPath(driver, "//*[contains(text(), 'Great, check your inbox')]");
        }

        /// <summary>
        /// Find element on page and fill it with data
        /// </summary>
        /// <param name="drv">Used Selenium driver</param>
        /// <param name="id">Element Id to be find</param>
        /// <param name="data">Data to be write</param>
        private void FindElementByIdAndFillData(ChromeDriver drv, string id, string data)
        {
            drv.FindElementById(id).SendKeys(data);
        }

        /// <summary>
        /// Find element on page and click it
        /// </summary>
        /// <param name="drv">Used Selenium driver</param>
        /// <param name="xpath">Element XPath to be find</param>
        private void FindElementByXPathAndClick(ChromeDriver drv, string xpath)
        {
            drv.FindElementByXPath(xpath).Click();
        }

        /// <summary>
        /// Find element on page and click it
        /// </summary>
        /// <param name="drv">Used Selenium driver</param>
        /// <param name="cssSelector">Element CssSelector to be find</param>
        private void FindElementByCssSelectorAndClick(ChromeDriver drv, string cssSelector)
        {
            drv.FindElementByCssSelector(cssSelector).Click();
            drv.Manage().Timeouts().ImplicitlyWait(TimeSpan.FromSeconds(30));
        }

        /// <summary>
        /// Wait for element with XPath
        /// </summary>
        /// <param name="drv">Used Selenium driver</param>
        /// <param name="xpath">Element XPath to be find</param>
        private void WaitForElementByXPath(ChromeDriver drv, string xpath)
        {
            var wait = new WebDriverWait(drv, TimeSpan.FromSeconds(3));
            IWebElement regCompleted = wait.Until(drvElem => drvElem.FindElement(By.XPath(xpath)));
        }
    }
}
