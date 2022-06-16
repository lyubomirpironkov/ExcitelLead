using ExcitelLead.Application.Common.Exceptions;
using ExcitelLead.Application.Common.Interfaces;
using ExcitelLead.Domain.Entities;
using MediatR;

namespace ExcitelLead.Application.Leads.Commands.UpdateLead
{
    public class UpdateLeadCommand : IRequest
    {
        public int Id { get; init; }

        public string Name { get; set; }

        public int SubAreaId { get; set; }

        public string Address { get; set; }

        public string? MobileNumber { get; set; }

        public string? Email { get; set; }
    }

    public class UpdateTodoItemCommandHandler : IRequestHandler<UpdateLeadCommand>
    {
        private readonly IUnitOfWork unitOfWork;

        public UpdateTodoItemCommandHandler(IUnitOfWorkEF unitOfWork)
        {
            this.unitOfWork = unitOfWork;
        }

        public async Task<Unit> Handle(UpdateLeadCommand request, CancellationToken cancellationToken)
        {
            var entity = await unitOfWork.LeadRepository.GetByIdAsync(request.Id);

            if (entity == null)
            {
                throw new NotFoundException(nameof(entity), request.Id);
            }

            entity.Address = request.Address;
            entity.MobileNumber = request.MobileNumber;
            entity.Email = request.Email;
            entity.SubAreaId = request.SubAreaId;
            entity.Modified = DateTime.Now;

            await unitOfWork.LeadRepository.Update(entity);

            return Unit.Value;
        }
    }
}
