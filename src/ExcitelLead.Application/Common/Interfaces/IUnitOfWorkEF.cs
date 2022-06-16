namespace ExcitelLead.Application.Common.Interfaces
{
    public interface IUnitOfWorkEF : IUnitOfWork
    {
        ISubAreaRepository SubAreaRepository { get; }
    }
}
