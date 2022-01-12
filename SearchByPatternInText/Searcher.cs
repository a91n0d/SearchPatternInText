using System;
using System.Collections.Generic;

namespace SearchByPatternInText
{
    public static class Searcher
    {
        /// <summary>
        /// Searches the pattern string inside the text and collects information about all hit positions in the order they appear.
        /// </summary>
        /// <param name="text">Source text.</param>
        /// <param name="pattern">Source pattern text.</param>
        /// <param name="overlap">Flag to overlap:
        /// if overlap flag is true collect every position overlapping included,
        /// if false no overlapping is allowed (next search behind).</param>
        /// <returns>List of positions of occurrence of the pattern string in the text, if any and empty otherwise.</returns>
        /// <exception cref="ArgumentException">Thrown if text or pattern is null.</exception>
        public static int[] SearchPatternString(this string text, string pattern, bool overlap)
        {
            if (text is null)
            {
                throw new ArgumentException("Source string cannot be null.", nameof(text));
            }

            if (pattern is null)
            {
                throw new ArgumentException("Pattern string cannot be null.", nameof(pattern));
            }

            int startIndex = 0;
            int index;
            List<int> patternString = new List<int>();
            while (true)
            {
                index = text.IndexOf(pattern, startIndex, StringComparison.OrdinalIgnoreCase);
                if (index == -1)
                {
                    break;
                }

                startIndex = overlap ? index + 1 : index + pattern.Length;
                patternString.Add(index + 1);
            }

            return patternString.ToArray();
        }
    }
}
