using System;

namespace Umc.VigiFlow.Core.Components.Case.Application.Services
{
    public interface IRegisterCaseService
    {
        void RegisterCase(Guid commandId, Domain.Models.Case newCase);
    }
}