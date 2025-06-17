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

    public Message GetMessageById(Guid id)
    {
        return _messageRepository.GetMessageById(id);
    }

    public List<Message> GetMessagesTo(Guid id)
    {
        return _messageRepository.GetMessagesTo(id);
    }

    public List<Message> GetMessagesFrom(Guid id)
    {
        return _messageRepository.GetMessagesFrom(id);
    }

    public void SendMessage(Message message)
    {
        _messageRepository.SendMessage(message);
    }

    public List<Message> GetMessagesToAbout(Guid to, Guid about)
    {
        return _messageRepository.GetMessagesToAbout(to, about);
    }
}

