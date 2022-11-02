using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace app.utility.microservice.IRepository
{
    public interface IMongoDataContext
    {
        public Task<IMongoDatabase> MongoDatabaseConnection();
    }
}
