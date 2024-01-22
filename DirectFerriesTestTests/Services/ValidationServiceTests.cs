using Microsoft.VisualStudio.TestTools.UnitTesting;
using DirectFerriesTest.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DirectFerriesTest.Interfaces;
using DirectFerriesTest.Models;
using Microsoft.VisualStudio.TestPlatform.CommunicationUtilities;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace DirectFerriesTest.Services.Tests
{
    [TestClass()]
    public class ValidationServiceTests
    {

        private ValidationService ValidationService;
        public ValidationServiceTests()
        {
            ValidationService = new ValidationService();
        }

        [TestMethod()]
        public void ValidDOBTest()
        {

            string message = string.Empty;
            bool valid = false;

            (message, valid) = ValidationService.ValidDOB(DateTime.Now.AddDays(1));
            Assert.IsFalse(valid);

            (message, valid) = ValidationService.ValidDOB(DateTime.Now.AddDays(-100));
            Assert.IsTrue(valid);
        }

        [TestMethod()]
        public void ValidNameTest()
        {
            string message = string.Empty;
            bool valid = false;

            (message, valid) = ValidationService.ValidName("£FSDS");
            Assert.IsFalse(valid);

            (message, valid) = ValidationService.ValidName("");
            Assert.IsFalse(valid);

            (message, valid) = ValidationService.ValidName("Amir");
            Assert.IsFalse(valid);

            (message, valid) = ValidationService.ValidName("Amir Ej");
            Assert.IsTrue(valid);

            (message, valid) = ValidationService.ValidName("  Amir Ej ");
            Assert.IsTrue(valid);


        }
    }
}