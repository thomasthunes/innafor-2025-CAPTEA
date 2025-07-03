using ClusterManagement.Models;
using ClusterManagement.Repositories;
namespace ClusterManagement.Services;
class ClusterUserService : IClusterUserService
{
    private readonly IClusterUserRepository _clusterUserRepository;
    public ClusterUserService(IClusterUserRepository clusterUserRepository)
    {
        _clusterUserRepository = clusterUserRepository;
    }

    public async Task<ClusterUser> GetUserByIdAsync(Guid userId)
    {
        return await _clusterUserRepository.GetUserByIdAsync(userId);
    }

    public async Task<IEnumerable<ClusterUser>> GetAllClusterUsersAsync()
    {
        return await _clusterUserRepository.GetAllClusterUsersAsync();
    }

    public async Task<IEnumerable<ClusterUser>> GetUsersByClusterIdAsync(Guid clusterId)
    {
        return await _clusterUserRepository.GetUsersByClusterIdAsync(clusterId);
    }
}
