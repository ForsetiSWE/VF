using System;
using Umc.VigiFlow.Core.Components.CaseComponent.Application.Commands;
using Umc.VigiFlow.Core.Ports;
using Umc.VigiFlow.Core.SharedKernel.Events;

namespace Umc.VigiFlow.Core.Components.CaseComponent.Application.EventListeners
{
    class CaseAmendedEventListener : IEventListener<CaseAmendedEvent>
    {

        #region Setup
        private readonly ICommandBus commandBus;

        public CaseAmendedEventListener(ICommandBus commandBus)
        {
            this.commandBus = commandBus;
        }

        #endregion Setup

        #region IEventListener

        public void OnEvent(CaseAmendedEvent @event)
        {
            // Transform event to Command
            commandBus.Send(new CreateHistoricCaseCommand(Guid.NewGuid(), @event.CaseId, @event.Revision, @event.CommandId));
        }

        #endregion IEventListener
    }
}
