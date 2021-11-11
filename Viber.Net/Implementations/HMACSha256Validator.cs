using System;
using System.Collections;
using System.Security.Cryptography;
using System.Text;
using Viber.Net.Configuration;
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

        public HMACSha256Validator(ViberSettings viberSettings) => _hashAlgorithm = new HMACSHA256(Encoding.UTF8.GetBytes(viberSettings.AuthToken));

        public bool IsValid(string signature, byte[] value, out byte[] computedSignature)
        {
            var valueBytes = _hashAlgorithm.ComputeHash(value);
            var signatureBytes = ConvertToBytes(signature);
            computedSignature = signatureBytes;

            return StructuralComparisons.StructuralEqualityComparer.Equals(valueBytes, signatureBytes);
        }

        private byte[] ConvertToBytes(string value)
        {
            var numberChars = value.Length;
            var bytes = new byte[numberChars / 2];
            for (var i = 0; i < numberChars; i += 2)
            {
                bytes[i / 2] = Convert.ToByte(value.Substring(i, 2), 16);
            }

            return bytes;
        }
    }
}
