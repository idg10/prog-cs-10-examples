using System.Numerics;

// This example shows something illegal. Change the #if false to #if true
// to see the complier error.
#if false
static void IllegalImmutableValueUse()
{
    var values = new Complex[10];
    // These lines both cause compiler errors:
    values[0].Real = 10;
    values[0].Imaginary = 1;
}
#endif

int[] numbers = new int[10];
string[] strings = new string[numbers.Length];

// Continued from Example 5-1
numbers[0] = 42;
numbers[1] = numbers.Length;
numbers[2] = numbers[0] + numbers[1];
numbers[numbers.Length - 1] = 99;

var values = new Complex[10];
values[0] = new Complex(10, 1);