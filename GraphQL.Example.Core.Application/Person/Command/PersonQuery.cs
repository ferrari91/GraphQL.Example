using GraphQL.Example.Core.Application.Interface.Repositories;
using GraphQL.Example.Core.Domain.Entity;
using GraphQL.Example.Core.Domain.Types;
using GraphQL.Types;
using Microsoft.AspNetCore.Http;

namespace GraphQL.Example.Core.Application.Person.Command
{
    public class PersonQuery : ObjectGraphType
    {
        public PersonQuery(IPersonRepository personRepository)
        {
            Name = nameof(PersonQuery);

            FieldAsync<PersonType>("person",
                arguments:
                new QueryArguments(
                    new QueryArgument<IntGraphType> { Name = "id", Description = "Código da Pessoa" }),
                resolve: async context =>
                {
                    var personId = context.GetArgument<int>("id");

                    var person = await personRepository.GetByIdAsync(personId);

                    return person is null ? default : person;
                });

            FieldAsync<ListGraphType<PersonType>>("persons",
                resolve: async context =>
                {
                    var persons = await personRepository.GetAllAsync();

                    return persons is null ? default : persons;
                });
        }
    }
}