using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WepAppFullApi.Cinema.Migrations
{
    /// <inheritdoc />
    public partial class SecondaSistemazioneNomi : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ProjectionActivities_Roles_ActivityRoleId",
                table: "ProjectionActivities");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Roles",
                table: "Roles");

            migrationBuilder.RenameTable(
                name: "Roles",
                newName: "ActivityRoles");

            migrationBuilder.AddPrimaryKey(
                name: "PK_ActivityRoles",
                table: "ActivityRoles",
                column: "ActivityRoleId");

            migrationBuilder.AddForeignKey(
                name: "FK_ProjectionActivities_ActivityRoles_ActivityRoleId",
                table: "ProjectionActivities",
                column: "ActivityRoleId",
                principalTable: "ActivityRoles",
                principalColumn: "ActivityRoleId",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ProjectionActivities_ActivityRoles_ActivityRoleId",
                table: "ProjectionActivities");

            migrationBuilder.DropPrimaryKey(
                name: "PK_ActivityRoles",
                table: "ActivityRoles");

            migrationBuilder.RenameTable(
                name: "ActivityRoles",
                newName: "Roles");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Roles",
                table: "Roles",
                column: "ActivityRoleId");

            migrationBuilder.AddForeignKey(
                name: "FK_ProjectionActivities_Roles_ActivityRoleId",
                table: "ProjectionActivities",
                column: "ActivityRoleId",
                principalTable: "Roles",
                principalColumn: "ActivityRoleId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
