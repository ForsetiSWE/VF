﻿using System.Collections.Generic;
using System.Linq;
using Umc.VigiFlow.Core.Components.Case.Application.Commands;
using Umc.VigiFlow.Core.SharedKernel.Command;

namespace Umc.VigiFlow.Adapters.Secondary.CommandBus
{
    class HardCodedCommandHandlerFactory
    {
        private static readonly IList<ICommandHandler<ICommand>> Handlers = new List<ICommandHandler<ICommand>>
        {
            new RegisterCaseCommandHandler()
        };

        private ICommandHandler<T> GetHandler<T>() where T : ICommand
        {
            var cmdHandler = (ICommandHandler<T>)Handlers.FirstOrDefault(handler => handler is ICommandHandler<T>);

            return cmdHandler;
        }

    }

}
