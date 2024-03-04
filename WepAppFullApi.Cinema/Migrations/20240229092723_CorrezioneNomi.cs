using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WepAppFullApi.Cinema.Migrations
{
    /// <inheritdoc />
    public partial class CorrezioneNomi : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Activities_Employees_EmployeeId",
                table: "Activities");

            migrationBuilder.DropForeignKey(
                name: "FK_Activities_Projections_ProjectionId",
                table: "Activities");

            migrationBuilder.DropForeignKey(
                name: "FK_Activities_Roles_ActivityRoleId",
                table: "Activities");

            migrationBuilder.DropForeignKey(
                name: "FK_MovieTechnology_Tecnologies_TechnologiesTechnologyId",
                table: "MovieTechnology");

            migrationBuilder.DropForeignKey(
                name: "FK_RoomTechnology_Tecnologies_TechnologiesTechnologyId",
                table: "RoomTechnology");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Tecnologies",
                table: "Tecnologies");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Activities",
                table: "Activities");

            migrationBuilder.RenameTable(
                name: "Tecnologies",
                newName: "Technologies");

            migrationBuilder.RenameTable(
                name: "Activities",
                newName: "ProjectionActivities");

            migrationBuilder.RenameIndex(
                name: "IX_Activities_ProjectionId",
                table: "ProjectionActivities",
                newName: "IX_ProjectionActivities_ProjectionId");

            migrationBuilder.RenameIndex(
                name: "IX_Activities_ActivityRoleId",
                table: "ProjectionActivities",
                newName: "IX_ProjectionActivities_ActivityRoleId");

            migrationBuilder.AddColumn<bool>(
                name: "IsDeleted",
                table: "ProjectionActivities",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddPrimaryKey(
                name: "PK_Technologies",
                table: "Technologies",
                column: "TechnologyId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_ProjectionActivities",
                table: "ProjectionActivities",
                columns: new[] { "EmployeeId", "ActivityRoleId", "ProjectionId" });

            migrationBuilder.AddForeignKey(
                name: "FK_MovieTechnology_Technologies_TechnologiesTechnologyId",
                table: "MovieTechnology",
                column: "TechnologiesTechnologyId",
                principalTable: "Technologies",
                principalColumn: "TechnologyId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ProjectionActivities_Employees_EmployeeId",
                table: "ProjectionActivities",
                column: "EmployeeId",
                principalTable: "Employees",
                principalColumn: "EmployeeId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ProjectionActivities_Projections_ProjectionId",
                table: "ProjectionActivities",
                column: "ProjectionId",
                principalTable: "Projections",
                principalColumn: "ProjectionId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ProjectionActivities_Roles_ActivityRoleId",
                table: "ProjectionActivities",
                column: "ActivityRoleId",
                principalTable: "Roles",
                principalColumn: "ActivityRoleId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_RoomTechnology_Technologies_TechnologiesTechnologyId",
                table: "RoomTechnology",
                column: "TechnologiesTechnologyId",
                principalTable: "Technologies",
                principalColumn: "TechnologyId",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_MovieTechnology_Technologies_TechnologiesTechnologyId",
                table: "MovieTechnology");

            migrationBuilder.DropForeignKey(
                name: "FK_ProjectionActivities_Employees_EmployeeId",
                table: "ProjectionActivities");

            migrationBuilder.DropForeignKey(
                name: "FK_ProjectionActivities_Projections_ProjectionId",
                table: "ProjectionActivities");

            migrationBuilder.DropForeignKey(
                name: "FK_ProjectionActivities_Roles_ActivityRoleId",
                table: "ProjectionActivities");

            migrationBuilder.DropForeignKey(
                name: "FK_RoomTechnology_Technologies_TechnologiesTechnologyId",
                table: "RoomTechnology");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Technologies",
                table: "Technologies");

            migrationBuilder.DropPrimaryKey(
                name: "PK_ProjectionActivities",
                table: "ProjectionActivities");

            migrationBuilder.DropColumn(
                name: "IsDeleted",
                table: "ProjectionActivities");

            migrationBuilder.RenameTable(
                name: "Technologies",
                newName: "Tecnologies");

            migrationBuilder.RenameTable(
                name: "ProjectionActivities",
                newName: "Activities");

            migrationBuilder.RenameIndex(
                name: "IX_ProjectionActivities_ProjectionId",
                table: "Activities",
                newName: "IX_Activities_ProjectionId");

            migrationBuilder.RenameIndex(
                name: "IX_ProjectionActivities_ActivityRoleId",
                table: "Activities",
                newName: "IX_Activities_ActivityRoleId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Tecnologies",
                table: "Tecnologies",
                column: "TechnologyId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Activities",
                table: "Activities",
                columns: new[] { "EmployeeId", "ActivityRoleId", "ProjectionId" });

            migrationBuilder.AddForeignKey(
                name: "FK_Activities_Employees_EmployeeId",
                table: "Activities",
                column: "EmployeeId",
                principalTable: "Employees",
                principalColumn: "EmployeeId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Activities_Projections_ProjectionId",
                table: "Activities",
                column: "ProjectionId",
                principalTable: "Projections",
                principalColumn: "ProjectionId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Activities_Roles_ActivityRoleId",
                table: "Activities",
                column: "ActivityRoleId",
                principalTable: "Roles",
                principalColumn: "ActivityRoleId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_MovieTechnology_Tecnologies_TechnologiesTechnologyId",
                table: "MovieTechnology",
                column: "TechnologiesTechnologyId",
                principalTable: "Tecnologies",
                principalColumn: "TechnologyId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_RoomTechnology_Tecnologies_TechnologiesTechnologyId",
                table: "RoomTechnology",
                column: "TechnologiesTechnologyId",
                principalTable: "Tecnologies",
                principalColumn: "TechnologyId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
