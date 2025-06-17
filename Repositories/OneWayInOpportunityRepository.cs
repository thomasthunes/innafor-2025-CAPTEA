using ClusterManagement.Models;
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
        var oneWayInOpportunity = _context.OneWayInOpportunities.Find(id);
        return oneWayInOpportunity;
    }
    public Task<IEnumerable<OneWayInOpportunity>> GetAllAsync()
    {
        // Implementation to retrieve all OneWayInOpportunity records
        var oneWayInOpportunities = _context.OneWayInOpportunities.ToList();
        return Task.FromResult<IEnumerable<OneWayInOpportunity>>(oneWayInOpportunities);
    }
    public Task<IEnumerable<OneWayInOpportunity>> GetByClusterIdAsync(Guid clusterId)
    {
        // Implementation to retrieve OneWayInOpportunity records by Cluster ID
        var oneWayInOpportunities = _context.OneWayInOpportunities
            .Where(o => o.Cluster.Id == clusterId)
            .ToList();
        return Task.FromResult<IEnumerable<OneWayInOpportunity>>(oneWayInOpportunities);
    }
    public async Task<IEnumerable<OneWayInOpportunity>> GetByUserIdAsync(Guid userId)
    {
        // Implementation to retrieve OneWayInOpportunity records by User ID
        var oneWayInOpportunities = _context.OneWayInOpportunities
            .Where(o => o.AssignedTo.Id == userId)
            .ToList();
        return await Task.FromResult(oneWayInOpportunities);
    }
}
