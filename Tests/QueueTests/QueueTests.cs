namespace Piligrimm.Structures.Tests;

public class QueueTests
{
    [Fact]
    public void AddByConstuctor_InitQueueByArrayInCtor_InitiatedQueue()
    {
        string[] input = ["one", "two", "three", "four", "five"];
        var actual = new Queue<string>(input);

        string[] expect = ["one", "two", "three", "four", "five"];

        expect.Should().BeEquivalentTo(actual);
        Assert.Equal(expect.Count(), actual.Count);
    }

    [Fact]
    public void Enqueue_AddValuesToQueue_InitiatedQueue()
    {
        var actual = new Queue<string>();

        actual.Enqueue("one");
        actual.Enqueue("two");
        actual.Enqueue("three");
        actual.Enqueue("four");
        actual.Enqueue("five");

        string[] expect = ["one", "two", "three", "four", "five"];

        expect.Should().BeEquivalentTo(actual);
        Assert.Equal(expect.Count(), actual.Count);
    }

    [Fact]
    public void Peek_GetValueByPeek_ReturnValueAndQueueShouldNotChange()
    {
        string[] input = ["one", "two", "three", "four", "five"];
        var actual = new Queue<string>(input);

        actual.Peek();

        string[] expect = ["one", "two", "three", "four", "five"];

        expect.Should().BeEquivalentTo(actual);
        Assert.Equal(expect.Count(), actual.Count);
    }

    [Fact]
    public void Peek_PeekValueFewTimes_ReturnSameValuesAndQueueShouldNotChange()
    {
        string[] input = ["one", "two", "three", "four", "five"];
        var actual = new Queue<string>(input);

        var first = actual.Peek();
        var second = actual.Peek();
        var third = actual.Peek();

        string[] expect = ["one", "two", "three", "four", "five"];

        expect.Should().BeEquivalentTo(actual);
        Assert.Equal(expect.Count(), actual.Count);

        first.Should().BeSameAs(second);
        second.Should().BeSameAs(third);
    }

    [Fact]
    public void Dequeue_GetFewValuesByDequeue_ReturnValueAndCleanValuesFromOrder()
    {
        string[] input = ["one", "two", "three", "four", "five"];
        var actual = new Queue<string>(input);

        var first = actual.Dequeue();
        var second = actual.Dequeue();
        var third = actual.Dequeue();

        string[] expect = ["four", "five"];

        expect.Should().BeEquivalentTo(actual);
        Assert.Equal(expect.Count(), actual.Count);

        first.Should().Be("one");
        second.Should().Be("two");
        third.Should().Be("three");
    }

    [Fact]
    public void DequeueAndPeek_DequeueAndPeekMoreItemsThenQueueContains_ReturnException()
    {
        var actual = new Queue<string>();

        actual.Invoking(y => y.Dequeue())
            .Should().Throw<InvalidOperationException>();
        actual.Invoking(y => y.Peek())
            .Should().Throw<InvalidOperationException>();

        actual.Enqueue("One");

        actual.Dequeue();

        actual.Invoking(y => y.Dequeue())
            .Should().Throw<InvalidOperationException>();
        actual.Invoking(y => y.Peek())
            .Should().Throw<InvalidOperationException>();

        actual.Enqueue("One");

        actual.Clear();

        actual.Invoking(y => y.Dequeue())
    .Should().Throw<InvalidOperationException>();
        actual.Invoking(y => y.Peek())
            .Should().Throw<InvalidOperationException>();
    }

    [Fact]
    public void Contains_QueueNotEmpty_ReturnTrue()
    {
        string[] input = ["one", "two", "three", "four", "five"];
        var actual = new Queue<string>(input);

        actual.Contains("one").Should().BeTrue();
        actual.Contains("two").Should().BeTrue();
        actual.Contains("three").Should().BeTrue();
        actual.Contains("four").Should().BeTrue();
        actual.Contains("five").Should().BeTrue();
    }

    [Fact]
    public void Contains_DequeueAndCheckIfContainsInQueue_ReturnFalse()
    {
        string[] input = ["one", "two", "three", "four", "five"];
        var actual = new Queue<string>(input);

        actual.Dequeue();
        actual.Contains("one").Should().BeFalse();

        actual.Contains("five").Should().BeTrue();

        actual.Clear();

        actual.Contains("five").Should().BeFalse();
    }
}
