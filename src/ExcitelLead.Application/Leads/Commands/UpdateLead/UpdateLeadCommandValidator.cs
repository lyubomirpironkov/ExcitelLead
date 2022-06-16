using FluentValidation;

namespace ExcitelLead.Application.Leads.Commands.UpdateLead
{
    internal class UpdateLeadCommandValidator : AbstractValidator<UpdateLeadCommand>
    {
        public UpdateLeadCommandValidator()
        {
            RuleFor(v => v.Address)
                .MaximumLength(255)
                .NotEmpty();

            RuleFor(v => v.Name)
                .MaximumLength(255)
                .NotEmpty();

            RuleFor(v => v.SubAreaId)
                .GreaterThan(0);
        }
    }
}
