using System;
using System.Reflection;

namespace EndIf.Yust
{
    internal class TokenType
    {
        public DescriptionAttribute Description { get; set; }

        public Type Type { get; set; }

        public TokenType(Type type)
        {
            this.Type = type;

            this.Description = type.GetCustomAttribute<DescriptionAttribute>();
        }

        internal bool BuildFrom(StringNumerator snum, out Instruction token)
        {
            token = null;

            if(snum.ContinuesWith(Description.Token))
            {
                var constructor = Type.GetConstructor(Type.EmptyTypes);
                token = constructor.Invoke(new object[] {}) as Instruction;
                token.Precedence = Description.Precedence;
                snum.Move(Description.Token.Length);
                return true;
            }

            if (Description.Start.Contains(snum.It))
            {
                var t = "";
                while (!snum.Finished && Description.Start.Contains(snum.It))
                {
                    t += snum.It;
                    snum.Move();
                }
                var constructor = Type.GetConstructor(new[] { typeof(string) });
                token = constructor.Invoke(new object[] { t }) as Instruction;
                token.Precedence = Description.Precedence;
                return true;
            }

            return false;
        }
    }
}
