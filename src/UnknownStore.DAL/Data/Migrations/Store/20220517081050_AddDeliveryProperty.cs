using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace UnknownStore.DAL.Data.Migrations.Store
{
    public partial class AddDeliveryProperty : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<TimeSpan>(
                name: "MaxTimeDelivered",
                table: "DeliveryCities",
                type: "interval",
                nullable: false,
                defaultValue: new TimeSpan(0, 0, 0, 0, 0));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "MaxTimeDelivered",
                table: "DeliveryCities");
        }
    }
}
