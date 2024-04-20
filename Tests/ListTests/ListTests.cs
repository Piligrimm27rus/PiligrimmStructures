namespace Piligrimm.Structures.Tests;

public class ListTests
{
    [Fact]
    public void Add_ListFilledHungredItemsByArray_ListFilledByArrayAndValuesSame()
    {
        var inputArray = new int[100]
        {
             1,  2,  3,  4,  5,  6,  7,  8,  9, 10,
            11, 12, 13, 14, 15, 16, 17, 18, 19, 20,
            21, 22, 23, 24, 25, 26, 27, 28, 29, 30,
            31, 32, 33, 34, 35, 36, 37, 38, 39, 40,
            41, 42, 43, 44, 45, 46, 47, 48, 49, 50,
            51, 52, 53, 54, 55, 56, 57, 58, 59, 60,
            61, 62, 63, 64, 65, 66, 67, 68, 69, 70,
            71, 72, 73, 74, 75, 76, 77, 78, 79, 80,
            81, 82, 83, 84, 85, 86, 87, 88, 89, 90,
            91, 92, 93, 94, 95, 96, 97, 98, 99, 100,
        };
        var list = new List<int>();

        for (int i = 0; i < inputArray.Length; i++)
        {
            list.Add(inputArray[i]);
        }

        Assert.True(list.Count == inputArray.Length);

        for (int i = 0; i < inputArray.Length; i++)
        {
            Assert.True(list[i] == inputArray[i]);
        }
    }

    [Fact]
    public void Clear_ListNotEmpty_EmptyList()
    {
        var list = new List<int>()
        {
             1,  2,  3,  4,  5,  6,  7,  8,  9, 10,
            11, 12, 13, 14, 15, 16, 17, 18, 19, 20,
            21, 22, 23, 24, 25, 26, 27, 28, 29, 30,
            31, 32, 33, 34, 35, 36, 37, 38, 39, 40,
            41, 42, 43, 44, 45, 46, 47, 48, 49, 50,
            51, 52, 53, 54, 55, 56, 57, 58, 59, 60,
            61, 62, 63, 64, 65, 66, 67, 68, 69, 70,
            71, 72, 73, 74, 75, 76, 77, 78, 79, 80,
            81, 82, 83, 84, 85, 86, 87, 88, 89, 90,
            91, 92, 93, 94, 95, 96, 97, 98, 99, 100,
        };

        list.Clear();
        Assert.True(list.Count == 0);
    }

    [Fact]
    public void Contains_ListNotEmpty_ContainsEveryItem()
    {
        var list = new List<int>()
        {
             1,  2,  3,  4,  5,  6,  7,  8,  9, 10,
            11, 12, 13, 14, 15, 16, 17, 18, 19, 20,
            21, 22, 23, 24, 25, 26, 27, 28, 29, 30,
            31, 32, 33, 34, 35, 36, 37, 38, 39, 40,
            41, 42, 43, 44, 45, 46, 47, 48, 49, 50,
            51, 52, 53, 54, 55, 56, 57, 58, 59, 60,
            61, 62, 63, 64, 65, 66, 67, 68, 69, 70,
            71, 72, 73, 74, 75, 76, 77, 78, 79, 80,
            81, 82, 83, 84, 85, 86, 87, 88, 89, 90,
            91, 92, 93, 94, 95, 96, 97, 98, 99, 100,
        };

        Assert.True(list.All(list.Contains));
    }

    [Fact]
    public void Clear_ClearListWhichNotEmptyAndThenAddAnotherData_ListNotEmptyAndHasCorrectData()
    {
        var list = new List<int>();

        var array1To30 = new int[]
        {
             1,  2,  3,  4,  5,  6,  7,  8,  9, 10,
            11, 12, 13, 14, 15, 16, 17, 18, 19, 20,
            21, 22, 23, 24, 25, 26, 27, 28, 29, 30,
        };
        var array31To100 = new int[]
        {
            31, 32, 33, 34, 35, 36, 37, 38, 39, 40,
            41, 42, 43, 44, 45, 46, 47, 48, 49, 50,
            51, 52, 53, 54, 55, 56, 57, 58, 59, 60,
            61, 62, 63, 64, 65, 66, 67, 68, 69, 70,
            71, 72, 73, 74, 75, 76, 77, 78, 79, 80,
            81, 82, 83, 84, 85, 86, 87, 88, 89, 90,
            91, 92, 93, 94, 95, 96, 97, 98, 99, 100,
        };

        for (int i = 0; i < array1To30.Length; i++)
        {
            list.Add(array1To30[i]);
        }

        list.Clear();

        for (int i = 0; i < array31To100.Length; i++)
        {
            list.Add(array31To100[i]);
        }

        for (int i = 0; i < list.Count; i++)
        {
            Assert.True(list[i] == array31To100[i]);
        }

        Assert.True(list.Count == array31To100.Length);
    }

    [Fact]
    public void Remove_ListHasTenItemsAndRemoveMiddleItem_ListHasNineItemsAndDataCorrect()
    {
        var list = new List<int>()
        {
            1, 2, 3, 4, 5, 6, 7, 8, 9, 10
        };
        var expect = new int[]
        {
            1, 2, 3, 4, 6, 7, 8, 9, 10
        };

        Assert.True(list.Remove(5));
        Assert.True(list.Count == expect.Length);

        for (int i = 0; i < expect.Length; i++)
        {
            Assert.True(list[i] == expect[i]);
        }

        Assert.False(list.Remove(100));
    }

    [Fact]
    public void Remove_RemoveFirstItem_ListHasNineItemsAndDataCorrect()
    {
        var list = new List<int>()
        {
            1, 2, 3, 4, 5, 6, 7, 8, 9, 10
        };
        var expect = new int[]
        {
            2, 3, 4, 5, 6, 7, 8, 9, 10
        };

        Assert.True(list.Remove(1));
        Assert.True(list.Count == expect.Length);

        for (int i = 0; i < expect.Length; i++)
        {
            Assert.True(list[i] == expect[i]);
        }
    }

    [Fact]
    public void Remove_RemoveLastItem_ListHasNineItemsAndDataCorrect()
    {
        var list = new List<int>()
        {
            1, 2, 3, 4, 5, 6, 7, 8, 9, 10
        };
        var expect = new int[]
        {
            1, 2, 3, 4, 5, 6, 7, 8, 9
        };

        Assert.True(list.Remove(10));
        Assert.True(list.Count == expect.Length);

        for (int i = 0; i < expect.Length; i++)
        {
            Assert.True(list[i] == expect[i]);
        }
    }

    [Fact]
    public void CopyTo_FilledListAndCopyDataFromDestinationIndexToArray_CopiedDataToArray()
    {
        int destinationIndex = 4;
        var list = new List<int>()
        {
            6, 7, 8, 9
        };

        var result = new int[]
        {
            0, 0, 0, 0, 0, 0, 0, 0, 0, 0
        };

        list.CopyTo(result, destinationIndex);

        var expect = new int[]
        {
            0, 0, 0, 0, 6, 7, 8, 9, 0, 0
        };

        for (int i = 0; i < expect.Length; i++)
        {
            Assert.True(expect[i] == result[i]);
        }
        for (int i = 0; i < list.Count; i++)
        {
            Assert.True(result[destinationIndex + i] == list[i]);
        }
    }
}