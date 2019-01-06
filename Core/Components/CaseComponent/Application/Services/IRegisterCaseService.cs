using System;

namespace Umc.VigiFlow.Core.Components.CaseComponent.Application.Services
{
    public interface IRegisterCaseService
    {
        void RegisterCase(Guid commandId, Domain.Models.Case newCase);
    }
}