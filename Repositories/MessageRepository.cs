using ClusterManagement.Models;

namespace ClusterManagement.Repositories;

public class MessageRepository : IMessageRepository
{
    private readonly ClusterContext _context;
    public MessageRepository(ClusterContext context)
    {
        _context = context;
    }
    public Message GetMessageById(Guid id)
    {
        return _context.Messages.Find(id) ?? throw new KeyNotFoundException($"Message with ID {id} not found.");
    }
    public List<Message> GetMessagesTo(Guid id)
    {
        return _context.Messages.Where(m => m.To == id).ToList();
    }
    public List<Message> GetMessagesFrom(Guid id)
    {
        return _context.Messages.Where(m => m.From == id).ToList();
    }
    public void SendMessage(Message message)
    {
        _context.Messages.Add(message);
        _context.SaveChanges();
    }
    public List<Message> GetMessagesToAbout(Guid to, Guid about)
    {
        return _context.Messages.Where(m => m.To == to && m.About == about).ToList();
    }


    
}
