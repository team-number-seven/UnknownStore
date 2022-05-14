using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace UnknownStore.DAL.Data.Migrations.Store
{
    public partial class test_f : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Factories_Countries_CountryId",
                table: "Factories");

            migrationBuilder.DropColumn(
                name: "Address",
                table: "Factories");

            migrationBuilder.AlterColumn<Guid>(
                name: "CountryId",
                table: "Factories",
                type: "uuid",
                nullable: true,
                oldClrType: typeof(Guid),
                oldType: "uuid");

            migrationBuilder.AddColumn<Guid>(
                name: "AddressId",
                table: "Factories",
                type: "uuid",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.CreateIndex(
                name: "IX_Factories_AddressId",
                table: "Factories",
                column: "AddressId",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Factories_Addresses_AddressId",
                table: "Factories",
                column: "AddressId",
                principalTable: "Addresses",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Factories_Countries_CountryId",
                table: "Factories",
                column: "CountryId",
                principalTable: "Countries",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Factories_Addresses_AddressId",
                table: "Factories");

            migrationBuilder.DropForeignKey(
                name: "FK_Factories_Countries_CountryId",
                table: "Factories");

            migrationBuilder.DropIndex(
                name: "IX_Factories_AddressId",
                table: "Factories");

            migrationBuilder.DropColumn(
                name: "AddressId",
                table: "Factories");

            migrationBuilder.AlterColumn<Guid>(
                name: "CountryId",
                table: "Factories",
                type: "uuid",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"),
                oldClrType: typeof(Guid),
                oldType: "uuid",
                oldNullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Address",
                table: "Factories",
                type: "character varying(500)",
                maxLength: 500,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddForeignKey(
                name: "FK_Factories_Countries_CountryId",
                table: "Factories",
                column: "CountryId",
                principalTable: "Countries",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
