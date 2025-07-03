using ClusterManagement.Models;
using Microsoft.EntityFrameworkCore;

namespace ClusterManagement.Repositories;

public class MessageRepository : IMessageRepository
{
    private readonly ClusterContext _context;
    public MessageRepository(ClusterContext context)
    {
        _context = context;
    }
    public async Task<Message> GetMessageByIdAsync(Guid id)
    {
        return await _context.Messages.FindAsync(id); 
    }
    public async Task<List<Message>> GetMessagesToAsync(Guid id)
    {
        return await _context.Messages.Where(m => m.To == id).ToListAsync();
    }
    public async Task<List<Message>> GetMessagesFromAsync(Guid id)
    {
        return await _context.Messages.Where(m => m.From == id).ToListAsync();
    }
    public async Task SendMessageAsync(Message message)
    {
        _context.Messages.Add(message);
        await _context.SaveChangesAsync();
    }
    public async Task<List<Message>> GetMessagesToAboutAsync(Guid to, Guid about)
    {
        return await _context.Messages.Where(m => m.To == to && m.About == about).ToListAsync();
    }


    
}
