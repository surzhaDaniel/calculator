using CalculatorApp.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CalculatorApp.Strategies.Interfaces;

/// <summary>
/// Defines the contract for creating input/output strategies based on the specified mode and parameters.
/// </summary>
internal interface IStrategyFactory
{
    /// <summary>
    /// Creates an input/output strategy based on the specified mode and parameters.
    /// </summary>
    /// <param name="mode">The mode of operation ("1" for console, "2" for file).</param>
    /// <param name="calculator">The calculator instance to use for evaluations.</param>
    /// <param name="inputPath">The path to the input file (required for file mode).</param>
    /// <param name="outputPath">The path to the output file (required for file mode).</param>
    /// <returns>An instance of IInputOutputStrategy configured for the specified mode.</returns>
    /// <exception cref="ArgumentException">Thrown when the mode is invalid or required parameters are missing.</exception>
    IInputOutputStrategy Create(string? mode, Calculator calculator, string? inputPath, string? outputPath);
}
