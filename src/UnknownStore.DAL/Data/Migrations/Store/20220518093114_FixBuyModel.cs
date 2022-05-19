using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace UnknownStore.DAL.Data.Migrations.Store
{
    public partial class FixBuyModel : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Size",
                table: "BuyModels");

            migrationBuilder.AddColumn<Guid>(
                name: "AmountOfSizeId",
                table: "BuyModels",
                type: "uuid",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.CreateIndex(
                name: "IX_BuyModels_AmountOfSizeId",
                table: "BuyModels",
                column: "AmountOfSizeId");

            migrationBuilder.AddForeignKey(
                name: "FK_BuyModels_AmountOfSizes_AmountOfSizeId",
                table: "BuyModels",
                column: "AmountOfSizeId",
                principalTable: "AmountOfSizes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_BuyModels_AmountOfSizes_AmountOfSizeId",
                table: "BuyModels");

            migrationBuilder.DropIndex(
                name: "IX_BuyModels_AmountOfSizeId",
                table: "BuyModels");

            migrationBuilder.DropColumn(
                name: "AmountOfSizeId",
                table: "BuyModels");

            migrationBuilder.AddColumn<double>(
                name: "Size",
                table: "BuyModels",
                type: "double precision",
                nullable: true);
        }
    }
}
