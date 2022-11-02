using app.recruiter.api.Models;
using app.utility.microservice.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace app.recruiter.api.IRepository
{
    public interface IJobRolesRepository
    {
        public Task<long> AddJobRoles(JobRoles jobRoles);
        public Task<long> UpdateJobRoles(JobRoles jobRoles);
        public Task<long> DeleteJobRoles(string roleId);
        public Task<List<JobRoles>> GetRolesDetailsForDropdown();
        public Task<MulitpleApiResponse> GetRolesDetailsForView(int pageNo, int pageSize, string searchValue);
    }
}
