using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace CodeLogic01.Tests
{
    [TestClass]
    public class UnitTest
    {
        [TestMethod]
        public void BaseTenNumberTestMethod()
        {
            var args = new string[] { "0", "2" };
            var baseNumbers = new Program.BaseNumbers(args);
            Assert.AreEqual(0, Program.Convert(baseNumbers));

            args = new string[] { "1", "2" };
            baseNumbers = new Program.BaseNumbers(args);
            Assert.AreEqual(1, Program.Convert(baseNumbers));

            args = new string[] { "2", "2" };
            baseNumbers = new Program.BaseNumbers(args);
            Assert.AreEqual(10, Program.Convert(baseNumbers));

            args = new string[] { "3", "2" };
            baseNumbers = new Program.BaseNumbers(args);
            Assert.AreEqual(11, Program.Convert(baseNumbers));

            args = new string[] { "4", "2" };
            baseNumbers = new Program.BaseNumbers(args);
            Assert.AreEqual(100, Program.Convert(baseNumbers));

            args = new string[] { "5", "2" };
            baseNumbers = new Program.BaseNumbers(args);
            Assert.AreEqual(101, Program.Convert(baseNumbers));

            args = new string[] { "6", "2" };
            baseNumbers = new Program.BaseNumbers(args);
            Assert.AreEqual(110, Program.Convert(baseNumbers));

            args = new string[] { "10", "2" };
            baseNumbers = new Program.BaseNumbers(args);
            Assert.AreEqual(1010, Program.Convert(baseNumbers));

            args = new string[] { "12", "2" };
            baseNumbers = new Program.BaseNumbers(args);
            Assert.AreEqual(1100, Program.Convert(baseNumbers));

            args = new string[] { "13", "2" };
            baseNumbers = new Program.BaseNumbers(args);
            Assert.AreEqual(1101, Program.Convert(baseNumbers));
        }

        [TestMethod]
        public void BaseTenNumberToBaseThreeNumberTestMethod()
        {
            string convertedBaseNumber = "3";
            var args = new string[] { "0", convertedBaseNumber };
            var baseNumbers = new Program.BaseNumbers(args);
            Assert.AreEqual(0, Program.Convert(baseNumbers));

            args = new string[] { "1", convertedBaseNumber };
            baseNumbers = new Program.BaseNumbers(args);
            Assert.AreEqual(1, Program.Convert(baseNumbers));

            args = new string[] { "2", convertedBaseNumber };
            baseNumbers = new Program.BaseNumbers(args);
            Assert.AreEqual(2, Program.Convert(baseNumbers));

            args = new string[] { "3", convertedBaseNumber };
            baseNumbers = new Program.BaseNumbers(args);
            Assert.AreEqual(10, Program.Convert(baseNumbers));

            args = new string[] { "14", convertedBaseNumber };
            baseNumbers = new Program.BaseNumbers(args);
            Assert.AreEqual(112, Program.Convert(baseNumbers));
        }
    }
}
