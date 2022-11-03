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
    public class TestJobRoleController
    {
        private Mock<IJobRolesRepository> _mockJobRolesRepository;
        private MockJobRoleController _mockJobRoleController;
        public TestJobRoleController()
        {
            _mockJobRoleController = new MockJobRoleController();
            _mockJobRolesRepository = new Mock<IJobRolesRepository>();
        }
        /// <summary>
        /// To Test Recruiter Save The New Role Details Should Be Saved The Data
        /// </summary>
        /// <returns></returns>
        [Fact(DisplayName = "To_Test_AddJobRoles_ShouldBe_Saved")]
        [Trait("Recruiter-Job-Roles", "To_Test_AddJobRoles_ShouldBe_Saved")]
        private async Task To_Test_AddJobRoles_ShouldBe_Saved()
        {
            //Arrange
            long result = 1;
            int expectedStatusCode = 200;
            JobRoles jobRoles = _mockJobRoleController.GetMockJobRole();
            _mockJobRolesRepository.Setup(x => x.AddJobRoles(jobRoles)).Returns(Task.FromResult(result));

            //Act
            JobRoleController jobRoleController = new JobRoleController(_mockJobRolesRepository.Object);
            var callAPI = jobRoleController.AddJobRoles(jobRoles);
            var actionResult = await callAPI as OkObjectResult;
            CommonApiReponse apiReponse = (CommonApiReponse)actionResult.Value;

            // Assert
            apiReponse.Should().NotBeNull();
            apiReponse.statusCode.Should().Be(expectedStatusCode);
            apiReponse.statusMessage.Should().BeEquivalentTo("Role Details Added...");
            apiReponse.responseData.Should().Be(result);
        }
        /// <summary>
        /// To Test Recruiter Save The New Role Details Should Not Be Saved The Data
        /// </summary>
        /// <returns></returns>
        [Fact(DisplayName = "To_Test_AddJobRoles_ShouldNotBe_Saved")]
        [Trait("Recruiter-Job-Roles", "To_Test_AddJobRoles_ShouldNotBe_Saved")]
        private async Task To_Test_AddJobRoles_ShouldNotBe_Saved()
        {
            //Arrange
            long result = 0;
            int expectedStatusCode = 404;
            JobRoles jobRoles = _mockJobRoleController.GetMockJobRole();
            _mockJobRolesRepository.Setup(x => x.AddJobRoles(jobRoles)).Returns(Task.FromResult(result));

            //Act
            JobRoleController jobRoleController = new JobRoleController(_mockJobRolesRepository.Object);
            var callAPI = jobRoleController.AddJobRoles(jobRoles);
            var actionResult = await callAPI as OkObjectResult;
            CommonApiReponse apiReponse = (CommonApiReponse)actionResult.Value;

            // Assert
            apiReponse.Should().NotBeNull();
            apiReponse.statusCode.Should().Be(expectedStatusCode);
            apiReponse.statusMessage.Should().BeEquivalentTo("Role Details Not Added...");
            apiReponse.responseData.Should().BeNull();
        }
        /// <summary>
        /// To Test Recruiter Update The Existing Role Details Should Be Update The Data
        /// </summary>
        /// <returns></returns>
        [Fact(DisplayName = "To_Test_UpdateJobRoles_ShouldBe_Updated")]
        [Trait("Recruiter-Job-Roles", "To_Test_UpdateJobRoles_ShouldBe_Updated")]
        private async Task To_Test_UpdateJobRoles_ShouldBe_Updated()
        {
            //Arrange
            long result = 1;
            int expectedStatusCode = 200;
            JobRoles jobRoles = _mockJobRoleController.GetMockJobRole();
            _mockJobRolesRepository.Setup(x => x.UpdateJobRoles(jobRoles)).Returns(Task.FromResult(result));

            //Act
            JobRoleController jobRoleController = new JobRoleController(_mockJobRolesRepository.Object);
            var callAPI = jobRoleController.UpdateJobRoles(jobRoles);
            var actionResult = await callAPI as OkObjectResult;
            CommonApiReponse apiReponse = (CommonApiReponse)actionResult.Value;

            // Assert
            apiReponse.Should().NotBeNull();
            apiReponse.statusCode.Should().Be(expectedStatusCode);
            apiReponse.statusMessage.Should().BeEquivalentTo("Role Details Updated...");
            apiReponse.responseData.Should().Be(result);
        }
        /// <summary>
        /// To Test Recruiter Update The Existing Role Details Should Not Be Update The Data
        /// </summary>
        /// <returns></returns>
        [Fact(DisplayName = "To_Test_UpdateJobRoles_ShouldNotBe_Updated")]
        [Trait("Recruiter-Job-Roles", "To_Test_UpdateJobRoles_ShouldNotBe_Updated")]
        private async Task To_Test_UpdateJobRoles_ShouldNotBe_Updated()
        {
            //Arrange
            long result = 0;
            int expectedStatusCode = 404;
            JobRoles jobRoles = _mockJobRoleController.GetMockJobRole();
            _mockJobRolesRepository.Setup(x => x.UpdateJobRoles(jobRoles)).Returns(Task.FromResult(result));

            //Act
            JobRoleController jobRoleController = new JobRoleController(_mockJobRolesRepository.Object);
            var callAPI = jobRoleController.UpdateJobRoles(jobRoles);
            var actionResult = await callAPI as OkObjectResult;
            CommonApiReponse apiReponse = (CommonApiReponse)actionResult.Value;

            // Assert
            apiReponse.Should().NotBeNull();
            apiReponse.statusCode.Should().Be(expectedStatusCode);
            apiReponse.statusMessage.Should().BeEquivalentTo("Role Details Not Updated...");
            apiReponse.responseData.Should().BeNull();
        }
        /// <summary>
        /// To Test Recruiter Delete The Existing Role Details Should Be Delete The Data
        /// </summary>
        /// <returns></returns>
        [Fact(DisplayName = "To_Test_DeleteJobRoles_ShouldBe_Deleted")]
        [Trait("Recruiter-Job-Roles", "To_Test_DeleteJobRoles_ShouldBe_Deleted")]
        private async Task To_Test_DeleteJobRoles_ShouldBe_Deleted()
        {
            //Arrange
            long result = 1;
            int expectedStatusCode = 200;
            string jobRoleId = Guid.NewGuid().ToString();
            _mockJobRolesRepository.Setup(x => x.DeleteJobRoles(jobRoleId)).Returns(Task.FromResult(result));

            //Act
            JobRoleController jobRoleController = new JobRoleController(_mockJobRolesRepository.Object);
            var callAPI = jobRoleController.DeleteJobRoles(jobRoleId);
            var actionResult = await callAPI as OkObjectResult;
            CommonApiReponse apiReponse = (CommonApiReponse)actionResult.Value;

            // Assert
            apiReponse.Should().NotBeNull();
            apiReponse.statusCode.Should().Be(expectedStatusCode);
            apiReponse.statusMessage.Should().BeEquivalentTo("Role Details Deleted...");
            apiReponse.responseData.Should().Be(result);
        }
        /// <summary>
        /// To Test Recruiter Delete The Existing Role Details Should Not Be Delete The Data
        /// </summary>
        /// <returns></returns>
        [Fact(DisplayName = "To_Test_DeleteJobRoles_ShouldNotBe_Deleted")]
        [Trait("Recruiter-Job-Roles", "To_Test_DeleteJobRoles_ShouldNotBe_Deleted")]
        private async Task To_Test_DeleteJobRoles_ShouldNotBe_Deleted()
        {
            //Arrange
            long result = 0;
            int expectedStatusCode = 404;
            string jobRoleId = Guid.NewGuid().ToString();
            _mockJobRolesRepository.Setup(x => x.DeleteJobRoles(jobRoleId)).Returns(Task.FromResult(result));

            //Act
            JobRoleController jobRoleController = new JobRoleController(_mockJobRolesRepository.Object);
            var callAPI = jobRoleController.DeleteJobRoles(jobRoleId);
            var actionResult = await callAPI as OkObjectResult;
            CommonApiReponse apiReponse = (CommonApiReponse)actionResult.Value;

            // Assert
            apiReponse.Should().NotBeNull();
            apiReponse.statusCode.Should().Be(expectedStatusCode);
            apiReponse.statusMessage.Should().BeEquivalentTo("Role Details Not Deleted...");
            apiReponse.responseData.Should().BeNull();
        }
        /// <summary>
        /// To Test Recruiter Get Saved Role Details Purpose Of Post Should Be Data Found
        /// </summary>
        /// <returns></returns>
        [Fact(DisplayName = "To_Test_GetRolesDetailsForDropdown_ShouldBe_Data_Found")]
        [Trait("Recruiter-Job-Roles", "To_Test_GetRolesDetailsForDropdown_ShouldBe_Data_Found")]
        private async Task To_Test_GetRolesDetailsForDropdown_ShouldBe_Data_Found()
        {
            //Arrange        
            int expectedStatusCode = 200;
            List<JobRoles> jobRoles = _mockJobRoleController.GetMockJobRoleListDataForDropDown();
            _mockJobRolesRepository.Setup(x => x.GetRolesDetailsForDropdown()).Returns(Task.FromResult(jobRoles));

            //Act
            JobRoleController jobRoleController = new JobRoleController(_mockJobRolesRepository.Object);
            var callAPI = jobRoleController.GetRolesDetailsForDropdown();
            var actionResult = await callAPI as OkObjectResult;
            CommonApiReponse apiReponse = (CommonApiReponse)actionResult.Value;

            // Assert
            apiReponse.Should().NotBeNull();
            apiReponse.statusCode.Should().Be(expectedStatusCode);
            apiReponse.statusMessage.Should().BeEquivalentTo("Role Details Found...");
            apiReponse.responseData.Should().Be(jobRoles);
        }
        /// <summary>
        /// To Test Recruiter Get Saved Role Details Purpose Of Post Should Not Be Data Found
        /// </summary>
        /// <returns></returns>
        [Fact(DisplayName = "To_Test_GetRolesDetailsForDropdown_ShouldNotBe_Data_Found")]
        [Trait("Recruiter-Job-Roles", "To_Test_GetRolesDetailsForDropdown_ShouldNotBe_Data_Found")]
        private async Task To_Test_GetRolesDetailsForDropdown_ShouldNotBe_Data_Found()
        {
            //Arrange        
            int expectedStatusCode = 404;
            List<JobRoles> jobRoles = null;
            _mockJobRolesRepository.Setup(x => x.GetRolesDetailsForDropdown()).Returns(Task.FromResult(jobRoles));

            //Act
            JobRoleController jobRoleController = new JobRoleController(_mockJobRolesRepository.Object);
            var callAPI = jobRoleController.GetRolesDetailsForDropdown();
            var actionResult = await callAPI as OkObjectResult;
            CommonApiReponse apiReponse = (CommonApiReponse)actionResult.Value;

            // Assert
            apiReponse.Should().NotBeNull();
            apiReponse.statusCode.Should().Be(expectedStatusCode);
            apiReponse.statusMessage.Should().BeEquivalentTo("Role Details Not Found...");
            apiReponse.responseData.Should().Be(jobRoles);
        }
        /// <summary>
        /// To Test Recruiter Get Saved Role Details Purpose Of View Table Should Be Data Found
        /// </summary>
        /// <returns></returns>
        [Fact(DisplayName = "To_Test_GetRolesDetailsForView_ShouldBe_Data_Found")]
        [Trait("Recruiter-Job-Roles", "To_Test_GetRolesDetailsForView_ShouldBe_Data_Found")]
        private async Task To_Test_GetRolesDetailsForView_ShouldBe_Data_Found()
        {
            //Arrange        
            int expectedStatusCode = 200;
            MulitpleApiResponse mulitpleApiResponse = _mockJobRoleController.GetMockJobRoleListDataForView();
            _mockJobRolesRepository.Setup(x => x.GetRolesDetailsForView(1,10,null)).Returns(Task.FromResult(mulitpleApiResponse));

            //Act
            JobRoleController jobRoleController = new JobRoleController(_mockJobRolesRepository.Object);
            var callAPI = jobRoleController.GetRolesDetailsForView(1, 10, null);
            var actionResult = await callAPI as OkObjectResult;
            CommonApiReponse apiReponse = (CommonApiReponse)actionResult.Value;

            // Assert
            apiReponse.Should().NotBeNull();
            apiReponse.statusCode.Should().Be(expectedStatusCode);
            apiReponse.statusMessage.Should().BeEquivalentTo("Role Details Found...");
            apiReponse.responseData.Should().Be(mulitpleApiResponse);
        }
        /// <summary>
        /// To Test Recruiter Get Saved Role Details Purpose Of View Table Should Not Be Data Found
        /// </summary>
        /// <returns></returns>
        [Fact(DisplayName = "To_Test_GetRolesDetailsForView_ShouldNotBe_Data_Found")]
        [Trait("Recruiter-Job-Roles", "To_Test_GetRolesDetailsForView_ShouldNotBe_Data_Found")]
        private async Task To_Test_GetRolesDetailsForView_ShouldNotBe_Data_Found()
        {
            //Arrange        
            int expectedStatusCode = 404;
            MulitpleApiResponse mulitpleApiResponse = null;
            _mockJobRolesRepository.Setup(x => x.GetRolesDetailsForView(1, 10, null)).Returns(Task.FromResult(mulitpleApiResponse));

            //Act
            JobRoleController jobRoleController = new JobRoleController(_mockJobRolesRepository.Object);
            var callAPI = jobRoleController.GetRolesDetailsForView(1, 10, null);
            var actionResult = await callAPI as OkObjectResult;
            CommonApiReponse apiReponse = (CommonApiReponse)actionResult.Value;

            // Assert
            apiReponse.Should().NotBeNull();
            apiReponse.statusCode.Should().Be(expectedStatusCode);
            apiReponse.statusMessage.Should().BeEquivalentTo("Role Details Not Found...");
            apiReponse.responseData.Should().Be(mulitpleApiResponse);
        }

    }
}
