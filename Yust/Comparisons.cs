using System;
using System.Collections.Generic;
using Yust;

namespace EndIf.Yust
{
    [Description(token: "=", precedence: 10)]
    internal class Equal : Instruction
    {
        public override bool Execute(Stack<object> stack, IValueFromKey<string, object> context)
        {
            var v1 = (IComparable)stack.Pop();
            var v2 = (IComparable)stack.Pop();
            stack.Push(v1.CompareTo(v2) == 0);
            return true;
        }
    }

    [Description(token: "<>", precedence: 10)]
    internal class NotEqual : Instruction
    {
        public override bool Execute(Stack<object> stack, IValueFromKey<string, object> context)
        {
            var v1 = (IComparable)stack.Pop();
            var v2 = (IComparable)stack.Pop();
            stack.Push(v1.CompareTo(v2) != 0);
            return true;
        }
    }

    [Description(token: "<", precedence: 9)]
    internal class LessThan : Instruction
    {
        public override bool Execute(Stack<object> stack, IValueFromKey<string, object> context)
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
        public override bool Execute(Stack<object> stack, IValueFromKey<string, object> context)
        {
            var v1 = (IComparable)stack.Pop();
            var v2 = (IComparable)stack.Pop();
            stack.Push(v1.CompareTo(v2) == -1);
            return true;
        }
    }

    [Description(token: ">=", precedence: 9)]
    internal class MoreThanOrEqual : Instruction
    {
        public override bool Execute(Stack<object> stack, IValueFromKey<string, object> context)
        {
            var v1 = (IComparable)stack.Pop();
            var v2 = (IComparable)stack.Pop();
            stack.Push(v1.CompareTo(v2) == -1 || v1.CompareTo(v2) == 0);
            return true;
        }
    }

    [Description(token: "<=", precedence: 9)]
    internal class LessThanOrEqual : Instruction
    {
        public override bool Execute(Stack<object> stack, IValueFromKey<string, object> context)
        {
            var v1 = (IComparable)stack.Pop();
            var v2 = (IComparable)stack.Pop();
            stack.Push(v1.CompareTo(v2) == 1 || v1.CompareTo(v2) == 0);
            return true;
        }
    }
}
