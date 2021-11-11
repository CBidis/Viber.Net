using System;

namespace Viber.Net.Exceptions
{
    /// <summary>
    /// Used to indicate invalid API Response codes.
    /// </summary>
    public class FailedApiResponseException : Exception
    {
        /// <summary>
        /// error code received from Viber API
        /// </summary>
        public int Code { get; }
        /// <summary>
        /// Error description of above code
        /// </summary>
        public string Error { get; }

        /// <summary>
        /// Default exception constructor
        /// </summary>
        /// <param name="code"></param>
        /// <param name="error"></param>
        public FailedApiResponseException(int code, string error) : base($"non success code {code} with msg {error}")
        {
            Code = code;
            Error = error;
        }
    }
}
