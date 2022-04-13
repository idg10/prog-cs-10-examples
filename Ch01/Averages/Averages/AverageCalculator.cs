namespace Averages;

public static class AverageCalculator
{
    public static double ArithmeticMean(string[] args)
    {
        return args.Select(numText => double.Parse(numText)).Average();
    }
}