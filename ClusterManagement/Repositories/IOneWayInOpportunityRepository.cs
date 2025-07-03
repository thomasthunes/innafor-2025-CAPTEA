using ClusterManagement.Models;
namespace ClusterManagement.Repositories;
public interface IOneWayInOpportunityRepository
{
    Task<OneWayInOpportunity> GetByIdAsync(Guid id);
    Task<IEnumerable<OneWayInOpportunity>> GetAllAsync();
    Task<IEnumerable<OneWayInOpportunity>> GetByClusterIdAsync(Guid clusterId);
    Task<IEnumerable<OneWayInOpportunity>> GetByUserIdAsync(Guid userId);
}
