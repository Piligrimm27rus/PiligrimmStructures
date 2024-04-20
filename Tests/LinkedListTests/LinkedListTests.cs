namespace Piligrimm.Structures.Tests;

public class LinkedList
{
    [Fact]
    private void AddByContructor_EmptyLinkedList_CreatedLinkedList()
    {
        var input = Enumerable.Range(0, 10).ToArray();
        var linkedList = new LinkedList<int>(input);

        LinkedListNode<int>? current = linkedList.First;
        List<int> actual = new List<int>();

        do
        {
            actual.Add(current.Value);
            current = current.Next;
        } while (current != null);

        var expect = Enumerable.Range(0, 10);

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
    private void FindLast_ChangeFoundData_ProperDataShouldBeChanged()
    {
        string[] input = ["the", "fox", "jumps", "over", "the", "dog", "yesterday"];

        var actual = new LinkedList<string>(input);
        var current = actual.FindLast("the");
        current.Value = $"({current.Value})";

        string[] expect = ["the", "fox", "jumps", "over", "(the)", "dog", "yesterday"];

        expect.Should().BeEquivalentTo(actual);
    }

    [Fact]
    private void AddAfter_AddTwoValuesAtMiddle_AddedValuesAndOrderFromStartCorrect()
    {
        string[] input = ["the", "fox", "jumps", "over", "the", "dog", "yesterday"];

        var actual = new LinkedList<string>(input);

        var current = actual.FindLast("the");
        actual.AddAfter(current, "old");
        actual.AddAfter(current, "lazy");

        string[] expect = ["the", "fox", "jumps", "over", "the", "lazy", "old", "dog", "yesterday"];

        expect.Should().BeEquivalentTo(actual);
    }

    [Fact]
    private void AddAfter_AddTwoValuesAtEnd_AddedValuesAndOrderFromEndCorrect()
    {
        string[] input = ["one", "two", "three"];

        var linkedList = new LinkedList<string>(input);

        var elem = linkedList.FindLast("three");
        linkedList.AddAfter(elem, "five");
        linkedList.AddAfter(elem, "four");

        var current = linkedList.Last;
        var actual = new List<string>();
        do
        {
            actual.Add(current.Value);
            current = current.Previous;
        } while (current != null);

        string[] expect = ["five", "four", "three", "two", "one"];

        expect.Should().BeEquivalentTo(actual);
    }
}