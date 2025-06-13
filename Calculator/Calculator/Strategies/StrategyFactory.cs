using CalculatorApp.Core;
using CalculatorApp.Strategies.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CalculatorApp.Strategies
{
    /// <summary>
    /// Factory class responsible for creating appropriate input/output strategies based on the specified mode.
    /// </summary>
    internal class StrategyFactory : IStrategyFactory
    {
        /// <summary>
        /// Creates an input/output strategy based on the specified mode and parameters.
        /// </summary>
        /// <param name="mode">The mode of operation ("1" for console, "2" for file).</param>
        /// <param name="calculator">The calculator instance to use for evaluations.</param>
        /// <param name="inputPath">The path to the input file (required for file mode).</param>
        /// <param name="outputPath">The path to the output file (required for file mode).</param>
        /// <returns>An instance of IInputOutputStrategy configured for the specified mode.</returns>
        /// <exception cref="ArgumentException">
        /// Thrown when:
        /// - The mode is empty or null
        /// - The mode is invalid
        /// - File paths are empty or null in file mode
        /// </exception>
        public IInputOutputStrategy Create(string? mode, Calculator calculator, string? inputPath, string? outputPath)
        {
            if (string.IsNullOrWhiteSpace(mode))
                throw new ArgumentException("Mode cannot be empty.");

            switch (mode)
            {
                case "1":
                    return new ConsoleMode(calculator);
                case "2":
                    if (string.IsNullOrWhiteSpace(inputPath) || string.IsNullOrWhiteSpace(outputPath))
                        throw new ArgumentException("File paths cannot be empty.");
                    return new FileMode(inputPath, outputPath, calculator);
                default:
                    throw new ArgumentException("Invalid mode selected.");
            }
        }
    }
}