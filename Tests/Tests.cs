using System.Text;

namespace Tests;

public class Tests
{
    [Theory]
    [InlineData(new[] { 1, 0, 0, 0, 1 }, 1, true)]
    [InlineData(new[] { 1, 0, 0, 0, 1 }, 2, false)]
    [InlineData(new[] { 0, 0, 0, 0, 0, 1 }, 1, true)]
    [InlineData(new[] { 0, 0, 1, 0, 1 }, 1, true)]
    public void CanPlaceFlowers_605(int[] flowerbed, int n, bool expectedResult)
    {
        for (int i = 0; i < flowerbed.Length; i++)
        {
            if (flowerbed[i] == 0 &&
                (i == flowerbed.Length - 1 || flowerbed[i + 1] == 0) && (i == 0 || flowerbed[i - 1] == 0))
            {
                flowerbed[i] = 1;
                n--;
            }
        }

        var testResult = n <= 0;

        Assert.Equal(testResult, expectedResult);
    }

    [Theory]
    [InlineData("hello", "holle")]
    [InlineData("leetcode", "leotcede")]
    public void ReverseVowelsOfAString_345(string s, string expectedResult)
    {
        var inputString = s.ToCharArray();
        var vowels = "aeiouAEIOU";

        var leftPointer = 0;
        var rightPointer = inputString.Length - 1;

        while (leftPointer < rightPointer)
        {
            if (vowels.Contains(inputString[leftPointer]) && vowels.Contains(inputString[rightPointer]))
            {
                (inputString[leftPointer], inputString[rightPointer]) =
                    (inputString[rightPointer], inputString[leftPointer]);
                leftPointer++;
                rightPointer--;
            }
            else if(!vowels.Contains(inputString[rightPointer]))
            {
                rightPointer--;
            }
            else
            {
                leftPointer++;
            }
        }
        var testResult = new string(inputString);
        Assert.Equal(testResult, expectedResult);
    }
    
    [Theory]
    [InlineData("the sky is blue", "blue is sky the")]
    [InlineData("  hello world  ", "world hello")]
    [InlineData("a good   example", "example good a")]
    public void ReverseWordsInAString_151(string s, string expectedResult)
    {
        string[] words = s.Split(' ', StringSplitOptions.RemoveEmptyEntries);
        var testResult = string.Join(' ', words.Reverse());

        Assert.Equal(testResult, expectedResult);
    }
}