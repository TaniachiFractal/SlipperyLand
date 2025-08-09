using System.Collections.Generic;

namespace SlipperyLand.Common.Extensions
{
#nullable enable
    /// <summary>
    /// <see cref="List{T}"/> extensions
    /// </summary>
    public static class ListExtensions
    {
        /// <typeparam name="T">The type that the <paramref name="input"/> <see cref="List{T}"/> is made of</typeparam>
        /// <param name="input">The <see cref="List{T}"/></param>
        /// <param name="index">Index of the target item</param>
        /// <param name="def">The default value of the <typeparamref name="T"/></param>
        /// <returns>The item at the index, the first item of the list, or null if the list is empty</returns>
        public static T ItemOrFirst<T>(
            this IList<T> input, int index, T def)
            where T : class
            => index >= 0 && index < input.Count ?
            input[index] :
            input.Count > 0 ? input[0] : def;
    }
}
