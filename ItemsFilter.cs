using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Policy;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Software_Testing_Project
{
    public class ItemsFilter : BasePage
    {
        LoginPage loginPageObj = new LoginPage();
        public void Filter(string url, string username, string password, int filterOptionNo, string expectedMessage)
        {
            driver.Url = url;

            /*driver.FindElement(By.Id("user-name")).SendKeys(username);
            driver.FindElement(By.Id("password")).SendKeys(password);
            driver.FindElement(By.Id("login-button")).Click();*/

            loginPageObj.LoginWithValidCredentials(url, username, password);

            driver.FindElement(By.ClassName("product_sort_container")).Click();

            Thread.Sleep(1000);
            
            driver.FindElement(By.XPath("//*[@id=\"header_container\"]/div[2]/div/span/select/option[" + filterOptionNo + "]")).Click();
            
            Thread.Sleep(2000);
            
            string actualMessage = driver.FindElement(By.ClassName("active_option")).Text;
            Assert.AreEqual(expectedMessage, actualMessage, "Assert Failed!");
        }
    }
}
