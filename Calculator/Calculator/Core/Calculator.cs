using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CalculatorApp.Core;

internal class Calculator : ICalculator
{
    public double Evaluate(string input)
    {
        if (string.IsNullOrWhiteSpace(input))
            throw new ArgumentException("Input expression cannot be empty or whitespace.");

        var tokens = Tokenizer.Tokenize(input);
        var parsedBySYP = ShuntingYardParser.Parse(tokens);
        return PostfixEvaluator.Evaluate(parsedBySYP);
    }
}