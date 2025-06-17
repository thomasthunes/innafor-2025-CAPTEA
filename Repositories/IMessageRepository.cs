using ClusterManagement.Models;

namespace ClusterManagement.Repositories;
public interface IMessageRepository
{
    Message GetMessageById(Guid id);
    List<Message> GetMessagesTo(Guid id);
    List<Message> GetMessagesFrom(Guid id);
    void SendMessage(Message message);
    List<Message> GetMessagesToAbout(Guid to, Guid about);
}
