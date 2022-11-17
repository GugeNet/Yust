namespace Yust
{
    public interface IValueFromKey<TKey, TValue>
    {
        //
        // Summary:
        //     Gets the element with the specified key.
        //
        // Parameters:
        //   key:
        //     The key of the element to get.
        //
        // Returns:
        //     The element with the specified key.
        //
        // Exceptions:
        //   T:System.ArgumentNullException:
        //     key is null.
        //
        //   T:System.Collections.Generic.KeyNotFoundException:
        //     The property is retrieved and key is not found.
        //
        //   T:System.NotSupportedException:
        //     The property is set and the System.Collections.Generic.IDictionary`2 is read-only.
        TValue this[TKey key] { get; }

        bool ContainsKey(TKey key);
    }
}
