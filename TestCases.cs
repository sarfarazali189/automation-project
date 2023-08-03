using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;
using System;
using System.Security.Policy;
using System.Threading;
using System.Timers;

namespace Software_Testing_Project
{
    [TestClass]
    public class TestExecution
    {
        LoginPage loginObj = new LoginPage();
        ItemsCart cartObj= new ItemsCart();
        Checkout checkOutObj = new Checkout();
        ItemsFilter filterObj = new ItemsFilter();
        LogoutPage logoutObj = new LogoutPage();
        BasePage basePageObj = new BasePage();


        [TestMethod, Description("Login With Correct Username Correct Password")]
        [TestCategory("Login"), TestCategory("Positive")]
        [DataRow("https://www.saucedemo.com/", "standard_user", "secret_sauce")]
        [DataRow("https://www.saucedemo.com/", "problem_user", "secret_sauce")]
        public void TestCase_01(string url, string username, string password)
        {
            basePageObj.SeleniumInit();
            loginObj.LoginWithValidCredentials(url, username, password);
            BasePage.driver.Close();
        }

        [TestMethod, Description("Login With Empty Username Empty Password")]
        [TestCategory("Login"), TestCategory("Negative")]
        [DataRow("https://www.saucedemo.com/", "", "", "Epic sadface: Username is required")]
        public void TestCase_02(string url, string username, string password, string expectedMessage)
        {
            basePageObj.SeleniumInit();
            loginObj.LoginWithInvalidCredentials(url, username, password, expectedMessage);
            BasePage.driver.Close();
        }

        [TestMethod, Description("Login With Correct Username Empty Password")]
        [TestCategory("Login"), TestCategory("Negative")]
        [DataRow("https://www.saucedemo.com/", "standard_user", "", "Epic sadface: Password is required")]
        public void TestCase_03(string url, string username, string password, string expectedMessage)
        {
            basePageObj.SeleniumInit();
            loginObj.LoginWithInvalidCredentials(url, username, password, expectedMessage);
            BasePage.driver.Close();
        }

        [TestMethod, Description("Login With Empty Username Correct Password")]
        [TestCategory("Login"), TestCategory("Negative")]
        [DataRow("https://www.saucedemo.com/", "", "secret_sauce", "Epic sadface: Username is required")]
        public void TestCase_04(string url, string username, string password, string expectedMessage)
        {
            basePageObj.SeleniumInit();
            loginObj.LoginWithInvalidCredentials(url, username, password, expectedMessage);
            BasePage.driver.Close();
        }

        [TestMethod, Description("Login With Correct Username Wrong Password")]
        [TestCategory("Login"), TestCategory("Negative")]
        [DataRow("https://www.saucedemo.com/", "standard_user", "wrongpass", "Epic sadface: Username and password do not match any user in this service")]
        public void TestCase_05(string url, string username, string password, string expectedMessage)
        {
            basePageObj.SeleniumInit();
            loginObj.LoginWithInvalidCredentials(url, username, password, expectedMessage);
            BasePage.driver.Close();
        }

        [TestMethod, Description("Login With Wrong Username Correct Password")]
        [TestCategory("Login"), TestCategory("Negative")]
        [DataRow("https://www.saucedemo.com/", "wrongusername", "secret_sauce", "Epic sadface: Username and password do not match any user in this service")]
        public void TestCase_06(string url, string username, string password, string expectedMessage)
        {
            basePageObj.SeleniumInit();
            loginObj.LoginWithInvalidCredentials(url, username, password, expectedMessage);
            BasePage.driver.Close();
        }

        [TestMethod, Description("Login With Wrong Username Wrong Password")]
        [TestCategory("Login"), TestCategory("Negative")]
        [DataRow("https://www.saucedemo.com/", "wrongusername", "wrongpass", "Epic sadface: Username and password do not match any user in this service")]
        public void TestCase_07(string url, string username, string password, string expectedMessage)
        {
            basePageObj.SeleniumInit();
            loginObj.LoginWithInvalidCredentials(url, username, password, expectedMessage);
            BasePage.driver.Close();
        }

        [TestMethod, Description("Add Item to Cart from Products Page")]
        [TestCategory("AddToCart"), TestCategory("Positive")]
        [DataRow("https://www.saucedemo.com/", "standard_user", "secret_sauce", "add-to-cart-sauce-labs-backpack", "item_4_title_link", "Sauce Labs Backpack")]
        public void TestCase_08(string url, string username, string password, string addToCartID, string itemID, string expectedMessage)
        {
            basePageObj.SeleniumInit();
            cartObj.AddToCartFromProductPage(url, username, password, addToCartID, itemID, expectedMessage);
            BasePage.driver.Close();
        }        

        [TestMethod, Description("Add Item to Cart from Product Description Page")]
        [TestCategory("AddToCart"), TestCategory("Positive")]
        [DataRow("https://www.saucedemo.com/", "standard_user", "secret_sauce", "add-to-cart-sauce-labs-backpack", "item_4_title_link", "Sauce Labs Backpack")]
        public void TestCase_09(string url, string username, string password, string addToCartID, string itemID, string expectedMessage)
        {
            basePageObj.SeleniumInit();
            cartObj.AddToCartFromProductDescriptionPage(url, username, password, addToCartID, itemID, expectedMessage);
            BasePage.driver.Close();
        }

