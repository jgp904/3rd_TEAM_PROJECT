using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace _3rd_TEAM_PROJECT.Migrations.AccountDb
{
    /// <inheritdoc />
    public partial class acount : Migration
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
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DepartmentCode = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_T1_Department", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "T1_Account",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DepartmentCode = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Position = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Authority = table.Column<int>(type: "int", nullable: false),
                    PassWord = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    RegDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DepartmentId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_T1_Account", x => x.Id);
                    table.ForeignKey(
                        name: "FK_T1_Account_T1_Department_DepartmentId",
                        column: x => x.DepartmentId,
                        principalTable: "T1_Department",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_T1_Account_DepartmentId",
                table: "T1_Account",
                column: "DepartmentId");

            migrationBuilder.CreateIndex(
                name: "IX_T1_Account_UserId",
                table: "T1_Account",
                column: "UserId",
                unique: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "T1_Account");

            migrationBuilder.DropTable(
                name: "T1_Department");
        }
    }
}
