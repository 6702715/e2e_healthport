using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Edge;
using System.Threading;
using NUnit.Allure.Core;
using NUnit.Allure.Attributes;

namespace nopCommerceLogIn;

[AllureNUnit]
[AllureSuite("LoginTest")]
public class Tests
{
    
    EdgeDriver? driver;
    
    [SetUp]
    public void Setup()
    {
        this.driver = new EdgeDriver();
        this.driver.Url = "http://192.168.56.3:8088/"; //set my url
    }

    [Test]
    public void Login()
    {
        this.driver.FindElement(By.XPath("//a[@class='ico-login']")).Click();
        Thread.Sleep(500);

        IWebElement loginField = this.driver.FindElement(By.XPath("//input[@id='Email']")); 
        loginField.Clear();
        loginField.SendKeys("puzanov@localnet.ua");

        IWebElement passwordField = this.driver.FindElement(By.XPath("//input[@id='Password']"));  
        passwordField.Clear();
        passwordField.SendKeys("Pa$$w0rd");

        this.driver.FindElement(By.XPath("//button[normalize-space()='Log in']")).Click();
        IWebElement logoutLink = this.driver.FindElement(By.XPath("//a[@class='ico-logout']"));
        System.Console.WriteLine(logoutLink.Text);
        Assert.That(logoutLink.Text == "LOG OUT", "You are not logged!");
        
        Thread.Sleep(3000);
    }

    [TearDown]
    public void endTests() {
        this.driver.Close();
    }
}