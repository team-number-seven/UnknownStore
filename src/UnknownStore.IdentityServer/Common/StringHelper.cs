using System.Linq;

namespace UnknownStore.IdentityServer.Common
{
    public static class StringHelper
    {
        /// <summary>
        ///     check string for null or empty
        /// </summary>
        /// <param name="strings">strings</param>
        /// <returns>If all string are not empty and null returns true, otherwise false</returns>
        public static bool HasNullOrEmptyStrings(params string[] strings)
        {
            return strings.All(string.IsNullOrEmpty);
        }
    }
}