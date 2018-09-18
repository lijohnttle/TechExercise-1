using System;
using TechExercise.Domain;

namespace TechExercise.Client
{
    internal class Program
    {
        private static void Main()
        {
            var wordOccurrenceCounter = new WordOccurrenceCounter();


            Console.CancelKeyPress += (s, e) =>
            {
                if (e.SpecialKey == ConsoleSpecialKey.ControlC)
                {
                    e.Cancel = true;

                    Environment.Exit(0);
                }
            };


            while (true)
            {
                Console.WriteLine("Please, input a sentence (Ctrl+C to exit):");

                var sentence = Console.ReadLine();

                var occurrences = wordOccurrenceCounter.Compute(sentence);
                if (occurrences.Length == 0)
                {
                    Console.WriteLine("There are no occurrences");
                }
                else
                {
                    foreach (var (word, count) in occurrences)
                    {
                        Console.WriteLine($"{word} - {count}");
                    }
                }

                Console.WriteLine();
                Console.WriteLine();
            }
        }
    }
}
