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

    private static bool IsOperator(string token)
    {
        return token == "+" || token == "-" || token == "*" || token == "/";
    }

}