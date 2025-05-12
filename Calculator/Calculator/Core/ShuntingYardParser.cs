using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace CalculatorApp.Core;
internal class ShuntingYardParser
{
    private static readonly Dictionary<string, int> Precedence = new()
    {
        { "+", 1 },
        { "-", 1 },
        { "*", 2 },
        { "/", 2 }
    };
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

