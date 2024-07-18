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
   var numArray = SplitNumbers(numbers);
  ValidateNumbers(numArray);

   return SumNumbers(numArray);
  }


  private List<int> SplitNumbers(string numbers)
    {
        var splitNumbers = numbers.Split(',');
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
            sum += num;
        }
        return sum;
  }
  
}
