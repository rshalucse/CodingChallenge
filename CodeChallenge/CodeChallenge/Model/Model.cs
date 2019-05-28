using System;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium;

namespace TestProject
{

    public class Model
    {
        private static IWebDriver browser;

        public Model(IWebDriver browser1)
        {
            browser = browser1;
        }

        public IWebElement numOfRooms
        {
            get
            {
                return browser.FindElement(By.Name("rooms"));
            }
        }

        public IWebElement submitButton
        {
            get
            {
                return browser.FindElement(By.CssSelector("input[type='submit']"));
            }
        }

        public IWebElement coordinatesTable
        {
            get
            {
                return browser.FindElement(By.Name("dimensions_table"));
            }
        }

        public IWebElement viewResults
        {
            get
            {
                return browser.FindElement(By.CssSelector("button[type='button']"));
            }
        }

        public IWebElement resultsTable
        {
            get
            {
                return browser.FindElement(By.Name("Results"));
            }
        }
    }
}
