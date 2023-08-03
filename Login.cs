using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Software_Testing_Project
{
    public class LoginPage : BasePage
    {
        public void LoginWithValidCredentials(string url, string username, string password)
        {
            driver.Url = url;

            driver.FindElement(By.Id("user-name")).SendKeys(username);
            driver.FindElement(By.Id("password")).SendKeys(password);
            driver.FindElement(By.Id("login-button")).Click();

            string actualMessage = driver.FindElement(By.ClassName("title")).Text;
            Assert.AreEqual("Products", actualMessage, "Assert Failed!");
        }
        public void LoginWithInvalidCredentials(string url, string username, string password, string expectedMessage)
        {
            driver.Url = url;

            driver.FindElement(By.Id("user-name")).SendKeys(username);
            driver.FindElement(By.Id("password")).SendKeys(password);
            driver.FindElement(By.Id("login-button")).Click();

            string actualMessage = driver.FindElement(By.XPath("//*[@id=\"login_button_container\"]/div/form/div[3]")).Text;
            Assert.AreEqual(expectedMessage, actualMessage, "Assert Failed!");
        }
    }
}