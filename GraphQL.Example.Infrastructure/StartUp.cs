using GraphQL.Example.Infrastructure.DataBase;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace GraphQL.Example.Infrastructure
{
    public static class StartUp
    {
        public static async Task InfrastructureStartup(this IServiceProvider serviceProvider)
        {
            using( var scope = serviceProvider.CreateScope())
            {
                var services = scope.ServiceProvider.GetRequiredService<DataContext>();

                await services.Database.EnsureCreatedAsync();
                await services.Database.MigrateAsync();
            }
        }
    }
}
