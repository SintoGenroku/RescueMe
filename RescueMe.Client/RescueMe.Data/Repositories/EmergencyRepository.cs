using Microsoft.EntityFrameworkCore;
using RescueMe.Common;
using RescueMe.Data.Core;
using RescueMe.Data.Repositories.Abstracts;

namespace RescueMe.Data.Repositories
{
    public class EmergencyRepository : Repository<Emergency>, IEmergencyRepository
    {
        public EmergencyRepository(RescueMeDbContext context) : base(context)
        {
        }

        public async Task<Emergency> GetByTittleAsync(string tittle)
        {
            var emergency = await Data.FirstOrDefaultAsync(e => e.Tittle == tittle);

            return emergency;
        }
    }
}
