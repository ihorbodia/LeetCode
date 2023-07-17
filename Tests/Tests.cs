namespace Tests;

public class Tests
{
    [Theory]
    [InlineData(new[] {1,0,0,0,1}, 1, true)]
    [InlineData(new[] {1,0,0,0,1}, 2, false)]
    [InlineData(new[] {0,0,0,0,0,1}, 1, true)]
    [InlineData(new[] {0,0,1,0,1}, 1, true)]
    public void CanPlaceFlowers_605(int[] flowerbed, int n, bool expectedResult)
    {
        for (int i = 0; i < flowerbed.Length; i++)
        {
            if (flowerbed[i] == 0 && 
                (i == flowerbed.Length - 1 || flowerbed[i+1] == 0) && (i == 0 || flowerbed[i-1] == 0))
            {
                flowerbed[i] = 1;
                n--;
            }
        }

        var testResult = n <= 0;
        
        Assert.Equal(testResult, expectedResult);
    }
}