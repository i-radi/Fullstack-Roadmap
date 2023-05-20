using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoFixture.Xunit2;
using Microsoft.AspNetCore.Mvc;
using Moq;
using TestingControllersSample.Controllers;
using TestingControllersSample.Core.Interfaces;
using TestingControllersSample.Core.Model;
using TestingControllersSample.ViewModels;
using Xunit;

namespace TestingControllersSample.Tests.UnitTests
{
    public class HomeControllerTests
    {
        #region snippet_Index_ReturnsAViewResult_WithAListOfBrainstormSessions

        [Theory]
        [AutoDomainData]
        public async Task Index_ReturnsAViewResult_WithAListOfBrainstormSessions(
            [CollectionSize(2)] List<BrainstormSession> brainstormSessions,
            [Frozen] Mock<IBrainstormSessionRepository> mockRepo,
            [Greedy] HomeController controller)
        {
            // Arrange
            mockRepo.Setup(repo => repo.ListAsync())
                .ReturnsAsync(brainstormSessions);

            // Act
            var result = await controller.Index();

            // Assert
            var viewResult = Assert.IsType<ViewResult>(result);
            var model = Assert.IsAssignableFrom<IEnumerable<StormSessionViewModel>>(
                viewResult.ViewData.Model);
            Assert.Equal(2, model.Count());
        }

        #endregion

        #region snippet_ModelState_ValidOrInvalid

        [Theory]
        [AutoDomainData]
        public async Task IndexPost_ReturnsBadRequestResult_WhenModelStateIsInvalid(
            List<BrainstormSession> brainstormSessions,
            [Frozen] Mock<IBrainstormSessionRepository> mockRepo,
            [Greedy] HomeController controller)
        {
            // Arrange
            mockRepo.Setup(repo => repo.ListAsync())
                .ReturnsAsync(brainstormSessions);
            controller.ModelState.AddModelError(nameof(HomeController.NewSessionModel.SessionName), "Required");
            var newSession = new HomeController.NewSessionModel();

            // Act
            var result = await controller.Index(newSession);

            // Assert
            var badRequestResult = Assert.IsType<BadRequestObjectResult>(result);
            Assert.IsType<SerializableError>(badRequestResult.Value);
        }

        [Theory]
        [AutoDomainData]
        public async Task IndexPost_ReturnsARedirectAndAddsSession_WhenModelStateIsValid(
            [Frozen] Mock<IBrainstormSessionRepository> mockRepo,
            [Greedy] HomeController controller,
            HomeController.NewSessionModel newSession)
        {
            // Arrange
            mockRepo.Setup(repo => repo.AddAsync(It.IsAny<BrainstormSession>()))
                .Returns(Task.CompletedTask)
                .Verifiable();

            // Act
            var result = await controller.Index(newSession);

            // Assert
            var redirectToActionResult = Assert.IsType<RedirectToActionResult>(result);
            Assert.Null(redirectToActionResult.ControllerName);
            Assert.Equal("Index", redirectToActionResult.ActionName);
            mockRepo.Verify();
        }

        #endregion
    }
}