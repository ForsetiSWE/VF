using System;
using FluentValidation;
using Umc.VigiFlow.Core.Components.CaseComponent.Application.Commands;

namespace Umc.VigiFlow.Adapters.Secondary.FluentCommandValidator.Validators
{
    class FollowUpCaseCommandValidator : AbstractValidator<FollowUpCaseCommand>
    {
        public FollowUpCaseCommandValidator()
        {
            // CommandId not Empty
            RuleFor(command => command.CommandId).NotEmpty();

            // CaseId not Empty
            RuleFor(command => command.CaseId).NotEmpty();

            // Revision not Empty
            RuleFor(command => command.Revision).NotEmpty();

            // Description not Empty
            RuleFor(command => command.Description).NotEmpty();

            // DateOfMostRecentInformation not Empty and not in the future
            RuleFor(command => command.DateOfMostRecentInformation).NotEmpty().LessThanOrEqualTo(DateTime.Now);
        }
    }
}
