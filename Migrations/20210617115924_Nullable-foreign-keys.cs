using Microsoft.EntityFrameworkCore.Migrations;

namespace SoftwareHouseManagement.Migrations
{
    public partial class Nullableforeignkeys : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Teams_Task_TaskId",
                table: "Teams");

            migrationBuilder.DropForeignKey(
                name: "FK_Workers_Computers_ComputerId",
                table: "Workers");

            migrationBuilder.DropIndex(
                name: "IX_Workers_ComputerId",
                table: "Workers");

            migrationBuilder.DropIndex(
                name: "IX_Teams_TaskId",
                table: "Teams");

            migrationBuilder.AlterColumn<long>(
                name: "ComputerId",
                table: "Workers",
                type: "bigint",
                nullable: true,
                oldClrType: typeof(long),
                oldType: "bigint");

            migrationBuilder.AlterColumn<long>(
                name: "TaskId",
                table: "Teams",
                type: "bigint",
                nullable: true,
                oldClrType: typeof(long),
                oldType: "bigint");

            migrationBuilder.CreateIndex(
                name: "IX_Workers_ComputerId",
                table: "Workers",
                column: "ComputerId",
                unique: true,
                filter: "[ComputerId] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_Teams_TaskId",
                table: "Teams",
                column: "TaskId",
                unique: true,
                filter: "[TaskId] IS NOT NULL");

            migrationBuilder.AddForeignKey(
                name: "FK_Teams_Task_TaskId",
                table: "Teams",
                column: "TaskId",
                principalTable: "Task",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Workers_Computers_ComputerId",
                table: "Workers",
                column: "ComputerId",
                principalTable: "Computers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Teams_Task_TaskId",
                table: "Teams");

            migrationBuilder.DropForeignKey(
                name: "FK_Workers_Computers_ComputerId",
                table: "Workers");

            migrationBuilder.DropIndex(
                name: "IX_Workers_ComputerId",
                table: "Workers");

            migrationBuilder.DropIndex(
                name: "IX_Teams_TaskId",
                table: "Teams");

            migrationBuilder.AlterColumn<long>(
                name: "ComputerId",
                table: "Workers",
                type: "bigint",
                nullable: false,
                defaultValue: 0L,
                oldClrType: typeof(long),
                oldType: "bigint",
                oldNullable: true);

            migrationBuilder.AlterColumn<long>(
                name: "TaskId",
                table: "Teams",
                type: "bigint",
                nullable: false,
                defaultValue: 0L,
                oldClrType: typeof(long),
                oldType: "bigint",
                oldNullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Workers_ComputerId",
                table: "Workers",
                column: "ComputerId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Teams_TaskId",
                table: "Teams",
                column: "TaskId",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Teams_Task_TaskId",
                table: "Teams",
                column: "TaskId",
                principalTable: "Task",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Workers_Computers_ComputerId",
                table: "Workers",
                column: "ComputerId",
                principalTable: "Computers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
