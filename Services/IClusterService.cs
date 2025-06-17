using ClusterManagement.Models;
namespace ClusterManagement.Services;
public interface IClusterService
{
    Task<Cluster> GetClusterByIdAsync(Guid userId);
    Task<IEnumerable<Cluster>> GetAllClustersAsync();
}
