using System.Collections.Generic;
using Yust;

namespace EndIf.Yust
{
    [Description(start: "abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ", precedence: 3)]
    internal class Variable : Instruction
    {
        public string VariableName { get; private set; }

        public Variable(string token)
        {
            VariableName = token;
        }

        public override bool Execute(Stack<object> stack, IValueFromKey<string,object> context)
        {
            stack.Push(context[VariableName]);
            return true;
        }
    }
}
