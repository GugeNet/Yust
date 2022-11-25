using System.Collections.Generic;
using Yust;

namespace EndIf.Yust
{
    public abstract class Instruction
    {
        public int Precedence { get; set; } = 0;

        public abstract bool Execute(Stack<object> stack, IValueFromKey<string, object> context = null);

        public void Execute(Stack<object> stack, Dictionary<string, object> context)
        {
            Execute(stack, new ValueGetter<string, object>(context));
        }

        public override string ToString()
        {
            return $"{this.GetType().Name} (p:{Precedence})";
        }
    }
}
