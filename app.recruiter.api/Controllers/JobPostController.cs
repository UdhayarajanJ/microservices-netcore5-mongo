using app.recruiter.api.IRepository;
using app.recruiter.api.Models;
using app.utility.microservice.Models;
using Microsoft.AspNetCore.Mvc;
using System.Net;
using System.Threading.Tasks;

namespace app.recruiter.api.Controllers
{
    [Route("JobPost")]
    [ApiController]
    public class JobPostController : ControllerBase
    {
        private IJobPostRepository _jobPostRepository;
        public JobPostController(IJobPostRepository jobPostRepository)
        {
            _jobPostRepository = jobPostRepository;
        }
        /// <summary>
        /// To Add New Job Post Details In MongoDatabase [ NetCoreMicroservice ] Collection [ Coll_JobPost ]
        /// </summary>
        /// <param name="jobPost"></param>
        /// <returns></returns>
        [HttpPost(nameof(AddJobPost))]
        public async Task<IActionResult> AddJobPost([FromBody] JobPost jobPost)
        {
            CommonApiReponse apiReponse = new CommonApiReponse();
            long result = await _jobPostRepository.AddJobPost(jobPost);
            if (result > 0)
            {
                apiReponse.statusCode = (int)HttpStatusCode.OK;
                apiReponse.statusMessage = "Job Post Details Saved...";
                apiReponse.responseData = result;
            }
            else
            {
                apiReponse.statusCode = (int)HttpStatusCode.NotFound;
                apiReponse.statusMessage = "Job Post Details Not Saved...";
                apiReponse.responseData = null;
            }
            return Ok(apiReponse);
        }
        /// <summary>
        /// To Update Existing Job Post Details In MongoDatabase [ NetCoreMicroservice ] Collection [ Coll_JobPost ]
        /// </summary>
        /// <param name="jobPost"></param>
        /// <returns></returns>
        [HttpPut(nameof(UpdateJobPost))]
        public async Task<IActionResult> UpdateJobPost([FromBody] JobPost jobPost)
        {
            CommonApiReponse apiReponse = new CommonApiReponse();
            long result = await _jobPostRepository.UpdateJobPost(jobPost);
            if (result > 0)
            {
                apiReponse.statusCode = (int)HttpStatusCode.OK;
                apiReponse.statusMessage = "Job Post Details Updated...";
                apiReponse.responseData = result;
            }
            else
            {
                apiReponse.statusCode = (int)HttpStatusCode.NotFound;
                apiReponse.statusMessage = "Job Post Details Not Updated...";
                apiReponse.responseData = null;
            }
            return Ok(apiReponse);
        }
        /// <summary>
        /// To Softly Deleted Existing Job Post Details In MongoDatabase [ NetCoreMicroservice ] Collection [ Coll_JobPost ]
        /// </summary>
        /// <param name="jobPostId"></param>
        /// <returns></returns>
        [HttpDelete(nameof(DeleteJobPost))]
        public async Task<IActionResult> DeleteJobPost([FromQuery] string jobPostId)
        {
            CommonApiReponse apiReponse = new CommonApiReponse();
            long result = await _jobPostRepository.DeleteJobPost(jobPostId);
            if (result > 0)
            {
                apiReponse.statusCode = (int)HttpStatusCode.OK;
                apiReponse.statusMessage = "Job Post Details Deleted...";
                apiReponse.responseData = result;
            }
            else
            {
                apiReponse.statusCode = (int)HttpStatusCode.NotFound;
                apiReponse.statusMessage = "Job Post Details Not Deleted...";
                apiReponse.responseData = null;
            }
            return Ok(apiReponse);
            
        }
        /// <summary>
        /// To Get Job Post Details Purpose Of View For Recruiter MongoDatabase [ NetCoreMicroservice ] Collection [ Coll_JobPost ]
        /// </summary>
        /// <param name="pageNo"></param>
        /// <param name="pageSize"></param>
        /// <param name="searchValue"></param>
        /// <param name="jobStatus"></param>
        /// <returns></returns>
        [HttpGet(nameof(GetJobPostDetailsForView))]
        public async Task<IActionResult> GetJobPostDetailsForView([FromQuery] int pageNo, [FromQuery] int pageSize, [FromQuery] string searchValue, [FromQuery] bool jobStatus)
        {
            CommonApiReponse apiReponse = new CommonApiReponse();
            MulitpleApiResponse mulitpleApiResponse = await _jobPostRepository.GetJobPostDetailsForView(pageNo, pageSize, searchValue, jobStatus);
            if (mulitpleApiResponse != null)
            {
                apiReponse.statusCode = (int)HttpStatusCode.OK;
                apiReponse.statusMessage = "Job Post Details Found...";
                apiReponse.responseData = mulitpleApiResponse;
            }
            else
            {
                apiReponse.statusCode = (int)HttpStatusCode.NotFound;
                apiReponse.statusMessage = "Job Post Details Not Found...";
                apiReponse.responseData = null;
            }
            return Ok(apiReponse);
        }
        /// <summary>
        /// To Get Job Post How Many ActiveJobs And NonActive Job
        /// Details Of View For Recruiter MongoDatabase [ NetCoreMicroservice ] Collection [ Coll_JobPost ]
        /// </summary>
        /// <returns></returns>
        [HttpGet(nameof(GetPostJobStatus))]
        public async Task<IActionResult> GetPostJobStatus()
        {
            CommonApiReponse apiReponse = new CommonApiReponse();
            JobPostStatusCount jobPostStatusCount= await _jobPostRepository.GetPostJobStatus();
            if (jobPostStatusCount != null)
            {
                apiReponse.statusCode = (int)HttpStatusCode.OK;
                apiReponse.statusMessage = "Job Post Details Found...";
                apiReponse.responseData = jobPostStatusCount;
            }
            else
            {
                apiReponse.statusCode = (int)HttpStatusCode.NotFound;
                apiReponse.statusMessage = "Job Post Details Not Found...";
                apiReponse.responseData = null;
            }
            return Ok(apiReponse);
        }

    }
}
