using System.Collections.Generic;
using System.Threading.Tasks;
using ClusterManagement.Models;
using ClusterManagement.Repositories;
namespace ClusterManagement.Services;

public class ClusterService : IClusterService
{
    private readonly IClusterRepository _clusterRepository;
    public ClusterService(IClusterRepository clusterRepository)
    {
        _clusterRepository = clusterRepository;
    }
    public async Task<Cluster> GetClusterAsync(Guid clusterId)
    {
        return await _clusterRepository.GetClusterByIdAsync(clusterId);
    }
    public async Task<IEnumerable<Cluster>> GetAllClustersAsync()
    {
        return await _clusterRepository.GetAllClustersAsync();
    }

    public async Task<Cluster> GetClusterByIdAsync(Guid userId)
    {
        return await _clusterRepository.GetClusterByIdAsync(userId);
    }
}
