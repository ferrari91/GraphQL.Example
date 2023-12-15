using GraphQL.Example.Core.Domain.Entity;
using GraphQL.Types;

namespace GraphQL.Example.Core.Domain.Types
{
    public class PersonType : ObjectGraphType<PersonEntity>
    {
        public PersonType()
        {
            Field(x => x.Id).Description("Id da pessoa.");
            Field(x => x.Name).Description("Nome completo da pessoa.");
            Field(x => x.Age).Description("Idade atual da pessoa.");
        }
    }
}
