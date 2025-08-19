namespace SlipperyLand.LevelMapper.Serialization.Helpers
{
    /// <summary>
    /// Convert to base 36
    /// </summary>
    internal static class Base36Converter
    {
        private const int Base = 36;
        private const string BaseChars = "0123456789ABCDEFGHIJKLMNOPQRSTUVWXYZ";

        /// <summary>
        /// <see cref="int"/> to base 36 <see cref="string"/>
        /// </summary>
        public static string ToBase36(this int val)
        {
            if (val == 0)
            {
                return 0.ToString();
            }
            var output = string.Empty;
            while (val > 0)
            {
                var remainder = val % Base;
                output += BaseChars[remainder];
                val /= 36;
            }
            return output;
        }

        /// <summary>
        /// Try convert base 36 <see cref="string"/> to <see cref="int"/>
        /// </summary>
        public static bool TryFromBase36(this string BaseStr, out int output)
        {
            output = 0;
            foreach (var c in BaseStr.ToUpper())
            {
                var val = BaseChars.IndexOf(c);
                if (val < 0)
                {
                    return false;
                }
                output *= 36;
                output += val;
            }
            return true;
        }
    }
}
