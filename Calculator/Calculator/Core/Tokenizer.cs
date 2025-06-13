using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace CalculatorApp.Core;

/// <summary>
/// Provides functionality to tokenize mathematical expressions into a list of tokens.
/// Handles numbers, operators, and parentheses, with special handling for negative numbers.
/// </summary>
internal class Tokenizer
{
    /// <summary>
    /// Tokenizes a mathematical expression string into a list of tokens.
    /// </summary>
    /// <param name="input">The mathematical expression to tokenize.</param>
    /// <returns>A list of tokens representing the expression.</returns>
    /// <exception cref="ArgumentException">Thrown when the input contains invalid characters or is malformed.</exception>
    /// <remarks>
    /// The tokenizer handles:
    /// - Numbers (integers and decimals)
    /// - Basic operators (+, -, *, /)
    /// - Parentheses
    /// - Negative numbers
    /// - Negative expressions in parentheses
    /// </remarks>
    public static List<string> Tokenize(string input)
    {
        var rawTokens = new List<string>();
        string pattern = @"\d+(\.\d+)?|[+\-*/()]";
        var matches = Regex.Matches(input, pattern);

        foreach (Match match in matches)
        {
            rawTokens.Add(match.Value);
        }

        var tokens = new List<string>();
        for (int i = 0; i < rawTokens.Count; i++)
        {
            string current = rawTokens[i];

            if (current == "-" &&
                i + 1 < rawTokens.Count &&
                Regex.IsMatch(rawTokens[i + 1], @"^\d+(\.\d+)?$") &&
                (i == 0 || rawTokens[i - 1] == "(" || IsOperator(rawTokens[i - 1])))
            {
                tokens.Add("-" + rawTokens[i + 1]);
                i++;
            }
            else if (current == "-" &&
                     i + 1 < rawTokens.Count &&
                     rawTokens[i + 1] == "(" &&
                     (i == 0 || rawTokens[i - 1] == "(" || IsOperator(rawTokens[i - 1])))
            {
                tokens.Add("-1");
                tokens.Add("*");
            }
            else
            {
                tokens.Add(current);
            }
        }

        if (!Regex.IsMatch(input.Replace(" ", ""), @"^[-+*/().\d]+$"))
            throw new ArgumentException("Wrong input. Some characters are not valid.");


        Console.WriteLine(string.Join(",", tokens));
        return tokens;
    }

    /// <summary>
    /// Determines if a token is a mathematical operator.
    /// </summary>
    /// <param name="token">The token to check.</param>
    /// <returns>True if the token is an operator (+, -, *, /), false otherwise.</returns>
    private static bool IsOperator(string token)
    {
        return token == "+" || token == "-" || token == "*" || token == "/";
    }

}