using System.Collections.Generic;

namespace EndIf.Yust
{
    [Description(token: "(", precedence: 0)]
    internal class ParenthesesStart : Instruction
    {
        public override bool Execute(Stack<object> stack, IDictionary<string, object> context)
        {
            return true;
        }
    }

    [Description(token: ")", precedence: 99)]
    internal class ParenthesesEnd : Instruction
    {
        public override bool Execute(Stack<object> stack, IDictionary<string, object> context)
        {
            return true;
        }
    }
}
