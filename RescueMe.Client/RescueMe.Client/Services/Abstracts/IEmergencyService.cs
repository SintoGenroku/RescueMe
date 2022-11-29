using RescueMe.Common;

namespace RescueMe.Client.Services.Abstracts
{
    public interface IEmergencyService
    {
        Task<List<Emergency>> GetAllAsync();

        Task<Emergency> GetById(Guid id);

        Task<Emergency> GetByTittle(string tittle);
    }
}
