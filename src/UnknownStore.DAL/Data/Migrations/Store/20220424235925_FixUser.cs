using Microsoft.EntityFrameworkCore.Migrations;

namespace UnknownStore.DAL.Data.Migrations.Store
{
    public partial class FixUser : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "CreateDateTime",
                table: "Users",
                type: "text",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CreateDateTime",
                table: "Users");
        }
    }
}
