using System.Collections.Generic;

namespace Yust
{
    internal class ValueGetter<TKey, TValue> : IValueFromKey<TKey, TValue>
    {
        private readonly IDictionary<TKey, TValue> dictionary;

        public ValueGetter(IDictionary<TKey,TValue> dictionary)
        {
            this.dictionary = dictionary;
        }

        public TValue this[TKey key] { get => dictionary[key]; set => dictionary[key] = value; }
    }
}
