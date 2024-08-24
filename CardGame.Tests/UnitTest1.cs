using CardGame.Backend;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace CardGame.Tests
{
    [TestClass]
    public class CalculatorTests
    {
        [TestMethod]
        public void Add_TwoNumbers_ReturnsSum()
        {
            var calculator = new Calculator();
            int a = 5;
            int b = 3;

            int result = calculator.Add(a, b);

            Assert.AreEqual(8, result);
        }
    }
}
