using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CalculatorApp.Core;
using CalculatorApp.Strategies.Interfaces;

namespace CalculatorApp.Strategies;
internal class ConsoleMode : IInputOutputStrategy
{
    private readonly Calculator _calculator;

    public ConsoleMode(Calculator calculator)
    {
        _calculator = calculator ?? throw new ArgumentNullException(nameof(calculator));
    }

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
