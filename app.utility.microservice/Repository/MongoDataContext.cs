using app.utility.microservice.IRepository;
using app.utility.microservice.Models;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace app.utility.microservice.Repository
{
    public class MongoDataContext : IMongoDataContext
    {
        private MongoDatabaseConfiguration _mongoDBConfiguration;
        public MongoDataContext(MongoDatabaseConfiguration mongoDBConfiguration)
        {
            _mongoDBConfiguration = mongoDBConfiguration;
        }
        public Task<IMongoDatabase> MongoDatabaseConnection()
        {
            string mongoDBConnectionString = _mongoDBConfiguration.isConnectServerDatabase ? _mongoDBConfiguration.mongoDatabaseServerConnectionString : _mongoDBConfiguration.mongoDatabaseLocalConnectionString;
            MongoClient mongoClient = new MongoClient(mongoDBConnectionString);
            IMongoDatabase mongoDatabaseBase = mongoClient.GetDatabase(_mongoDBConfiguration.mongoDatabase);
            return Task.FromResult(mongoDatabaseBase);
        }
    }
}
