using CalculatorApp.Core;
using CalculatorApp.Strategies;

namespace CalculatorApp;
class Program
{
    static void Main()
    {
        var calculator = new Calculator();
        var strategyFactory = new StrategyFactory();
        var runner = new CalculatorRunner(calculator, strategyFactory);
        runner.Run();
    }
}
