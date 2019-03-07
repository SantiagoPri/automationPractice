using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;

namespace AutomationPractice
{
    [TestClass]
    public class Challenge3
    {
        IWebDriver driver;

        [TestInitialize]
        public void TestInitialize()
        {
            driver = new ChromeDriver("Resources");
        }

        [TestMethod]
        public void TestMethod1()
        {
            driver.Url = "http://automationpractice.com/index.php?";
            driver.FindElement(By.ClassName("header_user_info")).Click();
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(20);
            driver.FindElement(By.Id("email")).SendKeys("sprieto@belatrixsf.com");
            driver.FindElement(By.Id("passwd")).SendKeys("password");
            driver.FindElement(By.XPath("//*[@id=\"SubmitLogin\"]/span")).Click();
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(20);
            string verify = driver.FindElement(By.ClassName("info-account")).Text;
            Assert.AreEqual("Welcome to your account. Here you can manage all of your personal information and orders.", verify);


        }

        [TestCleanup]
        public void TestCleanup()
        {
            driver.Close();
        }
    }
}
