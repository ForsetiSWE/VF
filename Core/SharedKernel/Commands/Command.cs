using System;

namespace Umc.VigiFlow.Core.SharedKernel.Commands
{
    public class Command : ICommand
    {
        #region Setup

        private readonly Guid commandId;

        public Command(Guid commandId)
        {
            this.commandId = commandId;
        }

        #endregion Setup
    }
}
