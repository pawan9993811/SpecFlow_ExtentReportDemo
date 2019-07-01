using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Login_BDD_NUnit.Global;
using OpenQA.Selenium;

namespace Login_BDD_NUnit.Helpers
{
     class Reports
    {
        public static String SaveScreenshot(IWebDriver driver)
        {
            string uuid = Guid.NewGuid().ToString();
            var folderLocation = (Constants.ReportingImages);
            if (!System.IO.Directory.Exists(folderLocation))
            {
                System.IO.Directory.CreateDirectory(folderLocation);
            }
            string fileName = Constants.ReportingImages + uuid + ".jpeg";
            Screenshot screen = ((ITakesScreenshot)driver).GetScreenshot();
            screen.SaveAsFile(fileName, ScreenshotImageFormat.Jpeg);
            return fileName;
        }
    }
}
