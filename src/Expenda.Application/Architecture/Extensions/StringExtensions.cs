namespace Expenda.Application.Architecture.Extensions;

public static class StringExtensions
{
    public static int GetCharacterCount(this string s, char c) => s.Count(character => character == c);

    public static string Capitalize(this string s) => $"{char.ToUpper(s[0])}{s[1..]}";
}
