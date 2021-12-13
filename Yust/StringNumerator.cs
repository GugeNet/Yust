using System;

namespace EndIf.Yust
{
    internal class StringNumerator
    {

        public string String { get; private set; }

        private int i = 0;

        public StringNumerator(string s)
        {
            String = s;
        }

        public char It => String[i];

        public char? Next => String[i + 1];
            
        public bool Finished => i >= String.Length;

        internal void Move()
        {
            i++;
        }
    }
}
