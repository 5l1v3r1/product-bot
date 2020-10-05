using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;
using ProductBot.Entities;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Text;

namespace ProductBot.Helpers
{
    class WebBot
    {
        private Dictionary<string, string> platforms;
        public List<Product> products;
        private ChromeOptions options;
        private ChromeDriverService service;
        private IWebDriver driver;
        private string google;
        private string url;
        private HandleException handle;

        public WebBot()
        {

            driver = SeleniumConfiguration();
            driver.Manage().Window.Maximize();

            google = "http://www.google.com/search?q=";
            platforms = new Dictionary<string, string>();
            platforms.Add("hepsiburada", "site:hepsiburada.com ");
            platforms.Add("trendyol", "site:trendyol.com ");
            products = new List<Product>();
            handle = new HandleException();
        }

        public List<Product> SearchProduct(string productName)
        {
            return handle.ExceptionTypeHandler<List<Product>>(() =>
            {
                var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(0));
                IList<IWebElement> elementList;
                products.Clear();

                foreach (var platform in platforms)
                {
                    url = google + platform.Value + productName;
                    driver.Navigate().GoToUrl(url);
                    var searchResult = driver.FindElement(By.Id("rso"));
                    elementList = searchResult.FindElements(By.ClassName("g"));

                    CheckProductUrl(elementList, platform.Key, productName);

                }

                return products;
            });
           
        }

        public void CheckProductUrl(IList<IWebElement> elementList,string platform , string productName)
        {
            handle.ExceptionHandler(() =>
            {
                foreach (var element in elementList)
                {
                    string urlName = element.FindElement(By.XPath("div[1]/div[1]/a/h3/span")).Text.Trim();
                    if (CheckProductName(productName, urlName))
                    {

                        element.FindElement(By.XPath("div[1]/div[1]/a/h3")).Click();

                        if (platform == "hepsiburada")

                        {
                            products.Add(new Product
                            {
                                Name = productName,
                                Platform = platform,
                                UrlName = urlName,
                                Url = driver.Url.ToString(),
                                Price = GetHepsiburadaPrice(),

                            });
                            break;
                        }
                        else if (platform == "trendyol")
                        {
                            products.Add(new Product
                            {
                                Name = productName,
                                Platform = platform,
                                UrlName = urlName,
                                Url = driver.Url.ToString(),
                                Price = GetTrendyolPrice(),

                            }); ;
                            break;
                        }

                    }
                }
            });

        }
        public decimal GetHepsiburadaPrice()
        {

            return handle.ExceptionTypeHandler<decimal>(() =>
            {
                IWebElement element;

                if (driver.PageSource.Contains("class=\"extra-price\""))
                {
                    element = driver.FindElement(By.ClassName("extra-discount-price"));
                    return Convert.ToDecimal(element.FindElement(By.XPath("span[1]")).Text.Trim());

                }
                else
                {
                    element = driver.FindElement(By.Id("offering-price"));
                    return Convert.ToDecimal(element.FindElement(By.XPath("span[1]")).Text.Trim());
                }
            });
        }

        public decimal CheckHepsiburadaPrice(string url)
        {

            return handle.ExceptionTypeHandler<decimal>(() =>
            {
                
                driver.Navigate().GoToUrl(url);
                IWebElement element;

                if (driver.PageSource.Contains("class=\"extra-price\""))
                {
                    element = driver.FindElement(By.ClassName("extra-discount-price"));
                    return Convert.ToDecimal(element.FindElement(By.XPath("span[1]")).Text.Trim());

                }
                else
                {
                    element = driver.FindElement(By.Id("offering-price"));
                    return Convert.ToDecimal(element.FindElement(By.XPath("span[1]")).Text.Trim());
                }
            });
        }

        public decimal CheckTrendyolPrice(string url)
        {
            return handle.ExceptionTypeHandler<decimal>(() =>
            {
                driver.Navigate().GoToUrl(url);
                IWebElement container = driver.FindElement(By.XPath("//div[@class='pr-in-w']"));

                if (container.Text.Contains("class=\"prc-dsc\""))
                {
                    return Convert.ToDecimal(container.FindElement(By.ClassName("prc-dsc")).Text.Trim().Split(" ")[0]);


                }
                else
                {
                    return Convert.ToDecimal(container.FindElement(By.ClassName("prc-slg")).Text.Trim().Split(" ")[0]);

                }
            });
        }

        public decimal GetTrendyolPrice()
        {
            return handle.ExceptionTypeHandler<decimal>(() =>
                {
                    IWebElement container = driver.FindElement(By.XPath("//div[@class='pr-in-w']"));

                if (container.Text.Contains("class=\"prc-dsc\""))
                {
                    return Convert.ToDecimal(container.FindElement(By.ClassName("prc-dsc")).Text.Trim().Split(" ")[0]);
              

                }
                else
                {
                    return Convert.ToDecimal(container.FindElement(By.ClassName("prc-slg")).Text.Trim().Split(" ")[0]);
              
                }
            });
        }
        public bool CheckProductName(string productName , string urlName)
        {
            return handle.ExceptionTypeHandler<bool>(() =>
            {
                string[] words = productName.ToLower().Split(' ');
                int count = 0;
                foreach (string word in words)
                {
                    if (urlName.ToLower().Contains(word) == true)
                    {
                        ++count;
                    }
                }

                return words.Length / 2 < count ? true : false;
            });
        }

        public ChromeDriver SeleniumConfiguration()
        {
            options = new ChromeOptions();
            options.AddArgument("--headless");
            options.AddArguments("--disable-web-security");
            options.AddArguments("--allow-runing-insecure-content");
            options.AddArguments("--user-agent=Mozilla/5.0 (Windows NT 10.0; Win64; x64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/74.0.3729.169 Safari/537.36");
            service = ChromeDriverService.CreateDefaultService();
            service.HideCommandPromptWindow = true;

            return new ChromeDriver(service, options);
        }
    }
}
