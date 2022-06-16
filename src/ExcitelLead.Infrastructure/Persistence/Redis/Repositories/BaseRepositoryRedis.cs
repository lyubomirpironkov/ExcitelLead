using ExcitelLead.Application.Common.Interfaces;
using ExcitelLead.Domain.Common;
using StackExchange.Redis;
using System.Text.Json;

namespace ExcitelLead.Infrastructure.Persistence.Redis.Repositories
{
    internal class BaseRepositoryRedis<TEntity> : IRepository<TEntity> where TEntity : class, IAggregateRoot
    {
        protected readonly IConnectionMultiplexer Redis;
        private readonly string entityName;

        public BaseRepositoryRedis(IConnectionMultiplexer redis)
        {
            Redis = redis;
            entityName = (typeof(TEntity)).Name;
            if (!Exists(entityName + ":Id"))
            {
                Save(entityName + ":Id", "0");
            }
        }

        public async Task Add(TEntity entity)
        {
            var entityNameId = entityName + ":Id";
            var database = Redis.GetDatabase();
            var maxId = database.StringGet(entityNameId);
            if (maxId.TryParse(out int idValue))
            {
                entity.Id = idValue + 1;
                await Save(entity.Id.ToString(), JsonSerializer.Serialize(entity));
                database.StringIncrement(entityNameId, 1);
            }
            else
            {
                throw new InvalidCastException($"Invalid Id sequence for {entityName}");
            }
        }

        public async Task<TEntity> GetByIdAsync(object id)
        {
            var key = MakeKey(id.ToString());
            var database = Redis.GetDatabase();
            var serializedObject = await database.StringGetAsync(key);
            if (serializedObject.IsNullOrEmpty)
            {
                return null;
            };
            var options = new JsonSerializerOptions { PropertyNameCaseInsensitive = true };
            return JsonSerializer.Deserialize<TEntity>(serializedObject.ToString(), options);
        }

        private bool Exists(int id)
        {
            return Exists(id.ToString());
        }

        private bool Exists(string keySuffix)
        {
            var key = MakeKey(keySuffix);
            var database = Redis.GetDatabase();
            var serializedObject = database.StringGet(key);
            return !serializedObject.IsNullOrEmpty;
        }

        public async Task Remove(TEntity entity)
        {
            var database = Redis.GetDatabase();
            await database.StringGetDeleteAsync(MakeKey(entity.Id.ToString()));
        }

        public async Task Update(TEntity entity)
        {
            await Save(entity.Id.ToString(), JsonSerializer.Serialize(entity));
        }

        private async Task Save(string keySuffix, string value)
        {
            var key = MakeKey(keySuffix);
            var database = Redis.GetDatabase();
            await database.StringSetAsync(MakeKey(key), value);
        }

        private string MakeKey(string keySuffix)
        {
            if (!keySuffix.StartsWith(entityName + ":"))
            {
                return entityName + ":" + keySuffix;
            }
            else return keySuffix; //Key is already suffixed with namespace
        }
    }
}
