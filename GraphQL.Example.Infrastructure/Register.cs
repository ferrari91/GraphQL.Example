using GraphQL.Example.Infrastructure.DataBase;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace GraphQL.Example.Infrastructure
{
    public static class Register
    {
        public static void InfrastructureRegister(this IServiceCollection services)
        {
            var path = Path.GetDirectoryName(System.Reflection.Assembly.GetExecutingAssembly().Location);

            services.AddDbContext<DataContext>(options =>
               options.UseSqlite($"Data Source={path}\\database.db"));
        }
    }
}
