using System;
using System.Collections.Generic;
using System.Globalization;
using System.Text;

namespace ClippyCore.Helpers
{
    /// <summary>
    /// Helper functions for formatting strings in various scenarios.
    /// </summary>
    public static class StringFormatter
    {
        /// <summary>
        /// Formats a variety of combos of names into Display Names (what a user might see).
        /// EX: TELL_JOKE, tell_joke, tellJoke, TellJoke, TELL-JOKE, etc => Tell Joke
        /// </summary>
        /// <param name="input">Text to format.</param>
        /// <returns>Formatted text.</returns>
        public static string FormatDisplayName(string input)
        {
            if(string.IsNullOrEmpty(input)) return input;
            string withSpaces = input.Replace('_', ' ').Replace('-', ' ');
            StringBuilder result = new StringBuilder();

            //Handle camelCase/PascalCase
            for(int i = 0; i < withSpaces.Length; i++)
            {
                if(i > 0 && char.IsUpper(withSpaces[i])
                    && !char.IsWhiteSpace(withSpaces[i - 1])
                    && !char.IsUpper(withSpaces[i - 1]))
                {
                    result.Append(' ');
                }

                result.Append(withSpaces[i]);

            }

            return ToTitleCase(result.ToString());
        }

        /// <summary>
        /// Capitalized first letter of each word.
        /// </summary>
        /// <param name="input">Text to capitalize.</param>
        /// <returns>Capitalized text.</returns>
        public static string ToTitleCase(string input)
        {
            if (string.IsNullOrEmpty(input))
                return input;

            TextInfo textInfo = CultureInfo.CurrentCulture.TextInfo;
            return textInfo.ToTitleCase(input.ToLower());
        }
    }
}
