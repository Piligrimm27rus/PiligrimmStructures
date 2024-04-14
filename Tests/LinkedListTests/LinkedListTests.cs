namespace Piligrimm.LinkedList.Tests;

public class LinkedList
{
    [Fact]
    private void Test()
    {
        string[] words = ["the", "fox", "jumps", "over", "the", "dog"];

        var actual = new LinkedList<string>(words);
        string[] expect = ["the", "fox", "jumps", "over", "the", "dog"];

        words.Should().BeSameAs(actual);
    }
}