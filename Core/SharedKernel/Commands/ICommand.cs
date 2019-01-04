using System;

namespace Umc.VigiFlow.Core.SharedKernel.Commands
{
    public interface ICommand
    {
        Guid CommandId { get; }
    }
}
