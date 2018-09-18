# TechExercise-1

Word frequency counter.

## Projects

#### TechExercise.Client
.NET Core 2.0 console application.

#### TechExercise.Domain
.NET Standard 2.0 library with a word frequency counter class - **WordOccurrenceCounter**.

#### TechExercise.Domain.Tests
.NET Core 2.0 unit tests library (XUnit).

## Example

Code example:

```
var sentence = "This is a statement, and so is this";
var counter = new WordOccurrenceCounter();
var occurrences = counter.Compute(sentence);

foreach (var (word, count) in occurrences)
{
    Console.WriteLine($"{word} - {count}");
}
```

Output:

```
this - 2
is - 2
a - 1
statement - 1
and - 1
so - 1
```
