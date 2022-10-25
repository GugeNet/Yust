using System.Collections.Generic;
using Yust;

namespace EndIf.Yust
{
    [Description(start: "0123456789", precedence: 3)]
    internal class Integer : Instruction
    {
        public int Value { get; private set; }

        public Integer(string token)
        {
            Value = int.Parse(token);
        }

        public override bool Execute(Stack<object> stack, IValueFromKey<string, object> context)
        {
            stack.Push(Value);
            return true;
        }

        public override string ToString()
        {
            return $"{Value} {base.ToString()}";
        }
    }
}
