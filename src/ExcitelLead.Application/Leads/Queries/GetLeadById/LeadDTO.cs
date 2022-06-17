namespace ExcitelLead.Application.Leads.Queries.GetLeadById
{
    public class LeadDTO
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public int SubAreaId { get; set; }

        public string Address { get; set; }

        public string? MobileNumber { get; set; }

        public string? Email { get; set; }

        public DateTime Created { get; set; }

        public DateTime? Modified { get; set; }
    }
}
