using System.ComponentModel.DataAnnotations;

namespace GraphQL.Example.Core.Domain.Common
{
    public class BaseEntity
    {
        [Key]
        public int Id { get; set; }
    }
}
