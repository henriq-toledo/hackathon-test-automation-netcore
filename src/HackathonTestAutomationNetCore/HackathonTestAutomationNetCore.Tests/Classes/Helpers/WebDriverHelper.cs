using OpenQA.Selenium;
using OpenQA.Selenium.Firefox;
using System;

namespace HackathonTestAutomationNetCore.Tests.Classes.Helpers
{
    internal class WebDriverHelper
    {
        private static IWebDriver _instance;

        public static IWebDriver Current
        {
            get
            {
                if (_instance == null)
                {
                    _instance = new FirefoxDriver(Environment.CurrentDirectory);
                }

                return _instance;
            }
        }

        public static void Dispose()
        {
            _instance.Dispose();
            _instance = null;
        }
    }
}
