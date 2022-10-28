using EndIf.Yust;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Yust
{
    [Description(token: "/", precedence: 5)]
    internal class Divide : Instruction
    {
        public override bool Execute(Stack<object> stack, IValueFromKey<string, object> context = null)
        {
            var f1 = (int)stack.Pop();
            var f2 = (int)stack.Pop();
            stack.Push(f2 / f1);
            return true;
        }
    }
}
