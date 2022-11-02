using app.canditates.api.Models;
using app.utility.microservice.Models;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace app.canditates.api.IRepository
{
    public interface ICanditateAccountRepository
    {
        public Task<long> AddCandidateLoginDetails(CandidateLoginDetails candidateLoginDetails);
        public Task<long> UpdateCandidateLoginDetails(CandidateLoginDetails candidateLoginDetails);
        public Task<long> DeleteCandidateLoginDetails(string candidateId);

        //----//

        public Task<long> AddCandidateInformation(CandidateAccount candidateAccount);
        public Task<long> UpdateCandidateInformation(CandidateAccount candidateAccount);
        public Task<DocumentResponse> UploadCandidateFileInformation(IFormFile formFile,string documentSuffixPath);
    }
}
