using ClusterManagement.Models;
namespace ClusterManagement.Repositories;

public class  ClusterUserRepository : IClusterUserRepository
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
        return _context.ClusterUsers.ToList();
    }
    public async Task<IEnumerable<ClusterUser>> GetUsersByClusterIdAsync(Guid clusterId)
    {
        return _context.ClusterUsers
            .Where(cu => cu.Cluster.Id == clusterId)
            .ToList();
    }
}

