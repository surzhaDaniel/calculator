using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CalculatorApp.Strategies.Interfaces;

internal interface IInputOutputStrategy
{
    double? Execute();
}
