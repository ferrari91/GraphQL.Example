using GraphQL.Example.Core.Application.Interface.Repositories;
using GraphQL.Example.Core.Domain.Entity;
using GraphQL.Example.Core.Domain.Types;
using GraphQL.Types;

namespace GraphQL.Example.Core.Application.Person.Command
{
    public class PersonMutation : ObjectGraphType
    {
        public PersonMutation(IPersonRepository personRepository)
        {
            Name = nameof(PersonMutation);

            FieldAsync<IntGraphType>("createPerson",
           arguments: new QueryArguments(
               new QueryArgument<NonNullGraphType<PersonInputType>> { Name = "person" }
           ),
           resolve: async context =>
           {
               var person = context.GetArgument<PersonEntity>("person");
               var data = await personRepository.AddAsync(person);

               await personRepository.SaveChangesAsync();

               return data.Id;
           }
       );
        }
    }
}
