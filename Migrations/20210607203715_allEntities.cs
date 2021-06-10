using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace SoftwareHouseManagement.Migrations
{
    public partial class allEntities : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Password",
                table: "Workers",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<long>(
                name: "PositionId",
                table: "Workers",
                type: "bigint",
                nullable: false,
                defaultValue: 0L);

            migrationBuilder.AddColumn<long>(
                name: "TaskId",
                table: "Teams",
                type: "bigint",
                nullable: false,
                defaultValue: 0L);

            migrationBuilder.CreateTable(
                name: "Access",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Access", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Client",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PhoneNumber = table.Column<int>(type: "int", nullable: false),
                    FirstName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    LastName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Company = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Client", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "HoursWorked",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Month = table.Column<DateTime>(type: "datetime2", nullable: false),
                    WorkerId = table.Column<long>(type: "bigint", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_HoursWorked", x => x.Id);
                    table.ForeignKey(
                        name: "FK_HoursWorked_Workers_WorkerId",
                        column: x => x.WorkerId,
                        principalTable: "Workers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Position",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Wage = table.Column<decimal>(type: "decimal(18,2)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Position", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Responsibilities",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Responsibilities", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AccessTeam",
                columns: table => new
                {
                    AccessesId = table.Column<long>(type: "bigint", nullable: false),
                    TeamsId = table.Column<long>(type: "bigint", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AccessTeam", x => new { x.AccessesId, x.TeamsId });
                    table.ForeignKey(
                        name: "FK_AccessTeam_Access_AccessesId",
                        column: x => x.AccessesId,
                        principalTable: "Access",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AccessTeam_Teams_TeamsId",
                        column: x => x.TeamsId,
                        principalTable: "Teams",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Task",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Subjec = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    AssignedHours = table.Column<TimeSpan>(type: "time", nullable: false),
                    WorkedHours = table.Column<TimeSpan>(type: "time", nullable: false),
                    ClientId = table.Column<long>(type: "bigint", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Task", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Task_Client_ClientId",
                        column: x => x.ClientId,
                        principalTable: "Client",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "PositionResponsibilities",
                columns: table => new
                {
                    PositionsId = table.Column<long>(type: "bigint", nullable: false),
                    ResponsibilitiesId = table.Column<long>(type: "bigint", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PositionResponsibilities", x => new { x.PositionsId, x.ResponsibilitiesId });
                    table.ForeignKey(
                        name: "FK_PositionResponsibilities_Position_PositionsId",
                        column: x => x.PositionsId,
                        principalTable: "Position",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_PositionResponsibilities_Responsibilities_ResponsibilitiesId",
                        column: x => x.ResponsibilitiesId,
                        principalTable: "Responsibilities",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Workers_PositionId",
                table: "Workers",
                column: "PositionId");

            migrationBuilder.CreateIndex(
                name: "IX_Teams_TaskId",
                table: "Teams",
                column: "TaskId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_AccessTeam_TeamsId",
                table: "AccessTeam",
                column: "TeamsId");

            migrationBuilder.CreateIndex(
                name: "IX_HoursWorked_WorkerId",
                table: "HoursWorked",
                column: "WorkerId");

            migrationBuilder.CreateIndex(
                name: "IX_PositionResponsibilities_ResponsibilitiesId",
                table: "PositionResponsibilities",
                column: "ResponsibilitiesId");

            migrationBuilder.CreateIndex(
                name: "IX_Task_ClientId",
                table: "Task",
                column: "ClientId");

            migrationBuilder.AddForeignKey(
                name: "FK_Teams_Task_TaskId",
                table: "Teams",
                column: "TaskId",
                principalTable: "Task",
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

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Teams_Task_TaskId",
                table: "Teams");

            migrationBuilder.DropForeignKey(
                name: "FK_Workers_Position_PositionId",
                table: "Workers");

            migrationBuilder.DropTable(
                name: "AccessTeam");

            migrationBuilder.DropTable(
                name: "HoursWorked");

            migrationBuilder.DropTable(
                name: "PositionResponsibilities");

            migrationBuilder.DropTable(
                name: "Task");

            migrationBuilder.DropTable(
                name: "Access");

            migrationBuilder.DropTable(
                name: "Position");

            migrationBuilder.DropTable(
                name: "Responsibilities");

            migrationBuilder.DropTable(
                name: "Client");

            migrationBuilder.DropIndex(
                name: "IX_Workers_PositionId",
                table: "Workers");

            migrationBuilder.DropIndex(
                name: "IX_Teams_TaskId",
                table: "Teams");

            migrationBuilder.DropColumn(
                name: "Password",
                table: "Workers");

            migrationBuilder.DropColumn(
                name: "PositionId",
                table: "Workers");

            migrationBuilder.DropColumn(
                name: "TaskId",
                table: "Teams");
        }
    }
}
