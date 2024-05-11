System.Console.WriteLine("MY_STRUCTURES");

// Create a new Piligrimm.Structures.Dictionary of strings, with string keys.
//
var openWith = new Piligrimm.Structures.Dictionary<string, string>();

// Add some elements to the Piligrimm.Structures.Dictionary. There are no
// duplicate keys, but some of the values are duplicates.

openWith.Add("txt", "notepad.exe");
openWith.Add("bmp", "paint.exe");
openWith.Add("dib", "paint.exe");
openWith.Add("rtf", "wordpad.exe");

// The Add method throws an exception if the new key is
// already in the Piligrimm.Structures.Dictionary.
try
{
    openWith.Add("txt", "winword.exe");
}
catch (ArgumentException)
{
    Console.WriteLine("An element with Key = \"txt\" already exists.");
}

// The Item property is another name for the indexer, so you
// can omit its name when accessing elements.
Console.WriteLine("For key = \"rtf\", value = {0}.", openWith["rtf"]);

// The indexer can be used to change the value associated
// with a key.
openWith["rtf"] = "winword.exe";
Console.WriteLine("For key = \"rtf\", value = {0}.", openWith["rtf"]);

// If a key does not exist, setting the indexer for that key
// adds a new key/value pair.
openWith["doc"] = "winword.exe";

// The indexer throws an exception if the requested key is
// not in the Piligrimm.Structures.Dictionary.
try
{
    Console.WriteLine("For key = \"tif\", value = {0}.", openWith["tif"]);
}
catch (KeyNotFoundException)
{
    Console.WriteLine("Key = \"tif\" is not found.");
}

// When a program often has to try keys that turn out not to
// be in the Piligrimm.Structures.Dictionary, TryGetValue can be a more efficient
// way to retrieve values.
string value = "";
if (openWith.TryGetValue("tif", out value))
{
    Console.WriteLine("For key = \"tif\", value = {0}.", value);
}
else
{
    Console.WriteLine("Key = \"tif\" is not found.");
}

// ContainsKey can be used to test keys before inserting
// them.
if (!openWith.ContainsKey("ht"))
{
    openWith.Add("ht", "hypertrm.exe");
    Console.WriteLine("Value added for key = \"ht\": {0}", openWith["ht"]);
}

// When you use foreach to enumerate Piligrimm.Structures.Dictionary elements,
// the elements are retrieved as KeyValuePair objects.
Console.WriteLine();
foreach (Piligrimm.Structures.KeyValuePair<string, string> kvp in openWith)
{
    Console.WriteLine("Key = {0}, Value = {1}", kvp.Key, kvp.Value);
}

// Use the Remove method to remove a key/value pair.
Console.WriteLine("\nRemove(\"doc\")");
openWith.Remove("doc");

if (!openWith.ContainsKey("doc"))
{
    Console.WriteLine("Key \"doc\" is not found.");
}

// /* This code example produces the following output:

// An element with Key = "txt" already exists.
// For key = "rtf", value = wordpad.exe.
// For key = "rtf", value = winword.exe.
// Key = "tif" is not found.
// Key = "tif" is not found.
// Value added for key = "ht": hypertrm.exe

// Key = txt, Value = notepad.exe
// Key = bmp, Value = paint.exe
// Key = dib, Value = paint.exe
// Key = rtf, Value = winword.exe
// Key = doc, Value = winword.exe
// Key = ht, Value = hypertrm.exe

// Remove("doc")
// Key "doc" is not found.
// */