// This code can be copied and pasted directly into the Kata

using static Preloaded.Elements;
using System.Globalization;
using System;                           // Required in Kata
using System.Linq;                      // Required in Kata
using System.Collections.Generic;       // Required in Kata

namespace Kata
{
    public class ElementalWords
    {
        public static string[][] ElementalForms(string word)
        {
            var elements = GetElements(word);

            var elementalWords = elements
                .Select(w => w
                    .Select(element => $"{ELEMENTS[element]} ({element})")
                    .ToArray())
                .ToArray()
                ?? Array.Empty<string[]>();

            return elementalWords;
        }

        private static IEnumerable<IEnumerable<string>> GetElements(string word)
        {
            word ??= string.Empty;
            var elements = ELEMENTS.Keys;

            var candidates = elements
                .Where(element => word.StartsWith(element, ignoreCase: true, new CultureInfo("es-ES")));

            var results = new List<IEnumerable<string>>();

            foreach (var candidate in candidates)
            {
                var nextCandidates = GetElements(word.Substring(candidate.Length));

                if (candidate.ToLower() == word.ToLower())
                {
                    results.Add(new[] { candidate });
                    continue;
                }

                foreach (var nextCandidate in nextCandidates)
                {
                    var result = (new[] { candidate }).Concat(nextCandidate);
                    results.Add(result);
                }
            }

            return results;
        }
    }
}
