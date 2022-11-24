using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Edge;
using System.Threading;
using NUnit.Allure.Core;
using NUnit.Allure.Attributes;
using CodeJam;

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
        this.driver.Url = "http://192.168.56.3:5044/about"; //set my url
    }

    [Test]
    public void AddFeedBack()
    {
        IWebElement? tbEmail = this.driver?.FindElement(By.Id("email"));  
        tbEmail?.Clear();
        tbEmail.SendKeys("user@gmail.com");

        IWebElement? tbMessage = this.driver?.FindElement(By.Id("textArea"));  
        tbMessage.Clear();
        tbMessage.SendKeys("AAA bbb CCC");


        //IWebElement? submitButton = this.driver?.FindElement(By.XPath("//button[@type='submit']"));
        IWebElement? btnSubmit = this.driver?.FindElement(By.Id("submit"));
        btnSubmit.Click();
        Thread.Sleep(1000);

        IWebElement? textElement = this.driver.FindElement(By.XPath("//h2"));
        string submitMessageText = textElement.Text.ToUpper();
        Code.AssertState(string.Equals(submitMessageText, "Thank you, your message has been sent and will be reviewed shortly".ToUpper()), "submitMessage is not valid!");
    }

    [TearDown]
    public void endTests() {
        this.driver.Close();
    }
}