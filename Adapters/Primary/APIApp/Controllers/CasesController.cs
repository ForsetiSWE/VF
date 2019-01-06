using System;
using Microsoft.AspNetCore.Mvc;
using Umc.VigiFlow.Adapters.Secondary.CommandBus;
using Umc.VigiFlow.Adapters.Secondary.MongoDBPersistance;
using Umc.VigiFlow.Adapters.Secondary.SimpleEventBus;
using Umc.VigiFlow.Application;
using Umc.VigiFlow.Core.Components.Case.Application.Commands;
using Umc.VigiFlow.Core.Components.Case.Domain.Models;

namespace Umc.VigiFlow.Adapters.Primary.APIApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CasesController : ControllerBase
    {
        // POST api/cases
        [HttpPost]
        public void Post([FromBody] string description)
        {
            var application = new VigiFlowCore(new CommandBus(), new Persistance("mongodb://localhost:27017"), new EventBus());

            application.Send(new RegisterCaseCommand(Guid.NewGuid(), new Case { Description = description }));
        }
    }
}
