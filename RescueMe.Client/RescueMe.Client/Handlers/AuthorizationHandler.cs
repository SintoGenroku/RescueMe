using RescueMe.Refit;
using RescueMe.Refit.Models.Account;
using System.Net.Http.Headers;

namespace RescueMe.Client.Handlers
{
    public class AuthorizationHandler : DelegatingHandler
    {
        private readonly IAccountApi _accountApi;

        public AuthorizationHandler(IAccountApi accountApi)
        {
            _accountApi = accountApi;
        }

        protected override async Task<HttpResponseMessage> SendAsync(HttpRequestMessage request, CancellationToken cancellationToken)
        {
            var requestToken = new RefreshRequestModel
            {
                ClientId = "api",
                ClientSecret = "users-secret",
                GrantType = "refresh_token",
                Scope = "ApiScope",
                RefreshToken = Preferences.Get("refresh_token", "empty")
            };
            var token = await _accountApi.RefreshAsync(requestToken);

            request.Headers.Authorization = new AuthenticationHeaderValue("Bearer", token.AccessToken);

            return await base.SendAsync(request, cancellationToken);
        }
    }
}
