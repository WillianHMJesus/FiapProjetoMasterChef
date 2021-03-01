using Domain;
using Microsoft.EntityFrameworkCore;

namespace Repository
{
    public interface IDbContext
    {
        DbSet<TEntity> Set<TEntity>() where TEntity : Entity;
        int SaveChanges();
    }
}
