using System;
using MongoDB.Driver;
using Umc.VigiFlow.Core.Ports;
using Umc.VigiFlow.Core.SharedKernel.Events;
using Umc.VigiFlow.Core.SharedKernel.Models;

namespace Umc.VigiFlow.Adapters.Secondary.MongoDBPersistance
{
    public class Persistance : IPersistance
    {
        #region Setup

        private readonly IConnectionStringProvider connectionStringProvider;
        private readonly IEventBus eventBus;

        public Persistance(IConnectionStringProvider connectionStringProvider, IEventBus eventBus)
        {
            this.connectionStringProvider = connectionStringProvider;
            this.eventBus = eventBus;
        }

        #endregion Setup

        #region IPersistance

        public void Store<T>(Guid commandId, T entity) where T : Entity
        {
            var filter = Builders<T>.Filter.Eq("_id", entity.Id);

            var revisionedEntity = entity as RevisionedEntity;
            if (revisionedEntity != null)
            {
                if (revisionedEntity.Revision > 0)
                {
                    // Not first revision, add filter for revision
                    filter = filter & Builders<T>.Filter.Eq("Revision", revisionedEntity.Revision);
                }

                // Move to next revision for entitiy
                revisionedEntity.NextRevision();
            }

            GetCollection<T>().ReplaceOne(filter, entity, new UpdateOptions { IsUpsert = true});

            // Send EntityStoredEvent
            eventBus.Publish(new EntityStoredEvent(Guid.NewGuid(), commandId, entity));
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
            var mongoClient = new MongoClient(connectionStringProvider.ConnectionString);
            // TODO: Hardcoded databasename?!?!?
            return mongoClient.GetDatabase("Test").GetCollection<T>(typeof(T).Name);
        }

        #endregion Private
    }
}
