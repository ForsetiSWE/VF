using System.Collections.Generic;
using MongoDB.Driver;
using Umc.VigiFlow.Core.Ports.Secondary;

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

        public void Store<T>(IEnumerable<T> items)
        {
            GetCollection<T>().InsertMany(items);
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
