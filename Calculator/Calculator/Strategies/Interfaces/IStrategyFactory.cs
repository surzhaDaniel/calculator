using CalculatorApp.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CalculatorApp.Strategies.Interfaces;
internal interface IStrategyFactory
{
    IInputOutputStrategy Create(string? mode, Calculator calculator, string? inputPath, string? outputPath);
}
