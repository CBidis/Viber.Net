namespace Viber.Net.Models.Requests
{
    /// <summary>
    /// Get Account Info request object, just an empty request object '{}'
    /// </summary>
    public class GetAccountInfoRequest : IViberRequest
    {
        /// <summary>
        /// Gets default Instance
        /// </summary>
        public static GetAccountInfoRequest Default => new GetAccountInfoRequest();
    }
}
