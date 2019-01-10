using System;

namespace Umc.VigiFlow.Core.SharedKernel.Commands
{
    public class Command : ICommand
    {
        #region Setup

        private readonly Guid? originFromCommandId;
        private readonly Guid commandId;

        public Command(Guid commandId, Guid? originFromCommandId)
        {
            this.commandId = commandId;
            this.originFromCommandId = originFromCommandId;
        }

        #endregion Setup

        #region ICommand

        public Guid CommandId => originFromCommandId ?? commandId;

        #endregion ICommand
    }
}
