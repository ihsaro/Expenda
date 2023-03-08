namespace Expenda.Application.Architecture.Extensions;

public static class StringExtensions
{
    public static bool IsNullOrEmpty(this string s) => s == null || s.Length == 0;

    public static int GetCharacterCount(this string s, char c)
    {
        int count = 0;
        foreach (char character in s) if (character == c) count++;
        return count;
    }

    public static string Capitalize(this string s) => $"{char.ToUpper(s[0])}{s[1..]}";
}
