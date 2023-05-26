using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoFixture.Xunit2;
using Microsoft.AspNetCore.Mvc;
using Moq;
using TestingControllersSample.Api;
using TestingControllersSample.ClientModels;
using TestingControllersSample.Core.Interfaces;
using TestingControllersSample.Core.Model;
using Xunit;

namespace TestingControllersSample.Tests.UnitTests
{
    public class ApiIdeasControllerTests
    {
        #region snippet_ApiIdeasControllerTests1
        [Fact]
        public async Task Create_ReturnsBadRequest_GivenInvalidModel()
        {
            // Arrange & Act
            var mockRepo = new Mock<IBrainstormSessionRepository>();
            var controller = new IdeasController(mockRepo.Object);
            controller.ModelState.AddModelError("error", "some error");

            // Act
            var result = await controller.Create(model: null);

            // Assert
            Assert.IsType<BadRequestObjectResult>(result);
        }
        #endregion

        #region snippet_ApiIdeasControllerTests2
        [Fact]
        public async Task Create_ReturnsHttpNotFound_ForInvalidSession()
        {
            // Arrange
            int testSessionId = 123;
            var mockRepo = new Mock<IBrainstormSessionRepository>();
            mockRepo.Setup(repo => repo.GetByIdAsync(testSessionId))
                .ReturnsAsync((BrainstormSession)null);
            var controller = new IdeasController(mockRepo.Object);

            // Act
            var result = await controller.Create(new NewIdeaModel());

            // Assert
            Assert.IsType<NotFoundObjectResult>(result);
        }
        #endregion

        #region snippet_ApiIdeasControllerTests3
        [Theory]
        [AutoDomainData]
        public async Task Create_ReturnsNewlyCreatedIdeaForSession(
            NewIdeaModel newIdea, BrainstormSession testSession)
        {
            // Arrange
            var mockRepo = new Mock<IBrainstormSessionRepository>();
            mockRepo.Setup(repo => repo.GetByIdAsync(newIdea.SessionId))
                .ReturnsAsync(testSession);
            var controller = new IdeasController(mockRepo.Object);

            
            mockRepo.Setup(repo => repo.UpdateAsync(testSession))
                .Returns(Task.CompletedTask)
                .Verifiable();

            // Act
            var result = await controller.Create(newIdea);

            // Assert
            var okResult = Assert.IsType<OkObjectResult>(result);
            var returnSession = Assert.IsType<BrainstormSession>(okResult.Value);
            mockRepo.Verify();
            Assert.Equal(2, returnSession.Ideas.Count());
            Assert.Equal(newIdea.Name, returnSession.Ideas.LastOrDefault().Name);
            Assert.Equal(newIdea.Description, returnSession.Ideas.LastOrDefault().Description);
        }
        #endregion

        #region snippet_ApiIdeasControllerTests4
        [Fact]
        public async Task ForSession_ReturnsHttpNotFound_ForInvalidSession()
        {
            // Arrange
            int testSessionId = 123;
            var mockRepo = new Mock<IBrainstormSessionRepository>();
            mockRepo.Setup(repo => repo.GetByIdAsync(testSessionId))
                .ReturnsAsync((BrainstormSession)null);
            var controller = new IdeasController(mockRepo.Object);

            // Act
            var result = await controller.ForSession(testSessionId);

            // Assert
            var notFoundObjectResult = Assert.IsType<NotFoundObjectResult>(result);
            Assert.Equal(testSessionId, notFoundObjectResult.Value);
        }
        #endregion

        #region snippet_ApiIdeasControllerTests5
        [Theory]
        [AutoDomainData]
        public async Task ForSession_ReturnsIdeasForSession(BrainstormSession testSession)
        {
            // Arrange
            testSession.Ideas[0].Name = "One";
            var mockRepo = new Mock<IBrainstormSessionRepository>();
            mockRepo.Setup(repo => repo.GetByIdAsync(testSession.Id))
                .ReturnsAsync(testSession);
            var controller = new IdeasController(mockRepo.Object);

            // Act
            var result = await controller.ForSession(testSession.Id);

            // Assert
            var okResult = Assert.IsType<OkObjectResult>(result);
            var returnValue = Assert.IsType<List<IdeaDTO>>(okResult.Value);
            var idea = returnValue.FirstOrDefault();
            Assert.Equal("One", idea.Name);
        }
        #endregion

