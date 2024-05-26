namespace Piligrimm.Structures.Tests;

public class BinaryTreeTests
{
    [Fact]
    public void Add_EmptyDictionary_AddedNewValues()
    {
        var actual = new BinaryTree<string>();

        var expect = new Fixture().Build<string>()
            .WithAutoProperties()
            .CreateMany(100);

        foreach (var pair in expect)
        {
            actual.Add(pair);
        }

        // expect.Should().BeEquivalentTo(actual);
    }
}