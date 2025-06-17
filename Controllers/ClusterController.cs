using ClusterManagement.Models;
using ClusterManagement.Services;
using Microsoft.AspNetCore.Mvc;
namespace ClusterManagement.Controllers;
[ApiController]
[Route("api/[controller]")]
public class ClusterController 
{
    private readonly IClusterService _clusterService;
    public ClusterController(IClusterService clusterService)
    {
        _clusterService = clusterService;
    }
    /// <summary>
    /// Get all clusters
    /// <returns>A list of clusters</returns>
    /// </summary>
    [HttpGet("")]
    public async Task<IEnumerable<Cluster>> Index()
    {
        var clusters = await _clusterService.GetAllClustersAsync();
        return clusters;
    }
    /// <summary>
    /// Get a specific cluster by ID
    /// param id: The ID of the cluster to retrieve
    /// <returns>A cluster object if found, otherwise NotFound</returns>
    /// </summary>
    [HttpGet("{id}")]
    public async Task<Cluster> Details(Guid id)
    {
        var cluster = await _clusterService.GetClusterByIdAsync(id);
        return cluster;
    }
}
