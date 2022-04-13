using Constructors.Simple;

var item1 = new Item(9.99M, "Hammer");

Console.WriteLine(item1);

// Change to #if true to see compilation error
#if false
static void WillNotCompile()
{
Uri oops = new Uri();  // Will not compile
}
#endif
