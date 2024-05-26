namespace Piligrimm.Structures.Extentions;

internal static class BaseTypesExtentions
{
    public static int IsGreaterThan(this object obj1, object obj2)
    {
        if (obj1 is null)
            throw new ArgumentNullException(nameof(obj1), "Object is null");
        if (obj2 is null)
            throw new ArgumentNullException(nameof(obj2), "Object is null");

        if (obj1.GetHashCode() > obj2.GetHashCode()) return 1;
        else if (obj1.GetHashCode() < obj2.GetHashCode()) return -1;

        return 0;
    }

    public static int IsLessThan(this object obj1, object obj2)
    {
        if (obj1 is null)
            throw new ArgumentNullException(nameof(obj1), "Object is null");
        if (obj2 is null)
            throw new ArgumentNullException(nameof(obj2), "Object is null");

        if (obj2.GetHashCode() > obj1.GetHashCode()) return 1;
        else if (obj2.GetHashCode() < obj1.GetHashCode()) return -1;

        return 0;
    }
}
