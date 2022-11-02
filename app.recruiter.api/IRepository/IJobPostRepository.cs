using app.recruiter.api.Models;
using app.utility.microservice.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace app.recruiter.api.IRepository
{
    public interface IJobPostRepository
    {
        public Task<long> AddJobPost(JobPost jobPost);
        public Task<long> UpdateJobPost(JobPost jobPost);
        public Task<long> DeleteJobPost(string jobPostId);
        public Task<MulitpleApiResponse> GetJobPostDetailsForView(int pageNo, int pageSize, string searchValue,bool jobStatus);
        public Task<JobPostStatusCount> GetPostJobStatus();
    }
}
