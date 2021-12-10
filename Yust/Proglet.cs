using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Yust
{
    public class Proglet<T>
    {
        private List<Instruction> tokens = new List<Instruction>();

        private static Compiler compiler = new Compiler();

        public Proglet(string expression)
        {
            tokens = compiler.Parse(expression);

            Compiler.Reorder(tokens);

            Compiler.RemoveParentheses(tokens);
        }

        public T Eval()
        {
            var stack = new Stack<object>();

            foreach (var token in tokens)
                token.Execute(stack);
            
            return (T)stack.Pop();
        }
    }
}
