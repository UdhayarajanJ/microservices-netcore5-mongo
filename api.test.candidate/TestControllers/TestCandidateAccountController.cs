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

    public class TestCandidateAccountController
    {
        private Mock<ICanditateAccountRepository> _mockCandidateAccountRepository;
        private MockCandidateAccountController _mockCanidateAccountController;
        public TestCandidateAccountController()
        {
            _mockCandidateAccountRepository = new Mock<ICanditateAccountRepository>();
            _mockCanidateAccountController = new MockCandidateAccountController();
        }
        /// <summary>
        /// To Test The Login Details For Candidates Should Case Passed And Saved The Details
        /// </summary>
        /// <returns></returns>
        [Fact(DisplayName = "To_Test_AddCandidateLoginDetails_ShouldBe_Saved")]
        [Trait("CandidateAccount", "To_Test_AddCandidateLoginDetails_ShouldBe_Saved")]
        private async Task To_Test_AddCandidateLoginDetails_ShouldBe_Saved()
        {
            //Arrange
            long result = 1;
            int expectedStatusCode = 200;
            CandidateLoginDetails candidateAccountLoginDetails = _mockCanidateAccountController.GetMockCandidateLoginInformation();
            _mockCandidateAccountRepository.Setup(x => x.AddCandidateLoginDetails(candidateAccountLoginDetails)).Returns(Task.FromResult(result));

            //Act
            CanditateAccountController canditateAccountController = new CanditateAccountController(_mockCandidateAccountRepository.Object);
            var callAPI = canditateAccountController.AddCandidateLoginDetails(candidateAccountLoginDetails);
            var actionResult = await callAPI as OkObjectResult;
            CommonApiReponse apiReponse = (CommonApiReponse)actionResult.Value;

            // Assert
            apiReponse.Should().NotBeNull();
            apiReponse.statusCode.Should().Be(expectedStatusCode);
            apiReponse.statusMessage.Should().BeEquivalentTo("Login Details Saved...");
            apiReponse.responseData.Should().Be(result);
        }
        /// <summary>
        /// To Test The Login Details For Candidates Should Case Not Passed And Not Saved The Details
        /// </summary>
        /// <returns></returns>
        [Fact(DisplayName = "To_Test_AddCandidateLoginDetails_ShouldNotBe_Saved")]
        [Trait("CandidateAccount", "To_Test_AddCandidateLoginDetails_ShouldNotBe_Saved")]
        private async Task To_Test_AddCandidateLoginDetails_ShouldNotBe_Saved()
        {
            //Arrange
            long result = 0;
            int expectedStatusCode = 404;
            CandidateLoginDetails candidateAccountLoginDetails = _mockCanidateAccountController.GetMockCandidateLoginInformation();
            _mockCandidateAccountRepository.Setup(x => x.AddCandidateLoginDetails(candidateAccountLoginDetails)).Returns(Task.FromResult(result));

            //Act
            CanditateAccountController canditateAccountController = new CanditateAccountController(_mockCandidateAccountRepository.Object);
            var callAPI = canditateAccountController.AddCandidateLoginDetails(candidateAccountLoginDetails);
            var actionResult = await callAPI as OkObjectResult;
            CommonApiReponse apiReponse = (CommonApiReponse)actionResult.Value;

            // Assert
            apiReponse.Should().NotBeNull();
            apiReponse.statusCode.Should().Be(expectedStatusCode);
            apiReponse.statusMessage.Should().BeEquivalentTo("Login Details Not Saved...");
            apiReponse.responseData.Should().BeNull();
        }
        /// <summary>
        /// To Test The Login Details For Candidates Should Case Passed And Update The Details
        /// </summary>
        /// <returns></returns>
        [Fact(DisplayName = "To_Test_UpdateCandidateLoginDetails_ShouldBe_Updated")]
        [Trait("CandidateAccount", "To_Test_UpdateCandidateLoginDetails_ShouldBe_Updated")]
        private async Task To_Test_UpdateCandidateLoginDetails_ShouldBe_Updated()
        {
            //Arrange
            long result = 1;
            int expectedStatusCode = 200;
            CandidateLoginDetails candidateAccountLoginDetails = _mockCanidateAccountController.GetMockCandidateLoginInformation();
            _mockCandidateAccountRepository.Setup(x => x.UpdateCandidateLoginDetails(candidateAccountLoginDetails)).Returns(Task.FromResult(result));

            //Act
            CanditateAccountController canditateAccountController = new CanditateAccountController(_mockCandidateAccountRepository.Object);
            var callAPI = canditateAccountController.UpdateCandidateLoginDetails(candidateAccountLoginDetails);
            var actionResult = await callAPI as OkObjectResult;
            CommonApiReponse apiReponse = (CommonApiReponse)actionResult.Value;

            // Assert
            apiReponse.Should().NotBeNull();
            apiReponse.statusCode.Should().Be(expectedStatusCode);
            apiReponse.statusMessage.Should().BeEquivalentTo("Login Details Updated...");
            apiReponse.responseData.Should().Be(result);
        }
        /// <summary>
        ///  To Test The Login Details For Candidates Should Case Not Passed And Not Update The Details
        /// </summary>
        /// <returns></returns>
        [Fact(DisplayName = "To_Test_UpdateCandidateLoginDetails_ShouldNotBe_Updated")]
        [Trait("CandidateAccount", "To_Test_UpdateCandidateLoginDetails_ShouldNotBe_Updated")]
        private async Task To_Test_UpdateCandidateLoginDetails_ShouldNotBe_Updated()
        {
            //Arrange
            long result = 0;
            int expectedStatusCode = 404;
            CandidateLoginDetails candidateAccountLoginDetails = _mockCanidateAccountController.GetMockCandidateLoginInformation();
            _mockCandidateAccountRepository.Setup(x => x.UpdateCandidateLoginDetails(candidateAccountLoginDetails)).Returns(Task.FromResult(result));

            //Act
            CanditateAccountController canditateAccountController = new CanditateAccountController(_mockCandidateAccountRepository.Object);
            var callAPI = canditateAccountController.UpdateCandidateLoginDetails(candidateAccountLoginDetails);
            var actionResult = await callAPI as OkObjectResult;
            CommonApiReponse apiReponse = (CommonApiReponse)actionResult.Value;

            // Assert
            apiReponse.Should().NotBeNull();
            apiReponse.statusCode.Should().Be(expectedStatusCode);
            apiReponse.statusMessage.Should().BeEquivalentTo("Login Details Not Updated...");
            apiReponse.responseData.Should().BeNull();
        }
        /// <summary>
        /// To Test The Login Details For Candidates Should Case Passed And Delete The Details
        /// </summary>
        /// <returns></returns>
        [Fact(DisplayName = "To_Test_DeleteCandidateLoginDetails_ShouldBe_Deleted")]
        [Trait("CandidateAccount", "To_Test_DeleteCandidateLoginDetails_ShouldBe_Deleted")]
        private async Task To_Test_DeleteCandidateLoginDetails_ShouldBe_Deleted()
        {
            //Arrange
            long result = 1;
            int expectedStatusCode = 200;
            string candidateId = Guid.NewGuid().ToString();
            _mockCandidateAccountRepository.Setup(x => x.DeleteCandidateLoginDetails(candidateId)).Returns(Task.FromResult(result));

            //Act
            CanditateAccountController canditateAccountController = new CanditateAccountController(_mockCandidateAccountRepository.Object);
            var callAPI = canditateAccountController.DeleteCandidateLoginDetails(candidateId);
            var actionResult = await callAPI as OkObjectResult;
            CommonApiReponse apiReponse = (CommonApiReponse)actionResult.Value;

            // Assert
            apiReponse.Should().NotBeNull();
            apiReponse.statusCode.Should().Be(expectedStatusCode);
            apiReponse.statusMessage.Should().BeEquivalentTo("Candidate Details Deleted...");
            apiReponse.responseData.Should().Be(result);
        }
        /// <summary>
        /// To Test The Login Details For Candidates Should Case Not Passed And Not Delete The Details
        /// </summary>
        /// <returns></returns>
        [Fact(DisplayName = "To_Test_DeleteCandidateLoginDetails_ShouldNotBe_Deleted")]
        [Trait("CandidateAccount", "To_Test_DeleteCandidateLoginDetails_ShouldNotBe_Deleted")]
        private async Task To_Test_DeleteCandidateLoginDetails_ShouldNotBe_Deleted()
        {
            //Arrange
            long result = 0;
            int expectedStatusCode = 404;
            string candidateId = Guid.NewGuid().ToString();
            _mockCandidateAccountRepository.Setup(x => x.DeleteCandidateLoginDetails(candidateId)).Returns(Task.FromResult(result));

            //Act
            CanditateAccountController canditateAccountController = new CanditateAccountController(_mockCandidateAccountRepository.Object);
            var callAPI = canditateAccountController.DeleteCandidateLoginDetails(candidateId);
            var actionResult = await callAPI as OkObjectResult;
            CommonApiReponse apiReponse = (CommonApiReponse)actionResult.Value;

            // Assert
            apiReponse.Should().NotBeNull();
            apiReponse.statusCode.Should().Be(expectedStatusCode);
            apiReponse.statusMessage.Should().BeEquivalentTo("Candidate Details Not Deleted...");
            apiReponse.responseData.Should().BeNull();
        }
        /// <summary>
        /// To Test The Login Details For Candidates Should Case Passed And Authorized
        /// </summary>
        /// <returns></returns>
        [Fact(DisplayName = "To_Test_CheckCandidateLoginDetails_ShouldBe_Authorized")]
        [Trait("CandidateAccount", "To_Test_CheckCandidateLoginDetails_ShouldBe_Authorized")]
        private async Task To_Test_CheckCandidateLoginDetails_ShouldBe_Authorized()
        {
            //Arrange            
            int expectedStatusCode = 200;
            string candidateId = Guid.NewGuid().ToString();
            LoginCandidate loginCandidate = _mockCanidateAccountController.GetMockCandidateLoginRequest();
            LoginResponse loginResponse = _mockCanidateAccountController.GetMockCandidateLoginResponse();
            _mockCandidateAccountRepository.Setup(x => x.CheckCandidateLoginDetails(loginCandidate)).Returns(Task.FromResult(loginResponse));

            //Act
            CanditateAccountController canditateAccountController = new CanditateAccountController(_mockCandidateAccountRepository.Object);
            var callAPI = canditateAccountController.CheckCandidateLoginDetails(loginCandidate);
            var actionResult = await callAPI as OkObjectResult;
            CommonApiReponse apiReponse = (CommonApiReponse)actionResult.Value;

            // Assert
            apiReponse.Should().NotBeNull();
            apiReponse.statusCode.Should().Be(expectedStatusCode);
            apiReponse.statusMessage.Should().BeEquivalentTo("Login Details Found...");
            apiReponse.responseData.Should().Be(loginResponse);
        }
        /// <summary>
        /// To Test The Login Details For Candidates Should Case Not Passed And Not Authorized
        /// </summary>
        /// <returns></returns>
        [Fact(DisplayName = "To_Test_CheckCandidateLoginDetails_ShouldNotBe_Authorized")]
        [Trait("CandidateAccount", "To_Test_CheckCandidateLoginDetails_ShouldNotBe_Authorized")]
        private async Task To_Test_CheckCandidateLoginDetails_ShouldNotBe_Authorized()
        {
            //Arrange            
            int expectedStatusCode = 404;
            string candidateId = Guid.NewGuid().ToString();
            LoginCandidate loginCandidate = _mockCanidateAccountController.GetMockCandidateLoginRequest();
            LoginResponse loginResponse = null;
            _mockCandidateAccountRepository.Setup(x => x.CheckCandidateLoginDetails(loginCandidate)).Returns(Task.FromResult(loginResponse));

            //Act
            CanditateAccountController canditateAccountController = new CanditateAccountController(_mockCandidateAccountRepository.Object);
            var callAPI = canditateAccountController.CheckCandidateLoginDetails(loginCandidate);
            var actionResult = await callAPI as OkObjectResult;
            CommonApiReponse apiReponse = (CommonApiReponse)actionResult.Value;

            // Assert
            apiReponse.Should().NotBeNull();
            apiReponse.statusCode.Should().Be(expectedStatusCode);
            apiReponse.statusMessage.Should().BeEquivalentTo("Login Details Not Found...");
            apiReponse.responseData.Should().Be(loginResponse);
        }
        [Fact(DisplayName = "To_Test_AddCandidateInformation_ShouldBe_Saved")]
        [Trait("CandidateAccount", "To_Test_AddCandidateInformation_ShouldBe_Saved")]
        private async Task To_Test_AddCandidateInformation_ShouldBe_Saved()
        {
            //Arrange
            long result = 1;
            int expectedStatusCode = 200;
            CandidateAccount candidateAccount = _mockCanidateAccountController.GetMockCandidateAccountInformation();
            _mockCandidateAccountRepository.Setup(x => x.AddCandidateInformation(candidateAccount)).Returns(Task.FromResult(result));

            //Act
            CanditateAccountController canditateAccountController = new CanditateAccountController(_mockCandidateAccountRepository.Object);
            var callAPI = canditateAccountController.AddCandidateInformation(candidateAccount);
            var actionResult = await callAPI as OkObjectResult;
            CommonApiReponse apiReponse = (CommonApiReponse)actionResult.Value;

            // Assert
            apiReponse.Should().NotBeNull();
            apiReponse.statusCode.Should().Be(expectedStatusCode);
            apiReponse.statusMessage.Should().BeEquivalentTo("Candidate Details Saved...");
            apiReponse.responseData.Should().Be(result);
        }
        [Fact(DisplayName = "To_Test_AddCandidateInformation_ShouldNotBe_Saved")]
        [Trait("CandidateAccount", "To_Test_AddCandidateInformation_ShouldNotBe_Saved")]
        private async Task To_Test_AddCandidateInformation_ShouldNotBe_Saved()
        {
            //Arrange
            long result = 0;
            int expectedStatusCode = 404;
            CandidateAccount candidateAccount = _mockCanidateAccountController.GetMockCandidateAccountInformation();
            _mockCandidateAccountRepository.Setup(x => x.AddCandidateInformation(candidateAccount)).Returns(Task.FromResult(result));

            //Act
            CanditateAccountController canditateAccountController = new CanditateAccountController(_mockCandidateAccountRepository.Object);
            var callAPI = canditateAccountController.AddCandidateInformation(candidateAccount);
            var actionResult = await callAPI as OkObjectResult;
            CommonApiReponse apiReponse = (CommonApiReponse)actionResult.Value;

            // Assert
            apiReponse.Should().NotBeNull();
            apiReponse.statusCode.Should().Be(expectedStatusCode);
            apiReponse.statusMessage.Should().BeEquivalentTo("Candidate Details Not Saved...");
            apiReponse.responseData.Should().BeNull();
        }
        [Fact(DisplayName = "To_Test_UpdateCandidateInformation_ShouldBe_Update")]
        [Trait("CandidateAccount", "To_Test_UpdateCandidateInformation_ShouldBe_Update")]
        private async Task To_Test_UpdateCandidateInformation_ShouldBe_Update()
        {
            //Arrange
            long result = 1;
            int expectedStatusCode = 200;
            CandidateAccount candidateAccount = _mockCanidateAccountController.GetMockCandidateAccountInformation();
            _mockCandidateAccountRepository.Setup(x => x.UpdateCandidateInformation(candidateAccount)).Returns(Task.FromResult(result));

            //Act
            CanditateAccountController canditateAccountController = new CanditateAccountController(_mockCandidateAccountRepository.Object);
            var callAPI = canditateAccountController.UpdateCandidateInformation(candidateAccount);
            var actionResult = await callAPI as OkObjectResult;
            CommonApiReponse apiReponse = (CommonApiReponse)actionResult.Value;

            // Assert
            apiReponse.Should().NotBeNull();
            apiReponse.statusCode.Should().Be(expectedStatusCode);
            apiReponse.statusMessage.Should().BeEquivalentTo("Candidate Details Updated...");
            apiReponse.responseData.Should().Be(result);
        }
        [Fact(DisplayName = "To_Test_UpdateCandidateInformation_ShouldNotBe_Update")]
        [Trait("CandidateAccount", "To_Test_UpdateCandidateInformation_ShouldNotBe_Update")]
        private async Task To_Test_UpdateCandidateInformation_ShouldNotBe_Update()
        {
            //Arrange
            long result = 0;
            int expectedStatusCode = 404;
            CandidateAccount candidateAccount = _mockCanidateAccountController.GetMockCandidateAccountInformation();
            _mockCandidateAccountRepository.Setup(x => x.UpdateCandidateInformation(candidateAccount)).Returns(Task.FromResult(result));

            //Act
            CanditateAccountController canditateAccountController = new CanditateAccountController(_mockCandidateAccountRepository.Object);
            var callAPI = canditateAccountController.UpdateCandidateInformation(candidateAccount);
            var actionResult = await callAPI as OkObjectResult;
            CommonApiReponse apiReponse = (CommonApiReponse)actionResult.Value;

            // Assert
            apiReponse.Should().NotBeNull();
            apiReponse.statusCode.Should().Be(expectedStatusCode);
            apiReponse.statusMessage.Should().BeEquivalentTo("Candidate Details Not Updated...");
            apiReponse.responseData.Should().BeNull();
        }
    }
}
