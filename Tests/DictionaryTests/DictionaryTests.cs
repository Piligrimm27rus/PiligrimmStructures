namespace Piligrimm.Structures.Tests;

public class DictionaryTests
{
    [Fact]
    public void Add_EmptyDictionary_AddedNewValues()
    {
        var actual = new Dictionary<string, string>();

        var expect = new Fixture().Build<KeyValuePair<string, string>>()
            .WithAutoProperties()
            .CreateMany(100);

        foreach (var pair in expect)
        {
            actual.Add(pair.Key, pair.Value);
        }

        expect.Should().BeEquivalentTo(actual);
    }

    [Fact]
    public void Add_AddExistedKey_ReturnException()
    {
        var actual = new Dictionary<string, string>
        {
            { "txt", "notepad.exe" },
            { "bmp", "paint.exe" },
            { "dib", "paint.exe" },
            { "rtf", "wordpad.exe" }
        };

        actual.Invoking(y => y.Add("txt", "winword.exe"))
            .Should().Throw<ArgumentException>();
    }

    [Fact]
    public void Add_AddNullKey_ReturnException()
    {
        var actual = new Dictionary<string?, string?>();

        actual.Invoking(y => y.Add("txt", null))
            .Should().NotThrow<ArgumentNullException>();

        actual.Invoking(y => y.Add(null, "winword.exe"))
            .Should().Throw<ArgumentNullException>();
    }
}