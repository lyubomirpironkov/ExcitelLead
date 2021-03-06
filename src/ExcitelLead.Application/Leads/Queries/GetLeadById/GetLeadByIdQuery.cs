using ExcitelLead.Application.Common.Exceptions;
using ExcitelLead.Application.Common.Interfaces;
using MediatR;

namespace ExcitelLead.Application.Leads.Queries.GetLeadById
{
    public class GetLeadByIdQuery : IRequest<LeadDTO>
    {
        public int Id { get; set; }
    }

    public class GetLeadByIdQueryHandler : IRequestHandler<GetLeadByIdQuery, LeadDTO>
    {
        private readonly IUnitOfWork unitOfWork;

        public GetLeadByIdQueryHandler(IUnitOfWork unitOfWork)
        {
            this.unitOfWork = unitOfWork;
        }

        public async Task<LeadDTO> Handle(GetLeadByIdQuery request, CancellationToken cancellationToken)
        {
            var leadEntity = await unitOfWork.LeadRepository.GetByIdAsync(request.Id);

            if (leadEntity == null)
            {
                throw new NotFoundException("Lead", request.Id);
            }

            return new LeadDTO
            {
                Id = leadEntity.Id,
                Address = leadEntity.Address,
                Email = leadEntity.Email,
                MobileNumber = leadEntity.MobileNumber,
                Name = leadEntity.Name,
                SubAreaId = leadEntity.SubAreaId,
                Created = leadEntity.Created,
                Modified = leadEntity.Modified
            };
        }
    }
}
