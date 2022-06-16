namespace ExcitelLead.Domain.Common
{
    public abstract class BaseEntity : IAggregateRoot
    {
        public int Id { get; set; }
    }
}
