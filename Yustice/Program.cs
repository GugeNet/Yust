using System;
using System.Collections.Generic;

namespace EndIf.Yust.REPL
{
    internal class Program
    {
        static void Main()
        {
            var expr = "Age > 22";

            var compiler = new Compiler();

            var tokens = compiler.Parse(expr);

            foreach (var token2 in tokens)
                Console.WriteLine(token2);

            Compiler.Reorder(tokens);

            Console.WriteLine();

            foreach (var token2 in tokens)
                Console.WriteLine(token2);

            Compiler.RemoveParentheses(tokens);

            Console.WriteLine();

            foreach(var token2 in tokens)  
                Console.WriteLine(token2);

            var stack = new Stack<object>();

            var context = new Dictionary<string, object>
            {
                { "Age", 25 }
            };

            foreach (var token in tokens)
                token.Execute(stack, context);

            Console.WriteLine();

            Console.WriteLine(stack.Pop());
        }
    }

    
}
