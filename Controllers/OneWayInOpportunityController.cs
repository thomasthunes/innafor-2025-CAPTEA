using Microsoft.AspNetCore.Mvc;
using ClusterManagement.Services;
using ClusterManagement.Models;
[ApiController]
[Route("api/OneWayInOpportunities")]
public class OneWayInOpportunityController 
{
    private readonly IOneWayInOpportunityService _oneWayInOpportunityService;
    public OneWayInOpportunityController(IOneWayInOpportunityService oneWayInOpportunityService)
    {
        _oneWayInOpportunityService = oneWayInOpportunityService;
    }
    /// <summary>
    /// Get all opportunities
    /// </summary>
    [HttpGet("all")]
    public async Task<IEnumerable<OneWayInOpportunity>> GetAll()
    {
        var opportunities = await _oneWayInOpportunityService.GetAllAsync();
        return opportunities;
    }
    /// <summary>
    /// Get a specific opportunity by ID
    /// param id: The ID of the opportunity to retrieve
    /// </summary>
    [HttpGet("{id}")]
    public async Task<OneWayInOpportunity> GetById(Guid id)
    {
        var opportunity = await _oneWayInOpportunityService.GetByIdAsync(id);
        return opportunity;
    }


}

                
