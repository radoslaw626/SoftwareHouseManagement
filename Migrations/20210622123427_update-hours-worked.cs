using Microsoft.EntityFrameworkCore.Migrations;

namespace SoftwareHouseManagement.Migrations
{
    public partial class updatehoursworked : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_HoursWorked_Tasks_TaskId",
                table: "HoursWorked");

            migrationBuilder.DropColumn(
                name: "ProjectId",
                table: "HoursWorked");

            migrationBuilder.AlterColumn<long>(
                name: "TaskId",
                table: "HoursWorked",
                type: "bigint",
                nullable: false,
                defaultValue: 0L,
                oldClrType: typeof(long),
                oldType: "bigint",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_HoursWorked_Tasks_TaskId",
                table: "HoursWorked",
                column: "TaskId",
                principalTable: "Tasks",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_HoursWorked_Tasks_TaskId",
                table: "HoursWorked");

            migrationBuilder.AlterColumn<long>(
                name: "TaskId",
                table: "HoursWorked",
                type: "bigint",
                nullable: true,
                oldClrType: typeof(long),
                oldType: "bigint");

            migrationBuilder.AddColumn<long>(
                name: "ProjectId",
                table: "HoursWorked",
                type: "bigint",
                nullable: false,
                defaultValue: 0L);

            migrationBuilder.AddForeignKey(
                name: "FK_HoursWorked_Tasks_TaskId",
                table: "HoursWorked",
                column: "TaskId",
                principalTable: "Tasks",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
