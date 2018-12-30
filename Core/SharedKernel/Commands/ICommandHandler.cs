namespace Umc.VigiFlow.Core.SharedKernel.Commands
{
    public interface ICommandHandler
    {
        bool CanHandle(ICommand command);
        void Handle(ICommand command);
    }
}
