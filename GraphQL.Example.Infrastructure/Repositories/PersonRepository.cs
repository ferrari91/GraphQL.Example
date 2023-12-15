using GraphQL.Example.Core.Application.Interface.Repositories;
using GraphQL.Example.Core.Domain.Entity;
using GraphQL.Example.Infrastructure.DataBase;

namespace GraphQL.Example.Infrastructure.Repositories
{
    public class PersonRepository : BaseRepository<PersonEntity>, IPersonRepository
    {
        public PersonRepository(DataContext dataContext) : base(dataContext)
        {
        }
    }
}
