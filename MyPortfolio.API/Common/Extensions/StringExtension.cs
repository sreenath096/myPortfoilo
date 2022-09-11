namespace MyPortfolio.API.Common.Extensions
{
    public static class StringExtension
    {
        public static string ReplaceEmptyStringWithNull(this string value)
        {
            return string.IsNullOrEmpty(value) ? null : value;
        }
    }
}