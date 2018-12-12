using Umc.VigiFlow.Core.Ports.Primary;
using Umc.VigiFlow.Core.Ports.Secondary;

namespace Umc.VigiFlow.Application
{
    public class Application
    {
        public ICommandBus CommandBus { get; }

        public Application(ICommandBus commandBus, IPersistance persistance)
        {
            CommandBus = commandBus;
            commandBus
            // Initilize DI

            
        }
    }
}
