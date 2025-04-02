using System.Diagnostics.CodeAnalysis;

namespace Solution.Domain.Extensions
{
    public static class StringExtensions
    {
        public static bool NotEmpty([NotNullWhen(true)]this string? value) => string.IsNullOrEmpty(value).IsFalse();
    }
}
