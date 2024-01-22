using Microsoft.VisualStudio.TestTools.UnitTesting;
using DirectFerriesTest.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DirectFerriesTest.Models;

namespace DirectFerriesTest.Services.Tests
{
    [TestClass()]
    public class UserProcessorServiceTests
    {
        private UserProcessorService userProcessor;
        public UserProcessorServiceTests()
        {
            userProcessor = new UserProcessorService();
        }
        [TestMethod()]
        public void GetUserResultsTest()
        {
            UserResults userResults;
            UserInfo userInfo = new UserInfo()
            {
                FullName = " john smith stuff",
                DOB =  DateTime.Now.AddYears(-10)
            };
            userResults = userProcessor.GetUserResults(userInfo);

            Assert.IsNotNull(userResults);
            Assert.AreEqual(userResults.FirstName, "John");
            Assert.AreEqual(userResults.Age, 10);

            userInfo.DOB = DateTime.Now.AddDays(50);
            userResults = userProcessor.GetUserResults(userInfo);

            Assert.AreEqual(userResults.DaysToBirthday, 50);
            Assert.AreEqual(userResults.VowelsCount, 1);

            Assert.Fail();
        }
    }
}