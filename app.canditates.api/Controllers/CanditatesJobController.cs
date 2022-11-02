using app.canditates.api.IRepository;
using app.canditates.api.Models;
using app.utility.microservice.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;

namespace app.canditates.api.Controllers
{
    [Route("CanditatesJob")]
    [ApiController]
    public class CanditatesJobController : ControllerBase
    {
        private ICandidateApplyJobRepository _candidateApplyJobRepository;
        public CanditatesJobController(ICandidateApplyJobRepository candidateApplyJobRepository)
        {
            _candidateApplyJobRepository = candidateApplyJobRepository;
        }
        /// <summary>
        /// To Candidate Apply The Job Post MongoDatabase [ NetCoreService ] MongoCollection [ Coll_CandidateApplyJobs ] 
        /// </summary>
        /// <param name="candidateApplyJobs"></param>
        /// <returns></returns>
        [HttpPost(nameof(CandidateApplyJobs))]
        public async Task<IActionResult> CandidateApplyJobs([FromBody] CandidateApplyJobs candidateApplyJobs)
        {
            CommonApiReponse apiReponse = new CommonApiReponse();
            long result = await _candidateApplyJobRepository.CandidateApplyJobs(candidateApplyJobs);
            if (result > 0)
            {
                apiReponse.statusCode = (int)HttpStatusCode.OK;
                apiReponse.statusMessage = "Job Applied Successfully...";
                apiReponse.responseData = result;
            }
            else
            {
                apiReponse.statusCode = (int)HttpStatusCode.NotFound;
                apiReponse.statusMessage = "Job Applied Failed...";
                apiReponse.responseData = null;
            }
            return Ok(apiReponse);
        }
    }
}