        #region snippet_ForSessionActionResult_ReturnsNotFoundObjectResultForNonexistentSession
        [Fact]
        public async Task ForSessionActionResult_ReturnsNotFoundObjectResultForNonexistentSession()
        {
            // Arrange
            var mockRepo = new Mock<IBrainstormSessionRepository>();
            var controller = new IdeasController(mockRepo.Object);
            var nonExistentSessionId = 999;

            // Act
            var result = await controller.ForSessionActionResult(nonExistentSessionId);

            // Assert
            var actionResult = Assert.IsType<ActionResult<List<IdeaDTO>>>(result);
            Assert.IsType<NotFoundObjectResult>(actionResult.Result);
        }
        #endregion

        #region snippet_ForSessionActionResult_ReturnsIdeasForSession
        
        [Theory]
        [AutoDomainData]
        public async Task ForSessionActionResult_ReturnsIdeasForSession(BrainstormSession testSession)
        {
            // Arrange

            testSession.Ideas[0].Name = "One";
            var mockRepo = new Mock<IBrainstormSessionRepository>();
            mockRepo.Setup(repo => repo.GetByIdAsync(testSession.Id))
                .ReturnsAsync(testSession);
            var controller = new IdeasController(mockRepo.Object);

            // Act
            var result = await controller.ForSessionActionResult(testSession.Id);

            // Assert
            var actionResult = Assert.IsType<ActionResult<List<IdeaDTO>>>(result);
            var returnValue = Assert.IsType<List<IdeaDTO>>(actionResult.Value);
            var idea = returnValue.FirstOrDefault();
            Assert.Equal("One", idea.Name);
        }
        #endregion

        #region snippet_CreateActionResult_ReturnsBadRequest_GivenInvalidModel
        [Fact]
        public async Task CreateActionResult_ReturnsBadRequest_GivenInvalidModel()
        {
            // Arrange & Act
            var mockRepo = new Mock<IBrainstormSessionRepository>();
            var controller = new IdeasController(mockRepo.Object);
            controller.ModelState.AddModelError("error", "some error");

            // Act
            var result = await controller.CreateActionResult(model: null);

            // Assert
            var actionResult = Assert.IsType<ActionResult<BrainstormSession>>(result);
            Assert.IsType<BadRequestObjectResult>(actionResult.Result);
        }
        #endregion

        #region snippet_CreateActionResult_ReturnsNotFoundObjectResultForNonexistentSession
        [Theory]
        [AutoData]
        public async Task CreateActionResult_ReturnsNotFoundObjectResultForNonexistentSession(
            NewIdeaModel newIdea)
        {
            // Arrange
            var mockRepo = new Mock<IBrainstormSessionRepository>();
            var controller = new IdeasController(mockRepo.Object);

            // Act
            var result = await controller.CreateActionResult(newIdea);

            // Assert
            var actionResult = Assert.IsType<ActionResult<BrainstormSession>>(result);
            Assert.IsType<NotFoundObjectResult>(actionResult.Result);
        }
        #endregion

        #region snippet_CreateActionResult_ReturnsNewlyCreatedIdeaForSession
        [Theory]
        [AutoDomainData]
        public async Task CreateActionResult_ReturnsNewlyCreatedIdeaForSession(
            NewIdeaModel newIdea, BrainstormSession testSession)
        {
            // Arrange
            newIdea.SessionId = testSession.Id;
            var mockRepo = new Mock<IBrainstormSessionRepository>();
            mockRepo.Setup(repo => repo.GetByIdAsync(newIdea.SessionId))
                .ReturnsAsync(testSession);
            var controller = new IdeasController(mockRepo.Object);
            mockRepo.Setup(repo => repo.UpdateAsync(testSession))
                .Returns(Task.CompletedTask)
                .Verifiable();

            // Act
            var result = await controller.CreateActionResult(newIdea);

            // Assert
            var actionResult = Assert.IsType<ActionResult<BrainstormSession>>(result);
            var createdAtActionResult = Assert.IsType<CreatedAtActionResult>(actionResult.Result);
            var returnValue = Assert.IsType<BrainstormSession>(createdAtActionResult.Value);
            mockRepo.Verify();
            Assert.Equal(2, returnValue.Ideas.Count());
            Assert.Equal(newIdea.Name, returnValue.Ideas.LastOrDefault().Name);
            Assert.Equal(newIdea.Description, returnValue.Ideas.LastOrDefault().Description);
        }
        #endregion
    }
}
