using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace CalculatorApp.Core;

internal class Tokenizer
{
    public static List<string> Tokenize(string input)
    {
        var tokens = new List<string>();

        string pattern = @"(\d+(\.\d+)?)|[+\-*/()]";

        var matches = Regex.Matches(input.Replace(" ", ""), pattern);

        foreach (Match match in matches)
        {
            tokens.Add(match.Value);
        }

        string combined = string.Concat(tokens);
        string cleaned = input.Replace(" ", "");
        if (combined.Length != cleaned.Length)
            throw new ArgumentException("Wrong input. Some characters are not valid.");

        return tokens;
    }
}