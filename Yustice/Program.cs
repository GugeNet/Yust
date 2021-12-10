using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;

namespace Yust
{
    internal class Program
    {
        const string digits = ".0123456789";

        static void Main(string[] args)
        {
            var expr = "7-(5+1)";

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

            foreach (var token in tokens)
                token.Execute(stack);

            Console.WriteLine();

            Console.WriteLine(stack.Pop());
        }
    }

    
}
