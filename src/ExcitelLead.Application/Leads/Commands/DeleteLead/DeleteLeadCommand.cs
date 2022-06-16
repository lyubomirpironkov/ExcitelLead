using ExcitelLead.Application.Common.Exceptions;
using ExcitelLead.Application.Common.Interfaces;
using MediatR;

namespace ExcitelLead.Application.Leads.Commands.DeleteLead
{
    public record DeleteLeadCommand(int Id) : IRequest;

    public class DeleteLeadCommandHandler : IRequestHandler<DeleteLeadCommand>
    {
        private readonly IUnitOfWork unitOfWork;

        public DeleteLeadCommandHandler(IUnitOfWorkEF unitOfWork)
        {
            this.unitOfWork = unitOfWork;
        }

        public async Task<Unit> Handle(DeleteLeadCommand request, CancellationToken cancellationToken)
        {

            var entity = await unitOfWork.LeadRepository.GetByIdAsync(request.Id);

            if (entity == null)
            {
                throw new NotFoundException(nameof(entity), request.Id);
            }

            await unitOfWork.LeadRepository.Remove(entity);

            return Unit.Value;
        }
    }
}
