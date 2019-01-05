using System;
using System.Web.Http;
using Umc.VigiFlow.Adapters.Secondary.CommandBus;
using Umc.VigiFlow.Adapters.Secondary.MongoDBPersistance;
using Umc.VigiFlow.Adapters.Secondary.SimpleEventBus;
using Umc.VigiFlow.Core.Components.Case.Application.Commands;
using Umc.VigiFlow.Core.Components.Case.Domain.Models;

namespace Umc.VigiFlow.Adapters.Primary.ApiApp.Controllers
{
    [RoutePrefix("case")]
    public class CaseController : ApiController
    {
        [Route("")]
        [HttpPost]
        public IHttpActionResult RegisterCase([FromBody]string description)
        {
            var application = new Application.Application(new CommandBus(), new Persistance("mongodb://localhost:27017"), new EventBus());

            application.Send(new RegisterCaseCommand(Guid.NewGuid(), new Case { Description = description }));
            return Ok();
        }
    }
}
