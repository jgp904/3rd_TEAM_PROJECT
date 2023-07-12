using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace _3rd_TEAM_PROJECT.Migrations.MProcessDbcontextMigrations
{
    /// <inheritdoc />
    public partial class MProcess : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "T1_Equipment",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Code = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Comment = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Status = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Event = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Constructor = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    RegDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Modifier = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ModDate = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_T1_Equipment", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "T1_Factory",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Code = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Constructor = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    RegDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Modifier = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ModDate = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_T1_Factory", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "T1_Item",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Code = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Type = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Constructor = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    RegDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Modifier = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ModDate = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_T1_Item", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "T1_WareHouse",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Product = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Item = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Amount = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_T1_WareHouse", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "T1_MProcess",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Code = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Coment = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    StockUnit1 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    StockUnit2 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Constructor = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    RegDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Modifier = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ModDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    FactoriesId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_T1_MProcess", x => x.Id);
                    table.ForeignKey(
                        name: "FK_T1_MProcess_T1_Factory_FactoriesId",
                        column: x => x.FactoriesId,
                        principalTable: "T1_Factory",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "T1_InBound",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Product = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Amount = table.Column<int>(type: "int", nullable: false),
                    Vendor = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    RegDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Contact = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    WareHouseId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_T1_InBound", x => x.Id);
                    table.ForeignKey(
                        name: "FK_T1_InBound_T1_WareHouse_WareHouseId",
                        column: x => x.WareHouseId,
                        principalTable: "T1_WareHouse",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "T1_CreateLot",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Code = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Amount = table.Column<int>(type: "int", nullable: false),
                    Action = table.Column<DateTime>(type: "datetime2", nullable: false),
                    HisNum = table.Column<int>(type: "int", nullable: false),
                    ProcessCode = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Constructor = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    RegDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Modifier = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ModDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    ItemId = table.Column<int>(type: "int", nullable: false),
                    ProcessId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_T1_CreateLot", x => x.Id);
                    table.ForeignKey(
                        name: "FK_T1_CreateLot_T1_Item_ItemId",
                        column: x => x.ItemId,
                        principalTable: "T1_Item",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_T1_CreateLot_T1_MProcess_ProcessId",
                        column: x => x.ProcessId,
                        principalTable: "T1_MProcess",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "T1_OutBound",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Product = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Amount = table.Column<int>(type: "int", nullable: false),
                    Contact = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    RegDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    WareHouseId = table.Column<int>(type: "int", nullable: true),
                    MProcessId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_T1_OutBound", x => x.Id);
                    table.ForeignKey(
                        name: "FK_T1_OutBound_T1_MProcess_MProcessId",
                        column: x => x.MProcessId,
                        principalTable: "T1_MProcess",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_T1_OutBound_T1_WareHouse_WareHouseId",
                        column: x => x.WareHouseId,
                        principalTable: "T1_WareHouse",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "T1_LotHis",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ModDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Modifier = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreateLotId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_T1_LotHis", x => x.Id);
                    table.ForeignKey(
                        name: "FK_T1_LotHis_T1_CreateLot_CreateLotId",
                        column: x => x.CreateLotId,
                        principalTable: "T1_CreateLot",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_T1_CreateLot_Code",
                table: "T1_CreateLot",
                column: "Code",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_T1_CreateLot_ItemId",
                table: "T1_CreateLot",
                column: "ItemId");

            migrationBuilder.CreateIndex(
                name: "IX_T1_CreateLot_ProcessId",
                table: "T1_CreateLot",
                column: "ProcessId");

            migrationBuilder.CreateIndex(
                name: "IX_T1_Equipment_Code",
                table: "T1_Equipment",
                column: "Code",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_T1_Factory_Code",
                table: "T1_Factory",
                column: "Code",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_T1_InBound_WareHouseId",
                table: "T1_InBound",
                column: "WareHouseId");

            migrationBuilder.CreateIndex(
                name: "IX_T1_Item_Code",
                table: "T1_Item",
                column: "Code",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_T1_LotHis_CreateLotId",
                table: "T1_LotHis",
                column: "CreateLotId");

            migrationBuilder.CreateIndex(
                name: "IX_T1_MProcess_Code",
                table: "T1_MProcess",
                column: "Code",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_T1_MProcess_FactoriesId",
                table: "T1_MProcess",
                column: "FactoriesId");

            migrationBuilder.CreateIndex(
                name: "IX_T1_OutBound_MProcessId",
                table: "T1_OutBound",
                column: "MProcessId");

            migrationBuilder.CreateIndex(
                name: "IX_T1_OutBound_WareHouseId",
                table: "T1_OutBound",
                column: "WareHouseId");

            migrationBuilder.CreateIndex(
                name: "IX_T1_WareHouse_Product",
                table: "T1_WareHouse",
                column: "Product",
                unique: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "T1_Equipment");

            migrationBuilder.DropTable(
                name: "T1_InBound");

            migrationBuilder.DropTable(
                name: "T1_LotHis");

            migrationBuilder.DropTable(
                name: "T1_OutBound");

            migrationBuilder.DropTable(
                name: "T1_CreateLot");

            migrationBuilder.DropTable(
                name: "T1_WareHouse");

            migrationBuilder.DropTable(
                name: "T1_Item");

            migrationBuilder.DropTable(
                name: "T1_MProcess");

            migrationBuilder.DropTable(
                name: "T1_Factory");
        }
    }
}
