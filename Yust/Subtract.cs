using System.Collections.Generic;

namespace EndIf.Yust
{
    [Description(token: "-", precedence: 6)]
    internal class Subtract : Instruction
    {
        public override bool Execute(Stack<object> stack)
        {
            var f1 = (int)stack.Pop();
            var f2 = (int)stack.Pop();
            stack.Push(f2 - f1);
            return true;
        }
    }
}
