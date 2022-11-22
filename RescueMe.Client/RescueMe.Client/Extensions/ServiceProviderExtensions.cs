using RescueMe.Data;
using RescueMe.Data.Repositories.Abstracts;

namespace RescueMe.Client.Extensions
{
    public static class ServiceProviderExtensions
    {
        public static async Task CreateDatabaseIfNotExists(this IServiceProvider serviceProvider)
        {
            using (var scope = serviceProvider.CreateScope())
            {
                var services = scope.ServiceProvider;
                try
                {
                    var context = services.GetRequiredService<RescueMeDbContext>();
                    var emergencyRepository = services.GetRequiredService<IEmergencyRepository>();

                    await DataInitializer.Initialize(context,emergencyRepository);
                }
                catch (Exception ex)
                {
                    throw new Exception(ex.Message);
                }
            }
        }
    }
}
