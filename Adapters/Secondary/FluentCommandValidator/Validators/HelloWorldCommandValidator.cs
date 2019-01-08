using FluentValidation;
using Umc.VigiFlow.Core.Components.HelloWorldComponent.Application.Commands;

namespace Umc.VigiFlow.Adapters.Secondary.FluentCommandValidator.Validators
{
    class HelloWorldCommandValidator : AbstractValidator<HelloWorldCommand>
    {
        public HelloWorldCommandValidator()
        {
            // CommandId not Empty
            RuleFor(command => command.CommandId).NotEmpty();

            // HelloWorld not Empty
            RuleFor(command => command.HelloWorld).NotEmpty();
        }
    }
}
