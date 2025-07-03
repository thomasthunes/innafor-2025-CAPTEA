using ClusterManagement.Models;

namespace ClusterManagement.Repositories;
public interface IMessageRepository
{
    Task<Message> GetMessageByIdAsync(Guid id);
    Task<List<Message>> GetMessagesToAsync(Guid id);
    Task<List<Message>> GetMessagesFromAsync(Guid id);
    Task SendMessageAsync(Message message);
    Task<List<Message>> GetMessagesToAboutAsync(Guid to, Guid about);
}
