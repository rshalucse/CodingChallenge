using System;
using System.Collections.Generic;
using System.Threading;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;

namespace TestProject
{

    public class Business
    {
        private static IWebDriver browser;
        private static Model model;

        public Business(IWebDriver browser1)
        {
            browser = browser1;
        }
        public static void OpenBrowser(String url)
        {
            browser.Manage().Window.Maximize();
            browser.Navigate().GoToUrl(url);
        }

        public static void closeBrowser()
        {
            browser.Close();

        }

        /// <summary>
        /// Enter the number of rooms and click submit
        /// </summary>
        /// <param name="numRooms"></param>
        public static void enterRoomCount(int numRooms)
        {
            model = new Model(browser);
            model.numOfRooms.SendKeys(numRooms.ToString());
            model.submitButton.Click();

        }

        /// <summary>
        /// Validate number of rows displayed after # rooms are entered
        /// </summary>
        /// <param name="numRooms"></param>
        /// <returns></returns>
        public static Boolean validateRows(int numRooms)
        {
            int numrooms = numRooms;

            var table = model.coordinatesTable;
            var rows = table.FindElements(By.TagName("tr"));

            if (numrooms.Equals(rows.Count - 1))
                return true;
            return false;
        }

        /// <summary>
        /// This function iterates through every row/ cell value and inputs the coordinates from the dictionary
        /// 
        /// </summary>
        /// <param name="myRoomDict"></param>
        public static void enterCoordinates(Dictionary<String, int> myRoomDict)
        {
            var table = model.coordinatesTable;
            var rows = table.FindElements(By.TagName("tr"));
            int i = 0;
            foreach (var row in rows)
            {
                var tds = row.FindElements(By.TagName("input"));

                foreach (var entry in tds)
                {
                    foreach (KeyValuePair<String, int> keyval in myRoomDict)
                    {
                        if (keyval.Key.Contains("length"+i))
                        {
                            var val = entry.FindElement(By.XPath("//input[starts-with(@name,'length-" + i + "')]"));
                            val.SendKeys(keyval.Value.ToString() + Keys.Tab);
                        }

                        if (keyval.Key.Contains("width"+i))
                        {
                            var val = entry.FindElement(By.XPath("//input[starts-with(@name,'width-" + i + "')]"));
                            val.SendKeys(keyval.Value.ToString() + Keys.Tab);
                        }

                        if (keyval.Key.Contains("height"+i))
                        {
                            var val = entry.FindElement(By.XPath("//input[starts-with(@name,'height-" + i + "')]"));
                            val.SendKeys(keyval.Value.ToString() + Keys.Tab);
                            i++;
                        }
                    }
                    break;
                }
            }
            model.submitButton.Click();
        }

        /// <summary>
        /// Compare expected values from dictionary to the results table values 
        /// Compare expected sq.ft and number of gallons to what is displayed on screen
        /// </summary>
        /// <param name="myRoomDict"></param>
        /// <returns></returns>
        public static Boolean validateResults(Dictionary<String, int> myRoomDict)
        {
            model.viewResults.Click();

            //WebDriverWait wait = new WebDriverWait(browser,TimeSpan.FromSeconds(5));
            //wait.Until(ExpectedConditions.VisibilityOfAllElementsLocatedBy(By.XPath("//td[starts-with(@class,'room-')]")));
            //browser.Manage().Timeouts().PageLoad. = TimeSpan.FromSeconds(5);

            Thread.Sleep(5000); //This could be replaced with a wait for condition as tried just above this
            int total = 0;
            int numGallons = 0;
            int i = 0;
            Boolean flag = false;
            var table = model.resultsTable;
            var rows = table.FindElements(By.TagName("tr"));

            int j = 1;
            foreach (var row in rows)
            {
                foreach (KeyValuePair<String, int> keyval in myRoomDict)
                {
                    if (keyval.Key.Contains("length" + i))
                    {
                        total = keyval.Value * 2;
                    }
                    if (keyval.Key.Contains("width" + i))
                    {
                        total += keyval.Value * 2;
                    }
                    if (keyval.Key.Contains("height" + i))
                    {
                        total *= keyval.Value;                      
                    }                                            
                }
                numGallons = total / 400;
                //Validate what is on the screen is what is expected
                var tds = row.FindElements(By.XPath("//tr[starts-with(@id,'room-" + j + "')]"));
                if (tds.Count > 0) //Proceed only if there are cells with value
                {
                    var text = tds[0].Text;
                    String[] values = new String[] { };
                    values = text.Split(' ');
                    var room = values[0];
                    var area = values[1];
                    var gallons = values[2];

                    if (int.Parse(area).Equals(total) && int.Parse(gallons).Equals(numGallons))
                        flag = true;
                    else
                    {
                        flag = false;
                        break;

                    }
                }
                i++;
                j++;
            }
            return flag;
        }
    }
}
