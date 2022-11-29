using Refit;
using RescueMe.HelpModels.RequestModels;

namespace RescueMe.Refit
{
    public interface ILifeguardApi
    {
        [Post("/api/help")]
        Task CallLifeguardAsync(HelpRequestModel request);
    }
}
