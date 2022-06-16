using ExcitelLead.Application.Common.Interfaces;
using ExcitelLead.Domain.Entities;
using MediatR;

namespace ExcitelLead.Application.Leads.Commands.CreateLead
{
    public class CreateLeadCommand : IRequest<int>
    {
        public string Name { get; set; }

        public int SubAreaId { get; set; }

        public string Address { get; set; }

        public string? MobileNumber { get; set; }

        public string? Email { get; set; }
    }

    public class CreateLeadCommandHandler : IRequestHandler<CreateLeadCommand, int>
    {
        private readonly IUnitOfWork unitOfWork;

        public CreateLeadCommandHandler(IUnitOfWorkEF unitOfWork)
        {
            this.unitOfWork = unitOfWork;
        }

        public async Task<int> Handle(CreateLeadCommand request, CancellationToken cancellationToken)
        {
            var entity = new Lead
            {
                Address = request.Address,
                Email = request.Email,
                MobileNumber = request.MobileNumber,
                Name = request.Name,
                SubAreaId = request.SubAreaId,
                Created = DateTime.Now
            };

            await unitOfWork.LeadRepository.Add(entity);

            return entity.Id;
        }
    }
}
