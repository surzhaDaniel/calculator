using CalculatorApp.Core;

using CalculatorApp.Core;
using CalculatorApp.Strategies;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.IO;

namespace CalculatorAppUnitTests
{
    [TestClass]
    public class CalculatorTests
    {
        private Calculator _calculator;

        [TestInitialize]
        public void Setup()
        {
            _calculator = new Calculator();
        }

        [TestMethod]
        public void Evaluate_SimpleAddition_ReturnsCorrectResult()
        {
            var result = _calculator.Evaluate("2+3");
            Assert.AreEqual(5, result);
        }

        [TestMethod]
        public void Evaluate_ComplexExpressionWithPriority_ReturnsCorrectResult()
        {
            var result = _calculator.Evaluate("2+3*4-5/2");
            Assert.AreEqual(11.5, result);
        }

        [TestMethod]
        public void Evaluate_WithParentheses_ReturnsCorrectResult()
        {
            var result = _calculator.Evaluate("(2+3)*4");
            Assert.AreEqual(20, result);
        }

        [TestMethod]
        public void Evaluate_NegativeNumbers_ReturnsCorrectResult()
        {
            var result = _calculator.Evaluate("-5+3*-2");
            Assert.AreEqual(-11, result);
        }

        [TestMethod]
        public void Evaluate_DecimalNumbers_ReturnsCorrectResult()
        {
            var result = _calculator.Evaluate("3.5*2+1.25");
            Assert.AreEqual(8.25, result);
        }

        [TestMethod]
        public void Evaluate_ExpressionWithSpaces_ReturnsCorrectResult()
        {
            var result = _calculator.Evaluate(" 2 + 3 * 4 ");
            Assert.AreEqual(14, result);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void Evaluate_EmptyInput_ThrowsException()
        {
            _calculator.Evaluate("");
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void Evaluate_InvalidCharacters_ThrowsException()
        {
            _calculator.Evaluate("2+a*3");
        }

        [TestMethod]
        [ExpectedException(typeof(DivideByZeroException))]
        public void Evaluate_DivisionByZero_ThrowsException()
        {
            _calculator.Evaluate("5/0");
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void Evaluate_MismatchedParentheses_ThrowsException()
        {
            _calculator.Evaluate("(2+3*4");
        }

        [TestMethod]
        [ExpectedException(typeof(InvalidOperationException))]
        public void Evaluate_InvalidOperatorSequence_ThrowsException()
        {
            _calculator.Evaluate("2++3");
        }

        [TestMethod]
        [ExpectedException(typeof(InvalidOperationException))]
        public void Evaluate_StartsWithOperator_ThrowsException()
        {
            _calculator.Evaluate("*2+3");
        }

        [TestMethod]
        [ExpectedException(typeof(InvalidOperationException))]
        public void Evaluate_EndsWithOperator_ThrowsException()
        {
            _calculator.Evaluate("2+3*");
        }

        [TestMethod]
        public void Evaluate_MultipleParentheses_ReturnsCorrectResult()
        {
            var result = _calculator.Evaluate("((2+3)*4-(8/2))");
            Assert.AreEqual(16, result);
        }

        [TestMethod]
        public void Evaluate_ComplexNegativeExpressions_ReturnsCorrectResult()
        {
            var result = _calculator.Evaluate("(-2+3)*-(-4+5)");
            Assert.AreEqual(-1, result);
        }

        [TestMethod]
        [ExpectedException(typeof(InvalidOperationException))]
        public void Evaluate_OnlyOperators_ThrowsException()
        {
            _calculator.Evaluate("+-*/");
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void Evaluate_OnlyParentheses_ThrowsException()
        {
            _calculator.Evaluate("(()))");
        }
    }
}
