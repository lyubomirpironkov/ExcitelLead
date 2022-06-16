using ExcitelLead.Domain.Common;

namespace ExcitelLead.Application.Common.Interfaces
{
    public interface IRepository<TEntity> where TEntity : IAggregateRoot
    {
        Task Add(TEntity entity);

        Task Remove(TEntity entity);

        Task Update(TEntity entity);

        Task<TEntity> GetByIdAsync(object id);
    }
}
