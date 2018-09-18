using System.Collections.Generic;
using Xunit;

namespace TechExercise.Domain.Tests
{
    public class WordOccurrenceCounterTest
    {
        [Theory]
        [MemberData(nameof(GetTestData))]
        public void Compute(string sentence, (string, int)[] expectedOccurrences)
        {
            // Arrange
            var wordOccurrenceCounter = new WordOccurrenceCounter();

            // Act
            var occurrences = wordOccurrenceCounter.Compute(sentence);

            // Assert
            Assert.Equal(expectedOccurrences.Length, occurrences.Length);

            for (int i = 0; i < expectedOccurrences.Length; i++)
            {
                var (word, count) = occurrences[i];
                var (expectedWord, expectedCount) = expectedOccurrences[i];

                Assert.Equal(expectedWord, word);
                Assert.Equal(expectedCount, count);
            }
        }


        public static IEnumerable<object[]> GetTestData()
        {
            var data = new List<object[]>
            {
                new object[]
                {
                    "This is a statement, and so is this",
                    new []
                    {
                        ("this", 2),
                        ("is", 2),
                        ("a", 1),
                        ("statement", 1),
                        ("and", 1),
                        ("so", 1)
                    }
                },
                new object[]
                {
                    null,
                    new (string, int)[0]
                },
                new object[]
                {
                    "",
                    new (string, int)[0]
                },
                new object[]
                {
                    "      @#@#  ((",
                    new (string, int)[0]
                },
                new object[]
                {
                    "_A a a, A a \na!!!34234$#",
                    new []
                    {
                        ("a", 6)
                    }
                }
            };

            return data;
        }
    }
}
