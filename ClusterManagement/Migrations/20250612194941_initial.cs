using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ClusterManagement.Migrations
{
    /// <inheritdoc />
    public partial class initial : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Clusters",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    Name = table.Column<string>(type: "text", nullable: true),
                    EmailAddress = table.Column<string>(type: "text", nullable: true),
                    Telephone = table.Column<string>(type: "text", nullable: true),
                    WebsiteUrl = table.Column<string>(type: "text", nullable: true),
                    OrganizationNumber = table.Column<string>(type: "text", nullable: true),
                    IndustryCode = table.Column<string>(type: "text", nullable: true),
                    ClusterPurpose = table.Column<string>(type: "text", nullable: true),
                    ClusterVision = table.Column<string>(type: "text", nullable: true),
                    DateOfFoundation = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    CreatedById = table.Column<Guid>(type: "uuid", nullable: true),
                    CreatedOn = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    ModifiedById = table.Column<Guid>(type: "uuid", nullable: true),
                    ModifiedOn = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    ClusterStatusId = table.Column<Guid>(type: "uuid", nullable: true),
                    OneWayInCounties = table.Column<List<string>>(type: "text[]", nullable: false),
                    OneWayInMunicipalities = table.Column<List<string>>(type: "text[]", nullable: false),
                    OneWayInVmaNames = table.Column<List<string>>(type: "text[]", nullable: false),
                    BsoContactEmail = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Clusters", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "OneWayInOpportunity",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    ClusterId = table.Column<Guid>(type: "uuid", nullable: false),
                    Title = table.Column<string>(type: "text", nullable: false),
                    OneWayInId = table.Column<string>(type: "text", nullable: true),
                    IsClosed = table.Column<bool>(type: "boolean", nullable: false),
                    Municipality = table.Column<string>(type: "text", nullable: true),
                    CustomerName = table.Column<string>(type: "text", nullable: true),
                    OrganizationName = table.Column<string>(type: "text", nullable: true),
                    OrganizationNumber = table.Column<string>(type: "text", nullable: true),
                    SubmittedOn = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    LastChangedOn = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    SendFollowUpReminderOn = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    ClusterMemberId = table.Column<Guid>(type: "uuid", nullable: true),
                    AssignedTo = table.Column<string>(type: "text", nullable: true),
                    NumericId = table.Column<int>(type: "integer", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OneWayInOpportunity", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ClusterUsers",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    ClusterId = table.Column<Guid>(type: "uuid", nullable: false),
                    EmailAddress = table.Column<string>(type: "text", nullable: false),
                    FirstName = table.Column<string>(type: "text", nullable: false),
                    LastName = table.Column<string>(type: "text", nullable: false),
                    Phone = table.Column<string>(type: "text", nullable: true),
                    Responsibilities = table.Column<string>(type: "text", nullable: true),
                    Organization = table.Column<string>(type: "text", nullable: true),
                    UserId = table.Column<Guid>(type: "uuid", nullable: true),
                    B2CId = table.Column<string>(type: "text", nullable: true),
                    InvitationCode = table.Column<Guid>(type: "uuid", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ClusterUsers", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ClusterUsers_Clusters_ClusterId",
                        column: x => x.ClusterId,
                        principalTable: "Clusters",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ClusterUsers_ClusterId",
                table: "ClusterUsers",
                column: "ClusterId",
                unique: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ClusterUsers");

            migrationBuilder.DropTable(
                name: "OneWayInOpportunity");

            migrationBuilder.DropTable(
                name: "Clusters");
        }
    }
}
