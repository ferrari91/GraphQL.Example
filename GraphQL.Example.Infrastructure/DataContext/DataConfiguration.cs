using GraphQL.Example.Core.Domain.Common;
using Microsoft.EntityFrameworkCore;

namespace GraphQL.Example.Infrastructure.DataContext
{
    public class DataConfiguration<T> where T : BaseEntity
    {
        public static void SetEntityBuilder(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<T>().Property(entity => entity.Id).IsRequired()
                         .ValueGeneratedOnAdd();

            modelBuilder.Entity<T>().HasIndex(entity => entity.Id).IsUnique();
        }
    }
}
