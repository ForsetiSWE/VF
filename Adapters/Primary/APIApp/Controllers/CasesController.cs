using System;
using Microsoft.AspNetCore.Mvc;
using Umc.VigiFlow.Core.Components.CaseComponent.Application.Commands;
using Umc.VigiFlow.Core.Components.CaseComponent.Domain.Models;
using Umc.VigiFlow.Core.Ports;

namespace Umc.VigiFlow.Adapters.Primary.APIApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CasesController : ControllerBase
    {
        #region Setup

        private readonly ICommandBus commandBus;

        public CasesController(ICommandBus commandBus)
        {
            this.commandBus = commandBus;
        }

        #endregion Setup

        #region API

        // POST api/cases
        [HttpPost]
        public void Post([FromBody] string description)
        {
            commandBus.Send(new RegisterCaseCommand(Guid.NewGuid(), new Case { Description = description }));
        }

        #endregion API
    }
}
