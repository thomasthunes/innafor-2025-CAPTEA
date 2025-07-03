using ClusterManagement.Models;
using ClusterManagement.Repositories;
namespace ClusterManagement.Services;
class OneWayInOpportunityService : IOneWayInOpportunityService
{
    private readonly IOneWayInOpportunityRepository _oneWayInOpportunityRepository;
    public OneWayInOpportunityService(IOneWayInOpportunityRepository oneWayInOpportunityRepository)
    {
        _oneWayInOpportunityRepository = oneWayInOpportunityRepository;
    }
    
    public async Task<OneWayInOpportunity> GetByIdAsync(Guid id)
    {
        return await _oneWayInOpportunityRepository.GetByIdAsync(id);
    }
    public async Task<IEnumerable<OneWayInOpportunity>> GetAllAsync()
    {
        return await _oneWayInOpportunityRepository.GetAllAsync();
    }
}
