using RescueMe.Common;
using RescueMe.Data.Contracts;

namespace RescueMe.Data.Repositories.Abstracts
{
    public interface IEmergencyRepository : IRepository<Emergency>
    {
        Task<Emergency> GetByTittleAsync(string tittle);
    }
}
