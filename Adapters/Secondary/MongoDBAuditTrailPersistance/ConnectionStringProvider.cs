namespace Umc.VigiFlow.Adapters.Secondary.MongoDBAuditTrailPersistance
{
    class ConnectionStringProvider : IConnectionStringProvider
    {
        #region Setup

        public ConnectionStringProvider()
        {
            ConnectionString = "mongodb://localhost:27017";
        }
        #endregion Setup

        #region IConnectionStringProvider

        public string ConnectionString { get; }

        #endregion IConnectionStringProvider

    }
}
