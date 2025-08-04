using System;

namespace Common
{
    /// <summary>
    /// Various extensions for numeric types
    /// </summary>
    public static class NumericsExtensions
    {
        /// <summary>
        /// Round a <see cref="double"/> to an <see cref="int"/>
        /// </summary>
        public static int Round(this double val) => (int)Math.Round(val);
    }
}
