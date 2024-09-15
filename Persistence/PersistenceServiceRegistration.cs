using Candlify.Application.Contracts.Persistence;
using Candlify.Domain.Entities;
using Candlify.Persistence.Repositories;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using MongoDB.Driver;

namespace Candlify.Persistence
{
    public static class PersistenceServiceRegistration
    {
        public static IServiceCollection AddPersistenceServices(this IServiceCollection services,
            IConfiguration configuration)
        {
            services.AddSingleton<IMongoClient>(new MongoClient(configuration["MongoDbSettings:ConnectionString"] ?? throw new ArgumentNullException()));

            // DbContext
            services.AddScoped<MongoDbContext<Event>>(sp =>
                new MongoDbContext<Event>(
                    sp.GetRequiredService<IMongoClient>(),
                    configuration["MongoDbSettings:DatabaseName"] ?? throw new ArgumentNullException(),
                    "events"));

            // Repositories
            services.AddScoped(typeof(IBaseRepository<>), typeof(BaseRepository<>));

            services.AddScoped<IEventRepository>(sp =>
                new EventRepository(sp.GetRequiredService<MongoDbContext<Event>>()));

            return services;
        }
    }
}
