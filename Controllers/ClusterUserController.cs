using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using ClusterManagement.Models;
using ClusterManagement.Services;

[ApiController]
[Route("api/[controller]")]
public class ClusterUserController
{
    private readonly IClusterUserService _clusterUserService;
    public ClusterUserController(IClusterUserService clusterUserService)
    {
        _clusterUserService = clusterUserService;
    }
    /// <summary>
    /// Get all users
    /// </summary>
    [HttpGet("")]
    public async Task<IEnumerable<ClusterUser>> GetAll()
    {
        var users = await _clusterUserService.GetAllClusterUsersAsync();
        return users;
    }
    /// <summary>
    /// Get a specific user by ID
    /// param id: The ID of the user to retrieve
    /// </summary>
    [HttpGet("{id}")]
    public async Task<ClusterUser> GetById(Guid id)
    {
        var user = await _clusterUserService.GetUserByIdAsync(id);
        return user;
    }
    /// <summary>
    /// get all users by cluster ID
    /// param clusterId: The ID of the cluster to retrieve users from
    /// </summary>
    [HttpGet("cluster/{clusterId}")]
    public async Task<IEnumerable<ClusterUser>> GetByClusterId(Guid clusterId)
    {
        var users = await _clusterUserService.GetUsersByClusterIdAsync(clusterId);
        return users;
    }
}
