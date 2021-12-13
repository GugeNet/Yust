using System.Collections.Generic;

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

        public override bool Execute(Stack<object> stack, IDictionary<string,object> context)
        {
            stack.Push(context[VariableName]);
            return true;
        }
    }
}
