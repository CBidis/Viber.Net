using System;

namespace Viber.Net.Exceptions
{
    /// <summary>
    /// used to indicate invalid hash computations
    /// </summary>
    public class InvalidViberHashException : Exception
    {
        /// <summary>
        /// raw data read from HttpRequest
        /// </summary>
        public byte[] RawDataReceived { get; }
        /// <summary>
        /// Viber signature received
        /// </summary>
        public string Signature { get; }
        /// <summary>
        /// Viber signature received
        /// </summary>
        public byte[] ComputedSignatureBytess { get; }

        /// <summary>
        /// Default exception constructor
        /// </summary>
        public InvalidViberHashException(string signature, byte[] computedSignatureBytes, byte[] data) 
            : base($"Invalid hash computed for signature [{signature}]")
        {
            RawDataReceived = data;
            Signature = signature;
            ComputedSignatureBytess = computedSignatureBytes;
        }
    }
}
