using System;

namespace Umc.VigiFlow.Core.SharedKernel.Commands
{
    public class Command : ICommand
    {
        #region Setup

        public Command(Guid commandId)
        {
            CommandId = commandId;
        }

        #endregion Setup

        #region ICommand

        public Guid CommandId { get; }

        #endregion ICommand
    }
}
