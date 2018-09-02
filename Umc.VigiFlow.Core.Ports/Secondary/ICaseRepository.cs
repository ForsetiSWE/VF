using Umc.VigiFlow.Core.Components.Case.Domain.Models;

namespace Umc.VigiFlow.Core.Ports.Secondary
{
    public interface ICaseRepository
    {
        void Store(Case newCase);
    }
}
