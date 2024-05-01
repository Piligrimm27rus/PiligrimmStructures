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
        Assert.Equal(expect.Count(), actual.Count);
    }

    [Fact]
    private void AddFirst_AddValueFirstNode_AddedValueFirstNode()
    {
        string[] input = ["the", "fox", "jumps", "over", "the", "dog"];

        var actual = new LinkedList<string>(input);
        actual.AddFirst("today");

        string[] expect = ["today", "the", "fox", "jumps", "over", "the", "dog"];

        expect.Should().BeEquivalentTo(actual);
        Assert.Equal(expect.Length, actual.Count);
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
        Assert.Equal(expect.Length, actual.Count);
    }
    

    [Fact]
    private void RemoveFirst_RemoveFirstItemToBeEmptyThenAdd_ListWasEmptyAndThenOrderCorrect()
    {
        int[] input = [0];
        var actual = new LinkedList<int>(input);

        actual.RemoveFirst();
        actual.Should().BeEmpty();
        actual.Add(0);
        actual.Should().NotBeEmpty();

        var actualForward = LinkedListToList(actual);
        var actualReversed = LinkedListToList(actual, false);

        int[] expectForward = Enumerable.Range(0, 1).ToArray();
        int[] expectReversed = expectForward.Reverse().ToArray();

        expectForward.Should().BeEquivalentTo(actualForward);
        expectReversed.Should().BeEquivalentTo(actualReversed);

        Assert.Equal(expectForward.Length, actualForward.Count);
    }

    [Fact]
    private void RemoveLast_RemoveLastItemToBeEmptyThenAdd_ListWasEmptyAndThenOrderCorrect()
    {
        var actual = new LinkedList<int>(0);

        actual.RemoveLast();
        actual.Should().BeEmpty();
        actual.Add(0);
        actual.Should().NotBeEmpty();

        var actualForward = LinkedListToList(actual);
        var actualReversed = LinkedListToList(actual, false);

        int[] expectForward = Enumerable.Range(0, 1).ToArray();
        int[] expectReversed = expectForward.Reverse().ToArray();

        expectForward.Should().BeEquivalentTo(actualForward);
        expectReversed.Should().BeEquivalentTo(actualReversed);

        Assert.Equal(expectForward.Length, actualForward.Count);
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
        Assert.Equal(expect.Length, actual.Count);
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
        Assert.Equal(expect.Length, actual.Count);
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
        Assert.Equal(expect.Length, actual.Count);
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
        Assert.Equal(expect.Length, actual.Count);
    }

    [Fact]
    private void AddAfter_AddTwoValuesAtEnd_AddedValuesAndOrderFromEndCorrect()
    {
        string[] input = ["one", "two", "three"];
        var linkedList = new LinkedList<string>(input);

        var elem = linkedList.FindLast("three");
        linkedList.AddAfter(elem, "five");
        linkedList.AddAfter(elem, "four");

        var actual = LinkedListToList(linkedList, false);

        string[] expect = ["five", "four", "three", "two", "one"];

        expect.Should().BeEquivalentTo(actual);
        Assert.Equal(expect.Length, actual.Count);
    }

    [Fact]
    private void Find_FindSomeDataFromFirstAndChange_DataWasFoundAndChanged()
    {
        string[] input = ["one", "two", "three"];
        var actual = new LinkedList<string>(input);

        var nodeOne = actual.Find("one");
        nodeOne.Value = $"({nodeOne.Value})";

        var nodeTwo = actual.Find("two");
        nodeTwo.Value = $"({nodeTwo.Value})";

        var nodeThree = actual.Find("three");
        nodeThree.Value = $"({nodeThree.Value})";

        string[] expect = ["(one)", "(two)", "(three)"];

        expect.Should().BeEquivalentTo(actual);
        Assert.Equal(expect.Length, actual.Count);
    }

    [Fact]
    private void AddBefore_AddTwoValuesAtStart_AddedValuesAndOrderFromStartCorrect()
    {
        string[] input = ["three", "four", "five"];
        var linkedList = new LinkedList<string>(input);

        var elem = linkedList.FindLast("three");
        linkedList.AddAfter(elem, "one");
        linkedList.AddAfter(elem, "two");

        var actualForward = LinkedListToList(linkedList);
        var actualReversed = LinkedListToList(linkedList, false);

        string[] expectForward = ["one", "two", "three", "four", "five"];
        string[] expectReversed = expectForward.Reverse().ToArray();

        expectForward.Should().BeEquivalentTo(actualForward);
        expectReversed.Should().BeEquivalentTo(actualReversed);
        Assert.Equal(expectForward.Length, actualForward.Count);
    }

    [Fact]
    private void Remove_RemoveMiddle_NodeWasRemovedAndOrderCorrect()
    {
        string[] input = ["one", "two", "three"];
        var linkedList = new LinkedList<string>(input);

        linkedList.Remove("two");

        var actualForward = LinkedListToList(linkedList);
        var actualReversed = LinkedListToList(linkedList, false);

        string[] expectForward = ["one", "three"];
        string[] expectReversed = expectForward.Reverse().ToArray();

        expectForward.Should().BeEquivalentTo(actualForward);
        expectReversed.Should().BeEquivalentTo(actualReversed);
        Assert.Equal(expectForward.Length, actualForward.Count);
    }

    [Fact]
    private void Remove_RemoveStart_NodeWasRemovedAndOrderCorrect()
    {
        string[] input = ["one", "two", "three"];
        var linkedList = new LinkedList<string>(input);

        linkedList.Remove("one");

        var actualForward = LinkedListToList(linkedList);
        var actualReversed = LinkedListToList(linkedList, false);

        string[] expectForward = ["two", "three"];
        string[] expectReversed = expectForward.Reverse().ToArray();

        expectForward.Should().BeEquivalentTo(actualForward);
        expectReversed.Should().BeEquivalentTo(actualReversed);
        Assert.Equal(expectForward.Length, actualForward.Count);
    }

    [Fact]
    private void Remove_RemoveEnd_NodeWasRemovedAndOrderCorrect()
    {
        string[] input = ["one", "two", "three"];
        var linkedList = new LinkedList<string>(input);

        linkedList.Remove("three");

        var actualForward = LinkedListToList(linkedList);
        var actualReversed = LinkedListToList(linkedList, false);

        string[] expectForward = ["one", "two"];
        string[] expectReversed = expectForward.Reverse().ToArray();

        expectForward.Should().BeEquivalentTo(actualForward);
        expectReversed.Should().BeEquivalentTo(actualReversed);
        Assert.Equal(expectForward.Length, actualForward.Count);
    }

    [Fact]
    private void Clear_ClearAllThenCheckIfDataContains_DataNotContains()
    {
        var input = Enumerable.Range(0, 10).ToArray();
        var actual = new LinkedList<int>(input);

        actual.Clear();

        Assert.DoesNotContain(5, actual);
    }

    List<T> LinkedListToList<T>(LinkedList<T> linkedList, bool isForward = true)
    {
        var current = isForward ? linkedList.First : linkedList.Last;

        var actual = new List<T>();
        do
        {
            actual.Add(current.Value);
            current = isForward ? current.Next : current.Previous;
        } while (current != null);

        return actual;
    }
}