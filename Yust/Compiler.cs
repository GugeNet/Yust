using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;

namespace EndIf.Yust
{
    public class Compiler
    {
        private readonly IEnumerable<TokenType> tokenTypes;

        public Compiler()
        {
            tokenTypes = (
                from tokenType
                in Assembly
                    .GetExecutingAssembly()
                    .GetTypes()
                    .Where(c => c.IsSubclassOf(typeof(Instruction)))
                select new TokenType(tokenType)).ToList();
        }

        public List<Instruction> Parse(string expression)
        {
            var tokens = new List<Instruction>();

            var snum = new StringNumerator(expression);

            while (!snum.Finished)
            {
                if (snum.It == ' ')
                    snum.Move();
                var c = tokens.Count;
                foreach (var t in tokenTypes.OrderBy(tt => tt.Description.Precedence))
                {
                    if (t.BuildFrom(snum, out var token))
                    {
                        tokens.Add(token);
                        break;
                    }
                }
                if (c == tokens.Count)
                    throw new Exception($"Unknown symbol {snum.It}");
            }

            return tokens;
        }

        public static void Reorder(List<Instruction> tokens)
        {
            var i = 0;

            while (tokens[i] is ParenthesesStart && i < tokens.Count)
                i++;

            while (i < tokens.Count - 1)
            {
                var currentToken = tokens[i];
                var nextToken = tokens[i + 1];

                if (currentToken.Precedence > nextToken.Precedence)
                {
                    var passedParentheses = (nextToken is ParenthesesStart) ? 1 : 0;
                    var j = i + 2;
                    while (j < tokens.Count)
                    {
                        var afterNextToken = tokens[j];

                        if (afterNextToken is ParenthesesStart)
                        {
                            passedParentheses++;
                        }
                        if (afterNextToken is ParenthesesEnd)
                        {
                            passedParentheses--;
                        }

                        if (passedParentheses > 0 || currentToken.Precedence > afterNextToken.Precedence)
                        {
                            nextToken = afterNextToken;
                            j++;
                        }
                        else break;
                    }

                    tokens.Remove(currentToken);
                    tokens.Insert(tokens.IndexOf(nextToken) + 1, currentToken);
                }
                else
                    i++;
            }
        }

        public static void RemoveParentheses(List<Instruction> tokens)
        {
            for (int i = 0; i < tokens.Count; i++)
            {
                if (tokens[i] is ParenthesesStart)
                    tokens.RemoveAt(i--);
                else if (tokens[i] is ParenthesesEnd)
                    tokens.RemoveAt(i--);
            }
        }
    }
}
