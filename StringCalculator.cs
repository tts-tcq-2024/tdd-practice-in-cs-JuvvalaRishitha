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
    var delimiters = GetDelimiters(ref numbers);
    var numArray = SplitNumbers(numbers, delimiters);
    ValidateNumbers(numArray);

   return SumNumbers(numArray);
  }

private string[] GetDelimiters(ref string numbers)
    {
        var delimiters = new List<string> { ",", "\n" };
        if (numbers.StartsWith("//"))
        {
            var match = Regex.Match(numbers, "//(.+)\n(.*)");
            delimiters.Add(match.Groups[1].Value);
            numbers = match.Groups[2].Value;
        }
        return delimiters.ToArray();
    }
  
  private List<int> SplitNumbers(string numbers)
    {
        var splitNumbers = Regex.Split(numbers, string.Join("|", delimiters));
        var numList = new List<int>();
        foreach (var num in splitNumbers)
        {
            numList.Add(int.Parse(num));
        }
        return numList;
    }
  
 private void ValidateNumbers(List<int> numbers)
    {
        var negatives = new List<int>();
        foreach (var num in numbers)
        {
            if (num < 0)
            {
                negatives.Add(num);
            }
        }
        if (negatives.Count > 0)
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
