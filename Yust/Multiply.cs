﻿using System.Collections.Generic;
using Yust;

namespace EndIf.Yust
{
    [Description(token: "*", precedence: 5)]
    internal class Multiply : Instruction
    {
        public override bool Execute(Stack<object> stack, IValueFromKey<string, object> context)
        {
            var f1 = (int)stack.Pop();
            var f2 = (int)stack.Pop();
            stack.Push(f1 * f2);
            return true;
        }
    }
}
