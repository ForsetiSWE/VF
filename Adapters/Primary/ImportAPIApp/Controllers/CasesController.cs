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

        public class ChangedCase
        {
            public Guid CaseId { get; set; }
            public int Revision { get; set; }
            public string Description { get; set; }
            public DateTime DateOfMostRecentInformation { get; set; }
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

        // Put api/cases
        [HttpPut]
        public void AmendCase([FromBody] ChangedCase changedCase)
        {
            // The Controller can't contain equal requests hence the if here, could be solved in many different ways... other verbs, routing...
            if (changedCase.DateOfMostRecentInformation != DateTime.MinValue)
            {
                // We got a date, its an follow-up
                commandBus.Send(new FollowUpCaseCommand(Guid.NewGuid(), changedCase.CaseId, changedCase.Revision, changedCase.Description, changedCase.DateOfMostRecentInformation));
            }
            else
            {
                // Got no date its an amendment
                commandBus.Send(new AmendCaseCommand(Guid.NewGuid(), changedCase.CaseId, changedCase.Revision, changedCase.Description));
            }
        }

        #endregion API
    }
}
