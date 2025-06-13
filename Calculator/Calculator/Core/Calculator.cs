using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CalculatorApp.Core;

/// <summary>
/// Provides functionality to evaluate mathematical expressions using the Shunting Yard algorithm
/// and postfix notation evaluation.
/// </summary>
internal class Calculator : ICalculator
{
    /// <summary>
    /// Evaluates a mathematical expression by converting it to postfix notation and then computing the result.
    /// </summary>
    /// <param name="input">The mathematical expression to evaluate.</param>
    /// <returns>The result of the evaluation as a double.</returns>
    /// <exception cref="ArgumentException">Thrown when the input expression is empty, contains only whitespace, or is invalid.</exception>
    /// <exception cref="InvalidOperationException">Thrown when the expression cannot be evaluated due to invalid operations or operands.</exception>
    public double Evaluate(string input)
    {
        if (string.IsNullOrWhiteSpace(input))
            throw new ArgumentException("Input expression cannot be empty or whitespace.");

        var tokens = Tokenizer.Tokenize(input);
        var parsedBySYP = ShuntingYardParser.Parse(tokens);
        return PostfixEvaluator.Evaluate(parsedBySYP);
    }
}