using MongoAppWebAPI.Context;
using MongoAppWebAPI.Services.Abstraction;
using MongoAppWebAPI.Services.Implementation;

namespace MongoAppWebAPI.Registries
{
    public class CoreModule
    {
        public static void Register(IServiceCollection Services)
        {
            Services.AddScoped<MongoDBContext>();
            Services.AddScoped<IUnitOfWork, UnitOfWork>();
        }

    }
}
