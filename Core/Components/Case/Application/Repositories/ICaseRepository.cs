namespace Umc.VigiFlow.Core.Components.Case.Application.Repositories
{
    public interface ICaseRepository
    {
        void Store(Domain.Models.Case newCase);
    }
}