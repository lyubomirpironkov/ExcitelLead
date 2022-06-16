namespace ExcitelLead.Domain.Entities
{
    public class Lead : AuditableEntity
    {
        public string Name { get; set; }

        public int SubAreaId { get; set; }

        public string Address { get; set; }

        public string? MobileNumber { get; set; }

        public string? Email { get; set; }
    }
}
