using Piligrimm;

namespace Tests;

public class PiligrimmList
{
    [Fact]
    public void Add_ListEmptyAndAddOneItem_ListNotEmpty()
    {
        var list = new PiligrimmList<int>();
        list.Add(1);

        Assert.True(list.Count == 1);
        Assert.True(list[0] == 1);
    }

    [Fact]
    public void Clear_ListNotEmpty_EmptyList()
    {
        var list = new PiligrimmList<int>();
        list.Add(1);
        list.Clear();

        Assert.True(list.Count == 0);
    }
}