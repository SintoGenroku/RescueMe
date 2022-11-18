using Refit;
using RescueMe.UserModels;

namespace RescueMe.Refit
{
    public interface IAccountApi
    {
        [Post("/connect/token")]
        Task<object> LoginAsync([Body] UserLoginModel request);
    }
}