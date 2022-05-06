using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

namespace UnknownStore.DAL.Data.Migrations.Store
{
    public partial class InitialStore : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                "AgeTypes",
                table => new
                {
                    Id = table.Column<Guid>("uuid", nullable: false),
                    Title = table.Column<string>("character varying(25)", maxLength: 25, nullable: false)
                },
                constraints: table => { table.PrimaryKey("PK_AgeTypes", x => x.Id); });

            migrationBuilder.CreateTable(
                "Brands",
                table => new
                {
                    Id = table.Column<Guid>("uuid", nullable: false),
                    Title = table.Column<string>("character varying(250)", maxLength: 250, nullable: false)
                },
                constraints: table => { table.PrimaryKey("PK_Brands", x => x.Id); });

            migrationBuilder.CreateTable(
                "Colors",
                table => new
                {
                    Id = table.Column<Guid>("uuid", nullable: false),
                    Title = table.Column<string>("character varying(100)", maxLength: 100, nullable: false)
                },
                constraints: table => { table.PrimaryKey("PK_Colors", x => x.Id); });

            migrationBuilder.CreateTable(
                "Countries",
                table => new
                {
                    Id = table.Column<Guid>("uuid", nullable: false),
                    Title = table.Column<string>("character varying(100)", maxLength: 100, nullable: false)
                },
                constraints: table => { table.PrimaryKey("PK_Countries", x => x.Id); });

            migrationBuilder.CreateTable(
                "Genders",
                table => new
                {
                    Id = table.Column<Guid>("uuid", nullable: false),
                    Title = table.Column<string>("character varying(75)", maxLength: 75, nullable: false)
                },
                constraints: table => { table.PrimaryKey("PK_Genders", x => x.Id); });

            migrationBuilder.CreateTable(
                "Roles",
                table => new
                {
                    Id = table.Column<Guid>("uuid", nullable: false),
                    Name = table.Column<string>("character varying(256)", maxLength: 256, nullable: true),
                    NormalizedName = table.Column<string>("character varying(256)", maxLength: 256, nullable: true),
                    ConcurrencyStamp = table.Column<string>("text", nullable: true)
                },
                constraints: table => { table.PrimaryKey("PK_Roles", x => x.Id); });

            migrationBuilder.CreateTable(
                "Seasons",
                table => new
                {
                    Id = table.Column<Guid>("uuid", nullable: false),
                    Title = table.Column<string>("character varying(50)", maxLength: 50, nullable: false)
                },
                constraints: table => { table.PrimaryKey("PK_Seasons", x => x.Id); });

            migrationBuilder.CreateTable(
                "Sizes",
                table => new
                {
                    Id = table.Column<Guid>("uuid", nullable: false),
                    Standard = table.Column<string>("character varying(15)", maxLength: 15, nullable: false),
                    MinValue = table.Column<double>("double precision", nullable: true),
                    MaxValue = table.Column<double>("double precision", nullable: true)
                },
                constraints: table => { table.PrimaryKey("PK_Sizes", x => x.Id); });

            migrationBuilder.CreateTable(
                "Users",
                table => new
                {
                    Id = table.Column<Guid>("uuid", nullable: false),
                    CreateDateTime = table.Column<string>("text", nullable: true),
                    UserName = table.Column<string>("character varying(256)", maxLength: 256, nullable: true),
                    NormalizedUserName = table.Column<string>("character varying(256)", maxLength: 256, nullable: true),
                    Email = table.Column<string>("character varying(256)", maxLength: 256, nullable: true),
                    NormalizedEmail = table.Column<string>("character varying(256)", maxLength: 256, nullable: true),
                    EmailConfirmed = table.Column<bool>("boolean", nullable: false),
                    PasswordHash = table.Column<string>("text", nullable: true),
                    SecurityStamp = table.Column<string>("text", nullable: true),
                    ConcurrencyStamp = table.Column<string>("text", nullable: true),
                    PhoneNumber = table.Column<string>("text", nullable: true),
                    PhoneNumberConfirmed = table.Column<bool>("boolean", nullable: false),
                    TwoFactorEnabled = table.Column<bool>("boolean", nullable: false),
                    LockoutEnd = table.Column<DateTimeOffset>("timestamp with time zone", nullable: true),
                    LockoutEnabled = table.Column<bool>("boolean", nullable: false),
                    AccessFailedCount = table.Column<int>("integer", nullable: false)
                },
                constraints: table => { table.PrimaryKey("PK_Users", x => x.Id); });

            migrationBuilder.CreateTable(
                "Categories",
                table => new
                {
                    Id = table.Column<Guid>("uuid", nullable: false),
                    Title = table.Column<string>("character varying(30)", maxLength: 30, nullable: false),
                    AgeTypeId = table.Column<Guid>("uuid", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Categories", x => x.Id);
                    table.ForeignKey(
                        "FK_Categories_AgeTypes_AgeTypeId",
                        x => x.AgeTypeId,
                        "AgeTypes",
                        "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                "Factories",
                table => new
                {
                    Id = table.Column<Guid>("uuid", nullable: false),
                    Title = table.Column<string>("character varying(150)", maxLength: 150, nullable: false),
                    Address = table.Column<string>("character varying(500)", maxLength: 500, nullable: false),
                    CountryId = table.Column<Guid>("uuid", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Factories", x => x.Id);
                    table.ForeignKey(
                        "FK_Factories_Countries_CountryId",
                        x => x.CountryId,
                        "Countries",
                        "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                "RoleClaims",
                table => new
                {
                    Id = table.Column<int>("integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy",
                            NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    RoleId = table.Column<Guid>("uuid", nullable: false),
                    ClaimType = table.Column<string>("text", nullable: true),
                    ClaimValue = table.Column<string>("text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RoleClaims", x => x.Id);
                    table.ForeignKey(
                        "FK_RoleClaims_Roles_RoleId",
                        x => x.RoleId,
                        "Roles",
                        "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                "UserClaims",
                table => new
                {
                    Id = table.Column<int>("integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy",
                            NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    UserId = table.Column<Guid>("uuid", nullable: false),
                    ClaimType = table.Column<string>("text", nullable: true),
                    ClaimValue = table.Column<string>("text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserClaims", x => x.Id);
                    table.ForeignKey(
                        "FK_UserClaims_Users_UserId",
                        x => x.UserId,
                        "Users",
                        "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                "UserLogins",
                table => new
                {
                    LoginProvider = table.Column<string>("text", nullable: false),
                    ProviderKey = table.Column<string>("text", nullable: false),
                    ProviderDisplayName = table.Column<string>("text", nullable: true),
                    UserId = table.Column<Guid>("uuid", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserLogins", x => new { x.LoginProvider, x.ProviderKey });
                    table.ForeignKey(
                        "FK_UserLogins_Users_UserId",
                        x => x.UserId,
                        "Users",
                        "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                "UserRoles",
                table => new
                {
                    UserId = table.Column<Guid>("uuid", nullable: false),
                    RoleId = table.Column<Guid>("uuid", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserRoles", x => new { x.UserId, x.RoleId });
                    table.ForeignKey(
                        "FK_UserRoles_Roles_RoleId",
                        x => x.RoleId,
                        "Roles",
                        "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        "FK_UserRoles_Users_UserId",
                        x => x.UserId,
                        "Users",
                        "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                "UserTokens",
                table => new
                {
                    UserId = table.Column<Guid>("uuid", nullable: false),
                    LoginProvider = table.Column<string>("text", nullable: false),
                    Name = table.Column<string>("text", nullable: false),
                    Value = table.Column<string>("text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserTokens", x => new { x.UserId, x.LoginProvider, x.Name });
                    table.ForeignKey(
                        "FK_UserTokens_Users_UserId",
                        x => x.UserId,
                        "Users",
                        "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                "SubCategories",
                table => new
                {
                    Id = table.Column<Guid>("uuid", nullable: false),
                    Title = table.Column<string>("character varying(50)", maxLength: 50, nullable: false),
                    CategoryId = table.Column<Guid>("uuid", nullable: false),
                    SizeId = table.Column<Guid>("uuid", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SubCategories", x => x.Id);
                    table.ForeignKey(
                        "FK_SubCategories_Categories_CategoryId",
                        x => x.CategoryId,
                        "Categories",
                        "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        "FK_SubCategories_Sizes_SizeId",
                        x => x.SizeId,
                        "Sizes",
                        "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                "Models",
                table => new
                {
                    Id = table.Column<Guid>("uuid", nullable: false),
                    Title = table.Column<string>("character varying(100)", maxLength: 100, nullable: false),
                    Price = table.Column<decimal>("numeric", nullable: false),
                    ArticleNumber = table.Column<string>("text", nullable: false),
                    BrandId = table.Column<Guid>("uuid", nullable: false),
                    SubCategoryId = table.Column<Guid>("uuid", nullable: false),
                    ColorId = table.Column<Guid>("uuid", nullable: false),
                    GenderId = table.Column<Guid>("uuid", nullable: false),
                    FactoryId = table.Column<Guid>("uuid", nullable: false),
                    SeasonId = table.Column<Guid>("uuid", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Models", x => x.Id);
                    table.ForeignKey(
                        "FK_Models_Brands_BrandId",
                        x => x.BrandId,
                        "Brands",
                        "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        "FK_Models_Colors_ColorId",
                        x => x.ColorId,
                        "Colors",
                        "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        "FK_Models_Factories_FactoryId",
                        x => x.FactoryId,
                        "Factories",
                        "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        "FK_Models_Genders_GenderId",
                        x => x.GenderId,
                        "Genders",
                        "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        "FK_Models_Seasons_SeasonId",
                        x => x.SeasonId,
                        "Seasons",
                        "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        "FK_Models_SubCategories_SubCategoryId",
                        x => x.SubCategoryId,
                        "SubCategories",
                        "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                "AmountOfSizes",
                table => new
                {
                    Id = table.Column<Guid>("uuid", nullable: false),
                    Value = table.Column<double>("double precision", nullable: false),
                    Amount = table.Column<int>("integer", nullable: false),
                    ModelId = table.Column<Guid>("uuid", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AmountOfSizes", x => x.Id);
                    table.ForeignKey(
                        "FK_AmountOfSizes_Models_ModelId",
                        x => x.ModelId,
                        "Models",
                        "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                "Comment",
                table => new
                {
                    Id = table.Column<Guid>("uuid", nullable: false),
                    Review = table.Column<int>("integer", nullable: false),
                    Value = table.Column<string>("text", nullable: true),
                    CreateDate = table.Column<string>("text", nullable: true),
                    ModelId = table.Column<Guid>("uuid", nullable: false),
                    UserId = table.Column<Guid>("uuid", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Comment", x => x.Id);
                    table.ForeignKey(
                        "FK_Comment_Models_ModelId",
                        x => x.ModelId,
                        "Models",
                        "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        "FK_Comment_Users_UserId",
                        x => x.UserId,
                        "Users",
                        "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                "Images",
                table => new
                {
                    Id = table.Column<Guid>("uuid", nullable: false),
                    Path = table.Column<string>("character varying(500)", maxLength: 500, nullable: false),
                    Format = table.Column<string>("character varying(20)", maxLength: 20, nullable: false),
                    ModelId = table.Column<Guid>("uuid", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Images", x => x.Id);
                    table.ForeignKey(
                        "FK_Images_Models_ModelId",
                        x => x.ModelId,
                        "Models",
                        "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                "ModelsData",
                table => new
                {
                    Id = table.Column<Guid>("uuid", nullable: false),
                    Key = table.Column<string>("character varying(50)", maxLength: 50, nullable: false),
                    Value = table.Column<string>("character varying(500)", maxLength: 500, nullable: false),
                    ModelId = table.Column<Guid>("uuid", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ModelsData", x => x.Id);
                    table.ForeignKey(
                        "FK_ModelsData_Models_ModelId",
                        x => x.ModelId,
                        "Models",
                        "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                "IX_AgeTypes_Title",
                "AgeTypes",
                "Title",
                unique: true);

            migrationBuilder.CreateIndex(
                "IX_AmountOfSizes_ModelId",
                "AmountOfSizes",
                "ModelId");

            migrationBuilder.CreateIndex(
                "IX_Categories_AgeTypeId",
                "Categories",
                "AgeTypeId");

            migrationBuilder.CreateIndex(
                "IX_Colors_Title",
                "Colors",
                "Title",
                unique: true);

            migrationBuilder.CreateIndex(
                "IX_Comment_ModelId",
                "Comment",
                "ModelId");

            migrationBuilder.CreateIndex(
                "IX_Comment_UserId",
                "Comment",
                "UserId",
                unique: true);

            migrationBuilder.CreateIndex(
                "IX_Countries_Title",
                "Countries",
                "Title",
                unique: true);

            migrationBuilder.CreateIndex(
                "IX_Factories_CountryId",
                "Factories",
                "CountryId");

            migrationBuilder.CreateIndex(
                "IX_Genders_Title",
                "Genders",
                "Title",
                unique: true);

            migrationBuilder.CreateIndex(
                "IX_Images_Format",
                "Images",
                "Format",
                unique: true);

            migrationBuilder.CreateIndex(
                "IX_Images_ModelId",
                "Images",
                "ModelId");

            migrationBuilder.CreateIndex(
                "IX_Images_Path",
                "Images",
                "Path",
                unique: true);

            migrationBuilder.CreateIndex(
                "IX_Models_ArticleNumber",
                "Models",
                "ArticleNumber",
                unique: true);

            migrationBuilder.CreateIndex(
                "IX_Models_BrandId",
                "Models",
                "BrandId");

            migrationBuilder.CreateIndex(
                "IX_Models_ColorId",
                "Models",
                "ColorId");

            migrationBuilder.CreateIndex(
                "IX_Models_FactoryId",
                "Models",
                "FactoryId");

            migrationBuilder.CreateIndex(
                "IX_Models_GenderId",
                "Models",
                "GenderId");

            migrationBuilder.CreateIndex(
                "IX_Models_SeasonId",
                "Models",
                "SeasonId");

            migrationBuilder.CreateIndex(
                "IX_Models_SubCategoryId",
                "Models",
                "SubCategoryId");

            migrationBuilder.CreateIndex(
                "IX_ModelsData_ModelId",
                "ModelsData",
                "ModelId");

            migrationBuilder.CreateIndex(
                "IX_RoleClaims_RoleId",
                "RoleClaims",
                "RoleId");

            migrationBuilder.CreateIndex(
                "RoleNameIndex",
                "Roles",
                "NormalizedName",
                unique: true);

            migrationBuilder.CreateIndex(
                "IX_Seasons_Title",
                "Seasons",
                "Title",
                unique: true);

            migrationBuilder.CreateIndex(
                "IX_SubCategories_CategoryId",
                "SubCategories",
                "CategoryId");

            migrationBuilder.CreateIndex(
                "IX_SubCategories_SizeId",
                "SubCategories",
                "SizeId");

            migrationBuilder.CreateIndex(
                "IX_SubCategories_Title",
                "SubCategories",
                "Title",
                unique: true);

            migrationBuilder.CreateIndex(
                "IX_UserClaims_UserId",
                "UserClaims",
                "UserId");

            migrationBuilder.CreateIndex(
                "IX_UserLogins_UserId",
                "UserLogins",
                "UserId");

            migrationBuilder.CreateIndex(
                "IX_UserRoles_RoleId",
                "UserRoles",
                "RoleId");

            migrationBuilder.CreateIndex(
                "EmailIndex",
                "Users",
                "NormalizedEmail");

            migrationBuilder.CreateIndex(
                "UserNameIndex",
                "Users",
                "NormalizedUserName",
                unique: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                "AmountOfSizes");

            migrationBuilder.DropTable(
                "Comment");

            migrationBuilder.DropTable(
                "Images");

            migrationBuilder.DropTable(
                "ModelsData");

            migrationBuilder.DropTable(
                "RoleClaims");

            migrationBuilder.DropTable(
                "UserClaims");

            migrationBuilder.DropTable(
                "UserLogins");

            migrationBuilder.DropTable(
                "UserRoles");

            migrationBuilder.DropTable(
                "UserTokens");

            migrationBuilder.DropTable(
                "Models");

            migrationBuilder.DropTable(
                "Roles");

            migrationBuilder.DropTable(
                "Users");

            migrationBuilder.DropTable(
                "Brands");

            migrationBuilder.DropTable(
                "Colors");

            migrationBuilder.DropTable(
                "Factories");

            migrationBuilder.DropTable(
                "Genders");

            migrationBuilder.DropTable(
                "Seasons");

            migrationBuilder.DropTable(
                "SubCategories");

            migrationBuilder.DropTable(
                "Countries");

            migrationBuilder.DropTable(
                "Categories");

            migrationBuilder.DropTable(
                "Sizes");

            migrationBuilder.DropTable(
                "AgeTypes");
        }
    }
}