        [TestMethod, Description("Remove Item from Cart from Products Page")]
        [TestCategory("RemoveFromCart"), TestCategory("Positive")]
        [DataRow("https://www.saucedemo.com/", "standard_user", "secret_sauce", "add-to-cart-sauce-labs-backpack", "remove-sauce-labs-backpack")]
        public void TestCase_10(string url, string username, string password, string addToCartID, string removeID)
        {
            basePageObj.SeleniumInit();
            cartObj.RemoveFromCartFromProductPage(url, username, password, addToCartID, removeID);
            BasePage.driver.Close();
        }

        [TestMethod, Description("Remove Item from Cart from Product Description Page")]
        [TestCategory("RemoveFromCart"), TestCategory("Positive")]
        [DataRow("https://www.saucedemo.com/", "standard_user", "secret_sauce", "item_4_title_link", "add-to-cart-sauce-labs-backpack", "remove-sauce-labs-backpack")]
        public void TestCase_11(string url, string username, string password, string itemID, string addToCartID, string removeID)
        {
            basePageObj.SeleniumInit();
            cartObj.RemoveFromCartProductDescriptionPage(url, username, password, itemID, addToCartID, removeID);
            BasePage.driver.Close();
        }

        [TestMethod, Description("Item Checkout With Valid Details")]
        [TestCategory("Checkout"), TestCategory("Positive")]
        [DataRow("https://www.saucedemo.com/", "standard_user", "secret_sauce", "add-to-cart-sauce-labs-backpack", "Shazim", "Abbas", "72500", "Thank you for your order!")]
        public void TestCase_12(string url, string username, string password, string addToCartID, string firstName, string lastName, string zipCode, string expectedMessage)
        {
            basePageObj.SeleniumInit();
            checkOutObj.ItemCheckoutWithValidDetails(url, username, password, addToCartID, firstName, lastName, zipCode, expectedMessage);
            BasePage.driver.Close();
        }

        [TestMethod, Description("Item Checkout With InValid Details")]
        [TestCategory("Checkout"), TestCategory("Negative")]
        [DataRow("https://www.saucedemo.com/", "standard_user", "secret_sauce", "add-to-cart-sauce-labs-backpack", "", "Abbas", "72500", "//*[@id=\"checkout_info_container\"]/div/form/div[1]/div[4]", "Error: First Name is required")]
        [DataRow("https://www.saucedemo.com/", "standard_user", "secret_sauce", "add-to-cart-sauce-labs-backpack", "Shazim", "", "72500", "//*[@id=\"checkout_info_container\"]/div/form/div[1]/div[4]", "Error: Last Name is required")]
        [DataRow("https://www.saucedemo.com/", "standard_user", "secret_sauce", "add-to-cart-sauce-labs-backpack", "Shazim", "Abbas", "", "//*[@id=\"checkout_info_container\"]/div/form/div[1]/div[4]", "Error: Postal Code is required")]
        [DataRow("https://www.saucedemo.com/", "standard_user", "secret_sauce", "add-to-cart-sauce-labs-backpack", "", "", "", "//*[@id=\"checkout_info_container\"]/div/form/div[1]/div[4]", "Error: First Name is required")]
        public void TestCase_13(string url, string username, string password, string addToCartID, string firstName, string lastName, string zipCode, string locator, string expectedMessage)
        {
            basePageObj.SeleniumInit();
            checkOutObj.ItemCheckoutWithInValidDetails(url, username, password, addToCartID, firstName, lastName, zipCode, locator, expectedMessage);
            BasePage.driver.Close();
        }

        [TestMethod, Description("Logout from Products Page")]
        [TestCategory("Logout"), TestCategory("Positive")]
        [DataRow("https://www.saucedemo.com/", "standard_user", "secret_sauce")]
        public void TestCase_14(string url, string username, string password)
        {
            basePageObj.SeleniumInit();
            logoutObj.Logout(url, username, password);
            BasePage.driver.Close();
        }

        [TestMethod, Description("Filter Products")]
        [TestCategory("FilterItems"), TestCategory("Positive")]
        [DataRow("https://www.saucedemo.com/", "standard_user", "secret_sauce", 1, "Name (A to Z)")]
        [DataRow("https://www.saucedemo.com/", "standard_user", "secret_sauce", 2, "Name (Z to A)")]
        [DataRow("https://www.saucedemo.com/", "standard_user", "secret_sauce", 3, "Price (low to high)")]
        [DataRow("https://www.saucedemo.com/", "standard_user", "secret_sauce", 4, "Price (high to low)")]
        public void TestCase_15(string url, string username, string password, int filterOptionNo, string expectedMessage)
        {
            basePageObj.SeleniumInit();
            filterObj.Filter(url, username, password, filterOptionNo, expectedMessage);
            BasePage.driver.Close();
        }
    }
}