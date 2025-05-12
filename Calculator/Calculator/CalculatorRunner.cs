using CalculatorApp.Core;
using CalculatorApp.Strategies.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CalculatorApp;
internal class CalculatorRunner
{
    private readonly Calculator _calculator;
    private readonly IStrategyFactory _strategyFactory;

    public CalculatorRunner(Calculator calculator, IStrategyFactory strategyFactory)
    {
        _calculator = calculator ?? throw new ArgumentNullException(nameof(calculator));
        _strategyFactory = strategyFactory ?? throw new ArgumentNullException(nameof(strategyFactory));
    }

    public void Run()
    {
        Console.WriteLine("Choose the mode: 1 - console, 2 - file");
        string? mode = Console.ReadLine();

        IInputOutputStrategy? strategy = null;
        try
        {
            string? inputPath = null, outputPath = null;
            if (mode == "2")
            {
                Console.WriteLine("Enter input file path:");
                inputPath = Console.ReadLine();
                Console.WriteLine("Enter output file path:");
                outputPath = Console.ReadLine();
            }
            strategy = _strategyFactory.Create(mode, _calculator, inputPath, outputPath);
        }
        catch (ArgumentException ex)
        {
            Console.WriteLine(ex.Message);
            return;
        }

        try
        {
            double? result = strategy.Execute();
            if (result.HasValue)
                Console.WriteLine($"Result: {result.Value}");
            else
                Console.WriteLine("No result returned.");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"An error occurred: {ex.Message}");
        }
    }
}