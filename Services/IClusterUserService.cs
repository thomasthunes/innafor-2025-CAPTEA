using ClusterManagement.Models;
namespace ClusterManagement.Services;

public interface IClusterUserService
{
    Task<ClusterUser> GetUserByIdAsync(Guid userId);
    Task<IEnumerable<ClusterUser>> GetAllClusterUsersAsync();
    Task<IEnumerable<ClusterUser>> GetUsersByClusterIdAsync(Guid clusterId);
}
