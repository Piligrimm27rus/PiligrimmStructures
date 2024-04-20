namespace Piligrimm.LinkedList.Tests;

public class LinkedList
{
    [Fact]
    private void AddByContructor_EmptyLinkedList_CreatedLinkedList()
    {
        string[] input = ["the", "fox", "jumps", "over", "the", "dog"];

        var actual = new LinkedList<string>(input);
        string[] expect = ["the", "fox", "jumps", "over", "the", "dog"];

        expect.Should().BeEquivalentTo(actual);
    }

    [Fact]
    private void AddFirst_AddValueFirstNode_AddedValueFirstNode()
    {
        string[] input = ["the", "fox", "jumps", "over", "the", "dog"];

        var actual = new LinkedList<string>(input);
        actual.AddFirst("today");

        string[] expect = ["today", "the", "fox", "jumps", "over", "the", "dog"];

        expect.Should().BeEquivalentTo(actual);
    }

    [Fact]
    private void RemoveFirstAndAddLast_MoveFirstNodeToBeLastNode_AddedFirstToLast()
    {
        string[] input = ["today", "the", "fox", "jumps", "over", "the", "dog"];

        var actual = new LinkedList<string>(input);

        LinkedListNode<string> mark1 = actual.First;
        actual.RemoveFirst();
        actual.AddLast(mark1);

        string[] expect = ["the", "fox", "jumps", "over", "the", "dog", "today"];

        expect.Should().BeEquivalentTo(actual);
    }

    [Fact]
    private void RemoveLast_ChangeLastNodeToYesterday_RemovedLastNode()
    {
        string[] input = ["the", "fox", "jumps", "over", "the", "dog", "today"];

        var actual = new LinkedList<string>(input);

        actual.RemoveLast();
        actual.AddLast("yesterday");

        string[] expect = ["the", "fox", "jumps", "over", "the", "dog", "yesterday"];

        expect.Should().BeEquivalentTo(actual);
    }

    [Fact]
    private void RemoveLast_MoveLastNodeToBeTheFirstNode_LastIsFirst()
    {
        string[] input = ["the", "fox", "jumps", "over", "the", "dog", "yesterday"];

        var actual = new LinkedList<string>(input);

        var mark1 = actual.Last;
        actual.RemoveLast();
        actual.AddFirst(mark1);

        string[] expect = ["yesterday", "the", "fox", "jumps", "over", "the", "dog"];

        expect.Should().BeEquivalentTo(actual);
    }

    [Fact]
    private void A()
    {
        var input = Enumerable.Range(0, 10).ToArray();
        var actual1 = new LinkedList<int>(input);

        List<int> actual = new List<int>();

        LinkedListNode<int>? current = actual1.First;
        do
        {
            actual.Add(current.Value);

            current = current.Next;
        } while (current != null);

        var expect = Enumerable.Range(0, 10);

        expect.Should().BeEquivalentTo(actual);
    }
}