using ExcitelLead.Application.Common.Interfaces;
using ExcitelLead.Infrastructure.Persistence.EF.Repositories;

namespace ExcitelLead.Infrastructure.Persistence.EF
{
    internal class UnitOfWorkEF : IUnitOfWorkEF, IAsyncDisposable
    {
        private readonly AppDbContext context;

        public ILeadRepository LeadRepository { get; private set; }
        public ISubAreaRepository SubAreaRepository { get; private set; }

        public UnitOfWorkEF(AppDbContext context)
        {
            this.context = context;

            LeadRepository = new LeadRepositoryEF(this.context);
            SubAreaRepository = new SubAreaRepositoryEF(this.context);
        }

        public async Task<int> SaveAsync()
        {
            return await context.SaveChangesAsync().ConfigureAwait(false);
        }

        public async Task<int> SaveAsync(CancellationToken cancellationToken)
        {
            return await context.SaveChangesAsync(cancellationToken).ConfigureAwait(false);
        }

        public ValueTask DisposeAsync()
        {
            return context.DisposeAsync();
        }
    }
}
