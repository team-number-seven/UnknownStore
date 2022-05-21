using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace UnknownStore.DAL.Data.Migrations.Store
{
    public partial class addBagItemAndFavoriteItems : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<Guid>(
                name: "UserBagItemId",
                table: "BuyModels",
                type: "uuid",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "FavoriteItems",
                columns: table => new
                {
                    FavoriteItemsId = table.Column<Guid>(type: "uuid", nullable: false),
                    UsersFavoriteItemsId = table.Column<Guid>(type: "uuid", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FavoriteItems", x => new { x.FavoriteItemsId, x.UsersFavoriteItemsId });
                    table.ForeignKey(
                        name: "FK_FavoriteItems_Models_FavoriteItemsId",
                        column: x => x.FavoriteItemsId,
                        principalTable: "Models",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_FavoriteItems_Users_UsersFavoriteItemsId",
                        column: x => x.UsersFavoriteItemsId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_BuyModels_UserBagItemId",
                table: "BuyModels",
                column: "UserBagItemId");

            migrationBuilder.CreateIndex(
                name: "IX_FavoriteItems_UsersFavoriteItemsId",
                table: "FavoriteItems",
                column: "UsersFavoriteItemsId");

            migrationBuilder.AddForeignKey(
                name: "FK_BuyModels_Users_UserBagItemId",
                table: "BuyModels",
                column: "UserBagItemId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_BuyModels_Users_UserBagItemId",
                table: "BuyModels");

            migrationBuilder.DropTable(
                name: "FavoriteItems");

            migrationBuilder.DropIndex(
                name: "IX_BuyModels_UserBagItemId",
                table: "BuyModels");

            migrationBuilder.DropColumn(
                name: "UserBagItemId",
                table: "BuyModels");
        }
    }
}
