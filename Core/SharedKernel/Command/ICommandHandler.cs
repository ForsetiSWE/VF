namespace Umc.VigiFlow.Core.SharedKernel.Command
{
    public interface ICommandHandler
    {
        bool CanHandle(ICommand command);
        void Handle(ICommand command);
    }
}
