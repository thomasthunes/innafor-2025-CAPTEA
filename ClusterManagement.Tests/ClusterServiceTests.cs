using Microsoft.EntityFrameworkCore;
using ClusterManagement.Models;
using ClusterManagement.Services;
using ClusterManagement.Repositories;

namespace ClusterManagement.Tests;

public class ClusterServiceTests
{
    private ClusterContext GetInMemoryContext()
    {
        var options = new DbContextOptionsBuilder<ClusterContext>()
            .UseInMemoryDatabase(databaseName: Guid.NewGuid().ToString())
            .Options;
        return new ClusterContext(options);
    }

    [Fact]
    public async Task GetAllClustersAsync_ShouldReturnAllClusters()
    {
        using var context = GetInMemoryContext();
        var repository = new ClusterRepository(context);
        var service = new ClusterService(repository);

        var cluster1 = new Cluster { Name = "Test Cluster 1", EmailAddress = "test1@example.com" };
        var cluster2 = new Cluster { Name = "Test Cluster 2", EmailAddress = "test2@example.com" };
        
        context.Clusters.AddRange(cluster1, cluster2);
        await context.SaveChangesAsync();

        var result = await service.GetAllClustersAsync();

        Assert.NotNull(result);
        Assert.Equal(2, result.Count());
        Assert.Contains(result, c => c.Name == "Test Cluster 1");
        Assert.Contains(result, c => c.Name == "Test Cluster 2");
    }

    [Fact]
    public async Task GetClusterByIdAsync_ShouldReturnCluster_WhenClusterExists()
    {
        using var context = GetInMemoryContext();
        var repository = new ClusterRepository(context);
        var service = new ClusterService(repository);

        var cluster = new Cluster { Name = "Test Cluster", EmailAddress = "test@example.com" };
        context.Clusters.Add(cluster);
        await context.SaveChangesAsync();

        var result = await service.GetClusterByIdAsync(cluster.Id);

        Assert.NotNull(result);
        Assert.Equal(cluster.Name, result.Name);
        Assert.Equal(cluster.EmailAddress, result.EmailAddress);
    }

    [Fact]
    public async Task GetClusterByIdAsync_ShouldReturnNull_WhenClusterDoesNotExist()
    {
        using var context = GetInMemoryContext();
        var repository = new ClusterRepository(context);
        var service = new ClusterService(repository);

        var result = await service.GetClusterByIdAsync(Guid.NewGuid());

        Assert.Null(result);
    }
}