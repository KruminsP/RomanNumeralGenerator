namespace RomanNumeralGenerator;

public class Generator : IRomanNumeralGenerator
{
    public string Generate(int number)
    {
        if (number is < 1 or > 3999)
        {
            return "Number out of bounds";
        }

        var result = "";
        var numerals = new Dictionary<int, string>
        {
            { 1000, "M"},
            { 900, "CM"},
            { 500, "D"},
            { 400, "CD"},
            { 100, "C"},
            { 90, "XC"},
            { 50, "L"},
            { 40, "XL"},
            { 10, "X"},
            { 9, "IX"},
            { 5, "V"},
            { 4, "IV"},
            { 1, "I"},
        };

        foreach (var num in numerals)
        {
            result += string.Concat(Enumerable.Repeat(num.Value, number / num.Key));
            number %= num.Key;
        }

        return result;
    }
}