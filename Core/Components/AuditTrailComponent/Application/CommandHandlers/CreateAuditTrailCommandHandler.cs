﻿using Umc.VigiFlow.Core.Components.AuditTrailComponent.Application.Commands;
using Umc.VigiFlow.Core.Components.AuditTrailComponent.Application.Services;
using Umc.VigiFlow.Core.SharedKernel.Commands;
using Umc.VigiFlow.Core.SharedKernel.Models;

namespace Umc.VigiFlow.Core.Components.AuditTrailComponent.Application.CommandHandlers
{
    public class CreateAuditTrailCommandHandler : ICommandHandler<CreateAuditTrailCommand>
    {
        #region Setup
        private readonly ICreateAuditTrailService createAuditTrailService;

        public CreateAuditTrailCommandHandler(ICreateAuditTrailService createAuditTrailService)
        {
            this.createAuditTrailService = createAuditTrailService;
        }

        #endregion Setup

        #region ICommandHandler

        public void Handle(CreateAuditTrailCommand createAuditTrailCommand)
        {
            createAuditTrailService.CreateAuditTrail(new AuditTrail<Entity>(createAuditTrailCommand.CommandId,
                createAuditTrailCommand.Entity));
        }

        #endregion ICommandHandler
    }
}