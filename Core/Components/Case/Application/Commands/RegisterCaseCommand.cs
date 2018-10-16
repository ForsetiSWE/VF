using Umc.VigiFlow.Core.Components.Case.Application.Services;
using Umc.VigiFlow.Core.SharedKernel;

namespace Umc.VigiFlow.Core.Components.Case.Application.Commands
{
    public class RegisterCaseCommand : ICommand
    {
        private readonly Domain.Models.Case _newCase;

        public RegisterCaseCommand(Domain.Models.Case newCase)
        {
            _newCase = newCase;
        }

        public void Execute()
        {
            var service = new RegisterCaseService();

            service.RegisterCase(_newCase);
        }
    }
}
