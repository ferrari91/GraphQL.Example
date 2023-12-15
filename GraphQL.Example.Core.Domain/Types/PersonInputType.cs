using GraphQL.Example.Core.Domain.Entity;
using GraphQL.Types;

namespace GraphQL.Example.Core.Domain.Types
{

    public class PersonInputType : InputObjectGraphType<PersonEntity>
    {
        public PersonInputType()
        {
            Name = "PersonInclude";
            Field<NonNullGraphType<StringGraphType>>("name", description: "Nome completo da pessoa.");
            Field<NonNullGraphType<IntGraphType>>("age", description: "Idade atual da pessoa.");
        }
    }
}
