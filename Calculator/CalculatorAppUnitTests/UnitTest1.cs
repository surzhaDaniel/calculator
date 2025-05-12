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

        [DataTestMethod]
        [DataRow("3 + 4", 7.0, DisplayName = "Simple Addition")]
        [DataRow("5 - 2", 3.0, DisplayName = "Simple Subtraction")]
        [DataRow("3 * 2", 6.0, DisplayName = "Simple Multiplication")]
        [DataRow("6 / 2", 3.0, DisplayName = "Simple Division")]
        [DataRow("3 + 4 * 2", 11.0, DisplayName = "Addition and Multiplication")]
        [DataRow("(3 + 2) * 4", 20.0, DisplayName = "Parentheses with Multiplication")]
        [DataRow("2 * (3 + 4 * (2 + 1))", 30.0, DisplayName = "Nested Parentheses")]
        [DataRow("10 + 20 + 30", 60.0, DisplayName = "Multiple Additions")]
        [DataRow("100 - 50 - 25", 25.0, DisplayName = "Multiple Subtractions")]
        [DataRow("2 * 3 * 4", 24.0, DisplayName = "Multiple Multiplications")]
        [DataRow("16 / 4 / 2", 2.0, DisplayName = "Multiple Divisions")]
        [DataRow("2.5 + 3.5", 6.0, DisplayName = "Decimal Numbers Addition")]
        [DataRow("1.5 * 2", 3.0, DisplayName = "Decimal Numbers Multiplication")]
        [DataRow("1000 * 1000", 1000000.0, DisplayName = "Large Numbers Multiplication")]
        [DataRow(" 3 + 4 ", 7.0, DisplayName = "Expression with Leading/Trailing Spaces")]
        [DataRow("5", 5.0, DisplayName = "Single Number")]
        [DataRow("(1 + (2 + (3 + 4)))", 10.0, DisplayName = "Deeply Nested Parentheses")]
        [DataRow("((2 * 3) + 4) / (1 + 1)", 5.0, DisplayName = "Complex Expression with All Operators")]
        [DataRow("10 * (2 + 3) - 4 / 2", 48.0, DisplayName = "Mixed Operators and Parentheses")]
        [DataRow("1 + 2 * 3 - 4 / 2 + (5 * 2)", 15.0, DisplayName = "All Operators with Parentheses")]
        public void Evaluate_ValidExpression_ReturnsCorrectResult(string expression, double expected)
        {
            double result = _calculator.Evaluate(expression);
            Assert.AreEqual(expected, result, 1e-10, $"Failed for expression: {expression}");
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void Evaluate_EmptyExpression_ThrowsArgumentException()
        {
            _calculator.Evaluate("");
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void Evaluate_InvalidCharacters_ThrowsArgumentException()
        {
            _calculator.Evaluate("3 + a");
        }

        [TestMethod]
        [ExpectedException(typeof(DivideByZeroException))]
        public void Evaluate_DivisionByZero_ThrowsDivideByZeroException()
        {
            _calculator.Evaluate("5 / 0");
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void Evaluate_MismatchedParentheses_ThrowsArgumentException()
        {
            _calculator.Evaluate("(3 + 2 * (4 + 1)");
        }

        [TestMethod]
        [ExpectedException(typeof(InvalidOperationException))]
        public void Evaluate_InvalidOperatorSequence_ThrowsInvalidOperationException()
        {
            _calculator.Evaluate("3 + + 4");
        }
    }
}
