using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace UnknownStore.DAL.Data.Migrations.Store
{
    public partial class FixTables : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Models_Genders_GenderId",
                table: "Models");

            migrationBuilder.DropForeignKey(
                name: "FK_SubCategories_Sizes_SizeId",
                table: "SubCategories");

            migrationBuilder.DropIndex(
                name: "IX_SubCategories_SizeId",
                table: "SubCategories");

            migrationBuilder.DropIndex(
                name: "IX_Models_GenderId",
                table: "Models");

            migrationBuilder.DropColumn(
                name: "SizeId",
                table: "SubCategories");

            migrationBuilder.DropColumn(
                name: "GenderId",
                table: "Models");

            migrationBuilder.AddColumn<Guid>(
                name: "GenderId",
                table: "Sizes",
                type: "uuid",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AddColumn<Guid>(
                name: "SubCategoryId",
                table: "Sizes",
                type: "uuid",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AddColumn<string>(
                name: "HexCode",
                table: "Colors",
                type: "text",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "CountryId",
                table: "Brands",
                type: "uuid",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.CreateIndex(
                name: "IX_Sizes_GenderId",
                table: "Sizes",
                column: "GenderId");

            migrationBuilder.CreateIndex(
                name: "IX_Sizes_SubCategoryId",
                table: "Sizes",
                column: "SubCategoryId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Brands_CountryId",
                table: "Brands",
                column: "CountryId");

            migrationBuilder.AddForeignKey(
                name: "FK_Brands_Countries_CountryId",
                table: "Brands",
                column: "CountryId",
                principalTable: "Countries",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Sizes_Genders_GenderId",
                table: "Sizes",
                column: "GenderId",
                principalTable: "Genders",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Sizes_SubCategories_SubCategoryId",
                table: "Sizes",
                column: "SubCategoryId",
                principalTable: "SubCategories",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Brands_Countries_CountryId",
                table: "Brands");

            migrationBuilder.DropForeignKey(
                name: "FK_Sizes_Genders_GenderId",
                table: "Sizes");

            migrationBuilder.DropForeignKey(
                name: "FK_Sizes_SubCategories_SubCategoryId",
                table: "Sizes");

            migrationBuilder.DropIndex(
                name: "IX_Sizes_GenderId",
                table: "Sizes");

            migrationBuilder.DropIndex(
                name: "IX_Sizes_SubCategoryId",
                table: "Sizes");

            migrationBuilder.DropIndex(
                name: "IX_Brands_CountryId",
                table: "Brands");

            migrationBuilder.DropColumn(
                name: "GenderId",
                table: "Sizes");

            migrationBuilder.DropColumn(
                name: "SubCategoryId",
                table: "Sizes");

            migrationBuilder.DropColumn(
                name: "HexCode",
                table: "Colors");

            migrationBuilder.DropColumn(
                name: "CountryId",
                table: "Brands");

            migrationBuilder.AddColumn<Guid>(
                name: "SizeId",
                table: "SubCategories",
                type: "uuid",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AddColumn<Guid>(
                name: "GenderId",
                table: "Models",
                type: "uuid",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.CreateIndex(
                name: "IX_SubCategories_SizeId",
                table: "SubCategories",
                column: "SizeId");

            migrationBuilder.CreateIndex(
                name: "IX_Models_GenderId",
                table: "Models",
                column: "GenderId");

            migrationBuilder.AddForeignKey(
                name: "FK_Models_Genders_GenderId",
                table: "Models",
                column: "GenderId",
                principalTable: "Genders",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_SubCategories_Sizes_SizeId",
                table: "SubCategories",
                column: "SizeId",
                principalTable: "Sizes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
