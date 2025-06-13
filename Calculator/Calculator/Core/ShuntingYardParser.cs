using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace CalculatorApp.Core;

/// <summary>
/// Implements the Shunting Yard algorithm to convert infix mathematical expressions to postfix notation.
/// </summary>
internal class ShuntingYardParser
{
    /// <summary>
    /// Defines the operator precedence for mathematical operations.
    /// Higher values indicate higher precedence.
    /// </summary>
    private static readonly Dictionary<string, int> Precedence = new()
    {
        { "+", 1 },
        { "-", 1 },
        { "*", 2 },
        { "/", 2 }
    };

    /// <summary>
    /// Converts a list of tokens from infix notation to postfix notation using the Shunting Yard algorithm.
    /// </summary>
    /// <param name="tokens">The list of tokens in infix notation.</param>
    /// <returns>A list of tokens in postfix notation (Reverse Polish Notation).</returns>
    /// <exception cref="ArgumentException">Thrown when there are mismatched parentheses in the expression.</exception>
    /// <remarks>
    /// The algorithm processes tokens in the following order:
    /// 1. Numbers are added directly to the output
    /// 2. Operators are handled according to their precedence
    /// 3. Parentheses are used to group expressions
    /// </remarks>
    public static List<string> Parse(List<string> tokens)
    {
        Stack<string> operators = new Stack<string>();
        List<string> output = new List<string>();

        foreach (string token in tokens)
        {
            if (double.TryParse(token, out _))
            {
                output.Add(token);
            }
            else if (Precedence.ContainsKey(token))
            {
                while (operators.Count > 0 && Precedence.ContainsKey(operators.Peek()) && Precedence[operators.Peek()] >= Precedence[token])
                {
                    output.Add(operators.Pop());
                }
                operators.Push(token);
            }
            else if (token == "(")
            {
                operators.Push(token);
            }
            else if (token == ")")
            {
                while (operators.Count > 0 && operators.Peek() != "(")
                {
                    output.Add(operators.Pop());
                }
                if (operators.Count > 0 && operators.Peek() == "(")
                {
                    operators.Pop();
                }
                else
                {
                    throw new ArgumentException("Mismatched parentheses");
                }
            }
        }

        while (operators.Count > 0)
        {
            if (operators.Peek() == "(")
            {
                throw new ArgumentException("Mismatched parentheses");
            }
            output.Add(operators.Pop());
        }

        return output;
    }
}

