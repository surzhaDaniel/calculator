using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CalculatorApp.Core
{
    /// <summary>
    /// Evaluates mathematical expressions in postfix notation (Reverse Polish Notation).
    /// </summary>
    internal class PostfixEvaluator
    {
        /// <summary>
        /// Evaluates a list of tokens in postfix notation and returns the result.
        /// </summary>
        /// <param name="postfixTokens">The list of tokens in postfix notation.</param>
        /// <returns>The result of the evaluation as a double.</returns>
        /// <exception cref="InvalidOperationException">
        /// Thrown when the postfix expression is invalid (not enough operands or too many operands/operators).
        /// </exception>
        /// <exception cref="DivideByZeroException">
        /// Thrown when attempting to divide by zero.
        /// </exception>
        /// <exception cref="ArgumentException">
        /// Thrown when encountering an unknown operator.
        /// </exception>
        /// <remarks>
        /// The evaluator processes tokens in the following way:
        /// 1. Numbers are pushed onto the stack
        /// 2. Operators pop two numbers from the stack, perform the operation, and push the result
        /// 3. The final result should be the only number left on the stack
        /// </remarks>
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
