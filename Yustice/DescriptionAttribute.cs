using System;

namespace Yust
{
    internal class DescriptionAttribute : Attribute
    {
        public string Start { get; private set; }

        /// <summary>
        /// Operator precedence as defined in
        /// https://en.cppreference.com/w/cpp/language/operator_precedence
        /// </summary>
        public int Precedence { get; private set; }

        public string Token { get; private set; }

        public DescriptionAttribute(int precedence, string start = "", string token = "")
        {
            Start = start;

            Token = token;

            Precedence = precedence;
        }
    }
}
