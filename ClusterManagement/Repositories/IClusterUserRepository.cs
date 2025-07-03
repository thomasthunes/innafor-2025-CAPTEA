using ClusterManagement.Models;
namespace ClusterManagement.Repositories;

public interface IClusterUserRepository
{
    Task<ClusterUser> GetUserByIdAsync(Guid userId);
    Task<IEnumerable<ClusterUser>> GetUsersByClusterIdAsync(Guid userId);
    Task<IEnumerable<ClusterUser>> GetAllClusterUsersAsync();
}
