namespace Umc.VigiFlow.Core.Components.CaseComponent.Application.Repositories
{
    public interface ICaseRepository
    {
        void Store(Domain.Models.Case newCase);
    }
}