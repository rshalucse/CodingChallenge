using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium;
using System.Collections.Generic;


namespace TestProject
{
    [TestClass]
    public class Tests
    {
       ChromeDriver driver;
        List<int> myRoomList = new List<int>();
        Dictionary<String, int> myRoomDict = new Dictionary<string, int>();


       /// <summary>
       /// Runs before every test initializing the browser
       /// </summary>
       [TestInitialize]
       public void initialize()
        {
            driver = new ChromeDriver();
            Business business = new Business(driver);
            var url = "http://127.0.0.1:5000";
            Business.OpenBrowser(url);
        }

        /// <summary>
        /// BVT test validates if the page launches
        /// </summary>
        [TestMethod]
        public void ValidatePageLaunch()
        {
            var header = driver.FindElement(By.TagName("h1"));
            Assert.AreEqual("Calculating Paint Required", header.Text);         
        }

        /// <summary>
        /// BVT - Validate number of rows displayed on submitting num of rooms
        /// </summary>
        [TestMethod]
        public void validateRowsDisplayed()
        {
            int numrooms = 2;
            Business.enterRoomCount(numrooms);
            Boolean flag = Business.validateRows(numrooms);
            Assert.IsTrue(flag);
        }

        /// <summary>
        /// Regression - Happy path test with 1 room entered
        /// </summary>
        [TestMethod]
        public void calculatePaintHappyPath()
        {
            int numrooms = 1;
            myRoomDict.Add("rooms", 1);
            myRoomDict.Add("length0", 10);
            myRoomDict.Add("width0", 20);
            myRoomDict.Add("height0", 30);
            Business.enterRoomCount(numrooms);
            Business.enterCoordinates(myRoomDict);
            Boolean flag = Business.validateResults(myRoomDict);
            Assert.IsTrue(flag);
        }

        /// <summary>
        /// Regression - Happy path test with 1 room less than 400 ft
        /// </summary>
        [TestMethod]
        public void calculatePaintHappyLessThanMinFeet()
        {
            int numrooms = 1;
            myRoomDict.Add("rooms", 1);
            myRoomDict.Add("length0", 20);
            myRoomDict.Add("width0", 10);
            myRoomDict.Add("height0", 1);
            Business.enterRoomCount(numrooms);
            Business.enterCoordinates(myRoomDict);
            Boolean flag = Business.validateResults(myRoomDict);
            Assert.IsTrue(flag);
        }


        /// <summary>
        /// Regression - Happy path test 2 rooms > 400ft
        /// </summary>
        [TestMethod]
        public void calculatePaintHappyTwoRooms()
        {
            int numrooms = 2;
            myRoomDict.Add("rooms", 2);
            myRoomDict.Add("length0", 40);
            myRoomDict.Add("width0", 17);
            myRoomDict.Add("height0", 30);
            myRoomDict.Add("length1", 20);
            myRoomDict.Add("width1", 10);
            myRoomDict.Add("height1", 15);
            Business.enterRoomCount(numrooms);
            Business.enterCoordinates(myRoomDict);
            Boolean flag = Business.validateResults(myRoomDict);
            Assert.IsTrue(flag);
        }

        /// <summary>
        /// Runs after each test to close the browser
        /// </summary>
        [TestCleanup]
        public void cleanup()
        {
            Business.closeBrowser();

        }

    }
}
