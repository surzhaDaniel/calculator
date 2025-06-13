using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CalculatorApp.Strategies.Interfaces;

/// <summary>
/// Defines the contract for input/output strategies in the calculator application.
/// </summary>
internal interface IInputOutputStrategy
{
    /// <summary>
    /// Executes the input/output strategy, processing the input and returning the calculation result.
    /// </summary>
    /// <returns>The result of the calculation, or null if no result was produced.</returns>
    /// <exception cref="InvalidOperationException">Thrown when the strategy execution fails.</exception>
    double? Execute();
}
