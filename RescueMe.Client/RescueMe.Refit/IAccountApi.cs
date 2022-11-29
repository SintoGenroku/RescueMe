using Refit;
using RescueMe.Refit.Models.Account;
using RescueMe.UserModels.Requests;
using RescueMe.UserModels.Responses;


namespace RescueMe.Refit
{
    public interface IAccountApi
    {
        [Post("/authentication/token")]
        Task<UserLoginResponseModel> LoginAsync([Body] UserLoginModel request);

        [Post("/authentication/token")]
        Task<UserLoginResponseModel> RefreshAsync([Body] RefreshRequestModel request);

        [Post("/authentication/registration")]
        Task RegisterAsync([Body] UserRegistrationModel request);

    }
}