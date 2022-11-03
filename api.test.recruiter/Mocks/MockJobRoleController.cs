using app.recruiter.api.Models;
using app.utility.microservice.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace api.test.recruiter.Mocks
{
    public class MockJobRoleController
    {
        public JobRoles GetMockJobRole()
        {
            return new JobRoles()
            {
                createdDate = DateTime.Now,
                documentObjectId = string.Empty,
                id = string.Empty,
                isDeleted = false,
                lastUpdate = DateTime.Now,
                roleName = ".Net Fullstack Web Developer"
            };
        }

        public List<JobRoles> GetMockJobRoleListDataForDropDown()
        {
            return new List<JobRoles>()
            {
                new JobRoles()
                {
                    createdDate = DateTime.Now,
                    documentObjectId = string.Empty,
                    id = string.Empty,
                    isDeleted = false,
                    lastUpdate = DateTime.Now,
                    roleName = ".Net Fullstack Web Developer"
                },
                new JobRoles()
                {
                    createdDate = DateTime.Now,
                    documentObjectId = string.Empty,
                    id = string.Empty,
                    isDeleted = false,
                    lastUpdate = DateTime.Now,
                    roleName = "C# Developer"
                },
                new JobRoles()
                {
                    createdDate = DateTime.Now,
                    documentObjectId = string.Empty,
                    id = string.Empty,
                    isDeleted = false,
                    lastUpdate = DateTime.Now,
                    roleName = "Angular Developer"
                },

            };
        }

        public MulitpleApiResponse GetMockJobRoleListDataForView()
        {
            PaginationReponse paginationReponse = new PaginationReponse()
            {
                pageNo=1,
                totalCount=12,
                totalPage=2
            };
            return new MulitpleApiResponse()
            {
                responseData1 = GetMockJobRoleListDataForDropDown(),
                responseData2 = paginationReponse
            };
        }
    }
}
