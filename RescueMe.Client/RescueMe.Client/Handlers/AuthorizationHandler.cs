using RescueMe.Refit;

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
            var requestToken = new
            {
                client_id = "api",
                client_secret = "users-secret",
                grant_type = "client_credentials",
                scope = "ApiScope"
            };
            //var token = await _accountApi.LoginAsync(requestToken)

            //request.Headers.Authorization = new System.Net.Http.Headers.AuthenticationHeaderValue("Bearer", token);
            return await base.SendAsync(request, cancellationToken);
        }
    }
}
