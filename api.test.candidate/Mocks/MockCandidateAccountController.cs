using app.canditates.api.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace api.test.candidate.Mocks
{
    public class MockCandidateAccountController
    {
        public CandidateLoginDetails GetMockCandidateLoginInformation()
        {
            return new CandidateLoginDetails()
            {
                createdDate = DateTime.Now,
                documentObjectId = string.Empty,
                id = string.Empty,
                isDeleted = false,
                lastUpdate = DateTime.Now,
                userEmail = "test@test.com",
                userPassword = "testPassword"
            };
        }
        public LoginCandidate GetMockCandidateLoginRequest()
        {
            return new LoginCandidate()
            {
                password = "testPassword",
                userEmail = "test@test.com",
            };
        }

        public LoginResponse GetMockCandidateLoginResponse()
        {
            return new LoginResponse()
            {
                userEmailId= "test@test.com",
                userId = Guid.NewGuid().ToString(),
                userTypeId=Guid.NewGuid().ToString()
            };
        }
        public CandidateAccount GetMockCandidateAccountInformation()
        {
            return new CandidateAccount()
            {
                candidateAddress = "testAddress",
                candidateDescription = "testDescription",
                candidateEducations = new List<EductationDetails>()
                {
                    new EductationDetails()
                    {
                        college = "testCollege",
                        currentlyGoingOn = false,
                        degree = "BCA",
                        endYear = 2020,
                        startYear = 2017
                    }
                },
                candidateEmail = "test@gmail.com",
                candidateExperience = new List<ExperienceDetails>()
                {
                    new ExperienceDetails()
                    {
                        companyName = "testCompany",
                        startYear = 2020,
                        endYear = 2021,
                        currentlyWorkingOn = false,
                        description = "test",
                        roles = ".Net Fullstack Web Developer"
                    }
                },
                candidateMobileNumber = "89797979797",
                candidateName = "Udhayarajan J",
                candidateProfileURL = "http://images.com/1.jpg",
                candidateResumeURL = "http://resume.com/2.pdf",
                candidateSkills = new List<Skills>()
                {
                    new Skills()
                    {
                        experienceOfSkills="2",
                        skillName  ="c#"
                    }
                },
                createdDate = DateTime.Now,
                documentObjectId = string.Empty,
                id = Guid.NewGuid().ToString(),
                isDeleted = false,
                lastUpdate = DateTime.Now
            };
        }
    }
}
