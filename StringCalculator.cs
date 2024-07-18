using System;
using System.Collections.Generic;
using System.Linq;

public class StringCalculator
{
  public int Add(string numbers)
  {
    if (string.IsNullOrEmpty(numbers))
    {
       return 0;
    }
       var delimiters = new List<string> { ",", "\n" };
        numbers = ExtractCustomDelimiter(numbers, delimiters);

        var numArray = SplitNumbers(numbers, delimiters.ToArray());
        ValidateNumbers(numArray);

   return SumNumbers(numArray);
  }

 private string ExtractCustomDelimiter(string numbers, List<string> delimiters)
    {
        if (numbers.StartsWith("//"))
        {
            var endOfDelimiterIndex = numbers.IndexOf('\n');
            var delimiterSection = numbers.Substring(2, endOfDelimiterIndex - 2);

            AddCustomDelimiters(delimiterSection, delimiters);
            numbers = numbers.Substring(endOfDelimiterIndex + 1);
        }

        return numbers;
    }

    private void AddCustomDelimiters(string delimiterSection, List<string> delimiters)
    {
        if (delimiterSection.StartsWith("[") && delimiterSection.EndsWith("]"))
        {
            delimiters.Add(delimiterSection.Substring(1, delimiterSection.Length - 2));
        }
        else
        {
            delimiters.Add(delimiterSection);
        }
    }
    private List<int> SplitNumbers(string numbers, string[] delimiters)
    {
        var splitNumbers = numbers.Split(delimiters, StringSplitOptions.None);
        return splitNumbers.Select(int.Parse).ToList();
    }

    private void ValidateNumbers(List<int> numbers)
    {
        var negatives = numbers.Where(num => num < 0).ToList();
        if (negatives.Any())
        {
            throw new ArgumentException($"negatives not allowed: {string.Join(", ", negatives)}");
        }
    }
  private int SumNumbers(List<int> numbers)
  {
        var sum = 0;
        foreach (var num in numbers)
        {
            if (num <= 1000)
            {
                sum += num;
            }
        }
        return sum;
  }
  
}
