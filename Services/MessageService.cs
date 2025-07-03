using ClusterManagement;
using ClusterManagement.Models;
using ClusterManagement.Repositories;

namespace ClusterManagement.Services;
public class MessageService : IMessageService
{
    private readonly IMessageRepository _messageRepository;
    public MessageService(IMessageRepository messageRepository)
    {
        _messageRepository = messageRepository;
    }

    public async Task<Message> GetMessageByIdAsync(Guid id)
    {
        return await _messageRepository.GetMessageByIdAsync(id);
    }

    public async Task<List<Message>> GetMessagesToAsync(Guid id)
    {
        return await _messageRepository.GetMessagesToAsync(id);
    }

    public async Task<List<Message>> GetMessagesFromAsync(Guid id)
    {
        return await _messageRepository.GetMessagesFromAsync(id);
    }

    public async Task SendMessageAsync(Message message)
    {
        await _messageRepository.SendMessageAsync(message);
    }

    public async Task<List<Message>> GetMessagesToAboutAsync(Guid to, Guid about)
    {
        return await _messageRepository.GetMessagesToAboutAsync(to, about);
    }
}

