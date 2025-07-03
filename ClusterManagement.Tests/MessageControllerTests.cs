using Microsoft.AspNetCore.Mvc;
using Moq;
using ClusterManagement.Controllers;
using ClusterManagement.Services;
using ClusterManagement.Models;

namespace ClusterManagement.Tests;

public class MessageControllerTests
{
    [Fact]
    public async Task GetMessage_ShouldReturnOkResult_WhenMessageExists()
    {
        var mockService = new Mock<IMessageService>();
        var messageId = Guid.NewGuid();
        var expectedMessage = new Message(Guid.NewGuid(), Guid.NewGuid(), Guid.NewGuid(), "Test content");
        
        mockService.Setup(s => s.GetMessageByIdAsync(messageId))
            .ReturnsAsync(expectedMessage);

        var controller = new MessageController(mockService.Object);

        var result = await controller.GetMessage(messageId);

        var okResult = Assert.IsType<OkObjectResult>(result);
        var returnedMessage = Assert.IsType<Message>(okResult.Value);
        Assert.Equal(expectedMessage.Content, returnedMessage.Content);
    }

    [Fact]
    public async Task GetMessage_ShouldReturnNotFound_WhenMessageDoesNotExist()
    {
        var mockService = new Mock<IMessageService>();
        var messageId = Guid.NewGuid();
        
        mockService.Setup(s => s.GetMessageByIdAsync(messageId))
            .ReturnsAsync((Message?)null);

        var controller = new MessageController(mockService.Object);

        var result = await controller.GetMessage(messageId);

        Assert.IsType<NotFoundResult>(result);
    }

    [Fact]
    public async Task SendMessage_ShouldReturnOkResult_WhenValidRequest()
    {
        var mockService = new Mock<IMessageService>();
        var controller = new MessageController(mockService.Object);
        
        var fromId = Guid.NewGuid();
        var toId = Guid.NewGuid();
        var aboutId = Guid.NewGuid();
        var content = "Test message";

        var message = new Message(fromId, toId, aboutId, content);
        mockService.Setup(s => s.SendMessageAsync(It.Is<Message>(m => m.Content == content)))
            .Returns(Task.CompletedTask);

        await controller.SendMessage(message);

        mockService.Verify(s => s.SendMessageAsync(It.Is<Message>(m => m.Content == content)), Times.Once);
    }
}