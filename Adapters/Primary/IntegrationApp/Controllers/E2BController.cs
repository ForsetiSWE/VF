using System;
using Microsoft.AspNetCore.Mvc;
using Umc.VigiFlow.Adapters.Primary.IntegrationApp.Models;
using Umc.VigiFlow.Core.Components.CaseComponent.Application.Commands;
using Umc.VigiFlow.Core.Ports;

namespace Umc.VigiFlow.Adapters.Primary.IntegrationApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class E2BController : ControllerBase
    {
        #region Setup

        private readonly ICommandBus commandBus;

        public E2BController(ICommandBus commandBus)
        {
            this.commandBus = commandBus;
        }

        #endregion Setup

        #region API

        // POST api/e2b
        [HttpPost]
        public void Post([FromBody] IchIcsr ichIcsr)
        {
            commandBus.Send(new ImportCaseCommand(Guid.NewGuid(), Guid.NewGuid(), $"{ichIcsr.SafetyReport.SafetyReportId} - {ichIcsr.SafetyReport.SafetyReportVersion}", DateTime.Now));
        }

        #endregion API
    }
}
