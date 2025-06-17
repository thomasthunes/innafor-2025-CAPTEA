using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ClusterManagement.Migrations
{
    /// <inheritdoc />
    public partial class update : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_ClusterUsers_ClusterId",
                table: "ClusterUsers");

            migrationBuilder.DropPrimaryKey(
                name: "PK_OneWayInOpportunity",
                table: "OneWayInOpportunity");

            migrationBuilder.DropColumn(
                name: "B2CId",
                table: "ClusterUsers");

            migrationBuilder.DropColumn(
                name: "InvitationCode",
                table: "ClusterUsers");

            migrationBuilder.DropColumn(
                name: "Organization",
                table: "ClusterUsers");

            migrationBuilder.DropColumn(
                name: "UserId",
                table: "ClusterUsers");

            migrationBuilder.DropColumn(
                name: "BsoContactEmail",
                table: "Clusters");

            migrationBuilder.DropColumn(
                name: "ClusterStatusId",
                table: "Clusters");

            migrationBuilder.DropColumn(
                name: "CreatedById",
                table: "Clusters");

            migrationBuilder.DropColumn(
                name: "CreatedOn",
                table: "Clusters");

            migrationBuilder.DropColumn(
                name: "ModifiedOn",
                table: "Clusters");

            migrationBuilder.DropColumn(
                name: "OneWayInCounties",
                table: "Clusters");

            migrationBuilder.DropColumn(
                name: "OneWayInMunicipalities",
                table: "Clusters");

            migrationBuilder.DropColumn(
                name: "OneWayInVmaNames",
                table: "Clusters");

            migrationBuilder.DropColumn(
                name: "AssignedTo",
                table: "OneWayInOpportunity");

            migrationBuilder.DropColumn(
                name: "Municipality",
                table: "OneWayInOpportunity");

            migrationBuilder.DropColumn(
                name: "NumericId",
                table: "OneWayInOpportunity");

            migrationBuilder.DropColumn(
                name: "OneWayInId",
                table: "OneWayInOpportunity");

            migrationBuilder.DropColumn(
                name: "OrganizationName",
                table: "OneWayInOpportunity");

            migrationBuilder.DropColumn(
                name: "OrganizationNumber",
                table: "OneWayInOpportunity");

            migrationBuilder.DropColumn(
                name: "SendFollowUpReminderOn",
                table: "OneWayInOpportunity");

            migrationBuilder.RenameTable(
                name: "OneWayInOpportunity",
                newName: "OneWayInOpportunities");

            migrationBuilder.RenameColumn(
                name: "ModifiedById",
                table: "Clusters",
                newName: "MainContact");

            migrationBuilder.RenameColumn(
                name: "ClusterMemberId",
                table: "OneWayInOpportunities",
                newName: "AssignedToId");

            migrationBuilder.AddColumn<string>(
                name: "Description",
                table: "OneWayInOpportunities",
                type: "text",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddPrimaryKey(
                name: "PK_OneWayInOpportunities",
                table: "OneWayInOpportunities",
                column: "Id");

            migrationBuilder.CreateIndex(
                name: "IX_ClusterUsers_ClusterId",
                table: "ClusterUsers",
                column: "ClusterId");

            migrationBuilder.CreateIndex(
                name: "IX_OneWayInOpportunities_AssignedToId",
                table: "OneWayInOpportunities",
                column: "AssignedToId");

            migrationBuilder.CreateIndex(
                name: "IX_OneWayInOpportunities_ClusterId",
                table: "OneWayInOpportunities",
                column: "ClusterId");

            migrationBuilder.AddForeignKey(
                name: "FK_OneWayInOpportunities_ClusterUsers_AssignedToId",
                table: "OneWayInOpportunities",
                column: "AssignedToId",
                principalTable: "ClusterUsers",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_OneWayInOpportunities_Clusters_ClusterId",
                table: "OneWayInOpportunities",
                column: "ClusterId",
                principalTable: "Clusters",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_OneWayInOpportunities_ClusterUsers_AssignedToId",
                table: "OneWayInOpportunities");

            migrationBuilder.DropForeignKey(
                name: "FK_OneWayInOpportunities_Clusters_ClusterId",
                table: "OneWayInOpportunities");

            migrationBuilder.DropIndex(
                name: "IX_ClusterUsers_ClusterId",
                table: "ClusterUsers");

            migrationBuilder.DropPrimaryKey(
                name: "PK_OneWayInOpportunities",
                table: "OneWayInOpportunities");

            migrationBuilder.DropIndex(
                name: "IX_OneWayInOpportunities_AssignedToId",
                table: "OneWayInOpportunities");

            migrationBuilder.DropIndex(
                name: "IX_OneWayInOpportunities_ClusterId",
                table: "OneWayInOpportunities");

            migrationBuilder.DropColumn(
                name: "Description",
                table: "OneWayInOpportunities");

            migrationBuilder.RenameTable(
                name: "OneWayInOpportunities",
                newName: "OneWayInOpportunity");

            migrationBuilder.RenameColumn(
                name: "MainContact",
                table: "Clusters",
                newName: "ModifiedById");

            migrationBuilder.RenameColumn(
                name: "AssignedToId",
                table: "OneWayInOpportunity",
                newName: "ClusterMemberId");

            migrationBuilder.AddColumn<string>(
                name: "B2CId",
                table: "ClusterUsers",
                type: "text",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "InvitationCode",
                table: "ClusterUsers",
                type: "uuid",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Organization",
                table: "ClusterUsers",
                type: "text",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "UserId",
                table: "ClusterUsers",
                type: "uuid",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "BsoContactEmail",
                table: "Clusters",
                type: "text",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "ClusterStatusId",
                table: "Clusters",
                type: "uuid",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "CreatedById",
                table: "Clusters",
                type: "uuid",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "CreatedOn",
                table: "Clusters",
                type: "timestamp with time zone",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "ModifiedOn",
                table: "Clusters",
                type: "timestamp with time zone",
                nullable: true);

            migrationBuilder.AddColumn<List<string>>(
                name: "OneWayInCounties",
                table: "Clusters",
                type: "text[]",
                nullable: false);

            migrationBuilder.AddColumn<List<string>>(
                name: "OneWayInMunicipalities",
                table: "Clusters",
                type: "text[]",
                nullable: false);

            migrationBuilder.AddColumn<List<string>>(
                name: "OneWayInVmaNames",
                table: "Clusters",
                type: "text[]",
                nullable: false);

            migrationBuilder.AddColumn<string>(
                name: "AssignedTo",
                table: "OneWayInOpportunity",
                type: "text",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Municipality",
                table: "OneWayInOpportunity",
                type: "text",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "NumericId",
                table: "OneWayInOpportunity",
                type: "integer",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "OneWayInId",
                table: "OneWayInOpportunity",
                type: "text",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "OrganizationName",
                table: "OneWayInOpportunity",
                type: "text",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "OrganizationNumber",
                table: "OneWayInOpportunity",
                type: "text",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "SendFollowUpReminderOn",
                table: "OneWayInOpportunity",
                type: "timestamp with time zone",
                nullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_OneWayInOpportunity",
                table: "OneWayInOpportunity",
                column: "Id");

            migrationBuilder.CreateIndex(
                name: "IX_ClusterUsers_ClusterId",
                table: "ClusterUsers",
                column: "ClusterId",
                unique: true);
        }
    }
}
