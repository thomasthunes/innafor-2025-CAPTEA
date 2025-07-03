using ClusterManagement.Models;
using Microsoft.EntityFrameworkCore;
namespace ClusterManagement.Repositories;
public class OneWayInOpportunityRepository: IOneWayInOpportunityRepository
{
    private readonly ClusterContext _context;
    public OneWayInOpportunityRepository(ClusterContext context)
    {
        _context = context;
    }
    public async Task<OneWayInOpportunity> GetByIdAsync(Guid id)
    {
        // Implementation to retrieve a OneWayInOpportunity by its ID
        var oneWayInOpportunity = await _context.OneWayInOpportunities.FindAsync(id);
        return oneWayInOpportunity;
    }
    public async Task<IEnumerable<OneWayInOpportunity>> GetAllAsync()
    {
        // Implementation to retrieve all OneWayInOpportunity records
        var oneWayInOpportunities = await _context.OneWayInOpportunities.ToListAsync();
        return oneWayInOpportunities;
    }
    public async Task<IEnumerable<OneWayInOpportunity>> GetByClusterIdAsync(Guid clusterId)
    {
        // Implementation to retrieve OneWayInOpportunity records by Cluster ID
        var oneWayInOpportunities = await _context.OneWayInOpportunities
            .Where(o => o.Cluster.Id == clusterId)
            .ToListAsync();
        return oneWayInOpportunities;
    }
    public async Task<IEnumerable<OneWayInOpportunity>> GetByUserIdAsync(Guid userId)
    {
        // Implementation to retrieve OneWayInOpportunity records by User ID
        var oneWayInOpportunities = await _context.OneWayInOpportunities
            .Where(o => o.AssignedTo.Id == userId)
            .ToListAsync();
        return oneWayInOpportunities;
    }
}
