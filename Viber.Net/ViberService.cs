using System;
using System.Threading;
using System.Threading.Tasks;
using Viber.Net.Contracts;
using Viber.Net.Models.Requests;
using Viber.Net.Models.Responses;

namespace Viber.Net
{
    /// <summary>
    /// Concrete Implementation of <see cref="IViberService"/>
    /// </summary>
    public class ViberService : IViberService
    {
        private readonly IViberHttpClient _viberHttpClient;

        public ViberService(IViberHttpClient viberHttpClient)
            => _viberHttpClient = viberHttpClient ?? throw new ArgumentNullException(nameof(viberHttpClient));

        public async Task<GetAccountInfoResponse> GetAccountInfo(GetAccountInfoRequest request, CancellationToken cancellationToken = default)
            => await _viberHttpClient.Post<GetAccountInfoRequest, GetAccountInfoResponse>("/pa/get_account_info", request, cancellationToken);

        public async Task<GetOnlineUsersStatusResponse> GetOnlineUsersStatus(GetOnlineUsersStatusRequest request, CancellationToken cancellationToken = default)
            => await _viberHttpClient.Post<GetOnlineUsersStatusRequest, GetOnlineUsersStatusResponse>("/pa/get_online", request, cancellationToken);

        public async Task<GetUserDetailsResponse> GetUserDetails(GetUserDetailsRequest request, CancellationToken cancellationToken = default)
            => await _viberHttpClient.Post<GetUserDetailsRequest, GetUserDetailsResponse>("/pa/get_user_details", request, cancellationToken);

        public async Task<SetWebhookResponse> RemoveWebhook(RemoveWebhookRequest request, CancellationToken cancellationToken = default)
            => await _viberHttpClient.Post<RemoveWebhookRequest, SetWebhookResponse>("/pa/set_webhook", request, cancellationToken);

        public async Task<SendMessageResponse> SendMessage<TMessageRequest>(TMessageRequest request, CancellationToken cancellationToken = default)
            where TMessageRequest : ISendMessageViberRequest
            => await _viberHttpClient.Post<TMessageRequest, SendMessageResponse>("/pa/send_message", request, cancellationToken);

        public async Task<SetWebhookResponse> SetWebhook(SetWebhookRequest request, CancellationToken cancellationToken = default)
            => await _viberHttpClient.Post<SetWebhookRequest, SetWebhookResponse>("/pa/set_webhook", request, cancellationToken);
    }
}
