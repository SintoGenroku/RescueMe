using RescueMe.Client.Services.Abstracts;
using RescueMe.Common;
using RescueMe.Data.Repositories.Abstracts;

namespace RescueMe.Client.Services
{
    public class EmergencyService : IEmergencyService
    {
        private readonly IEmergencyRepository _emergencyRepository;

        public EmergencyService(IEmergencyRepository emergencyRepository)
        {
            _emergencyRepository = emergencyRepository;
        }

        public async Task<List<Emergency>> GetAllAsync()
        {
            var emergencies = await _emergencyRepository.GetAllAsync();

            return emergencies;
        }

        public async Task<Emergency> GetById(Guid id)
        {
            var emergency = await _emergencyRepository.FindByIdAsync(id);

            return emergency;
        }

        public async Task<Emergency> GetByTittle(string tittle)
        {
            var emergency = await _emergencyRepository.GetByTittleAsync(tittle);

            return emergency;
        }
    }
}
