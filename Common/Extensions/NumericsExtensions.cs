using System;

namespace Common.Extensions
{
    /// <summary>
    /// Various extensions for numeric types
    /// </summary>
    public static class NumericsExtensions
    {
        /// <summary>
        /// Round a numeric to an <see cref="int"/>
        /// </summary>
        public static int Round(this double val) => (int)Math.Round(val);

        /// <inheritdoc cref="Round(double)"/>
        /// <remarks>float</remarks>
        public static int Round(this float val) => (int)Math.Round(val);
    }
}
