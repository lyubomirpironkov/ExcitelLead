using ExcitelLead.Application.Common.Interfaces;
using ExcitelLead.Domain.Entities;

namespace ExcitelLead.Infrastructure.Persistence.EF.Repositories
{
    internal class SubAreaRepositoryEF : BaseRepositoryEF<SubArea>, ISubAreaRepository
    {
        public SubAreaRepositoryEF(AppDbContext context) : base(context)
        {

        }

        public AppDbContext AppDbContext
        {
            get { return Context as AppDbContext; }
        }

        //Customizing Add, Update, Detele here
    }
}
