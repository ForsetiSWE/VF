using System;
using Umc.VigiFlow.Core.Components.CaseComponent.Application.Commands;
using Umc.VigiFlow.Core.Ports;
using Umc.VigiFlow.Core.SharedKernel.Events;

namespace Umc.VigiFlow.Core.Components.CaseComponent.Application.EventListeners
{
    class CaseRegisteredEventListener : IEventListener<CaseRegisteredEvent>
    {

        #region Setup
        private readonly ICommandBus commandBus;

        public CaseRegisteredEventListener(ICommandBus commandBus)
        {
            this.commandBus = commandBus;
        }

        #endregion Setup

        #region IEventListener

        public void OnEvent(CaseRegisteredEvent @event)
        {
            // Transform event to Command
            commandBus.Send(new CreateHistoricCaseCommand(Guid.NewGuid(), @event.CaseId, @event.Revision, @event.CommandId));
        }

        #endregion IEventListener
    }
}
