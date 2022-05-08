using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace UnknownStore.DAL.Data.Migrations.Store
{
    public partial class fixSizeEntity : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Sizes_Genders_GenderId",
                table: "Sizes");

            migrationBuilder.DropIndex(
                name: "IX_Sizes_GenderId",
                table: "Sizes");

            migrationBuilder.DropColumn(
                name: "GenderId",
                table: "Sizes");

            migrationBuilder.AddColumn<Guid>(
                name: "GenderId",
                table: "SubCategories",
                type: "uuid",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.CreateIndex(
                name: "IX_SubCategories_GenderId",
                table: "SubCategories",
                column: "GenderId");

            migrationBuilder.AddForeignKey(
                name: "FK_SubCategories_Genders_GenderId",
                table: "SubCategories",
                column: "GenderId",
                principalTable: "Genders",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_SubCategories_Genders_GenderId",
                table: "SubCategories");

            migrationBuilder.DropIndex(
                name: "IX_SubCategories_GenderId",
                table: "SubCategories");

            migrationBuilder.DropColumn(
                name: "GenderId",
                table: "SubCategories");

            migrationBuilder.AddColumn<Guid>(
                name: "GenderId",
                table: "Sizes",
                type: "uuid",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.CreateIndex(
                name: "IX_Sizes_GenderId",
                table: "Sizes",
                column: "GenderId");

            migrationBuilder.AddForeignKey(
                name: "FK_Sizes_Genders_GenderId",
                table: "Sizes",
                column: "GenderId",
                principalTable: "Genders",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
