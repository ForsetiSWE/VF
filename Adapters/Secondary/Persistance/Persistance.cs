using System;
using Umc.VigiFlow.Core.Ports.Secondary;

namespace Umc.VigiFlow.Adapters.Secondary.Persistance
{
    public class Persistance : IPersistance
    {
        public T Store<T>(T item)
        {
            throw new NotImplementedException();
        }
    }
}
