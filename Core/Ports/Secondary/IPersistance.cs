namespace Umc.VigiFlow.Core.Ports.Secondary
{
    public interface IPersistance
    {
        T Store<T>(T item);
    }
}
