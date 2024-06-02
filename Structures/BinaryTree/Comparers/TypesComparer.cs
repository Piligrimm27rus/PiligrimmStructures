namespace Piligrimm.Structures;

internal class BinaryTreeNodeIntCompare : Comparer<int>
{
    public override int Compare(int x, int y)
    {
        if (x == y)
            return 0;
        else if (x > y)
            return 1;
        else
            return -1;
    }
}

internal class BinaryTreeNodeStringCompare : Comparer<string>
{
    public override int Compare(string x, string y)
    {

        return 0;
    }
}
