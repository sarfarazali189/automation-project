using OpenQA.Selenium.Chrome;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Software_Testing_Project;

namespace Software_Testing_Project
{
    public class BasePage
    {
        public static IWebDriver driver;
        public void SeleniumInit()
        {
            driver = new ChromeDriver();
            driver.Manage().Window.Maximize();
        }
    }
}
