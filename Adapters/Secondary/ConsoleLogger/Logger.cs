using System;
using Umc.VigiFlow.Core.Ports;

namespace Umc.VigiFlow.Adapters.Secondary.ConsoleLogger
{
    class Logger : ILogger
    {
        public void Info(string message)
        {
            Console.WriteLine(message);
        }
    }
}
