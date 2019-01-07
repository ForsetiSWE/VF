using System;

namespace Umc.VigiFlow.Core.Ports
{
    public interface IPersistance
    {
        void Store<T>(T item, Guid id);
        T Get<T>(Guid id);
    }
}
