using FluentValidation;
using Umc.VigiFlow.Core.Components.CaseComponent.Application.Commands;

namespace Umc.VigiFlow.Adapters.Secondary.FluentCommandValidator.Validators
{
    class AmendCaseCommandValidator : AbstractValidator<AmendCaseCommand>
    {
        public AmendCaseCommandValidator()
        {
            // CommandId not Empty
            RuleFor(command => command.CommandId).NotEmpty();

            // CaseId not Empty
            RuleFor(command => command.CaseId).NotEmpty();

            // Revision not Empty
            RuleFor(command => command.Revision).NotEmpty();

            // Description not Empty
            RuleFor(command => command.Description).NotEmpty();
        }
    }
}
