using RescueMe.UserModels.Requests;

namespace RescueMe.Client.Services.Abstracts
{
    public interface IAuthenticationService
    {
        Task LoginAsync(UserLoginModel loginViewModel);
    }
}
