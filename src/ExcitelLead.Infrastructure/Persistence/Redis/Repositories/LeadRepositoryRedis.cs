using ExcitelLead.Application.Common.Interfaces;
using ExcitelLead.Domain.Entities;
using StackExchange.Redis;

namespace ExcitelLead.Infrastructure.Persistence.Redis.Repositories
{
    internal class LeadRepositoryRedis : BaseRepositoryRedis<Lead>, ILeadRepository
    {
        public LeadRepositoryRedis(IConnectionMultiplexer redis) : base(redis)
        {

        }

        public ConnectionMultiplexer ConnectionMultiplexer
        {
            get { return Redis as ConnectionMultiplexer; }
        }

        //Customizing Add, Update, Detele here
    }
}
