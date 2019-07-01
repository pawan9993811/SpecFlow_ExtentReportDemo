using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using AventStack.ExtentReports;
using Login_BDD_NUnit.Global;
using Login_BDD_NUnit.Helpers;
using NUnit.Framework;
using OpenQA.Selenium;
using TechTalk.SpecFlow;

namespace Login_BDD_NUnit.StepsDefination
{
    [Binding]
    public sealed class LoginSteps
    {
        private IWebDriver driver = ScenarioContext.Current.Get<IWebDriver>();

        private ExtentTest test = ScenarioContext.Current.Get<ExtentTest>();
        // For additional details on SpecFlow step definitions see http://go.specflow.org/doc-stepdef

        [Given(@"I have a registered user on NopCommerce website")]
        public void GivenIhavearegistereduseronNopCommercewebsite()
        {
            driver.Navigate().GoToUrl(Constants.NopComURL);
            string pageTitle = driver.Title;
            Assert.AreEqual(pageTitle, "nopCommerce - ASP.NET Open-source Ecommerce Shopping Cart Solution");

        }

        [Given(@"User is on the NopCommerce page")]
        public void GivenUserIsOnTheNopCommercePage()
        {
            IWebElement LoginLnq = driver.FindElement(By.XPath("//a[@href='/login.aspx']"));
            LoginLnq.Click();
            Assert.AreEqual(driver.Title, "Login - nopCommerce");
            Console.WriteLine("Login Linq has been clicked");
            //ScenarioContext.Current.Pending();
        }
        [When(@"User logs in using username (.*)and password (.*)")]
        public void WhenUserLogsInUsingUsernameAlphaBAndPasswordQwerty(string username, string password)
        {
            IWebElement Username = driver.FindElement(By.Id("ctl00_ctl00_cph1_cph1_ctrlCustomerLogin_LoginForm_UserName"));
            Username.SendKeys(username);

            IWebElement Password = driver.FindElement(By.Id("ctl00_ctl00_cph1_cph1_ctrlCustomerLogin_LoginForm_Password"));
            Password.SendKeys(password);


            IWebElement Checkbox = driver.FindElement(By.Id("ctl00_ctl00_cph1_cph1_ctrlCustomerLogin_LoginForm_RememberMe"));
            Checkbox.Click();

            IWebElement LoginBtn = driver.FindElement(By.Id("ctl00_ctl00_cph1_cph1_ctrlCustomerLogin_LoginForm_LoginButton"));
            LoginBtn.Click();
        }

        [When(@"User logs in using valid username and invalid password")]
        public void WhenUserLogsInUsingValidUsernameAndInvalidPassword()
        {
            IWebElement Username = driver.FindElement(By.Id("ctl00_ctl00_cph1_cph1_ctrlCustomerLogin_LoginForm_UserName"));
            Username.SendKeys("AlphaB");

            IWebElement Password = driver.FindElement(By.Id("ctl00_ctl00_cph1_cph1_ctrlCustomerLogin_LoginForm_Password"));
            Password.SendKeys("WRONGpswd");

            IWebElement Checkbox = driver.FindElement(By.Id("ctl00_ctl00_cph1_cph1_ctrlCustomerLogin_LoginForm_RememberMe"));
            Checkbox.Click();

            IWebElement LoginBtn = driver.FindElement(By.Name("ctl00$ctl00$cph1$cph1$ctrlCustomerLogin$LoginForm$LoginButton"));
            LoginBtn.Click();
        }


        [Then(@"User should land on the Home page")]
        public void ThenUserShouldLandOnTheHomePage()
        {
            Assert.AreEqual(driver.Title, "nopCommerce - ASP.NET Open-source Ecommerce Shopping Cart Solution");
            try
            {
                Assert.IsTrue(driver.PageSource.Contains("My account"), "User has not landed on Home Page");
                test.Pass("Login Successful", MediaEntityBuilder.CreateScreenCaptureFromPath(Reports.SaveScreenshot(driver)).Build());
            }
            catch (Exception)
            {
                test.Fail("Failure occurred ", MediaEntityBuilder.CreateScreenCaptureFromPath(Reports.SaveScreenshot(driver)).Build());
            }


        }



        [Then(@"he should see an error message stating that the Login attempt was not successful")]
        public void ThenHeShouldSeeAnErrorMessageStatingThatTheLoginAttemptWasNotSuccessful()
        {
            Assert.IsTrue(driver.PageSource.Contains("Your login attempt was not successful. Please try again."));
            test.Pass("Login Attempt Failure", MediaEntityBuilder.CreateScreenCaptureFromPath(Reports.SaveScreenshot(driver)).Build());
            
        }

    }
}
