using ClusterManagement.Models;
using Microsoft.EntityFrameworkCore;
namespace ClusterManagement.Repositories;
public class ClusterRepository : IClusterRepository
{
    private readonly ClusterContext _context;
    public ClusterRepository(ClusterContext context)
    {
        _context = context;
    }
    public async Task<Cluster> GetClusterByIdAsync(Guid clusterId)
    {
        var cluster = await _context.Clusters.FindAsync(clusterId);
        return cluster;
    }
    public async Task<IEnumerable<Cluster>> GetAllClustersAsync()
    {
        var clusters = await _context.Clusters.ToListAsync();
        return clusters;
    }
}

