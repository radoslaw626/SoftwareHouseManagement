using Microsoft.EntityFrameworkCore.Migrations;

namespace SoftwareHouseManagement.Migrations
{
    public partial class WorkerTeam : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Teams",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    MemberCount = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Teams", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "TeamWorker",
                columns: table => new
                {
                    TeamsId = table.Column<long>(type: "bigint", nullable: false),
                    WorkersId = table.Column<long>(type: "bigint", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TeamWorker", x => new { x.TeamsId, x.WorkersId });
                    table.ForeignKey(
                        name: "FK_TeamWorker_Teams_TeamsId",
                        column: x => x.TeamsId,
                        principalTable: "Teams",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_TeamWorker_Workers_WorkersId",
                        column: x => x.WorkersId,
                        principalTable: "Workers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_TeamWorker_WorkersId",
                table: "TeamWorker",
                column: "WorkersId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "TeamWorker");

            migrationBuilder.DropTable(
                name: "Teams");
        }
    }
}
