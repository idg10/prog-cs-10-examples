using System.Numerics;

BigInteger i1 = 1;
BigInteger i2 = 1;
Console.WriteLine(i1);
int count = 0;
while (true)
{
    // The % operator returns the remainder of dividing its 1st operand by its
    // 2nd, so this displays the number only when count is divisible by 100000.
    if (count++ % 100000 == 0)
    {
        Console.WriteLine(i2);
    }
    BigInteger next = i1 + i2;
    i1 = i2;
    i2 = next;
}