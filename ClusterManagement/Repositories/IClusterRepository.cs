using ClusterManagement.Models;
namespace ClusterManagement.Repositories;
public interface IClusterRepository
{
    Task<Cluster> GetClusterByIdAsync(Guid userId);
    Task<IEnumerable<Cluster>> GetAllClustersAsync();
}
