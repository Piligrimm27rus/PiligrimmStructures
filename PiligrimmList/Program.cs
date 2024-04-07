System.Console.WriteLine("MY_STRUCTURES");


var list = new Piligrimm.List<int>()
        {
            4, 5, 6, 7, 8, 9, 10
        };
var expect = new int[]
{
            7, 8
};

var a = new int[]
{
    1,2 ,3,4, 5, 1,2 ,3,4, 5
};

expect.CopyTo(a,2);

for (int i = 0; i < expect.Length; i++)
{
    System.Console.WriteLine(list[i] == expect[i]);
}