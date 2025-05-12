using CalculatorApp.Core;
using CalculatorApp.Strategies.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CalculatorApp.Strategies
{
    internal class StrategyFactory : IStrategyFactory
    {
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
