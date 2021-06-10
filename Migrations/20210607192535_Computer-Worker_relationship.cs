using Microsoft.EntityFrameworkCore.Migrations;

namespace SoftwareHouseManagement.Migrations
{
    public partial class ComputerWorker_relationship : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_Workers_ComputerId",
                table: "Workers");

            migrationBuilder.CreateIndex(
                name: "IX_Workers_ComputerId",
                table: "Workers",
                column: "ComputerId",
                unique: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_Workers_ComputerId",
                table: "Workers");

            migrationBuilder.CreateIndex(
                name: "IX_Workers_ComputerId",
                table: "Workers",
                column: "ComputerId");
        }
    }
}
