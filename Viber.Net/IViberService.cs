using System.Threading;
using System.Threading.Tasks;
using Viber.Net.Models.Requests;
using Viber.Net.Models.Responses;

namespace Viber.Net
{
    /// <summary>
    /// Viber REST API Services Definition
    /// </summary>
    public interface IViberService
    {
        /// <summary>
        /// Setting the webhook will be done by calling the set_webhook API with a valid and certified URL. 
        /// This action defines the account’s webhook and the type of events the account wants to be notified about.
        /// </summary>
        /// <param name="request"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        Task<SetWebhookResponse> SetWebhook(SetWebhookRequest request, CancellationToken cancellationToken = default);
        /// <summary>
        /// Once you set a webhook to your bot your 1-on-1 conversation button will appear and users will be able to access it. 
        /// </summary>
        /// <param name="request"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        Task<SetWebhookResponse> RemoveWebhook(RemoveWebhookRequest request, CancellationToken cancellationToken = default);
        /// <summary>
        /// The get_account_info request will fetch the account’s details as registered in Viber.
        /// The account admin will be able to edit most of these details from his Viber client.
        /// </summary>
        /// <param name="request"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        Task<GetAccountInfoResponse> GetAccountInfo(GetAccountInfoRequest request, CancellationToken cancellationToken = default);
        /// <summary>
        /// The get_user_details request will fetch the details of a specific Viber user based on his unique user ID.
        /// The user ID can be obtained from the callbacks sent to the account regarding user’s actions.
        /// This request can be sent twice during a 12 hours period for each user ID.
        /// </summary>
        /// <param name="request"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        Task<GetUserDetailsResponse> GetUserDetails(GetUserDetailsRequest request, CancellationToken cancellationToken = default);
        /// <summary>
        /// The get_online request will fetch the online status of a given subscribed account members. 
        /// The API supports up to 100 user id per request and those users must be subscribed to the account.
        /// </summary>
        /// <param name="request"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        Task<GetOnlineUsersStatusResponse> GetOnlineUsersStatus(GetOnlineUsersStatusRequest request, CancellationToken cancellationToken = default);
        /// <summary>
        /// The send_message API allows accounts to send messages to Viber users who subscribe to the account. 
        /// Sending a message to a user will be possible only after the user has subscribed to the bot. 
        /// (see subscribed callback for additional information). You can share your bot with the users via a deeplink.
        /// Maximum total JSON size of the request is 30kb.
        /// </summary>
        /// <typeparam name="TMessageRequest">type of request object</typeparam>
        /// <param name="request">request object must implement <see cref="ISendMessageViberRequest"/> or extend <see cref="AbstractSendMessageRequest"/></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        Task<SendMessageResponse> SendMessage<TMessageRequest>(TMessageRequest request, CancellationToken cancellationToken = default) 
            where TMessageRequest : ISendMessageViberRequest;
    }
}
