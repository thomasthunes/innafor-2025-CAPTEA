using Microsoft.EntityFrameworkCore;
using Npgsql.EntityFrameworkCore;
namespace ClusterManagement.Models;
public class ClusterContext : DbContext
{
    public DbSet<ClusterUser> ClusterUsers { get; set; }
    public DbSet<Cluster> Clusters { get; set; }
    public DbSet<OneWayInOpportunity> OneWayInOpportunities { get; set; }
    public DbSet<Message> Messages { get; set; }
    public string ConnectionString { get; set; } = string.Empty;
    public ClusterContext(DbContextOptions<ClusterContext> options) : base(options)
    {
    }

    // protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    //     => optionsBuilder.UseNpgsql(@"Server=localhost;Database=postgres;user=postgres;Password=;");
}
public class ClusterUser
{
    public Guid Id { get; set; }
    public Cluster Cluster { get; set; }
    public string EmailAddress { get; set; } = string.Empty;
    public string FirstName { get; set; } = string.Empty;
    public string LastName { get; set; } = string.Empty;
    public string? Phone { get; set; }
    public string? Responsibilities { get; set; }
}  
public class Cluster
{
    public Guid Id { get; set; }
    public string? Name { get; set; }
    public string? EmailAddress { get; set; }
    public string? Telephone { get; set; }
    public string? WebsiteUrl { get; set; }
    public string? OrganizationNumber { get; set; }
    // public Address? Address { get; set; }
    public string? IndustryCode { get; set; }
    public string? ClusterPurpose { get; set; }
    public string? ClusterVision { get; set; }
    
    public string? ClusterDescription { get; set; }
    public string? Services { get; set; }
    public string? Industry { get; set; }
    // hvaslags aktør er det?
    // tjeneste typer
    //     bransje
    // kriterier
    // tjenestekatalog??
    // hvilket fylke

    public DateTime? DateOfFoundation { get; set; }
    /// <summary>
    /// guid of the clusterUser that is the main contact
    /// </summary>
    public Guid? MainContact { get; set; }
}
/// <summary>
/// Dette objektet representerer en mulighet hos en klynge. 
/// Den inneholder informasjonen som her kommet fra En Vei Inn til en aktør.
/// Den kan henvises til en annen aktør. Det vil si at det opprettes en kopi 
/// av objektet, med den andre aktøren s ClusterId.
/// </summary>
public class OneWayInOpportunity
{
    public Cluster Cluster { get; set; }
    public Guid Id { get; set; }
    public string Title { get; set; } = string.Empty;
    public string Description { get; set; } = string.Empty;
    public bool IsClosed { get; set; }
    public string? CustomerName { get; set; }
    public DateTime? SubmittedOn { get; set; }
    public DateTime? LastChangedOn { get; set; }
    public ClusterUser? AssignedTo { get; set; }
}
