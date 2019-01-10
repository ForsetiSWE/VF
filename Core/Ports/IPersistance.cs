using System;
using Umc.VigiFlow.Core.SharedKernel.Models;

namespace Umc.VigiFlow.Core.Ports
{
    public interface IPersistance
    {
        void Store<T>(Guid commandId, T entity) where T : Entity;

        T Get<T>(Guid id, int revision);
    }
}
