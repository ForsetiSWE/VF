namespace Umc.VigiFlow.Core.Components.Case.Application.Repositories
{
    internal interface ICaseRepository
    {
        void Store(Domain.Models.Case newCase);
    }
}