using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CalculatorApp.Core
{
    /// <summary>
    /// Represents a calculator that can evaluate mathematical expressions.
    /// </summary>
    internal interface ICalculator
    {
        /// <summary>
        /// Evaluates a mathematical expression and returns the result.
        /// </summary>
        /// <param name="input">The mathematical expression to evaluate.</param>
        /// <returns>The result of the evaluation as a double.</returns>
        /// <exception cref="ArgumentException">Thrown when the input expression is invalid or cannot be evaluated.</exception>
        double Evaluate(string input);
    }
}
