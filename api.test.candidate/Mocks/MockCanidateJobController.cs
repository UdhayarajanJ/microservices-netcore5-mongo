using app.canditates.api.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace api.test.candidate.Mocks
{
    public class MockCanidateJobController
    {
        public CandidateApplyJobs GetMockDataCandidateApplyJobs()
        {
            return new CandidateApplyJobs()
            {
                documentObjectId = string.Empty,
                candidateId = Guid.NewGuid().ToString(),
                isDeleted = false,
                createdDate = DateTime.Now,
                id = Guid.NewGuid().ToString(),
                jobApplyDate = DateTime.Now,
                jobPostId = Guid.NewGuid().ToString(),
                lastUpdate=DateTime.Now
            };
        }
    }
}
