using ClusterManagement.Models;
using Microsoft.EntityFrameworkCore;
namespace ClusterManagement.Repositories;

public class ClusterUserRepository : IClusterUserRepository
{
    private readonly ClusterContext _context;
    public ClusterUserRepository(ClusterContext context)
    {
        _context = context;
    }
    public async Task<ClusterUser> GetUserByIdAsync(Guid userId)
    {
        return await _context.ClusterUsers.FindAsync(userId);
    }
    public async Task<IEnumerable<ClusterUser>> GetAllClusterUsersAsync()
    {
        return await _context.ClusterUsers.ToListAsync();
    }
    public async Task<IEnumerable<ClusterUser>> GetUsersByClusterIdAsync(Guid clusterId)
    {
        return await _context.ClusterUsers
            .Where(cu => cu.Cluster.Id == clusterId)
            .ToListAsync();
    }
}

