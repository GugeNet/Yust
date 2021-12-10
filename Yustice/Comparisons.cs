﻿using System;
using System.Collections.Generic;

namespace Yust
{
    [Description(token: "=", precedence: 10)]
    internal class Equal : Instruction
    {
        public override bool Execute(Stack<object> stack)
        {
            var v1 = (IComparable)stack.Pop();
            var v2 = (IComparable)stack.Pop();
            stack.Push(v1.CompareTo(v2) == 0);
            return true;
        }
    }

    [Description(token: "<", precedence: 9)]
    internal class LessThan : Instruction
    {
        public override bool Execute(Stack<object> stack)
        {
            var v1 = (IComparable)stack.Pop();
            var v2 = (IComparable)stack.Pop();
            stack.Push(v1.CompareTo(v2) == 1);
            return true;
        }
    }

    [Description(token: ">", precedence: 9)]
    internal class MoreThan : Instruction
    {
        public override bool Execute(Stack<object> stack)
        {
            var v1 = (IComparable)stack.Pop();
            var v2 = (IComparable)stack.Pop();
            stack.Push(v1.CompareTo(v2) == -1);
            return true;
        }
    }
}