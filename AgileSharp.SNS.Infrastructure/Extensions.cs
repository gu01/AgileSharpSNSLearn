
using System.Text.RegularExpressions;
using System.Collections;
namespace AgileSharp.SNS.Infrastructure
{
    public static class Extensions
    {
        private static Regex emailRegex = new Regex(@"\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*");

        public static string Encrypt(this string s, string key)
        {
            return Cryptography.Encrypt(s, key);
        }

        public static string Decrypt(this string s, string key)
        {
            return Cryptography.Decrypt(s, key);
        }

        public static bool IsNotEmpty(this string value)
        {
            return !string.IsNullOrEmpty(value);
        }

        public static bool IsEmail(this string value)
        {
            bool result = false;
            if (value.IsNotEmpty())
            {
                result = emailRegex.IsMatch(value);
            }
            return result;
        }

        public static bool SafeBoolParse(this string value)
        {
            bool result = false;
            if (value.IsNotEmpty())
            {
                bool.TryParse(value, out result);
            }
            return result;
        }

        public static bool IsNotNull(this IList list)
        {
            return list != null && list.Count > 0;
        }

    }
}
