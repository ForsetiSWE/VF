using System;
using MongoDB.Driver;
using Umc.VigiFlow.Core.Ports;
using Umc.VigiFlow.Core.SharedKernel.BaseModel;

namespace Umc.VigiFlow.Adapters.Secondary.MongoDBPersistance
{
    public class Persistance : IPersistance
    {
        #region Setup

        private readonly string connectionString;

        public Persistance(string connectionString)
        {
            this.connectionString = connectionString;
        }

        #endregion Setup

        #region IPersistance

        public void Store<T>(T entity) where T : BaseEntity
        {
            var filter = Builders<T>.Filter.Eq("_id", entity.Id);

            if (entity.Revision > 0)
            {
                // Not first revision, add filter for revision
                filter = filter & Builders<T>.Filter.Eq("Revision", entity.Revision);
            }

            // Move to next revision for entitiy
            entity.NextRevision();

            GetCollection<T>().ReplaceOne(filter, entity, new UpdateOptions { IsUpsert = true});
        }

        public T Get<T>(Guid id, int revision)
        {
            var filter = Builders<T>.Filter.Eq("_id", id);
            filter = filter & Builders<T>.Filter.Eq("Revision", revision);

            return GetCollection<T>().Find(filter).Single();
        }

        #endregion IPersistance

        #region Private

        private IMongoCollection<T> GetCollection<T>()
        {
            var mongoClient = new MongoClient(connectionString);
            // TODO: Hardcoded databasename?!?!?
            return mongoClient.GetDatabase("Test").GetCollection<T>(typeof(T).Name);
        }

        #endregion Private
    }
}
