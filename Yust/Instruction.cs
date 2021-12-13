using System.Collections.Generic;

namespace EndIf.Yust
{
    public abstract class Instruction
    {
        public int Precedence { get; set; } = 0;

        public abstract bool Execute(Stack<object> stack);

        public override string ToString()
        {
            return $"{this.GetType().Name} (p:{Precedence})";
        }
    }
}
