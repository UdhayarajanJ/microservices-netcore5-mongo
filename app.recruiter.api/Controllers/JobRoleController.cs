using app.recruiter.api.IRepository;
using app.recruiter.api.Models;
using app.utility.microservice.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;

namespace app.recruiter.api.Controllers
{
    [Route("JobRole")]
    [ApiController]
    public class JobRoleController : ControllerBase
    {
        private IJobRolesRepository _jobRolesRepository;
        public JobRoleController(IJobRolesRepository jobRolesRepository)
        {
            _jobRolesRepository = jobRolesRepository;
        }

        /// <summary>
        /// To Add New Job Roles Details In MongoDatabase [ NetCoreMicroservice ] Collection [ Coll_JobRoles ]
        /// </summary>
        /// <param name="jobRoles"></param>
        /// <returns></returns>
        [HttpPost(nameof(AddJobRoles))]
        public async Task<IActionResult> AddJobRoles([FromBody] JobRoles jobRoles)
        {
            CommonApiReponse apiReponse = new CommonApiReponse();
            long result = await _jobRolesRepository.AddJobRoles(jobRoles);
            if (result > 0)
            {
                apiReponse.statusCode = (int)HttpStatusCode.OK;
                apiReponse.statusMessage = "Role Details Added...";
                apiReponse.responseData = result;
            }
            else
            {
                apiReponse.statusCode = (int)HttpStatusCode.NotFound;
                apiReponse.statusMessage = "Role Details Not Added...";
                apiReponse.responseData = null;
            }
            return Ok(apiReponse);
        }
        /// <summary>
        /// To Update Existing Job Roles Details In MongoDatabase [ NetCoreMicroservice ] Collection [ Coll_JobRoles ]
        /// </summary>
        /// <param name="jobRoles"></param>
        /// <returns></returns>
        [HttpPut(nameof(UpdateJobRoles))]
        public async Task<IActionResult> UpdateJobRoles([FromBody] JobRoles jobRoles)
        {
            CommonApiReponse apiReponse = new CommonApiReponse();
            long result = await _jobRolesRepository.UpdateJobRoles(jobRoles);
            if (result > 0)
            {
                apiReponse.statusCode = (int)HttpStatusCode.OK;
                apiReponse.statusMessage = "Role Details Updated...";
                apiReponse.responseData = result;
            }
            else
            {
                apiReponse.statusCode = (int)HttpStatusCode.NotFound;
                apiReponse.statusMessage = "Role Details Not Updated...";
                apiReponse.responseData = null;
            }
            return Ok(apiReponse);
        }
        /// <summary>
        /// To Softly Deleted Existing Job Roles Details In MongoDatabase [ NetCoreMicroservice ] Collection [ Coll_JobRoles ]
        /// </summary>
        /// <param name="roleId"></param>
        /// <returns></returns>
        [HttpDelete(nameof(DeleteJobRoles))]
        public async Task<IActionResult> DeleteJobRoles([FromQuery] string roleId)
        {
            CommonApiReponse apiReponse = new CommonApiReponse();
            long result = await _jobRolesRepository.DeleteJobRoles(roleId);
            if (result > 0)
            {
                apiReponse.statusCode = (int)HttpStatusCode.OK;
                apiReponse.statusMessage = "Role Details Deleted...";
                apiReponse.responseData = result;
            }
            else
            {
                apiReponse.statusCode = (int)HttpStatusCode.NotFound;
                apiReponse.statusMessage = "Role Details Not Deleted...";
                apiReponse.responseData = null;
            }
            return Ok(apiReponse);
        }
        /// <summary>
        /// To Get Roles Details Purpose Of Post A Job For Recruiter MongoDatabase [ NetCoreMicroservice ] Collection [ Coll_JobRoles ]
        /// </summary>
        /// <returns></returns>
        [HttpGet(nameof(GetRolesDetailsForDropdown))]
        public async Task<IActionResult> GetRolesDetailsForDropdown()
        {
            CommonApiReponse apiReponse = new CommonApiReponse();
            List<JobRoles> jobRolesList = await _jobRolesRepository.GetRolesDetailsForDropdown();
            if (jobRolesList !=null)
            {
                apiReponse.statusCode = (int)HttpStatusCode.OK;
                apiReponse.statusMessage = "Role Details Found...";
                apiReponse.responseData = jobRolesList;
            }
            else
            {
                apiReponse.statusCode = (int)HttpStatusCode.NotFound;
                apiReponse.statusMessage = "Role Details Not Found...";
                apiReponse.responseData = null;
            }
            return Ok(apiReponse);
        }
    }
}
