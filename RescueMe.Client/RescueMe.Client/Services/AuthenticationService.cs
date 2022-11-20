using RescueMe.Client.Services.Abstracts;
using RescueMe.Refit;
using RescueMe.UserModels.Requests;

namespace RescueMe.Client.Services
{
    public class AuthenticationService : IAuthenticationService
    {
        private readonly IAccountApi _accountApi;

        public AuthenticationService(IAccountApi accountApi)
        {
            _accountApi = accountApi;
        }

        public async Task LoginAsync(UserLoginModel loginViewModel)
        {
            var loginRequest = loginViewModel;
            loginRequest.ClientId = "rescue-client";
            loginRequest.ClientSecret = "rescue-secret";
            loginRequest.GrantType = "password";
            loginRequest.Scope = "clientScope";

            var response = await _accountApi.LoginAsync(loginRequest);

            Preferences.Set(response.AccessToken, "acces_token");
            Preferences.Set(response.RefreshToken, "refreash_token");
            Preferences.Set(response.Scope, "scope");
            Preferences.Set(response.TokenType, "token_type");

        }

        public async Task RegisterAsync(UserRegistrationModel registrationViewModel)
        {
            await _accountApi.RegisterAsync(registrationViewModel);
        }
    }
}
