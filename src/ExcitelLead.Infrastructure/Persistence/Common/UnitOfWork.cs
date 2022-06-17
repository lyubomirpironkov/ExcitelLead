using ExcitelLead.Application.Common.Interfaces;


namespace ExcitelLead.Infrastructure.Persistence.Common
{
    internal class UnitOfWork : IUnitOfWork
    {
        public ILeadRepository LeadRepository { get; private set; }

        public UnitOfWork(ILeadRepository leadRepository)
        {
            this.LeadRepository = leadRepository;
        }
    }
}
