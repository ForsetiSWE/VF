using MongoDB.Driver;
using Umc.VigiFlow.Core.Ports;
using Umc.VigiFlow.Core.SharedKernel.Models;

namespace Umc.VigiFlow.Adapters.Secondary.MongoDBAuditTrailPersistance
{
    public class AuditTrailPersistance : IAuditTrailPersistance
    {
        #region Setup

        private readonly IConnectionStringProvider connectionStringProvider;

        public AuditTrailPersistance(IConnectionStringProvider connectionStringProvider)
        {
            this.connectionStringProvider = connectionStringProvider;
        }

        #endregion Setup

        #region IAuditTrailPersistance

        public void Store(AuditTrail<BaseEntity> auditTrail)
        {
            GetCollection().InsertOne(auditTrail);
        }

        #endregion IAuditTrailPersistance

        #region Private

        private IMongoCollection<AuditTrail<BaseEntity>> GetCollection()
        {
            var mongoClient = new MongoClient(connectionStringProvider.ConnectionString);
            // TODO: Hardcoded databasename?!?!?
            return mongoClient.GetDatabase("Test").GetCollection<AuditTrail<BaseEntity>>("AuditTrail");
        }

        #endregion Private
    }
}
