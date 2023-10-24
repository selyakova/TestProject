using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Firefox;


namespace NUnitTestAptimeaLappolainen
{
    public class Tests
    {

        IWebDriver driver;
        String test_url = "https://anastassiaseljakova22.thkit.ee/vormid2/vormid2.html";
        private readonly Random _random = new Random();

        [SetUp]
        public void start_browser()
        {
            driver = new FirefoxDriver();
            driver.Manage().Window.Maximize();
        }

        [Test]
        public void test_page1()
        {
            driver.Url = test_url;
            driver.Navigate().GoToUrl(test_url);
            Thread.Sleep(4000);

            try
            {
                IWebElement sButton2 = driver.FindElement(By.XPath("//button[@class='agree-button eu-cookie-compliance-secondary-button']"));
                sButton2.Click();
            }
            catch (Exception) { }

            for (int a = 0; a < 1; a++)
            {
                Thread.Sleep(5000);
                var sRadio = driver.FindElements(By.XPath("//div[@class='fieldset-wrapper']"));
                for (int i = 0; i < sRadio.Count; i++)
                {
                    var els = sRadio[i].FindElements(By.XPath(".//input[@type='radio']"));
                    if (els.Count >= 2)
                    {
                        try { els[_random.Next(0, els.Count)].Click(); } catch (Exception) { }
                    }
                }
                var sText = driver.FindElements(By.XPath("//input[@type='text']"));
                for (int i = 0; i < sText.Count; i++)
                {
                    try { sText[i].Click(); sText[i].SendKeys("TEST"); } catch (Exception) { }
                }
                var sTextArea = driver.FindElements(By.XPath("//textarea"));
                for (int i = 0; i < sTextArea.Count; i++)
                {
                    try { sTextArea[i].Click(); sTextArea[i].SendKeys("TEST"); } catch (Exception) { }
                }
                var sNum = driver.FindElements(By.XPath("//input[@type='number']"));
                for (int i = 0; i < sNum.Count; i++)
                {
                    try { sNum[i].Click(); sNum[i].SendKeys("123456"); } catch (Exception) { }
                }
                var sSelect = driver.FindElements(By.XPath("//select"));
                for (int i = 0; i < sSelect.Count; i++)
                {
                    try { sSelect[i].Click(); sSelect[i].FindElements(By.XPath(".//*"))[2].Click(); } catch (Exception) { }
                }

                IWebElement sButtonE = driver.FindElement(By.XPath("//*[@value='OK']"));
                try { sButtonE.Click(); } catch (Exception) { }
                Thread.Sleep(5000);
                IWebElement sButton = driver.FindElement(By.XPath("//*[@value='OK']"));
                try { sButton.Click(); } catch (Exception) { }
            }
            Thread.Sleep(5000);

            IWebElement sButton3 = driver.FindElement(By.XPath("//*[@value='Finaliser']"));
            try { sButton3.Click(); } catch (Exception) { }

            Thread.Sleep(5000);
        }
        [TearDown]
        public void close_Browser()
        {
            driver.Quit();
        }
    }
}
