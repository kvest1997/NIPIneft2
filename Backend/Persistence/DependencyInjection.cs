using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Application.Interfaces;
using Microsoft.Extensions.Configuration;


namespace Persistence
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddPersistence(this IServiceCollection services,
            IConfiguration configuration)
        {
            var connectionString = configuration["DbConnection"];
            services.AddDbContext<ParticipantDbContext>(options =>
            {
                options.UseSqlServer(connectionString);
            });

            services.AddScoped<IParticipantDbContext>(provider =>
            provider.GetService<ParticipantDbContext>());
            return services;
        }
    }
}
