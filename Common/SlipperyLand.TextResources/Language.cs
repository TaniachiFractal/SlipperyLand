using System.Collections.Generic;

namespace SlipperyLand.TextResources
{
    /// <summary>
    /// Get the languages
    /// </summary>
    public static class LangDict
    {
        private static readonly Dictionary<Language, string> dict = new Dictionary<Language, string>()
        {
            {Language.en, "en"},
            {Language.ru, "ru"}
        };

        /// <summary>
        /// Try get the language string
        /// </summary>
        public static bool TryGet(Language language, out string langStr) => dict.TryGetValue(language, out langStr);
    }

    /// <summary>
    /// The list of supported languages
    /// </summary>
    public enum Language
    {
        /// <summary>
        /// Choose system language
        /// </summary>
        None = 0,
        /// <summary>
        /// English
        /// </summary>
        en,
        /// <summary>
        /// Russian
        /// </summary>
        ru
    }
}
