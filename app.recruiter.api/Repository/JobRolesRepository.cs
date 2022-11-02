using app.recruiter.api.IRepository;
using app.recruiter.api.Models;
using app.utility.microservice.IRepository;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace app.recruiter.api.Repository
{
    public class JobRolesRepository : IJobRolesRepository
    {
        private IMongoDataContext _mongoDataContext;
        public JobRolesRepository(IMongoDataContext mongoDataContext)
        {
            _mongoDataContext = mongoDataContext;
        }
        public async Task<long> AddJobRoles(JobRoles jobRoles)
        {
            IMongoDatabase mongoDatabase = await _mongoDataContext.MongoDatabaseConnection();
            IMongoCollection<JobRoles> mongoCollection = mongoDatabase.GetCollection<JobRoles>("Coll_JobRoles");

            jobRoles.id = Guid.NewGuid().ToString();
            jobRoles.createdDate = DateTime.Now;
            jobRoles.lastUpdate = DateTime.Now;
            jobRoles.isDeleted = false;

            await mongoCollection.InsertOneAsync(jobRoles);
            long result = !string.IsNullOrEmpty(jobRoles.documentObjectId.ToString()) ? 1 : 0;

            return result;
            throw new NotImplementedException();
        }

        public async Task<long> DeleteJobRoles(string roleId)
        {
            IMongoDatabase mongoDatabase = await _mongoDataContext.MongoDatabaseConnection();
            IMongoCollection<JobRoles> mongoCollection = mongoDatabase.GetCollection<JobRoles>("Coll_JobRoles");

            var filter = Builders<JobRoles>.Filter.Eq(x => x.id, roleId) & Builders<JobRoles>.Filter.Eq(x => x.isDeleted, false);
            var builder = Builders<JobRoles>.Update.Set(x => x.isDeleted, true).Set(x => x.lastUpdate, DateTime.Now);

            var resultUpdate = await mongoCollection.UpdateOneAsync(filter, builder);
            long result = resultUpdate.ModifiedCount > 0 ? 1 : 0;
            return result;
            throw new NotImplementedException();
        }

        public async Task<List<JobRoles>> GetRolesDetailsForDropdown()
        {
            IMongoDatabase mongoDatabase = await _mongoDataContext.MongoDatabaseConnection();
            IMongoCollection<JobRoles> mongoCollection = mongoDatabase.GetCollection<JobRoles>("Coll_JobRoles");

            List<JobRoles> listData = (from roles in mongoCollection.AsQueryable()
                                               where
                                               roles.isDeleted == false
                                               orderby roles.roleName ascending
                                               select new JobRoles()
                                               {
                                                   id = roles.id,
                                                   roleName = roles.roleName
                                               }).ToList();
            return listData;
            throw new NotImplementedException();
        }

        public async Task<long> UpdateJobRoles(JobRoles jobRoles)
        {
            IMongoDatabase mongoDatabase = await _mongoDataContext.MongoDatabaseConnection();
            IMongoCollection<JobRoles> mongoCollection = mongoDatabase.GetCollection<JobRoles>("Coll_JobRoles");

            jobRoles.lastUpdate = DateTime.Now;
            jobRoles.isDeleted = false;

            var filter = Builders<JobRoles>.Filter.Eq(x => x.id , jobRoles.id);

            var resultUpdate = await mongoCollection.ReplaceOneAsync(filter, jobRoles);
            long result = resultUpdate.ModifiedCount > 0 ? 1 : 0;

            return result;
            throw new NotImplementedException();
        }
    }
}
