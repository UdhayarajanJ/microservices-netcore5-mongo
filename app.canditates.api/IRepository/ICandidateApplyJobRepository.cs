using app.canditates.api.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace app.canditates.api.IRepository
{
    public interface ICandidateApplyJobRepository
    {
        public Task<long> CandidateApplyJobs(CandidateApplyJobs candidateApplyJobs);
    }
}
