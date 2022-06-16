using ExcitelLead.Application.Common.Interfaces;
using ExcitelLead.Domain.Entities;

namespace ExcitelLead.Infrastructure.Persistence.EF.Repositories
{
    internal class LeadRepositoryEF : BaseRepositoryEF<Lead>, ILeadRepository
    {
        public LeadRepositoryEF(AppDbContext context) : base(context)
        {

        }

        public AppDbContext AppDbContext
        {
            get { return Context as AppDbContext; }
        }

        //Customizing Add, Update, Detele here
    }
}
