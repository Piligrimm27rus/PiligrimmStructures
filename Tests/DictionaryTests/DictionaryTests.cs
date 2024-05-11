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

    [Fact]
    public void IndexerGet_DictionaryNotEmpty_ReturnCorrectValueFromKey()
    {
        var actual = new Dictionary<string, string>
        {
            { "txt", "notepad.exe" },
            { "bmp", "paint.exe" },
            { "dib", "paint.exe" },
            { "rtf", "wordpad.exe" }
        };

        actual["rtf"].Should().Be("wordpad.exe");
    }

    [Fact]
    public void IndexerGet_DictionaryEmpty_ReturnException()
    {
        var actual = new Dictionary<string, string>();

        actual.Invoking(y => y["rtf"])
            .Should().Throw<KeyNotFoundException>();
    }

    [Fact]
    public void IndexerSet_DictionaryNotEmpty_SetNewValueByKey()
    {
        var actual = new Dictionary<string, string>
        {
            { "txt", "notepad.exe" },
            { "bmp", "paint.exe" },
            { "dib", "paint.exe" },
            { "rtf", "wordpad.exe" }
        };

        actual["rtf"] = "winword.exe";

        actual["rtf"].Should().Be("winword.exe");
    }

    [Fact]
    public void IndexerSet_KeyDoesntExists_AddNewValueKeyPair()
    {
        var actual = new Dictionary<string, string>();

        actual["doc"] = "winword.exe";

        actual["doc"].Should().Be("winword.exe");
    }

    [Fact]
    public void TryGetValue_ValueExists_GetCorrectValue()
    {
        var actual = new Dictionary<string, string>
        {
            { "txt", "notepad.exe" }
        };

        actual.TryGetValue("txt", out string Value).Should().BeTrue();
        Value.Should().Be("notepad.exe");
    }

    [Fact]
    public void TryGetValue_ValueIsntExists_GetNull()
    {
        var actual = new Dictionary<string, string>
        {
            { "txt", "notepad.exe" }
        };

        actual.TryGetValue("doc", out string Value).Should().BeFalse();
        Value.Should().BeNull();
    }

    [Fact]
    public void ContainsKey_KeyExists_GetTrue()
    {
        var actual = new Dictionary<string, string>
        {
            { "doc", "winword.exe" }
        };

        actual.ContainsKey("doc").Should().BeTrue();
    }

    [Fact]
    public void ContainsKey_KeyIsntExists_GetFalse()
    {
        var actual = new Dictionary<string, string>
        {
            { "txt", "notepad.exe" }
        };

        actual.ContainsKey("doc").Should().BeFalse();
    }

    [Fact]
    public void Remove_KeyExists_RemovePairs()
    {
        var actual = new Dictionary<string, string>
        {
            { "txt", "notepad.exe" }
        };

        actual.ContainsKey("txt").Should().BeTrue();
        actual.Remove("txt");
        actual.ContainsKey("txt").Should().BeFalse();
    }

    [Fact]
    public void Remove_KeyIsntExists_PairDoesntRemoved()
    {
        var actual = new Dictionary<string, string>
        {
            { "txt", "notepad.exe" }
        };
        
        actual.Invoking(y => actual.Remove("doc"))
            .Should().NotThrow();
    }
}