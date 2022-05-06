using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace UnknownStore.DAL.Data.Migrations.Store
{
    public partial class FixTables : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                "FK_Models_Genders_GenderId",
                "Models");

            migrationBuilder.DropForeignKey(
                "FK_SubCategories_Sizes_SizeId",
                "SubCategories");

            migrationBuilder.DropIndex(
                "IX_SubCategories_SizeId",
                "SubCategories");

            migrationBuilder.DropIndex(
                "IX_Models_GenderId",
                "Models");

            migrationBuilder.DropColumn(
                "SizeId",
                "SubCategories");

            migrationBuilder.DropColumn(
                "GenderId",
                "Models");

            migrationBuilder.AddColumn<Guid>(
                "GenderId",
                "Sizes",
                "uuid",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AddColumn<Guid>(
                "SubCategoryId",
                "Sizes",
                "uuid",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AddColumn<string>(
                "HexCode",
                "Colors",
                "text",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                "CountryId",
                "Brands",
                "uuid",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.CreateIndex(
                "IX_Sizes_GenderId",
                "Sizes",
                "GenderId");

            migrationBuilder.CreateIndex(
                "IX_Sizes_SubCategoryId",
                "Sizes",
                "SubCategoryId",
                unique: true);

            migrationBuilder.CreateIndex(
                "IX_Brands_CountryId",
                "Brands",
                "CountryId");

            migrationBuilder.AddForeignKey(
                "FK_Brands_Countries_CountryId",
                "Brands",
                "CountryId",
                "Countries",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                "FK_Sizes_Genders_GenderId",
                "Sizes",
                "GenderId",
                "Genders",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                "FK_Sizes_SubCategories_SubCategoryId",
                "Sizes",
                "SubCategoryId",
                "SubCategories",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                "FK_Brands_Countries_CountryId",
                "Brands");

            migrationBuilder.DropForeignKey(
                "FK_Sizes_Genders_GenderId",
                "Sizes");

            migrationBuilder.DropForeignKey(
                "FK_Sizes_SubCategories_SubCategoryId",
                "Sizes");

            migrationBuilder.DropIndex(
                "IX_Sizes_GenderId",
                "Sizes");

            migrationBuilder.DropIndex(
                "IX_Sizes_SubCategoryId",
                "Sizes");

            migrationBuilder.DropIndex(
                "IX_Brands_CountryId",
                "Brands");

            migrationBuilder.DropColumn(
                "GenderId",
                "Sizes");

            migrationBuilder.DropColumn(
                "SubCategoryId",
                "Sizes");

            migrationBuilder.DropColumn(
                "HexCode",
                "Colors");

            migrationBuilder.DropColumn(
                "CountryId",
                "Brands");

            migrationBuilder.AddColumn<Guid>(
                "SizeId",
                "SubCategories",
                "uuid",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AddColumn<Guid>(
                "GenderId",
                "Models",
                "uuid",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.CreateIndex(
                "IX_SubCategories_SizeId",
                "SubCategories",
                "SizeId");

            migrationBuilder.CreateIndex(
                "IX_Models_GenderId",
                "Models",
                "GenderId");

            migrationBuilder.AddForeignKey(
                "FK_Models_Genders_GenderId",
                "Models",
                "GenderId",
                "Genders",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                "FK_SubCategories_Sizes_SizeId",
                "SubCategories",
                "SizeId",
                "Sizes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}