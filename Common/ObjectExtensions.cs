using System.Reflection;

namespace Common
{
    /// <summary>
    /// Extensions for all objects
    /// </summary>
    public static class ObjectExtensions
    {
        /// <summary>
        /// Copy fields from <paramref name="source"/> to <paramref name="destination"/>
        /// </summary>
        public static void CopyTo<T>(this T source, T destination)
        {
            if (source == null || destination == null)
            {
                return;
            }

            var type = typeof(T);
            var fields = type.GetFields(BindingFlags.Public | BindingFlags.NonPublic | BindingFlags.Instance);

            foreach (var field in fields)
            {
                object value = field.GetValue(source);
                field.SetValue(destination, value);
            }
        }
    }
}
