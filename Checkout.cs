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
    public class Checkout : BasePage
    {
        LoginPage loginPageObj = new LoginPage();
        public void ItemCheckoutWithValidDetails(string url, string username, string password, string addToCartID, string firstName, string lastName, string zipCode, string expectedMessage)
        {
            driver.Url = url;

            /*driver.FindElement(By.Id("user-name")).SendKeys(username);
            driver.FindElement(By.Id("password")).SendKeys(password);
            driver.FindElement(By.Id("login-button")).Click();*/

            loginPageObj.LoginWithValidCredentials(url, username, password);

            driver.FindElement(By.Id(addToCartID)).Click();

            driver.FindElement(By.ClassName("shopping_cart_link")).Click();
            driver.FindElement(By.Id("checkout")).Click();
            driver.FindElement(By.Id("first-name")).SendKeys(firstName);
            driver.FindElement(By.Id("last-name")).SendKeys(lastName);
            driver.FindElement(By.Id("postal-code")).SendKeys(zipCode);
            driver.FindElement(By.Id("continue")).Click();
            driver.FindElement(By.Id("finish")).Click();

            string actualMessage = driver.FindElement(By.ClassName("complete-header")).Text;
            Assert.AreEqual(expectedMessage, actualMessage, "Assert Failed!");
        }
        public void ItemCheckoutWithInValidDetails(string url, string username, string password, string addToCartID, string firstName, string lastName, string zipCode, string locator, string expectedMessage)
        {
            driver.Url = url;

            driver.FindElement(By.Id("user-name")).SendKeys(username);
            driver.FindElement(By.Id("password")).SendKeys(password);
            driver.FindElement(By.Id("login-button")).Click();

            driver.FindElement(By.Id(addToCartID)).Click();

            driver.FindElement(By.ClassName("shopping_cart_link")).Click();
            driver.FindElement(By.Id("checkout")).Click();
            driver.FindElement(By.Id("first-name")).SendKeys(firstName);
            driver.FindElement(By.Id("last-name")).SendKeys(lastName);
            driver.FindElement(By.Id("postal-code")).SendKeys(zipCode);
            driver.FindElement(By.Id("continue")).Click();

            string actualMessage = driver.FindElement(By.XPath(locator)).Text;
            Assert.AreEqual(expectedMessage, actualMessage, "Assert Failed!");
        }
    }
}