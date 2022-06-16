using FluentValidation;

namespace ExcitelLead.Application.Leads.Commands.CreateLead
{
    internal class CreateLeadCommandValidator : AbstractValidator<CreateLeadCommand>
    {
        public CreateLeadCommandValidator()
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
