using ExcitelLead.Application.Common.Interfaces;
using ExcitelLead.Infrastructure.Persistence.Redis.Repositories;
using StackExchange.Redis;

namespace ExcitelLead.Infrastructure.Persistence.Redis
{
    internal class UnitOfWorkRedis : IUnitOfWorkRedis, IAsyncDisposable
    {
        protected readonly IConnectionMultiplexer redis;

        public ILeadRepository LeadRepository { get; private set; }

        public UnitOfWorkRedis(IConnectionMultiplexer redis)
        {
            this.redis = redis;
            LeadRepository = new LeadRepositoryRedis(this.redis);
        }

        public ValueTask DisposeAsync()
        {
            throw new NotImplementedException();
        }
    }
}
