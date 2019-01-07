using System;
using Microsoft.AspNetCore.Mvc;
using Umc.VigiFlow.Core.Components.CaseComponent.Application.Commands;
using Umc.VigiFlow.Core.Ports;

namespace Umc.VigiFlow.Adapters.Primary.APIApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CasesController : ControllerBase
    {
        public class NewCase
        {
            public string Description { get; set; }
            public DateTime InitialDate { get; set; }
        }

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
        public void Post([FromBody] NewCase newCase)
        {
            commandBus.Send(new RegisterCaseCommand(Guid.NewGuid(), Guid.NewGuid(), newCase.Description, newCase.InitialDate));
        }

        #endregion API
    }
}
