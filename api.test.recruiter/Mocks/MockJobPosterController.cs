using app.recruiter.api.Models;
using app.utility.microservice.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace api.test.recruiter.Mocks
{
    public class MockJobPosterController
    {
        public JobPost GetMockJobPostValue()
        {
            return new JobPost()
            {
                createdDate = DateTime.Now,
                documentObjectId = string.Empty,
                experience = 1,
                id = string.Empty,
                isDeleted = false,
                jobDescription = "Test Description",
                jobTitle = ".Net Full Stack Web Developer",
                lastUpdate = DateTime.Now,
                roleId = Guid.NewGuid().ToString(),
                roleName = "Test Role Name",
                salary = 20000
            };
        }

        public MulitpleApiResponse GetMockJobRoleListDataForView()
        {
            List<JobPost> jobPosts = new List<JobPost>()
            {
                GetMockJobPostValue(),
                GetMockJobPostValue(),
                GetMockJobPostValue()
            };
            PaginationReponse paginationReponse = new PaginationReponse()
            {
                pageNo = 1,
                totalCount = 12,
                totalPage = 2
            };
            return new MulitpleApiResponse()
            {
                responseData1 = jobPosts,
                responseData2 = paginationReponse
            };
        }

        public JobPostStatusCount GetMockJobPostStatusCount()
        {
            return new JobPostStatusCount()
            {
                activeJobs = 12,
                closedJobs = 0
            };
        }
    }
}
