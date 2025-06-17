using ClusterManagement.Models;
using ClusterManagement.Repositories;
using ClusterManagement.Services;
using Microsoft.EntityFrameworkCore;
using NSwag.AspNetCore;

internal class Program
{
    private static void Main(string[] args)
    {
        var builder = WebApplication.CreateBuilder(args);
        builder.Services.AddTransient<IClusterUserService, ClusterUserService>();
        builder.Services.AddTransient<IClusterService, ClusterService>();
        builder.Services.AddTransient<IOneWayInOpportunityService,OneWayInOpportunityService>();
        builder.Services.AddTransient<IClusterUserRepository, ClusterUserRepository>();
        builder.Services.AddTransient<IClusterRepository, ClusterRepository>();
        builder.Services.AddTransient<IOneWayInOpportunityRepository,OneWayInOpportunityRepository>();
        builder.Services.AddDbContext<ClusterManagement.Models.ClusterContext>(options =>
        {
            options.UseNpgsql(builder.Configuration.GetConnectionString("DefaultConnection"));
        });
        builder.Services.AddEndpointsApiExplorer();
        builder.Services.AddControllers();
        builder.Services.AddOpenApiDocument();
        var app = builder.Build();
        // using (var scope = app.Services.CreateScope())
        // {
        //     var dbContext = scope.ServiceProvider.GetRequiredService<ClusterManagement.Models.ClusterContext>();
        //     dbContext.Database.Migrate();
        // }
        app.MapControllers();
        app.UseSwaggerUi(c =>
        { 
            app.UseOpenApi();
            app.UseSwaggerUi(); // UseSwaggerUI Protected by if (env.IsDevelopment())
        });
        app.Run();
    }
}
