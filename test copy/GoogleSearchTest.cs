using System;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;

namespace test;

public class GoogleTestSearch
{
    [Test]
    public void SearchJourney()
    {
        IWebDriver driver = InitialiseWebDriver();

        OpenGoogleSearchPage(driver);
        EnterSearchText(driver, "Tracy Lethoko");
        ClickArticle(driver);
       
    }
    private static IWebDriver InitialiseWebDriver()
    {
        IWebDriver driver = new ChromeDriver();
        driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromMilliseconds(5000);
        return driver;
    }

    private static void OpenGoogleSearchPage(IWebDriver driver)
    {
        driver.Navigate().GoToUrl("https://www.google.com");
        var title = driver.Title;
        Assert.That(title, Is.EqualTo("Google"));
    }

    private static void EnterSearchText(IWebDriver driver, string text)
    {
        var searchField = driver.FindElement(By.Name("q"));
        searchField.SendKeys(text + "\n");
    }

    private static void ClickArticle(IWebDriver driver)
    {
        var searchArticle = driver.FindElement(By.XPath("//h3[contains(text(),'GirlCodeHack: Young women participate in 30 hours ')]"));
        searchArticle.Click();
    }

}