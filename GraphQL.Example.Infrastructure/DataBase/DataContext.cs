using GraphQL.Example.Core.Application.Extensions;
using GraphQL.Example.Core.Domain.Entity;
using Microsoft.EntityFrameworkCore;

namespace GraphQL.Example.Infrastructure.DataBase
{
    public class DataContext : DbContext
    {
        public DbSet<PersonEntity> Persons { get; set; }

        public DataContext(DbContextOptions<DataContext> options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            DataConfiguration<PersonEntity>.SetEntityBuilder(modelBuilder);

            modelBuilder.Entity<PersonEntity>().ToTable(nameof(PersonEntity).RemoveEntityName());
        }
    }
}
