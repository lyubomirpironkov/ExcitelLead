namespace ExcitelLead.Domain.Common
{
    public abstract class AuditableEntity : BaseEntity
    {
        public DateTime Created { get; set; } = DateTime.Now;

        public DateTime? Modified { get; set; }
    }
}
