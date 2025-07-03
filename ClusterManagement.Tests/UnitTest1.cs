using Microsoft.EntityFrameworkCore;
using ClusterManagement.Models;
using ClusterManagement.Services;
using ClusterManagement.Repositories;

namespace ClusterManagement.Tests;

public class MessageServiceTests
{
    private ClusterContext GetInMemoryContext()
    {
        var options = new DbContextOptionsBuilder<ClusterContext>()
            .UseInMemoryDatabase(databaseName: Guid.NewGuid().ToString())
            .Options;
        return new ClusterContext(options);
    }

    [Fact]
    public async Task SendMessageAsync_ShouldCreateMessage_WhenValidDataProvided()
    {
        using var context = GetInMemoryContext();
        var repository = new MessageRepository(context);
        var service = new MessageService(repository);

        var fromId = Guid.NewGuid();
        var toId = Guid.NewGuid();
        var aboutId = Guid.NewGuid();
        var content = "Test message";

        var message = new Message(fromId, toId, aboutId, content);
        await service.SendMessageAsync(message);

        var messages = await context.Messages.ToListAsync();
        Assert.Single(messages);
        Assert.Equal(content, messages[0].Content);
        Assert.Equal(fromId, messages[0].From);
        Assert.Equal(toId, messages[0].To);
        Assert.Equal(aboutId, messages[0].About);
    }

    [Fact]
    public async Task GetMessageByIdAsync_ShouldReturnMessage_WhenMessageExists()
    {
        using var context = GetInMemoryContext();
        var repository = new MessageRepository(context);
        var service = new MessageService(repository);

        var message = new Message(Guid.NewGuid(), Guid.NewGuid(), Guid.NewGuid(), "Test content");
        context.Messages.Add(message);
        await context.SaveChangesAsync();

        var result = await service.GetMessageByIdAsync(message.Id);

        Assert.NotNull(result);
        Assert.Equal(message.Content, result.Content);
    }

    [Fact]
    public async Task GetMessageByIdAsync_ShouldReturnNull_WhenMessageDoesNotExist()
    {
        using var context = GetInMemoryContext();
        var repository = new MessageRepository(context);
        var service = new MessageService(repository);

        var result = await service.GetMessageByIdAsync(Guid.NewGuid());

        Assert.Null(result);
    }
}
