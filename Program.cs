namespace RomanNumeralGenerator;

public class Program
{
    public static void Main()
    {
        int n = 1989;
        var numerator = new Generator();

        Console.WriteLine(numerator.Generate(n));
    }
}