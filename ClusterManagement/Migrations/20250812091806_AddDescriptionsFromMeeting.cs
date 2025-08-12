using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ClusterManagement.Migrations
{
    /// <inheritdoc />
    public partial class AddDescriptionsFromMeeting : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "ClusterDescription",
                table: "Clusters",
                type: "text",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Industry",
                table: "Clusters",
                type: "text",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Services",
                table: "Clusters",
                type: "text",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ClusterDescription",
                table: "Clusters");

            migrationBuilder.DropColumn(
                name: "Industry",
                table: "Clusters");

            migrationBuilder.DropColumn(
                name: "Services",
                table: "Clusters");
        }
    }
}
