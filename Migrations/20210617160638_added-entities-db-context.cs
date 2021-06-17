using Microsoft.EntityFrameworkCore.Migrations;

namespace SoftwareHouseManagement.Migrations
{
    public partial class addedentitiesdbcontext : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AccessTeam_Access_AccessesId",
                table: "AccessTeam");

            migrationBuilder.DropForeignKey(
                name: "FK_Task_Client_ClientId",
                table: "Task");

            migrationBuilder.DropForeignKey(
                name: "FK_Teams_Task_TaskId",
                table: "Teams");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Task",
                table: "Task");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Access",
                table: "Access");

            migrationBuilder.RenameTable(
                name: "Task",
                newName: "Tasks");

            migrationBuilder.RenameTable(
                name: "Access",
                newName: "Accesses");

            migrationBuilder.RenameIndex(
                name: "IX_Task_ClientId",
                table: "Tasks",
                newName: "IX_Tasks_ClientId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Tasks",
                table: "Tasks",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Accesses",
                table: "Accesses",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_AccessTeam_Accesses_AccessesId",
                table: "AccessTeam",
                column: "AccessesId",
                principalTable: "Accesses",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Tasks_Client_ClientId",
                table: "Tasks",
                column: "ClientId",
                principalTable: "Client",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Teams_Tasks_TaskId",
                table: "Teams",
                column: "TaskId",
                principalTable: "Tasks",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AccessTeam_Accesses_AccessesId",
                table: "AccessTeam");

            migrationBuilder.DropForeignKey(
                name: "FK_Tasks_Client_ClientId",
                table: "Tasks");

            migrationBuilder.DropForeignKey(
                name: "FK_Teams_Tasks_TaskId",
                table: "Teams");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Tasks",
                table: "Tasks");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Accesses",
                table: "Accesses");

            migrationBuilder.RenameTable(
                name: "Tasks",
                newName: "Task");

            migrationBuilder.RenameTable(
                name: "Accesses",
                newName: "Access");

            migrationBuilder.RenameIndex(
                name: "IX_Tasks_ClientId",
                table: "Task",
                newName: "IX_Task_ClientId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Task",
                table: "Task",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Access",
                table: "Access",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_AccessTeam_Access_AccessesId",
                table: "AccessTeam",
                column: "AccessesId",
                principalTable: "Access",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Task_Client_ClientId",
                table: "Task",
                column: "ClientId",
                principalTable: "Client",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Teams_Task_TaskId",
                table: "Teams",
                column: "TaskId",
                principalTable: "Task",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
