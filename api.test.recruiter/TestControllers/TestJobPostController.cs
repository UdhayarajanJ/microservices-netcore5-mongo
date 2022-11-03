using api.test.recruiter.Mocks;
using app.recruiter.api.Controllers;
using app.recruiter.api.IRepository;
using app.recruiter.api.Models;
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

namespace api.test.recruiter.TestControllers
{
    public class TestJobPostController
    {
        private Mock<IJobPostRepository> _mockJobPostRepository;
        private MockJobPosterController _mockJobPostController;
        public TestJobPostController()
        {
            _mockJobPostRepository = new Mock<IJobPostRepository>();
            _mockJobPostController = new MockJobPosterController();
        }
        [Fact(DisplayName = "To_Test_AddJobPost_ShouldBe_Posted")]
        [Trait("Recruiter-Job-Post", "To_Test_AddJobPost_ShouldBe_Posted")]
        private async Task To_Test_AddJobPost_ShouldBe_Posted()
        {
            //Arrange
            long result = 1;
            int expectedStatusCode = 200;
            JobPost jobPost = _mockJobPostController.GetMockJobPostValue();
            _mockJobPostRepository.Setup(x => x.AddJobPost(jobPost)).Returns(Task.FromResult(result));

            //Act
            JobPostController jobPostController = new JobPostController(_mockJobPostRepository.Object);
            var callAPI = jobPostController.AddJobPost(jobPost);
            var actionResult = await callAPI as OkObjectResult;
            CommonApiReponse apiReponse = (CommonApiReponse)actionResult.Value;

            // Assert
            apiReponse.Should().NotBeNull();
            apiReponse.statusCode.Should().Be(expectedStatusCode);
            apiReponse.statusMessage.Should().BeEquivalentTo("Job Post Details Saved...");
            apiReponse.responseData.Should().Be(result);
        }
        [Fact(DisplayName = "To_Test_AddJobPost_ShouldNotBe_Posted")]
        [Trait("Recruiter-Job-Post", "To_Test_AddJobPost_ShouldNotBe_Posted")]
        private async Task To_Test_AddJobPost_ShouldNotBe_Posted()
        {
            //Arrange
            long result = 0;
            int expectedStatusCode = 404;
            JobPost jobPost = _mockJobPostController.GetMockJobPostValue();
            _mockJobPostRepository.Setup(x => x.AddJobPost(jobPost)).Returns(Task.FromResult(result));

            //Act
            JobPostController jobPostController = new JobPostController(_mockJobPostRepository.Object);
            var callAPI = jobPostController.AddJobPost(jobPost);
            var actionResult = await callAPI as OkObjectResult;
            CommonApiReponse apiReponse = (CommonApiReponse)actionResult.Value;

            // Assert
            apiReponse.Should().NotBeNull();
            apiReponse.statusCode.Should().Be(expectedStatusCode);
            apiReponse.statusMessage.Should().BeEquivalentTo("Job Post Details Not Saved...");
            apiReponse.responseData.Should().BeNull();
        }
        [Fact(DisplayName = "To_Test_UpdateJobPost_ShouldBe_Updated")]
        [Trait("Recruiter-Job-Post", "To_Test_UpdateJobPost_ShouldBe_Updated")]
        private async Task To_Test_UpdateJobPost_ShouldBe_Updated()
        {
            //Arrange
            long result = 1;
            int expectedStatusCode = 200;
            JobPost jobPost = _mockJobPostController.GetMockJobPostValue();
            _mockJobPostRepository.Setup(x => x.UpdateJobPost(jobPost)).Returns(Task.FromResult(result));

            //Act
            JobPostController jobPostController = new JobPostController(_mockJobPostRepository.Object);
            var callAPI = jobPostController.UpdateJobPost(jobPost);
            var actionResult = await callAPI as OkObjectResult;
            CommonApiReponse apiReponse = (CommonApiReponse)actionResult.Value;

            // Assert
            apiReponse.Should().NotBeNull();
            apiReponse.statusCode.Should().Be(expectedStatusCode);
            apiReponse.statusMessage.Should().BeEquivalentTo("Job Post Details Updated...");
            apiReponse.responseData.Should().Be(result);
        }
        [Fact(DisplayName = "To_Test_UpdateJobPost_ShouldNotBe_Updated")]
        [Trait("Recruiter-Job-Post", "To_Test_UpdateJobPost_ShouldNotBe_Updated")]
        private async Task To_Test_UpdateJobPost_ShouldNotBe_Updated()
        {
            //Arrange
            long result = 0;
            int expectedStatusCode = 404;
            JobPost jobPost = _mockJobPostController.GetMockJobPostValue();
            _mockJobPostRepository.Setup(x => x.UpdateJobPost(jobPost)).Returns(Task.FromResult(result));

            //Act
            JobPostController jobPostController = new JobPostController(_mockJobPostRepository.Object);
            var callAPI = jobPostController.UpdateJobPost(jobPost);
            var actionResult = await callAPI as OkObjectResult;
            CommonApiReponse apiReponse = (CommonApiReponse)actionResult.Value;

            // Assert
            apiReponse.Should().NotBeNull();
            apiReponse.statusCode.Should().Be(expectedStatusCode);
            apiReponse.statusMessage.Should().BeEquivalentTo("Job Post Details Not Updated...");
            apiReponse.responseData.Should().BeNull();
        }
        [Fact(DisplayName = "To_Test_DeleteJobPost_ShouldBe_Deleted")]
        [Trait("Recruiter-Job-Post", "To_Test_DeleteJobPost_ShouldBe_Deleted")]
        private async Task To_Test_DeleteJobPost_ShouldBe_Deleted()
        {
            //Arrange
            long result = 1;
            int expectedStatusCode = 200;
            string jobPostId = Guid.NewGuid().ToString();
            _mockJobPostRepository.Setup(x => x.DeleteJobPost(jobPostId)).Returns(Task.FromResult(result));

            //Act
            JobPostController jobPostController = new JobPostController(_mockJobPostRepository.Object);
            var callAPI = jobPostController.DeleteJobPost(jobPostId);
            var actionResult = await callAPI as OkObjectResult;
            CommonApiReponse apiReponse = (CommonApiReponse)actionResult.Value;

            // Assert
            apiReponse.Should().NotBeNull();
            apiReponse.statusCode.Should().Be(expectedStatusCode);
            apiReponse.statusMessage.Should().BeEquivalentTo("Job Post Details Deleted...");
            apiReponse.responseData.Should().Be(result);
        }
        [Fact(DisplayName = "To_Test_DeleteJobPost_ShouldNotBe_Deleted")]
        [Trait("Recruiter-Job-Post", "To_Test_DeleteJobPost_ShouldNotBe_Deleted")]
        private async Task To_Test_DeleteJobPost_ShouldNotBe_Deleted()
        {
            //Arrange
            long result = 0;
            int expectedStatusCode = 404;
            string jobPostId = Guid.NewGuid().ToString();
            _mockJobPostRepository.Setup(x => x.DeleteJobPost(jobPostId)).Returns(Task.FromResult(result));

            //Act
            JobPostController jobPostController = new JobPostController(_mockJobPostRepository.Object);
            var callAPI = jobPostController.DeleteJobPost(jobPostId);
            var actionResult = await callAPI as OkObjectResult;
            CommonApiReponse apiReponse = (CommonApiReponse)actionResult.Value;

            // Assert
            apiReponse.Should().NotBeNull();
            apiReponse.statusCode.Should().Be(expectedStatusCode);
            apiReponse.statusMessage.Should().BeEquivalentTo("Job Post Details Not Deleted...");
            apiReponse.responseData.Should().BeNull();
        }
        [Fact(DisplayName = "To_Test_GetJobPostDetailsForView_ShouldBe_DataFound")]
        [Trait("Recruiter-Job-Post", "To_Test_GetJobPostDetailsForView_ShouldBe_DataFound")]
        private async Task To_Test_GetJobPostDetailsForView_ShouldBe_DataFound()
        {
            //Arrange
            int expectedStatusCode = 200;
            MulitpleApiResponse mulitpleApiResponse = _mockJobPostController.GetMockJobRoleListDataForView();
            _mockJobPostRepository.Setup(x => x.GetJobPostDetailsForView(1,10,null,true)).Returns(Task.FromResult(mulitpleApiResponse));

            //Act
            JobPostController jobPostController = new JobPostController(_mockJobPostRepository.Object);
            var callAPI = jobPostController.GetJobPostDetailsForView(1, 10, null, true);
            var actionResult = await callAPI as OkObjectResult;
            CommonApiReponse apiReponse = (CommonApiReponse)actionResult.Value;

            // Assert
            apiReponse.Should().NotBeNull();
            apiReponse.statusCode.Should().Be(expectedStatusCode);
            apiReponse.statusMessage.Should().BeEquivalentTo("Job Post Details Found...");
            apiReponse.responseData.Should().Be(mulitpleApiResponse);
        }
        [Fact(DisplayName = "To_Test_GetJobPostDetailsForView_ShouldNotBe_DataFound")]
        [Trait("Recruiter-Job-Post", "To_Test_GetJobPostDetailsForView_ShouldNotBe_DataFound")]
        private async Task To_Test_GetJobPostDetailsForView_ShouldNotBe_DataFound()
        {
            //Arrange
            int expectedStatusCode = 404;
            MulitpleApiResponse mulitpleApiResponse = null;
            _mockJobPostRepository.Setup(x => x.GetJobPostDetailsForView(1, 10, null, true)).Returns(Task.FromResult(mulitpleApiResponse));

            //Act
            JobPostController jobPostController = new JobPostController(_mockJobPostRepository.Object);
            var callAPI = jobPostController.GetJobPostDetailsForView(1, 10, null, true);
            var actionResult = await callAPI as OkObjectResult;
            CommonApiReponse apiReponse = (CommonApiReponse)actionResult.Value;

            // Assert
            apiReponse.Should().NotBeNull();
            apiReponse.statusCode.Should().Be(expectedStatusCode);
            apiReponse.statusMessage.Should().BeEquivalentTo("Job Post Details Not Found...");
            apiReponse.responseData.Should().Be(mulitpleApiResponse);
        }
        [Fact(DisplayName = "To_Test_GetPostJobStatus_ShouldBe_DataFound")]
        [Trait("Recruiter-Job-Post", "To_Test_GetPostJobStatus_ShouldBe_DataFound")]
        private async Task To_Test_GetPostJobStatus_ShouldBe_DataFound()
        {
            //Arrange
            int expectedStatusCode = 200;
            JobPostStatusCount jobPostStatusCount = _mockJobPostController.GetMockJobPostStatusCount();
            _mockJobPostRepository.Setup(x => x.GetPostJobStatus()).Returns(Task.FromResult(jobPostStatusCount));

            //Act
            JobPostController jobPostController = new JobPostController(_mockJobPostRepository.Object);
            var callAPI = jobPostController.GetPostJobStatus();
            var actionResult = await callAPI as OkObjectResult;
            CommonApiReponse apiReponse = (CommonApiReponse)actionResult.Value;

            // Assert
            apiReponse.Should().NotBeNull();
            apiReponse.statusCode.Should().Be(expectedStatusCode);
            apiReponse.statusMessage.Should().BeEquivalentTo("Job Post Details Found...");
            apiReponse.responseData.Should().Be(jobPostStatusCount);
        }
        [Fact(DisplayName = "To_Test_GetPostJobStatus_ShouldNotBe_DataFound")]
        [Trait("Recruiter-Job-Post", "To_Test_GetPostJobStatus_ShouldNotBe_DataFound")]
        private async Task To_Test_GetPostJobStatus_ShouldNotBe_DataFound()
        {
            //Arrange
            int expectedStatusCode = 404;
            JobPostStatusCount jobPostStatusCount = null;
            _mockJobPostRepository.Setup(x => x.GetPostJobStatus()).Returns(Task.FromResult(jobPostStatusCount));

            //Act
            JobPostController jobPostController = new JobPostController(_mockJobPostRepository.Object);
            var callAPI = jobPostController.GetPostJobStatus();
            var actionResult = await callAPI as OkObjectResult;
            CommonApiReponse apiReponse = (CommonApiReponse)actionResult.Value;

            // Assert
            apiReponse.Should().NotBeNull();
            apiReponse.statusCode.Should().Be(expectedStatusCode);
            apiReponse.statusMessage.Should().BeEquivalentTo("Job Post Details Not Found...");
            apiReponse.responseData.Should().Be(jobPostStatusCount);
        }

    }
}
