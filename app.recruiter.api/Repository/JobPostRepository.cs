using app.recruiter.api.IRepository;
using app.recruiter.api.Models;
using app.utility.microservice.IRepository;
using app.utility.microservice.Models;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace app.recruiter.api.Repository
{
    public class JobPostRepository : IJobPostRepository
    {
        private IMongoDataContext _mongoDataContext;
        public JobPostRepository(IMongoDataContext mongoDataContext)
        {
            _mongoDataContext = mongoDataContext;
        }
        public async Task<long> AddJobPost(JobPost jobPost)
        {
            IMongoDatabase mongoDatabase = await _mongoDataContext.MongoDatabaseConnection();
            IMongoCollection<JobPost> mongoCollection = mongoDatabase.GetCollection<JobPost>("Coll_JobPost");

            jobPost.id = Guid.NewGuid().ToString();
            jobPost.createdDate = DateTime.Now;
            jobPost.lastUpdate = DateTime.Now;
            jobPost.isDeleted = false;

            await mongoCollection.InsertOneAsync(jobPost);
            long result = !string.IsNullOrEmpty(jobPost.documentObjectId.ToString()) ? 1 : 0;

            return result;
            throw new NotImplementedException();
        }

        public async Task<long> DeleteJobPost(string jobPostId)
        {
            IMongoDatabase mongoDatabase = await _mongoDataContext.MongoDatabaseConnection();
            IMongoCollection<JobPost> mongoCollection = mongoDatabase.GetCollection<JobPost>("Coll_JobPost");

            var filter = Builders<JobPost>.Filter.Eq(x => x.id, jobPostId) & Builders<JobPost>.Filter.Eq(x => x.isDeleted, false);
            var builder = Builders<JobPost>.Update.Set(x => x.isDeleted, true).Set(x => x.lastUpdate, DateTime.Now);

            var resultUpdate = await mongoCollection.UpdateOneAsync(filter, builder);
            long result = resultUpdate.ModifiedCount > 0 ? 1 : 0;
            return result;
            throw new NotImplementedException();
        }

        public async Task<MulitpleApiResponse> GetJobPostDetailsForView(int pageNo, int pageSize, string searchValue, bool jobStatus)
        {
            MulitpleApiResponse mulitpleApiResponse = new MulitpleApiResponse();
            PaginationReponse paginationReponse = new PaginationReponse();

            IMongoDatabase mongoDatabase = await _mongoDataContext.MongoDatabaseConnection();

            IMongoCollection<JobPost> mongoCollection = mongoDatabase.GetCollection<JobPost>("Coll_JobPost");
            IMongoCollection<JobRoles> mongoCollectionJobRoles = mongoDatabase.GetCollection<JobRoles>("Coll_JobRoles");

            pageNo = pageNo == 0 ? 1 : pageNo;
            pageSize = pageSize == 0 ? 10 : pageSize;
            int offSetValue = (pageNo - 1) * pageSize;
            searchValue = string.IsNullOrEmpty(searchValue) ? string.Empty : searchValue;

            List<JobPost> listData = (from postDetails in mongoCollection.AsQueryable()
                                      join rolesDetails in mongoCollectionJobRoles.AsQueryable() on postDetails.roleId equals rolesDetails.id
                                      where
                                      (postDetails.isDeleted == jobStatus && rolesDetails.isDeleted == false) &&
                                      (rolesDetails.roleName.Contains(searchValue) || postDetails.jobTitle.Contains(searchValue))
                                      orderby postDetails.documentObjectId descending
                                      select new JobPost()
                                      {
                                          documentObjectId = postDetails.documentObjectId,
                                          id = postDetails.id,
                                          roleName = rolesDetails.roleName,
                                          createdDate = postDetails.createdDate,
                                          isDeleted = postDetails.isDeleted,
                                          jobTitle = postDetails.jobTitle,
                                          jobDescription = postDetails.jobDescription,
                                          experience = postDetails.experience,
                                          roleId = postDetails.roleId,
                                          salary = postDetails.salary
                                      }).Skip(offSetValue * pageSize).Take(pageSize).ToList();

            List<JobPost> totalCount = (from postDetails in mongoCollection.AsQueryable()
                                        join rolesDetails in mongoCollectionJobRoles.AsQueryable() on postDetails.roleId equals rolesDetails.id
                                        where
                                        (postDetails.isDeleted == jobStatus && rolesDetails.isDeleted == false) &&
                                        (rolesDetails.roleName.Contains(searchValue) || postDetails.jobTitle.Contains(searchValue))
                                        select new JobPost()
                                        {
                                            id = postDetails.id,
                                        }).ToList();

            paginationReponse.pageNo = pageNo;
            paginationReponse.totalCount = totalCount.Count();

            int lastPage = 0;
            int pageCount = 0;
            lastPage = (int)paginationReponse.totalCount % pageSize;
            pageCount = (int)paginationReponse.totalCount / pageSize;
            paginationReponse.totalPage = lastPage > 0 ? pageCount + 1 : pageCount;

            mulitpleApiResponse.responseData1 = listData;
            mulitpleApiResponse.responseData2 = paginationReponse;
            return mulitpleApiResponse;
            throw new NotImplementedException();
        }

        public async Task<JobPostStatusCount> GetPostJobStatus()
        {
            JobPostStatusCount jobPostStatusCount = new JobPostStatusCount();

            IMongoDatabase mongoDatabase = await _mongoDataContext.MongoDatabaseConnection();
            IMongoCollection<JobPost> mongoCollection = mongoDatabase.GetCollection<JobPost>("Coll_JobPost");

            var getActiveJobsfilter = Builders<JobPost>.Filter.Eq(x => x.isDeleted, false);
            var getNonActiveJobsfilter = Builders<JobPost>.Filter.Eq(x => x.isDeleted, true);

            jobPostStatusCount.activeJobs = mongoCollection.CountDocuments(getActiveJobsfilter);
            jobPostStatusCount.closedJobs = mongoCollection.CountDocuments(getNonActiveJobsfilter);

            return jobPostStatusCount;
            throw new NotImplementedException();
        }
        public async Task<long> UpdateJobPost(JobPost jobPost)
        {
            IMongoDatabase mongoDatabase = await _mongoDataContext.MongoDatabaseConnection();
            IMongoCollection<JobPost> mongoCollection = mongoDatabase.GetCollection<JobPost>("Coll_JobPost");

            jobPost.lastUpdate = DateTime.Now;
            jobPost.isDeleted = false;

            var filter = Builders<JobPost>.Filter.Eq(x => x.id, jobPost.id);

            var resultUpdate = await mongoCollection.ReplaceOneAsync(filter, jobPost);
            long result = resultUpdate.ModifiedCount > 0 ? 1 : 0;

            return result;
            throw new NotImplementedException();
        }
    }
}
