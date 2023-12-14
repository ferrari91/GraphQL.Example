using GraphQL.Example.Core.Domain.Common;

namespace GraphQL.Example.Core.Domain.Entity
{
    public class PersonEntity : BaseEntity
    {
        public string Name { get; set; }
        public int Age { get; set; }
    }
}
