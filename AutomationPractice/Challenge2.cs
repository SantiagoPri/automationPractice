using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;

namespace AutomationPractice
{
    [TestClass]
    public class Challenge2
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
            driver.FindElement(By.Id("email_create")).SendKeys("sprieto1@belatrixsf.com");
            driver.FindElement(By.XPath("//*[@id=\"SubmitCreate\"]")).Click();
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(20);
            driver.FindElement(By.Id("id_gender1")).Click();
            driver.FindElement(By.Id("customer_firstname")).SendKeys("P");
            driver.FindElement(By.Id("customer_lastname")).SendKeys("Sherman");
            driver.FindElement(By.Id("passwd")).SendKeys("password");
            driver.FindElement(By.Id("address1")).SendKeys("Wallaby street");
            driver.FindElement(By.Id("city")).SendKeys("Sidney");
            new SelectElement(driver.FindElement(By.Id("id_state"))).SelectByValue("43");
            driver.FindElement(By.Id("postcode")).SendKeys("70133");
            driver.FindElement(By.Id("phone_mobile")).SendKeys("3158799523");
            driver.FindElement(By.Id("submitAccount")).Click();
            string verificacion = driver.FindElement(By.ClassName("info-account")).Text;
            Assert.AreEqual("Welcome to your account. Here you can manage all of your personal information and orders.", verificacion);
            driver.FindElement(By.ClassName("logout")).Click();
        }

        [TestCleanup]
        public void TestCleanup()
        {
            driver.Close();
        }
    }
}
