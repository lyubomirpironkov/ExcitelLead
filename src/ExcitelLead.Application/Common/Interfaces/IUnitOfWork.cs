namespace ExcitelLead.Application.Common.Interfaces
{
    public interface IUnitOfWork
    {
        ILeadRepository LeadRepository { get; }
    }
}
