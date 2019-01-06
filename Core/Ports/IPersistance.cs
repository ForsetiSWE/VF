using System.Collections.Generic;

namespace Umc.VigiFlow.Core.Ports
{
    public interface IPersistance
    {
        void Store<T>(IEnumerable<T> items);
    }
}
