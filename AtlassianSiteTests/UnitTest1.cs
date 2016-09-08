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
            testPageObject.OpenMainPage(driver);
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
            testPageObject.CreateNewPage(driver);
        }
    }
}
