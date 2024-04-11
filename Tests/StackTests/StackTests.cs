namespace Piligrimm.Stask.Tests;

public class StaskTests
{
    [Fact]
    private void Push_EmptyStackAndPushTenItems_AddedItemsToStack()
    {
        var actual = new Stack<int>();

        foreach (var item in Enumerable.Range(0, 9))
        {
            actual.Push(item);
        }

        var expect = Enumerable.Range(0, 9).Reverse();

        Assert.Equal(actual, expect);
    }
}