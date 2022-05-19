using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace UnknownStore.DAL.Data.Migrations.Store
{
    public partial class DeliveryCityMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "DeliveredTo",
                table: "Orders");

            migrationBuilder.AddColumn<Guid>(
                name: "DeliveryCityId",
                table: "Orders",
                type: "uuid",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.CreateTable(
                name: "DeliveryCities",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    CityId = table.Column<Guid>(type: "uuid", nullable: false),
                    MaxTimeDelivered = table.Column<DateTime>(type: "timestamp without time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DeliveryCities", x => x.Id);
                    table.ForeignKey(
                        name: "FK_DeliveryCities_Cities_CityId",
                        column: x => x.CityId,
                        principalTable: "Cities",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Orders_DeliveryCityId",
                table: "Orders",
                column: "DeliveryCityId");

            migrationBuilder.CreateIndex(
                name: "IX_DeliveryCities_CityId",
                table: "DeliveryCities",
                column: "CityId");

            migrationBuilder.AddForeignKey(
                name: "FK_Orders_DeliveryCities_DeliveryCityId",
                table: "Orders",
                column: "DeliveryCityId",
                principalTable: "DeliveryCities",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Orders_DeliveryCities_DeliveryCityId",
                table: "Orders");

            migrationBuilder.DropTable(
                name: "DeliveryCities");

            migrationBuilder.DropIndex(
                name: "IX_Orders_DeliveryCityId",
                table: "Orders");

            migrationBuilder.DropColumn(
                name: "DeliveryCityId",
                table: "Orders");

            migrationBuilder.AddColumn<string>(
                name: "DeliveredTo",
                table: "Orders",
                type: "text",
                nullable: true);
        }
    }
}
