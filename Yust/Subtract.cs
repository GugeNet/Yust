using System.Collections.Generic;
using Yust;

namespace EndIf.Yust
{
    [Description(token: "-", precedence: 6)]
    internal class Subtract : Instruction
    {
        public override bool Execute(Stack<object> stack, IValueFromKey<string, object> context)
        {
            var f1 = (int)stack.Pop();
            var f2 = (int)stack.Pop();
            stack.Push(f2 - f1);
            return true;
        }
    }
}
