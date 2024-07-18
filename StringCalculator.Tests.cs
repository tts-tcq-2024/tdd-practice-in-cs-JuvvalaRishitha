using System;
using System.Collections.Generic;
using Xunit;


public class StringCalculatorAddTests
{
    [Fact]
    public void ExpectZeroForEmptyInput()
    {
        int expectedResult = 0;
        string input = "";
        StringCalculator objUnderTest = new StringCalculator();
        int result = objUnderTest.Add(input);

       Assert.Equal(expectedResult, result);
    }

  [Fact]
    public void ExpectZeroForSingleZero()
    {
        int expectedResult = 0;
        string input = "0";
        StringCalculator objUnderTest = new StringCalculator();
        int result = objUnderTest.Add(input);

        Assert.Equal(expectedResult, result);
    }

  [Fact]
    public void ExpectSumForTwoNumbers()
    {
        int expectedResult = 3;
        string input = "1,2";
        StringCalculator objUnderTest = new StringCalculator();
        int result = objUnderTest.Add(input);

       Assert.Equal(expectedResult, result);
    }

    [Fact]
    public void ExpectExceptionForNegativeNumbers()
    {
        var ex = Assert.Throws<ArgumentException>(() =>
        {
            string input = "-1,2";
            StringCalculator objUnderTest = new StringCalculator();
            objUnderTest.Add(input);
        });
        Assert.Equal("negatives not allowed: -1", ex.Message);
    }

  [Fact]
    public void ExpectSumWithNewlineDelimiter()
    {
        int expectedResult = 6;
        string input = "1\n2,3";
        StringCalculator objUnderTest = new StringCalculator();
        int result = objUnderTest.Add(input);

       Assert.Equal(expectedResult, result);
    }

  [Fact]
    public void IgnoreNumbersGreaterThan1000()
    {
        int expectedResult = 1;
        string input = "1,1001";
        StringCalculator objUnderTest = new StringCalculator();
        int result = objUnderTest.Add(input);

       Assert.Equal(expectedResult, result);
    }

    [Fact]
    public void ExpectSumWithCustomDelimiter()
    {
        int expectedResult = 3;
        string input = "//;\n1;2";
        StringCalculator objUnderTest = new StringCalculator();
        int result = objUnderTest.Add(input);

       Assert.Equal(expectedResult, result);
    }
 
}
