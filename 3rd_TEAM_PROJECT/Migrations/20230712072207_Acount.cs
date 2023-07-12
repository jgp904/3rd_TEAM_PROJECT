using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace _3rd_TEAM_PROJECT.Migrations
{
    /// <inheritdoc />
    public partial class Acount : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "T1_Department",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DepartmentCode = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_T1_Department", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "T1_Acount",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Position = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Authority = table.Column<int>(type: "int", nullable: false),
                    PassWord = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    RegDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DepartmentId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_T1_Acount", x => x.Id);
                    table.ForeignKey(
                        name: "FK_T1_Acount_T1_Department_DepartmentId",
                        column: x => x.DepartmentId,
                        principalTable: "T1_Department",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_T1_Acount_DepartmentId",
                table: "T1_Acount",
                column: "DepartmentId");

            migrationBuilder.CreateIndex(
                name: "IX_T1_Acount_UserId",
                table: "T1_Acount",
                column: "UserId",
                unique: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "T1_Acount");

            migrationBuilder.DropTable(
                name: "T1_Department");
        }
    }
}
