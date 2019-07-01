using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;

namespace Login_BDD_NUnit.Helpers
{
    public static class DriverMethod
    {

        //public static IWebDriver driver { get; set; }
        //public ExtentTest test { get; set; }

        public static IWebDriver GetDriver()
        {
            IWebDriver driver = new ChromeDriver();
            driver.Manage().Window.Maximize();
            return driver;
        }


        #region WaitforElement 

        //public static void wait(int time)
        //{
        //    driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(time);

        //}
        //public static IWebElement WaitForElement(IWebDriver driver, By by, int timeOutinSeconds)
        //{
        //    WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(timeOutinSeconds));
        //    return (wait.Until(condition: ExpectedConditions.ElementIsVisible(by)));
        //}
        #endregion
    }
}
