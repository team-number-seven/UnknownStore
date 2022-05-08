using Microsoft.EntityFrameworkCore.Migrations;

namespace UnknownStore.DAL.Data.Migrations.Store
{
    public partial class DeletePhoneNumberAndFixFormatImage : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                "IX_Images_Format",
                "Images");

            migrationBuilder.DropColumn(
                "PhoneNumber",
                "Users");

            migrationBuilder.DropColumn(
                "PhoneNumberConfirmed",
                "Users");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                "PhoneNumber",
                "Users",
                "text",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                "PhoneNumberConfirmed",
                "Users",
                "boolean",
                nullable: false,
                defaultValue: false);

            migrationBuilder.CreateIndex(
                "IX_Images_Format",
                "Images",
                "Format",
                unique: true);
        }
    }
}