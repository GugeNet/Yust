using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Yust
{
    public interface IValueFromKey<TKey,TValue>
    {
        //
        // Summary:
        //     Gets or sets the element with the specified key.
        //
        // Parameters:
        //   key:
        //     The key of the element to get or set.
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
        TValue this[TKey key] { get; set; }
    }
}
