using ClusterManagement.Models;
namespace ClusterManagement.Services;
public interface IOneWayInOpportunityService
{
    Task<OneWayInOpportunity> GetByIdAsync(Guid id);
    Task<IEnumerable<OneWayInOpportunity>> GetAllAsync();
}
