using CalculatorApp.Core;
using CalculatorApp.Strategies.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CalculatorApp.Strategies;

/// <summary>
/// Implements the file-based input/output strategy for the calculator.
/// This strategy reads expressions from an input file and writes results to an output file.
/// </summary>
internal class FileMode : IInputOutputStrategy
{
    private readonly string _inputPath;
    private readonly string _outputPath;
    private readonly Calculator _calculator;

    /// <summary>
    /// Initializes a new instance of the FileMode class.
    /// </summary>
    /// <param name="inputPath">The path to the input file containing the expression to evaluate.</param>
    /// <param name="outputPath">The path to the output file where the result will be written.</param>
    /// <param name="calculator">The calculator instance to use for evaluations.</param>
    /// <exception cref="ArgumentNullException">Thrown when any of the parameters are null.</exception>
    public FileMode(string inputPath, string outputPath, Calculator calculator)
    {
        _inputPath = inputPath;
        _outputPath = outputPath;
        _calculator = calculator;
    }

    /// <summary>
    /// Executes the file mode strategy by reading an expression from the input file,
    /// evaluating it, and writing the result to the output file.
    /// </summary>
    /// <returns>The result of the calculation.</returns>
    /// <exception cref="FileNotFoundException">Thrown when the input file does not exist.</exception>
    /// <exception cref="ArgumentException">Thrown when the input file is empty.</exception>
    /// <exception cref="InvalidOperationException">Thrown when the expression evaluation fails.</exception>
    /// <exception cref="IOException">Thrown when there are issues reading from or writing to the files.</exception>
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
