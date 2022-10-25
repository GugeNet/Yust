using System.Collections.Generic;
using System.Linq;
using Yust;

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

        public T Eval()
        {
            var stack = new Stack<object>();

            foreach (var token in tokens)
                token.Execute(stack);

            return (T)stack.Pop();
        }

        public T Eval(IValueFromKey<string, object> context)
        {
            var stack = new Stack<object>();

            foreach (var token in tokens)
                token.Execute(stack, context);

            return (T)stack.Pop();
        }

        public T Eval(IDictionary<string,object> context)
        {
            return Eval(new ValueGetter<string,object>(context));
        }

        public IEnumerable<string> VariablesUsed()
        {
            return from instr in tokens.OfType<Variable>() select instr.VariableName;
        }
    }
}
