using System;

namespace SlipperyLand.Common
{
    /// <summary>
    /// Holder for a Random.Shared
    /// </summary>
    public static class RandomSh
    {
        /// <summary>
        /// Shared instance of a <see cref="Random"/>
        /// </summary>
        public readonly static Random Shared = new();
    }
}
