using System;
using System.Collections.Generic;
using System.Linq;
using Autofac;
using FluentValidation;
using Umc.VigiFlow.Core.Ports;
using Umc.VigiFlow.Core.SharedKernel.Commands;

namespace Umc.VigiFlow.Adapters.Secondary.FluentCommandValidator
{
    public class CommandValidator : ICommandValidator
    {

        #region Setup
        private readonly IComponentContext componentContext;
        public CommandValidator(IComponentContext componentContext)
        {
            this.componentContext = componentContext;
        }

        #endregion Setup
        
        #region ICommandValidator

        public void Validate<TCommand>(TCommand command) where TCommand : ICommand
        {
            // Get validators for TCommand
            var validators = componentContext.Resolve<IEnumerable<IValidator<TCommand>>>();

            // Run validators
            var failures = validators
                .Select(v => v.Validate(command))
                .SelectMany(result => result.Errors)
                .Where(error => error != null)
                .ToList();

            if (failures.Any())
            {
                // Validation failures, throw exception
                throw new ArgumentException(
                    $"Command Validation Errors for type {typeof(TCommand).Name}", new ValidationException("Validation exception", failures));
            }
        }

        #endregion ICommandValidator
    }
}
