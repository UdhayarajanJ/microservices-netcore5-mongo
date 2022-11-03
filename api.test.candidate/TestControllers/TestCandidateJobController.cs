using api.test.candidate.Mocks;
using app.canditates.api.Controllers;
using app.canditates.api.IRepository;
using app.canditates.api.Models;
using app.utility.microservice.Models;
using FluentAssertions;
using Microsoft.AspNetCore.Mvc;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace api.test.candidate.TestControllers
{
    public class TestCandidateJobController
    {
        private Mock<ICandidateApplyJobRepository> _mockCandidateApplyJobRepository;
        private MockCanidateJobController _mockCanidateJobController;
        public TestCandidateJobController()
        {
            _mockCandidateApplyJobRepository = new Mock<ICandidateApplyJobRepository>();
            _mockCanidateJobController = new MockCanidateJobController();
        }
        /// <summary>
        /// To Test The Apply For Job Candidates Should Case Passed And Apply Jobs
        /// </summary>
        /// <returns></returns>
        [Fact(DisplayName = "To_Test_ApplyCandidateJobs_ShouldBe_Applied")]
        [Trait("CandidateJobs", "To_Test_ApplyCandidateJobs_ShouldBe_Applied")]
        private async Task To_Test_ApplyCandidateJobs_ShouldBe_Applied()
        {
            //Arrange
            long result = 1;
            int expectedStatusCode = 200;
            CandidateApplyJobs candidateApplyJobs = _mockCanidateJobController.GetMockDataCandidateApplyJobs();
            _mockCandidateApplyJobRepository.Setup(x => x.CandidateApplyJobs(candidateApplyJobs)).Returns(Task.FromResult(result));

            //Act
            CanditatesJobController canditatesJobController = new CanditatesJobController(_mockCandidateApplyJobRepository.Object);
            var callAPI = canditatesJobController.CandidateApplyJobs(candidateApplyJobs);
            var actionResult = await callAPI as OkObjectResult;
            CommonApiReponse apiReponse = (CommonApiReponse)actionResult.Value;

            // Assert
            apiReponse.Should().NotBeNull();
            apiReponse.statusCode.Should().Be(expectedStatusCode);
            apiReponse.statusMessage.Should().BeEquivalentTo("Job Applied Successfully...");
            apiReponse.responseData.Should().Be(result);
        }
        /// <summary>
        /// To Test The Apply For Job Candidates Should Not Case Passed And Apply Jobs
        /// </summary>
        /// <returns></returns>
        [Fact(DisplayName = "To_Test_ApplyCandidateJobs_ShouldNotBe_Applied")]
        [Trait("CandidateJobs", "To_Test_ApplyCandidateJobs_ShouldNotBe_Applied")]
        private async Task To_Test_ApplyCandidateJobs_ShouldNotBe_Applied()
        {
            //Arrange
            long result = 0;
            int expectedStatusCode = 404;
            CandidateApplyJobs candidateApplyJobs = _mockCanidateJobController.GetMockDataCandidateApplyJobs();
            _mockCandidateApplyJobRepository.Setup(x => x.CandidateApplyJobs(candidateApplyJobs)).Returns(Task.FromResult(result));

            //Act
            CanditatesJobController canditatesJobController = new CanditatesJobController(_mockCandidateApplyJobRepository.Object);
            var callAPI = canditatesJobController.CandidateApplyJobs(candidateApplyJobs);
            var actionResult = await callAPI as OkObjectResult;
            CommonApiReponse apiReponse = (CommonApiReponse)actionResult.Value;

            // Assert
            apiReponse.Should().NotBeNull();
            apiReponse.statusCode.Should().Be(expectedStatusCode);
            apiReponse.statusMessage.Should().BeEquivalentTo("Job Applied Failed...");
            apiReponse.responseData.Should().BeNull();
        }
    }
}
