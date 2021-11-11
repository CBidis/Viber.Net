using System;
using System.Collections;
using System.Security.Cryptography;
using System.Text;
using Viber.Net.Contracts;

namespace Viber.Net.Implementations
{
    /// <summary>
    /// The signature is HMAC with SHA256 that will use the authentication token as the key and the JSON as the value
    /// </summary>
    public class HMACSha256Validator : IHashValidator
    {
        /// <summary>
        /// Hash algorithm.
        /// </summary>
        private readonly HMACSHA256 _hashAlgorithm;

        public HMACSha256Validator(string authToken) => _hashAlgorithm = new HMACSHA256(Encoding.UTF8.GetBytes(authToken));

        public bool IsValid(string signature, byte[] value)
        {
            var valueBytes = _hashAlgorithm.ComputeHash(value);
            var signatureBytes = ParseHex(signature);

            return StructuralComparisons.StructuralEqualityComparer.Equals(valueBytes, signatureBytes);
        }

        private byte[] ParseHex(string hex)
        {
            var numberChars = hex.Length;
            var bytes = new byte[numberChars / 2];
            for (var i = 0; i < numberChars; i += 2)
            {
                bytes[i / 2] = Convert.ToByte(hex.Substring(i, 2), 16);
            }

            return bytes;
        }
    }
}
