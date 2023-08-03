using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Software_Testing_Project
{
    public class LogoutPage : BasePage
    {
        LoginPage loginPageObj = new LoginPage();
        public void Logout(string url, string username, string password)
        {
            driver.Url = url;

            /*driver.FindElement(By.Id("user-name")).SendKeys(username);
            driver.FindElement(By.Id("password")).SendKeys(password);
            driver.FindElement(By.Id("login-button")).Click();*/

            loginPageObj.LoginWithValidCredentials(url, username, password);

            driver.FindElement(By.Id("react-burger-menu-btn")).Click();
            Thread.Sleep(1000);
            driver.FindElement(By.Id("logout_sidebar_link")).Click();

            string actualMessage = driver.FindElement(By.Id("login-button")).TagName;
            Thread.Sleep(1000);
            Assert.AreEqual("input", actualMessage, "Assert Failed!");
        }
    }
}
