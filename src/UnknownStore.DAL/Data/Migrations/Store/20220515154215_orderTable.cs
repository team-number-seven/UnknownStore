using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace UnknownStore.DAL.Data.Migrations.Store
{
    public partial class orderTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Orders",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    TotalPrice = table.Column<decimal>(type: "numeric", nullable: false),
                    DeliveryCost = table.Column<decimal>(type: "numeric", nullable: false),
                    Discount = table.Column<decimal>(type: "numeric", nullable: false),
                    PhoneNumber = table.Column<string>(type: "text", nullable: true),
                    FirstName = table.Column<string>(type: "text", nullable: true),
                    OrderDescription = table.Column<string>(type: "text", nullable: true),
                    OrderStatusDescription = table.Column<string>(type: "text", nullable: true),
                    CreteDate = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    PickUpBefore = table.Column<DateTime>(type: "timestamp without time zone", nullable: true),
                    DeliveredTo = table.Column<DateTime>(type: "timestamp without time zone", nullable: true),
                    PaymentMode = table.Column<int>(type: "integer", nullable: false),
                    DeliveryMode = table.Column<int>(type: "integer", nullable: false),
                    OrderStatus = table.Column<int>(type: "integer", nullable: false),
                    AddressId = table.Column<Guid>(type: "uuid", nullable: false),
                    UserId = table.Column<Guid>(type: "uuid", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Orders", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Orders_Addresses_AddressId",
                        column: x => x.AddressId,
                        principalTable: "Addresses",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Orders_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "BuyModels",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    Size = table.Column<string>(type: "text", nullable: true),
                    ModelId = table.Column<Guid>(type: "uuid", nullable: false),
                    OrderId = table.Column<Guid>(type: "uuid", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BuyModels", x => x.Id);
                    table.ForeignKey(
                        name: "FK_BuyModels_Models_ModelId",
                        column: x => x.ModelId,
                        principalTable: "Models",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_BuyModels_Orders_OrderId",
                        column: x => x.OrderId,
                        principalTable: "Orders",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_BuyModels_ModelId",
                table: "BuyModels",
                column: "ModelId");

            migrationBuilder.CreateIndex(
                name: "IX_BuyModels_OrderId",
                table: "BuyModels",
                column: "OrderId");

            migrationBuilder.CreateIndex(
                name: "IX_Orders_AddressId",
                table: "Orders",
                column: "AddressId");

            migrationBuilder.CreateIndex(
                name: "IX_Orders_UserId",
                table: "Orders",
                column: "UserId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "BuyModels");

            migrationBuilder.DropTable(
                name: "Orders");
        }
    }
}
