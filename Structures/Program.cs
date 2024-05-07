System.Console.WriteLine("MY_STRUCTURES");

string[] input = ["one"];
var actual = new Queue<string>(input);

var first = actual.Dequeue();

actual.Peek();

actual.Enqueue("one");

first = actual.Peek();
