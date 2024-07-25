using Microsoft.CodeAnalysis.CSharp.Syntax;
using MudBlazor;
using System.Text.RegularExpressions;

namespace ProConsult.Extensions
{
    public static class StringExtensions
    {
        public static string OnlyCharacters(this string input)
        {
            if (String.IsNullOrEmpty(input))
                return input;

            string pattern = @"[-\.\(\)\s]";

            string result = Regex.Replace(input, pattern, string.Empty);

            return result;
        }
    }
}
