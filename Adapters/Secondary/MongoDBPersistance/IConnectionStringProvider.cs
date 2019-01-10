namespace Umc.VigiFlow.Adapters.Secondary.MongoDBPersistance
{
    public interface IConnectionStringProvider
    {
        string ConnectionString { get; }
    }
}
