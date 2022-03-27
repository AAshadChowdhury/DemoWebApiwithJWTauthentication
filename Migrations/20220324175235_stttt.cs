using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace DemoWebApi.Migrations
{
    public partial class stttt : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "department",
                columns: table => new
                {
                    deptid = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    deptname = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    location = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_department", x => x.deptid);
                });

            migrationBuilder.CreateTable(
                name: "parties",
                columns: table => new
                {
                    partyId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    partyname = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    address = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_parties", x => x.partyId);
                });

            migrationBuilder.CreateTable(
                name: "storeledgers",
                columns: table => new
                {
                    slno = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    date = table.Column<DateTime>(type: "datetime2", nullable: false),
                    vono = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    narration = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    received = table.Column<int>(type: "int", nullable: false),
                    issue = table.Column<int>(type: "int", nullable: false),
                    valance = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_storeledgers", x => x.slno);
                });

            migrationBuilder.CreateTable(
                name: "items",
                columns: table => new
                {
                    itemcode = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    itemname = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    deptid = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    cost = table.Column<decimal>(type: "decimal(18,4)", nullable: true),
                    rate = table.Column<decimal>(type: "decimal(18,4)", nullable: true),
                    date = table.Column<DateTime>(type: "datetime2", nullable: false),
                    picture = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_items", x => x.itemcode);
                    table.ForeignKey(
                        name: "FK_items_department_deptid",
                        column: x => x.deptid,
                        principalTable: "department",
                        principalColumn: "deptid",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "purchasemasters",
                columns: table => new
                {
                    purchaseId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    date = table.Column<DateTime>(type: "datetime2", nullable: false),
                    partyId = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    total = table.Column<decimal>(type: "decimal(18,4)", nullable: true),
                    discount = table.Column<decimal>(type: "decimal(18,4)", nullable: true),
                    net = table.Column<decimal>(type: "decimal(18,4)", nullable: true),
                    paid = table.Column<decimal>(type: "decimal(18,4)", nullable: true),
                    due = table.Column<decimal>(type: "decimal(18,4)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_purchasemasters", x => x.purchaseId);
                    table.ForeignKey(
                        name: "FK_purchasemasters_parties_partyId",
                        column: x => x.partyId,
                        principalTable: "parties",
                        principalColumn: "partyId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "salesemasters",
                columns: table => new
                {
                    saleId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    date = table.Column<DateTime>(type: "datetime2", nullable: false),
                    partyId = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    total = table.Column<decimal>(type: "decimal(18,4)", nullable: true),
                    discount = table.Column<decimal>(type: "decimal(18,4)", nullable: true),
                    net = table.Column<decimal>(type: "decimal(18,4)", nullable: true),
                    paid = table.Column<decimal>(type: "decimal(18,4)", nullable: true),
                    due = table.Column<decimal>(type: "decimal(18,4)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_salesemasters", x => x.saleId);
                    table.ForeignKey(
                        name: "FK_salesemasters_parties_partyId",
                        column: x => x.partyId,
                        principalTable: "parties",
                        principalColumn: "partyId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "purchasedetails",
                columns: table => new
                {
                    purchaseId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    slno = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    itemcode = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    date = table.Column<DateTime>(type: "datetime2", nullable: false),
                    costprice = table.Column<decimal>(type: "decimal(18,4)", nullable: true),
                    qty = table.Column<int>(type: "int", nullable: false),
                    total = table.Column<decimal>(type: "decimal(18,4)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_purchasedetails", x => new { x.purchaseId, x.slno });
                    table.ForeignKey(
                        name: "FK_purchasedetails_items_itemcode",
                        column: x => x.itemcode,
                        principalTable: "items",
                        principalColumn: "itemcode",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_purchasedetails_purchasemasters_purchaseId",
                        column: x => x.purchaseId,
                        principalTable: "purchasemasters",
                        principalColumn: "purchaseId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "salesdetails",
                columns: table => new
                {
                    saleId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    slno = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    itemcode = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    date = table.Column<DateTime>(type: "datetime2", nullable: false),
                    costprice = table.Column<decimal>(type: "decimal(18,4)", nullable: true),
                    qty = table.Column<int>(type: "int", nullable: false),
                    total = table.Column<decimal>(type: "decimal(18,4)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_salesdetails", x => new { x.saleId, x.slno });
                    table.ForeignKey(
                        name: "FK_salesdetails_items_itemcode",
                        column: x => x.itemcode,
                        principalTable: "items",
                        principalColumn: "itemcode",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_salesdetails_salesemasters_saleId",
                        column: x => x.saleId,
                        principalTable: "salesemasters",
                        principalColumn: "saleId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_items_deptid",
                table: "items",
                column: "deptid");

            migrationBuilder.CreateIndex(
                name: "IX_purchasedetails_itemcode",
                table: "purchasedetails",
                column: "itemcode");

            migrationBuilder.CreateIndex(
                name: "IX_purchasemasters_partyId",
                table: "purchasemasters",
                column: "partyId");

            migrationBuilder.CreateIndex(
                name: "IX_salesdetails_itemcode",
                table: "salesdetails",
                column: "itemcode");

            migrationBuilder.CreateIndex(
                name: "IX_salesemasters_partyId",
                table: "salesemasters",
                column: "partyId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "purchasedetails");

            migrationBuilder.DropTable(
                name: "salesdetails");

            migrationBuilder.DropTable(
                name: "storeledgers");

            migrationBuilder.DropTable(
                name: "purchasemasters");

            migrationBuilder.DropTable(
                name: "items");

            migrationBuilder.DropTable(
                name: "salesemasters");

            migrationBuilder.DropTable(
                name: "department");

            migrationBuilder.DropTable(
                name: "parties");
        }
    }
}
