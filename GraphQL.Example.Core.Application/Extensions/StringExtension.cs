namespace GraphQL.Example.Core.Application.Extensions
{
    public static class StringExtension
    {
        public static string RemoveEntityName(this string str) => str.Replace("Entity", "").Trim();
    }
}
