using System.Text.RegularExpressions;

namespace Leads.Infrastructure.MySqlDatabase.Extensions
{
    public static class StringExtensions
    {
        public static string ToSnakCase( this string input )
        {
            if ( string.IsNullOrWhiteSpace( input ) )
            {
                return input;
            }

            var snakeCase = Regex.Replace( input, "([^_])([A-Z])", "$1_$2" );

            return snakeCase.ToLower();
        }
    }
}