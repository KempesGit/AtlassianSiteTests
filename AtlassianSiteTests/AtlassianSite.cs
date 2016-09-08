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
            driver.Navigate().GoToUrl("https://www.atlassian.com/software/confluence/try");
            driver.Manage().Timeouts().ImplicitlyWait(TimeSpan.FromSeconds(30));
        }

        public void CreateNewPage(ChromeDriver driver)
        {
            Random random = new Random();
            string randomString = random.Next(999, 99999).ToString();
            string email = firstName + randomString + "." + lastName + "@nowa.lepsza.poczta.pl";

            ClickTryIt(driver);
            driver.FindElementById("accountName").SendKeys(firstName + randomString);
            driver.FindElementById("firstName").SendKeys(firstName + randomString);
            driver.FindElementById("lastName").SendKeys(lastName);
            driver.FindElementById("email").SendKeys(email);
            driver.FindElementById("aod-password").SendKeys("haslo1234");
            driver.FindElementByXPath("//*[contains(text(), 'Start now')]").Click();

            var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(3));
            IWebElement regCompleted = wait.Until(drv => drv.FindElement(By.XPath("//*[contains(text(), 'Great, check your inbox')]")));
        }

        public void ClickTryIt(ChromeDriver driver)
        {
            driver.FindElementByCssSelector(
                "a[href=\"https://www.atlassian.com/ondemand/signup/form?product=confluence.ondemand,jira-software.ondemand,jira-servicedesk.ondemand\"]").Click();
            driver.Manage().Timeouts().ImplicitlyWait(TimeSpan.FromSeconds(30));
        }
    }
}
