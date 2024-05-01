namespace Piligrimm.Structures.Tests;

public class StaskTests
{
    [Fact]
    private void Push_EmptyStackAndPushTenItems_AddedTenItemsToStack()
    {
        var actual = new Stack<int>();

        foreach (var item in Enumerable.Range(0, 10))
        {
            actual.Push(item);
        }

        var expect = Enumerable.Range(0, 10).Reverse();

        expect.Should().BeEquivalentTo(actual);
    }


    [Fact]
    private void CopyTo_StackHasData_CopyAllStackDataToAnotherArray()
    {
        var input = new Stack<int>();

        var destinationIndex = 5;
        var destinationArray = Enumerable.Range(5, 3).ToArray();

        foreach (var item in destinationArray)
        {
            input.Push(item);
        }

        var actual = Enumerable.Range(0, 10).ToArray();
        input.CopyTo(actual, destinationIndex);


        var expect = Enumerable.Range(0, 10).ToArray();
        destinationArray.Reverse().ToArray().CopyTo(expect, destinationIndex);

        expect.Should().BeEquivalentTo(actual);
        input.Should().BeEquivalentTo(destinationArray.Reverse());
    }

    [Fact]
    private void Pop_StackHasData_GetLastItemAndDeleteLastItem()
    {
        var actual = new Stack<int>();

        foreach (var item in Enumerable.Range(0, 10))
        {
            actual.Push(item);
        }

        var expect = Enumerable.Range(0, 9).Reverse();
        var lastItemOfStack = actual.Pop();

        lastItemOfStack.Should().Be(9);
        actual.Count.Should().Be(9);
        expect.Should().BeEquivalentTo(actual);
    }

    [Fact]
    private void Peek_StackHasData_GetLastItemAndDontChangeStack()
    {
        var actual = new Stack<int>();

        foreach (var item in Enumerable.Range(0, 10))
        {
            actual.Push(item);
        }

        var expect = Enumerable.Range(0, 10).Reverse();
        var lastItemOfStack = actual.Peek();

        lastItemOfStack.Should().Be(9);
        actual.Count.Should().Be(10);
        expect.Should().BeEquivalentTo(actual);
    }

    [Fact]
    private void Clear_StackHasData_StackEmpty()
    {
        var actual = new Stack<int>();

        foreach (var item in Enumerable.Range(0, 10))
        {
            actual.Push(item);
        }

        actual.Clear();

        var expect = Enumerable.Empty<int>();

        expect.Should().BeEquivalentTo(actual);
        actual.Count.Should().Be(0);
    }

    [Fact]
    private void Push_PushDataFromStack_StackDataSame()
    {
        string[] someData = ["fisrt", "second", "third"];

        var actual = new Stack<string>();

        foreach (var data in someData)
        {
            actual.Push(data);
        }

        string[] expect = someData.Reverse().ToArray();

        expect.Should().BeEquivalentTo(actual);
    }

    [Fact]
    private void Pop_PopDataFromStack_StackDataSame()
    {
        string[] someData = ["fisrt", "second", "third"];

        var actual = new Stack<string>();

        foreach (var data in someData)
        {
            actual.Push(data);
        }

        actual.Pop();

        string[] expect = someData.Take(someData.Length - 1).Reverse().ToArray();
        expect.Should().BeEquivalentTo(actual);
    }

    [Fact]
    private void Peek_PeekDataFromStack_StackDataSame()
    {
        string[] someData = ["fisrt", "second", "third"];

        var actual = new Stack<string>();

        foreach (var data in someData)
        {
            actual.Push(data);
        }

        actual.Peek();

        string[] expect = someData.Reverse().ToArray();
        expect.Should().BeEquivalentTo(actual);
    }
}