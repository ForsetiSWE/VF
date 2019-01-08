using System;
using FluentValidation;
using Umc.VigiFlow.Core.Components.CaseComponent.Application.Commands;

namespace Umc.VigiFlow.Adapters.Secondary.FluentCommandValidator.Validators
{
    class RegisterCaseCommandValidator : AbstractValidator<RegisterCaseCommand>
    {
        public RegisterCaseCommandValidator()
        {
            // CommandId not Empty
            RuleFor(command => command.CommandId).NotEmpty();

            // CaseId not Empty
            RuleFor(command => command.CaseId).NotEmpty();

            // Description not Empty
            RuleFor(command => command.Description).NotEmpty();
            
            // InitialDate not Empty and not in the future
            RuleFor(command => command.InitialDate).NotEmpty().LessThanOrEqualTo(DateTime.Now);
        }
    }
}
