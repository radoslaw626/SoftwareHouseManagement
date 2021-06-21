using Microsoft.EntityFrameworkCore.Migrations;

namespace SoftwareHouseManagement.Migrations
{
    public partial class realtionforhoursworked2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<long>(
                name: "ProjectId",
                table: "HoursWorked",
                type: "bigint",
                nullable: false,
                defaultValue: 0L);

            migrationBuilder.AddColumn<long>(
                name: "TaskId",
                table: "HoursWorked",
                type: "bigint",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_HoursWorked_TaskId",
                table: "HoursWorked",
                column: "TaskId");

            migrationBuilder.AddForeignKey(
                name: "FK_HoursWorked_Tasks_TaskId",
                table: "HoursWorked",
                column: "TaskId",
                principalTable: "Tasks",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_HoursWorked_Tasks_TaskId",
                table: "HoursWorked");

            migrationBuilder.DropIndex(
                name: "IX_HoursWorked_TaskId",
                table: "HoursWorked");

            migrationBuilder.DropColumn(
                name: "ProjectId",
                table: "HoursWorked");

            migrationBuilder.DropColumn(
                name: "TaskId",
                table: "HoursWorked");
        }
    }
}
