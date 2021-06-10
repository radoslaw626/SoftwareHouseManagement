using Microsoft.EntityFrameworkCore.Migrations;

namespace SoftwareHouseManagement.Migrations
{
    public partial class corrected_entity : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Subjec",
                table: "Task",
                newName: "Subject");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Subject",
                table: "Task",
                newName: "Subjec");
        }
    }
}
