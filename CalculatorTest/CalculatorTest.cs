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
            var result = calculator.Add("31",false);
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
            var result = calculator.Add("1,4,5", false);
            Assert.AreEqual(result, 10);
        }

        [TestMethod]
        public void Add_Null_ReturnZero()
        {
            var calculator = new Calculator();
            var result = calculator.Add(null,false);
            Assert.AreEqual(result, 0);
        }

        [TestMethod]
        public void Add_InvalidNumbers_ReturnSum()
        {
            var calculator = new Calculator();
            var result = calculator.Add("1,test", false);
            Assert.AreEqual(result, 1);
        }

       //For Step One Missing Numbers Test
        [TestMethod]
        public void Add_MissingNumbers_ReturnSum()
        {
            var calculator = new Calculator();
            var result = calculator.Add("1,,4", false);
            Assert.AreEqual(result, 5);
        }

        [TestMethod]
        public void Add_NewLineDelimiter_ReturnSum()
        {
            var calculator = new Calculator();
            var result = calculator.Add("1\n2,3", false);
            Assert.AreEqual(result, 6);
        }

        [TestMethod]
        public void Add_ManyNegativeNumbers_ThrowArgumentException()
        {
            try
            {
                var calculator = new Calculator();
                calculator.Add("-100,-5,-2,1,4",false);
                Assert.Fail();
            }
            catch (ArgumentException ex)
            {
                Assert.AreEqual("These negatives: -100,-5,-2 are not allowed.", ex.Message);
            }
        }

        [TestMethod]
        public void Add_IgnoreNumbersGreaterThan1000_ReturnSum()
        {
            var calculator = new Calculator();
            var result = calculator.Add("1,1500,24",false);
            Assert.AreEqual(result, 25);
        }

        [TestMethod]
        public void Add_OneCustomDelimiterOfOneCharacterLength_ReturnsSum()
        {
            var calculator = new Calculator();
            string input = "//;\n1;2";
            int result = calculator.Add(input,false);
            Assert.AreEqual(3, result);
        }

        [TestMethod]
        public void Add_OneCustomDelimiterOfAnyLength_ReturnsSum()
        {
            var calculator = new Calculator();
            string input = "//[***]\n11***22***33";
            int result = calculator.Add(input, false);
            Assert.AreEqual(66, result);
        }

        [TestMethod]
        public void Add_MultipleCustomDelimiterOfAnyLength_ReturnsSum()
        {
            var calculator = new Calculator();
            string input = "//[*][!!][rrr]\n11rrr22*33!!44";
            int result = calculator.Add(input, false);
            Assert.AreEqual(110, result);
        }

        //Part of Stretch Goals
        [TestMethod]
        public void Add_AllowNegatives_ReturnSum()
        {
            var calculator = new Calculator();
            var result = calculator.Add("1,-2,4", true);
            Assert.AreEqual(result, 3);
        }

        [TestMethod]
        public void Add_AllowNegativesAndMultipleCustomDelimiterOfAnyLength_ReturnsSum()
        {
            var calculator = new Calculator();
            string input = "//[*][!!][rrr]\n-11rrr22*33!!44";
            int result = calculator.Add(input, true);
            Assert.AreEqual(88, result);
        }

    }
}

