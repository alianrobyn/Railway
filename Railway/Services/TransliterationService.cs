using System.Text;

namespace Railway.Services;

public class TransliterationService
{
    private static readonly Dictionary<char, string> ConvertedLetters = new()
    {
        { 'а', "a" },
        { 'б', "b" },
        { 'в', "v" },
        { 'г', "h" },
        { 'ґ', "g" },
        { 'д', "d" },
        { 'е', "e" },
        { 'є', "ye" },
        { 'ж', "zh" },
        { 'з', "z" },
        { 'и', "y" },
        { 'і', "i" },
        { 'ї', "yi" },
        { 'й', "j" },
        { 'к', "k" },
        { 'л', "l" },
        { 'м', "m" },
        { 'н', "n" },
        { 'о', "o" },
        { 'п', "p" },
        { 'р', "r" },
        { 'с', "s" },
        { 'т', "t" },
        { 'у', "u" },
        { 'ф', "f" },
        { 'х', "kh" },
        { 'ц', "c" },
        { 'ч', "ch" },
        { 'ш', "sh" },
        { 'щ', "sch" },
        { 'ь', "" },
        { 'ю', "yu" },
        { 'я', "ya" },
        { 'А', "A" },
        { 'Б', "B" },
        { 'В', "V" },
        { 'Г', "H" },
        { 'Ґ', "G" },
        { 'Д', "D" },
        { 'Е', "E" },
        { 'Є', "Ye" },
        { 'Ж', "Zh" },
        { 'З', "Z" },
        { 'И', "Y" },
        { 'І', "I" },
        { 'Ї', "Yi" },
        { 'Й', "J" },
        { 'К', "K" },
        { 'Л', "L" },
        { 'М', "M" },
        { 'Н', "N" },
        { 'О', "O" },
        { 'П', "P" },
        { 'Р', "R" },
        { 'С', "S" },
        { 'Т', "T" },
        { 'У', "U" },
        { 'Ф', "F" },
        { 'Х', "Kh" },
        { 'Ц', "C" },
        { 'Ч', "Ch" },
        { 'Ш', "Sh" },
        { 'Щ', "Sch" },
        { 'Ь', "" },
        { 'Ю', "Yu" },
        { 'Я', "Ya" }
    };

    public string Transliterate(string source)
    {
        var result = new StringBuilder();
        foreach (var letter in source)
            if (ConvertedLetters.TryGetValue(letter, out var convertedLetter)) result.Append(convertedLetter);
            else result.Append(letter);

        return result.ToString();
    }
}