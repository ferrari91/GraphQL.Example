using GraphQL.Example.Infrastructure.DataBase;
using GraphQL.Example.Infrastructure.Schemas;
using GraphQL.Server.Transports.AspNetCore;
using GraphQL.Server.Ui.Playground;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Routing;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace GraphQL.Example.Infrastructure
{
    public static class StartUp
    {
        public static async Task InfrastructureStartup(this IServiceProvider serviceProvider)
        {
            using (var scope = serviceProvider.CreateScope())
            {
                var services = scope.ServiceProvider.GetRequiredService<DataContext>();

                await services.Database.EnsureCreatedAsync();
                await services.Database.MigrateAsync();
            }
        }

        public static void InfrastructureBuilder(this IApplicationBuilder _, IEndpointRouteBuilder endpoint, IConfiguration config)
        {
            endpoint.MapGraphQL<PersonSchema, GraphQLHttpMiddleware<PersonSchema>>("/graphql");
            endpoint.MapGraphQLPlayground(
                new PlaygroundOptions
                {
                    GraphQLEndPoint = config["ROUTE_PREFIX"] + "/graphql"
                }, "/ui/graphql");
        }
    }
}
