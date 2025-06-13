using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CalculatorApp.Core;
using CalculatorApp.Strategies.Interfaces;

namespace CalculatorApp.Strategies;

/// <summary>
/// Implements the console-based input/output strategy for the calculator.
/// This strategy reads expressions from the console and displays results directly to the console.
/// </summary>
internal class ConsoleMode : IInputOutputStrategy
{
    private readonly Calculator _calculator;

    /// <summary>
    /// Initializes a new instance of the ConsoleMode class.
    /// </summary>
    /// <param name="calculator">The calculator instance to use for evaluations.</param>
    /// <exception cref="ArgumentNullException">Thrown when calculator is null.</exception>
    public ConsoleMode(Calculator calculator)
    {
        _calculator = calculator ?? throw new ArgumentNullException(nameof(calculator));
    }

    /// <summary>
    /// Executes the console mode strategy by reading an expression from the console and evaluating it.
    /// </summary>
    /// <returns>The result of the calculation, or null if no input was provided.</returns>
    /// <exception cref="InvalidOperationException">Thrown when the expression evaluation fails.</exception>
    public double? Execute()
    {
        Console.WriteLine("Console mode execution");
        Console.WriteLine("Enter the expression: ");

        string? input = Console.ReadLine();

        if (string.IsNullOrWhiteSpace(input))
            return null;

        return _calculator.Evaluate(input);
    }
}
