using System.Text.Json.Serialization;

namespace Viber.Net.Models.Requests
{
    /// <summary>
    /// Send Contact Message Request Object
    /// </summary>
    public class SendContactMessageRequest : AbstractSendMessageRequest
    {
        public override MessageType Type => MessageType.Contact;
        /// <summary>
        /// Contact details object, required
        /// </summary>
        [JsonPropertyName("contact")]
        public ContactDetails Contact { get; set; }
    }

    public class ContactDetails
    {
        /// <summary>
        /// Name of the contact required. Max 28 characters
        /// </summary>
        [JsonPropertyName("name")]
        public string Name { get; set; }
        /// <summary>
        /// Phone number of the contact required. Max 18 characters
        /// </summary>
        [JsonPropertyName("phone_number")]
        public string PhoneNumber { get; set; }
    }
}
