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
            services.AddScoped<MongoDbContext<Candle>>(sp =>
                new MongoDbContext<Candle>(
                    sp.GetRequiredService<IMongoClient>(),
                    configuration["MongoDbSettings:DatabaseName"] ?? throw new ArgumentNullException(),
                    "candles"));

            // Repositories
            services.AddScoped(typeof(IBaseRepository<>), typeof(BaseRepository<>));

            services.AddScoped<ICandleRepository>(sp =>
                new CandleRepository(sp.GetRequiredService<MongoDbContext<Candle>>()));

            return services;
        }
    }
}
