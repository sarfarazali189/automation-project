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
    public class ItemsCart : BasePage
    {
        LoginPage loginPageObj = new LoginPage();
        public void AddToCartFromProductPage(string url, string username, string password, string addToCartID, string itemID, string expectedMessage)
        {
            driver.Url = url;

            /*driver.FindElement(By.Id("user-name")).SendKeys(username);
            driver.FindElement(By.Id("password")).SendKeys(password);
            driver.FindElement(By.Id("login-button")).Click();*/

            loginPageObj.LoginWithValidCredentials(url, username, password);

            driver.FindElement(By.Id(addToCartID)).Click();

            driver.FindElement(By.ClassName("shopping_cart_link")).Click();

            string actualMessage = driver.FindElement(By.Id(itemID)).Text;
            Assert.AreEqual(expectedMessage, actualMessage, "Assert Failed!");
        }
        public void AddToCartFromProductDescriptionPage(string url, string username, string password, string addToCartID, string itemID, string expectedMessage)
        {
            driver.Url = url;

            driver.FindElement(By.Id("user-name")).SendKeys(username);
            driver.FindElement(By.Id("password")).SendKeys(password);
            driver.FindElement(By.Id("login-button")).Click();

            driver.FindElement(By.Id(itemID)).Click();
            driver.FindElement(By.Id(addToCartID)).Click();

            driver.FindElement(By.ClassName("shopping_cart_link")).Click();

            string actualMessage = driver.FindElement(By.Id(itemID)).Text;
            Assert.AreEqual(expectedMessage, actualMessage, "Assert Failed!");
        }
        public void RemoveFromCartFromProductPage(string url, string username, string password, string addToCartID, string removeID)
        {
            driver.Url = url;

            driver.FindElement(By.Id("user-name")).SendKeys(username);
            driver.FindElement(By.Id("password")).SendKeys(password);
            driver.FindElement(By.Id("login-button")).Click();

            driver.FindElement(By.Id(addToCartID)).Click();
            
            driver.FindElement(By.ClassName("shopping_cart_link")).Click();
            var totalItems = driver.FindElement(By.Id("shopping_cart_container")).Text;

            driver.FindElement(By.Id(removeID)).Click();
            var totalItems2 = driver.FindElement(By.Id("shopping_cart_container")).Text;

            Assert.AreNotEqual(totalItems, totalItems2, "Assert Failed!");
        }
        public void RemoveFromCartProductDescriptionPage(string url, string username, string password, string itemID, string addToCartID, string removeID)
        {
            driver.Url = url;

            driver.FindElement(By.Id("user-name")).SendKeys(username);
            driver.FindElement(By.Id("password")).SendKeys(password);
            driver.FindElement(By.Id("login-button")).Click();

            driver.FindElement(By.Id(itemID)).Click();
            driver.FindElement(By.Id(addToCartID)).Click();

            driver.FindElement(By.ClassName("shopping_cart_link")).Click();
            var totalItems = driver.FindElement(By.Id("shopping_cart_container")).Text;

            driver.FindElement(By.Id(removeID)).Click();

            var totalItems2 = driver.FindElement(By.Id("shopping_cart_container")).Text;

            Assert.AreNotEqual(totalItems, totalItems2, "Assert Failed!");
        }
    }
}