using System.Collections.Generic;

namespace EndIf.Yust
{
    [Description(token: "+", precedence: 6)]
    internal class Add : Instruction
    {
        public override bool Execute(Stack<object> stack, IDictionary<string, object> context)
        {
            var f1 = (int)stack.Pop();
            var f2 = (int)stack.Pop();
            stack.Push(f1 + f2);
            return true;
        }
    }
}
