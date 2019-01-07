using System;
using MongoDB.Driver;
using Umc.VigiFlow.Core.Ports;

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

        public void Store<T>(T item, Guid id)
        {
            var filter = Builders<T>.Filter.Eq("_id", id);

            GetCollection<T>().ReplaceOne(filter, item, new UpdateOptions { IsUpsert = true});
        }

        public T Get<T>(Guid id)
        {
            var filter = Builders<T>.Filter.Eq("_id", id);

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
