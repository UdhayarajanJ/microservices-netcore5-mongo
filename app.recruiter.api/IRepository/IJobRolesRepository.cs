using app.recruiter.api.Models;
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
    }
}
