using app.canditates.api.IRepository;
using app.canditates.api.Models;
using app.utility.microservice.IRepository;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace app.canditates.api.Repository
{
    public class CandidateApplyJobRepository : ICandidateApplyJobRepository
    {
        private IMongoDataContext _mongoDataContext;
        public CandidateApplyJobRepository(IMongoDataContext mongoDataContext)
        {
            _mongoDataContext = mongoDataContext;
        }
        public async Task<long> CandidateApplyJobs(CandidateApplyJobs candidateApplyJobs)
        {
            IMongoDatabase mongoDatabase = await _mongoDataContext.MongoDatabaseConnection();
            IMongoCollection<CandidateApplyJobs> mongoCollection = mongoDatabase.GetCollection<CandidateApplyJobs>("Coll_CandidateApplyJobs");

            candidateApplyJobs.id = Guid.NewGuid().ToString();
            candidateApplyJobs.createdDate = DateTime.Now;
            candidateApplyJobs.lastUpdate = DateTime.Now;
            candidateApplyJobs.jobApplyDate = DateTime.Now;
            candidateApplyJobs.isDeleted = false;

            await mongoCollection.InsertOneAsync(candidateApplyJobs);
            long result = !string.IsNullOrEmpty(candidateApplyJobs.documentObjectId.ToString()) ? 1 : 0;
            return result;
            throw new NotImplementedException();
        }
    }
}
