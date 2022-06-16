using ExcitelLead.Application.Common.Interfaces;
using ExcitelLead.Domain.Common;
using Microsoft.EntityFrameworkCore;

namespace ExcitelLead.Infrastructure.Persistence.EF.Repositories
{
    internal class BaseRepositoryEF<TEntity> : IRepository<TEntity> where TEntity : class, IAggregateRoot
    {
        protected readonly DbContext Context;

        private readonly DbSet<TEntity> dbSet;

        public BaseRepositoryEF(DbContext context)
        {
            Context = context;

            if (context != null)
            {
                dbSet = context.Set<TEntity>();
            }
        }

        public virtual async Task Add(TEntity entity)
        {
            dbSet.Add(entity);
            await Context.SaveChangesAsync();
        }

        public virtual async Task Remove(TEntity entity)
        {
            dbSet.Remove(entity);
            await Context.SaveChangesAsync();
        }

        public virtual async Task Update(TEntity entity)
        {
            dbSet.Update(entity);
            await Context.SaveChangesAsync();
        }

        public async Task<TEntity> GetByIdAsync(object id)
        {
            return await dbSet.FindAsync(id).ConfigureAwait(false);
        }
    }
}
