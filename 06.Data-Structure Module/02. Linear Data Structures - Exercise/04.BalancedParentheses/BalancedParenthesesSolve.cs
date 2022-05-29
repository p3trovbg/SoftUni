namespace Problem04.BalancedParentheses
{
    using System;
    using System.Collections.Generic;

    public class BalancedParenthesesSolve : ISolvable
    { 
        public bool AreBalanced(string parentheses)
        {
        //{[()]} - This is a balanced parenthesis.
        //{[(])} -This is not a balanced parenthesis.
        var stack = new Stack<char>();
            for (int i = 0; i < parentheses.Length; i++)
            {
                var currentBracket = parentheses[i];
                if (stack.Count == 0 || currentBracket == '{' || currentBracket == '[' || currentBracket == '(')
                {
                    stack.Push(currentBracket);
                    continue;
                }

                if (currentBracket == ')' && stack.Peek() == '(')
                {
                    stack.Pop();
                } else if (currentBracket == ']' && stack.Peek() == '[')
                {
                    stack.Pop();
                } else if (currentBracket == '}' && stack.Peek() == '{')
                {
                    stack.Pop();
                }
                else
                {
                    return false;
                }
            }
            if(stack.Count != 0)
            {
                return false;
            }
            return true;
        }
    }
}
