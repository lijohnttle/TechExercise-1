using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TechExercise.Domain
{
    public class WordOccurrenceCounter
    {
        /// <summary>
        /// Computes word occurrences.
        /// </summary>
        /// <param name="sentence">Target sentence.</param>
        /// <returns>Pairs of words and occurrences.</returns>
        public (string Word, int Count)[] Compute(string sentence)
        {
            if (string.IsNullOrWhiteSpace(sentence))
            {
                return new (string Word, int Count)[0];
            }


            var wordBuilder = new StringBuilder();
            var wordOccurences = new Dictionary<string, int>();
            var orderedWords = new List<string>();

            for (int charIndex = 0; charIndex < sentence.Length; charIndex++)
            {
                var character = sentence[charIndex];

                // only letters are allowed (digits?)
                if (char.IsLetter(character))
                {
                    wordBuilder.Append(char.ToLower(character));
                }
                else
                {
                    BreakWord();
                }
            }

            BreakWord();

            // return word occurrences keeping words order
            return orderedWords.Select(t => (t, wordOccurences[t])).ToArray();


            void BreakWord()
            {
                if (wordBuilder.Length == 0)
                {
                    return;
                }

                var word = wordBuilder.ToString();

                if (wordOccurences.TryGetValue(word, out var count))
                {
                    wordOccurences[word] = count + 1;
                }
                else
                {
                    wordOccurences[word] = 1;
                    orderedWords.Add(word);
                }

                wordBuilder.Clear();
            }
        }
    }
}
