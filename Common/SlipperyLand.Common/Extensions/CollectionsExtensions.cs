using System.Collections.Generic;

namespace SlipperyLand.Common.Extensions
{
    /// <summary>
    /// Array extensions
    /// </summary>
    public static class CollectionsExtensions
    {
        /// <typeparam name="T">The type that the <paramref name="input"/> <see cref="List{T}"/> consists of</typeparam>
        /// <param name="input">The <see cref="List{T}"/></param>
        /// <param name="index">Index of the target item</param>
        /// <param name="def">The default value of the <typeparamref name="T"/></param>
        /// <returns>The item at the <paramref name="index"/>; the first item of the list if the index is incorrect; or <paramref name="def"/> if the list is empty</returns>
        public static T ItemOrFirst<T>(
            this IList<T> input, int index, T def)
            where T : class
            => index.InRange(input.Count) ?
            input[index] :
            input.Count > 0 ? input[0] : def;

        /// <typeparam name="T">The type that the <paramref name="input"/> array consists of</typeparam>
        /// <param name="input">The target array</param>
        /// <param name="row">The target row</param>
        /// <param name="col">The target column</param>
        /// <param name="rowCou">Row count</param>
        /// <param name="colCou">Column count</param>
        /// <param name="def">The default value</param>
        /// <returns>The item at the <paramref name="row"/> and <paramref name="col"/>; or <paramref name="def"/> if the index is incorrect</returns>
        public static T ItemOrDef<T>(
            this T[,] input, int row, int col, int rowCou, int colCou, T def)
            where T : class
            => row.InRange(rowCou) && col.InRange(colCou) ? input[row, col] : def;

        private static bool InRange(this int index, int max)
            => index >= 0 && index < max;
    }
}
