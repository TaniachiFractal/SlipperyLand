using System.Collections.Generic;

namespace Common
{
#nullable enable
    /// <summary>
    /// <see cref="List{T}"/> extensions
    /// </summary>
    public static class ListExtensions
    {
        /// <summary>
        /// Return the item at the index, the first item of the list, or null if the list is empty
        /// </summary>
        public static T? ItemOrFirst<T>(
            this IList<T?> input, int index)
            where T : class
            => index >= 0 && index < input.Count ?
            input[index] :
            input.Count > 0 ? input[0] : default;
    }
}
