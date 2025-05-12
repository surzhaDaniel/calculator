using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CalculatorApp.Core
{
    internal class PostfixEvaluator
    {
        public static double Evaluate(List<string> postfixTokens)
        {
            Stack<double> stack = new Stack<double>();

            foreach (string token in postfixTokens)
            {
                if (double.TryParse(token, out double number))
                    stack.Push(number);
                else
                {
                    if (stack.Count < 2)
                    {
                        throw new InvalidOperationException("Invalid postfix expression (not enough operands)");
                    }

                    double rightNumber = stack.Pop();
                    double leftNumber = stack.Pop();

                    switch (token)
                    {
                        case "+":
                            stack.Push(leftNumber + rightNumber);
                            break;
                        case "-":
                            stack.Push(leftNumber - rightNumber);
                            break;
                        case "*":
                            stack.Push(leftNumber * rightNumber);
                            break;
                        case "/":
                            if (rightNumber == 0)
                                throw new DivideByZeroException("Division by zero");
                            stack.Push(leftNumber / rightNumber);
                            break;
                        default:
                            throw new ArgumentException($"Unknown operator: {token}");
                    }
                }
            }
            if (stack.Count != 1)
            {
                throw new InvalidOperationException("Invalid postfix expression (too many operands or operators)");
            }

            return stack.Pop();
        }
    }
}
