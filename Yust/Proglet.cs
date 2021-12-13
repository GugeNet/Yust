using System.Collections.Generic;
using System.Linq;

namespace EndIf.Yust
{
    public class Proglet<T>
    {
        private readonly List<Instruction> tokens = new();

        private static readonly Compiler compiler = new();

        public Proglet(string expression)
        {
            tokens = compiler.Parse(expression);

            Compiler.Reorder(tokens);

            Compiler.RemoveParentheses(tokens);
        }

        public T Eval(IDictionary<string,object> context = null)
        {
            var stack = new Stack<object>();

            foreach (var token in tokens)
                token.Execute(stack, context);
            
            return (T)stack.Pop();
        }

        public IEnumerable<string> VariablesUsed()
        {
            return from instr in tokens.OfType<Variable>() select instr.VariableName;
        }
    }
}
