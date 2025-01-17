using System.Security.Cryptography;
using System.Text;

namespace MyBlogSite.Core.Utilities
{
    /// <summary>
    /// Utility class for computing SHA-256 hash values.
    /// </summary>
    public static class HashHelper
    {
        /// <summary>
        /// Computes the SHA-256 hash of the input string.
        /// </summary>
        /// <param name="input">The input string to hash.</param>
        /// <returns>The SHA-256 hash value as a hexadecimal string.</returns>
        public static string ComputeSha256Hash(string input)
        {
            // Create an instance of SHA-256 algorithm
            using SHA256 sha256 = SHA256.Create();
            // Convert the input string to byte array
            var inputBytes = Encoding.UTF8.GetBytes(input);

            // Compute the hash value of the input bytes
            var hashBytes = sha256.ComputeHash(inputBytes);

            // Convert the hash bytes to a hexadecimal string
            var sb = new StringBuilder();
            foreach (var t in hashBytes)
            {
                sb.Append(t.ToString("X2"));
            }
            return sb.ToString();
        }
    }
}
