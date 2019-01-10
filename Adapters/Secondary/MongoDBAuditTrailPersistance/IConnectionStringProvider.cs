namespace Umc.VigiFlow.Adapters.Secondary.MongoDBAuditTrailPersistance
{
    public interface IConnectionStringProvider
    {
        string ConnectionString { get; }
    }
}
