using RescueMe.Client.Commands.Abstracts;
using RescueMe.Refit;
using RescueMe.UserModels;

namespace RescueMe.Client.Commands
{
    public class LoginCommand : CommandBase
    {
        private readonly IAccountApi _accountApi;

        public LoginCommand(IAccountApi accountApi)
        {
            _accountApi = accountApi;
        }

        public override async Task ExecuteAsync(object parameter)
        {
            var loginModel = (UserLoginModel)parameter;
            loginModel.ClientId = "rescue-client";
            loginModel.ClientSecret = "rescue-secret";
            loginModel.GrantType = "password";
            loginModel.Scope = "clientScope";
            
            var response = await _accountApi.LoginAsync(loginModel);

            //Preferences.Set(response.access_token, "jwt");
        }
    }
}
