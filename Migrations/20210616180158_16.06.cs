using Microsoft.EntityFrameworkCore.Migrations;

namespace SoftwareHouseManagement.Migrations
{
    public partial class _1606 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_PositionResponsibilities_Position_PositionsId",
                table: "PositionResponsibilities");

            migrationBuilder.DropForeignKey(
                name: "FK_Workers_Position_PositionId",
                table: "Workers");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Position",
                table: "Position");

            migrationBuilder.RenameTable(
                name: "Position",
                newName: "Positions");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Positions",
                table: "Positions",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_PositionResponsibilities_Positions_PositionsId",
                table: "PositionResponsibilities",
                column: "PositionsId",
                principalTable: "Positions",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Workers_Positions_PositionId",
                table: "Workers",
                column: "PositionId",
                principalTable: "Positions",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_PositionResponsibilities_Positions_PositionsId",
                table: "PositionResponsibilities");

            migrationBuilder.DropForeignKey(
                name: "FK_Workers_Positions_PositionId",
                table: "Workers");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Positions",
                table: "Positions");

            migrationBuilder.RenameTable(
                name: "Positions",
                newName: "Position");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Position",
                table: "Position",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_PositionResponsibilities_Position_PositionsId",
                table: "PositionResponsibilities",
                column: "PositionsId",
                principalTable: "Position",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Workers_Position_PositionId",
                table: "Workers",
                column: "PositionId",
                principalTable: "Position",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
