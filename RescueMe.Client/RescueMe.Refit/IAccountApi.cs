using Refit;
using RescueMe.Refit.Models.Account;
using RescueMe.UserModels.Requests;
using RescueMe.UserModels.Responses;


namespace RescueMe.Refit
{
    public interface IAccountApi
    {
        [Post("/authentication-api/token")]
        Task<UserLoginResponseModel> LoginAsync([Body] UserLoginModel request);

        [Post("/authentication-api/token")]
        Task<UserLoginResponseModel> RefreshAsync([Body] RefreshRequestModel request);

        [Post("/authentication-api/registration")]
        Task RegisterAsync([Body] UserRegistrationModel request);

    }
}