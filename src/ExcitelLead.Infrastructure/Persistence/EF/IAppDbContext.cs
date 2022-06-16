using ExcitelLead.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace ExcitelLead.Infrastructure.Persistence.EF
{
    internal interface IAppDbContext
    {
        DbSet<Lead> Lead { get; }

        DbSet<SubArea> SubAreas { get; }
    }
}
