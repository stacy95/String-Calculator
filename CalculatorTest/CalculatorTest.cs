using System;
using Calculator_StacyHong;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace CalculatorTest
{
    [TestClass]
    public class CalculatorTest
    {
        [TestMethod]
        public void Add_OneNumber_ReturnSum()
        {
            var calculator = new Calculator();
            var result = calculator.Add("31");
            Assert.AreEqual(result, 31);
        }

        ////This test case is for Step One: only support a maximum of two numbers.
        //[TestMethod]
        //public void Add_MoreThanTwoNumbers_ReturnZero()
        //{
        //    var calculator = new Calculator();
        //    var result = calculator.Add("1,4,5");
        //    Assert.AreEqual(result, 0);
        //}

        //This is for Step Two and onwards.
        [TestMethod]
        public void Add_MoreThanTwoNumbers_ReturnSum()
        {
            var calculator = new Calculator();
            var result = calculator.Add("1,4,5");
            Assert.AreEqual(result, 10);
        }

        [TestMethod]
        public void Add_Null_ReturnZero()
        {
            var calculator = new Calculator();
            var result = calculator.Add(null);
            Assert.AreEqual(result, 0);
        }

        [TestMethod]
        public void Add_InvalidNumbers_ReturnSum()
        {
            var calculator = new Calculator();
            var result = calculator.Add("1,test");
            Assert.AreEqual(result, 1);
        }

    }
}

