using System;
using Umc.VigiFlow.Core.SharedKernel.BaseModel;

namespace Umc.VigiFlow.Core.Ports
{
    public interface IPersistance
    {
        void Store<T>(T entity) where T : BaseEntity;
        T Get<T>(Guid id, int revision);
    }
}
