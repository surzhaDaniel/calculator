using CalculatorApp.Core;
using CalculatorApp.Strategies.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CalculatorApp.Strategies;
internal class FileMode : IInputOutputStrategy
{
    private readonly string _inputPath;
    private readonly string _outputPath;
    private readonly Calculator _calculator;

    public FileMode(string inputPath, string outputPath, Calculator calculator)
    {
        _inputPath = inputPath;
        _outputPath = outputPath;
        _calculator = calculator;
    }

    public double? Execute()
    {
        if (!File.Exists(_inputPath))
            throw new FileNotFoundException($"Input file not found: {_inputPath}");

        string inputExpression = File.ReadAllText(_inputPath).Trim();

        if (string.IsNullOrWhiteSpace(inputExpression))
            throw new ArgumentException("Input file is empty.");

        double result = _calculator.Evaluate(inputExpression);

        File.WriteAllText(_outputPath, $"Result: {result}");

        return result;
    }
}
