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
    [Route("CanditateAccount")]
    [ApiController]
    public class CanditateAccountController : ControllerBase
    {
        private ICanditateAccountRepository _canditateAccountRepository;
        public CanditateAccountController(ICanditateAccountRepository canditateAccountRepository)
        {
            _canditateAccountRepository = canditateAccountRepository;
        }
        /// <summary>
        /// To Save The Candidate Login Details In MongoDatabase [ NetCoreMicroservice ] Collection [ Coll_CandidateCredential ]
        /// </summary>
        /// <param name="candidateLoginDetails"></param>
        /// <returns></returns>
        [HttpPost(nameof(AddCandidateLoginDetails))]
        public async Task<IActionResult> AddCandidateLoginDetails([FromBody] CandidateLoginDetails candidateLoginDetails)
        {
            CommonApiReponse apiReponse = new CommonApiReponse();
            long result = await _canditateAccountRepository.AddCandidateLoginDetails(candidateLoginDetails);
            if (result > 0)
            {
                apiReponse.statusCode = (int)HttpStatusCode.OK;
                apiReponse.statusMessage = "Login Details Saved...";
                apiReponse.responseData = result;
            }
            else
            {
                apiReponse.statusCode = (int)HttpStatusCode.NotFound;
                apiReponse.statusMessage = "Login Details Not Saved...";
                apiReponse.responseData = null;
            }
            return Ok(apiReponse);
        }
        /// <summary>
        /// To Update The Candidate Login Details In MongoDatabase [ NetCoreMicroservice ] Collection [ Coll_CandidateCredential ]
        /// </summary>
        /// <param name="candidateLoginDetails"></param>
        /// <returns></returns>
        [HttpPut(nameof(UpdateCandidateLoginDetails))]
        public async Task<IActionResult> UpdateCandidateLoginDetails([FromBody] CandidateLoginDetails candidateLoginDetails)
        {
            CommonApiReponse apiReponse = new CommonApiReponse();
            long result = await _canditateAccountRepository.UpdateCandidateLoginDetails(candidateLoginDetails);
            if (result > 0)
            {
                apiReponse.statusCode = (int)HttpStatusCode.OK;
                apiReponse.statusMessage = "Login Details Updated...";
                apiReponse.responseData = result;
            }
            else
            {
                apiReponse.statusCode = (int)HttpStatusCode.NotFound;
                apiReponse.statusMessage = "Login Details Not Updated...";
                apiReponse.responseData = null;
            }
            return Ok(apiReponse);
        }
        /// <summary>
        /// To Delete The Candidate Login Details In MongoDatabase [ NetCoreMicroservice ] Collection [ Coll_CandidateCredential ]
        /// </summary>
        /// <param name="jobPostId"></param>
        /// <returns></returns>
        [HttpDelete(nameof(DeleteCandidateLoginDetails))]
        public async Task<IActionResult> DeleteCandidateLoginDetails([FromQuery] string candidateId)
        {
            CommonApiReponse apiReponse = new CommonApiReponse();
            long result = await _canditateAccountRepository.DeleteCandidateLoginDetails(candidateId);
            if (result > 0)
            {
                apiReponse.statusCode = (int)HttpStatusCode.OK;
                apiReponse.statusMessage = "Candidate Details Deleted...";
                apiReponse.responseData = result;
            }
            else
            {
                apiReponse.statusCode = (int)HttpStatusCode.NotFound;
                apiReponse.statusMessage = "Candidate Details Not Deleted...";
                apiReponse.responseData = null;
            }
            return Ok(apiReponse);

        }
        /// <summary>
        /// To Upload The File Information Of Candidates Required Documents
        /// </summary>
        /// <param name="formFile"></param>
        /// <param name="documentSuffixPath"></param>
        /// <returns></returns>
        [HttpPost(nameof(UploadCandidateFileInformation))]
        public async Task<IActionResult> UploadCandidateFileInformation([FromForm] IFormFile formFile, [FromForm] string documentSuffixPath)
        {
            CommonApiReponse apiReponse = new CommonApiReponse();
            DocumentResponse result = await _canditateAccountRepository.UploadCandidateFileInformation(formFile, documentSuffixPath);
            if (result != null)
            {
                apiReponse.statusCode = (int)HttpStatusCode.OK;
                apiReponse.statusMessage = "File Upload Successfully...";
                apiReponse.responseData = result;
            }
            else
            {
                apiReponse.statusCode = (int)HttpStatusCode.NotFound;
                apiReponse.statusMessage = "File Upload Failed...";
                apiReponse.responseData = null;
            }
            return Ok(apiReponse);
        }
    }
}
