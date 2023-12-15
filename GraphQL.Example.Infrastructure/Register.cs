using GraphQL.Example.Core.Application.Interface.Repositories;
using GraphQL.Example.Core.Application.Person.Command;
using GraphQL.Example.Core.Domain.Types;
using GraphQL.Example.Infrastructure.DataBase;
using GraphQL.Example.Infrastructure.Repositories;
using GraphQL.Example.Infrastructure.Schemas;
using GraphQL.Server;
using Microsoft.EntityFrameworkCore;
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

            services.Repositories();
            services.GraphqlSchemasQueriesTypes();

            services.GraphqlConfiguration();
        }

        public static void GraphqlConfiguration(this IServiceCollection services)
        {
            services
                .AddGraphQL((opt, _) =>
                {
                    opt.EnableMetrics = true;
                })
                .AddSystemTextJson()
                .AddErrorInfoProvider(x => x.ExposeExceptionStackTrace = true)
                .AddGraphTypes(typeof(PersonSchema).Assembly)
                .AddDataLoader();
        }

        private static void Repositories(this IServiceCollection services)
        {
            services.AddScoped(typeof(IBaseRepository<>), typeof(BaseRepository<>));
            services.AddScoped<IPersonRepository, PersonRepository>();
        }

        private static void GraphqlSchemasQueriesTypes(this IServiceCollection services)
        {
            services.AddScoped<PersonType>();
            services.AddScoped<PersonQuery>();

            services.AddScoped<PersonInputType>();
            services.AddScoped<PersonMutation>();

            services.AddScoped<PersonSchema>();
        }
    }
}