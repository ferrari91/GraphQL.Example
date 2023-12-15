using GraphQL.Example.Core.Application.Interface.Repositories;
using GraphQL.Example.Infrastructure.DataBase;
using Microsoft.EntityFrameworkCore;

namespace GraphQL.Example.Infrastructure.Repositories
{
    public class BaseRepository<T> : IBaseRepository<T> where T : class
    {
        private readonly DataContext _dataContext;

        public BaseRepository(DataContext dataContext)
        {
            _dataContext = dataContext;
        }

        public async Task<List<T>> GetAllAsync()
        {
            return await _dataContext.Set<T>().ToListAsync();
        }

        public async Task<T?> GetByIdAsync(int id)
        {
            return await _dataContext.Set<T>().FindAsync(id);
        }

        public async Task<T> AddAsync(T entity)
        {
            await _dataContext.Set<T>().AddAsync(entity);

            return entity;
        }

        public async Task<bool> SaveChangesAsync()
        {
            return await _dataContext.SaveChangesAsync() > 0;
        }

        public void Delete(T entity)
        {
            _dataContext.Set<T>().Remove(entity);
        }

        public void Update(T entity)
        {
            _dataContext.ChangeTracker.Clear();
            _dataContext.Entry(entity).State = EntityState.Modified;
        }
    }
}
