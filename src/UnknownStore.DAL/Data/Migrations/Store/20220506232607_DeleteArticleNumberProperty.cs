using Microsoft.EntityFrameworkCore.Migrations;

namespace UnknownStore.DAL.Data.Migrations.Store
{
    public partial class DeleteArticleNumberProperty : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                "IX_Models_ArticleNumber",
                "Models");

            migrationBuilder.DropColumn(
                "ArticleNumber",
                "Models");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                "ArticleNumber",
                "Models",
                "text",
                nullable: false,
                defaultValue: "");

            migrationBuilder.CreateIndex(
                "IX_Models_ArticleNumber",
                "Models",
                "ArticleNumber",
                unique: true);
        }
    }
}