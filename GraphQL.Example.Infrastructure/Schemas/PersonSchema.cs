using GraphQL.Example.Core.Application.Interface.Repositories;
using GraphQL.Example.Core.Application.Person.Command;

namespace GraphQL.Example.Infrastructure.Schemas
{
    public class PersonSchema : GraphQL.Types.Schema
    {
        public PersonSchema(IPersonRepository personRepository, IServiceProvider services) : base(services)
        {
            Query = new PersonQuery(personRepository);
            Mutation = new PersonMutation(personRepository);
        }
    }
}