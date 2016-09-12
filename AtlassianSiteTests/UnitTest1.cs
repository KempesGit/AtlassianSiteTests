using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium.Chrome;

namespace AtlassianSiteTests
{
    [TestClass]
    public class UnitTest1
    {
        private ChromeDriver driver;
        private AtlassianSite testPageObject;

        [TestInitialize]
        public void InitTest()
        {
            driver = new ChromeDriver();
            testPageObject = new AtlassianSite();
        }

        [TestCleanup]
        public void CleanupTest()
        {
            driver.Close();
        }

        [TestMethod]
        public void CreateNewPage()
        {
            testPageObject.OpenMainPage(driver);
            testPageObject.LoginToConfluence(driver);
            testPageObject.LoginOffConfluence(driver); 
        }

        [TestMethod]
        public void SetRestrictions()
        {
            testPageObject.OpenMainPage(driver);
            testPageObject.LoginToConfluence(driver);
            testPageObject.SetRestrictions(driver);
            testPageObject.LoginOffConfluence(driver);
        }

    }
}
