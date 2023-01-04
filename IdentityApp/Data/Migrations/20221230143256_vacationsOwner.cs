using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace IdentityApp.Data.Migrations
{
    public partial class vacationsOwner : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "InvoiceMonth",
                table: "Invoice");

            migrationBuilder.RenameColumn(
                name: "InvoiceOwner",
                table: "Invoice",
                newName: "VacationsOwner");

            migrationBuilder.RenameColumn(
                name: "InvoiceMonth2",
                table: "Invoice",
                newName: "VacationsMonth");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "VacationsOwner",
                table: "Invoice",
                newName: "InvoiceOwner");

            migrationBuilder.RenameColumn(
                name: "VacationsMonth",
                table: "Invoice",
                newName: "InvoiceMonth2");

            migrationBuilder.AddColumn<string>(
                name: "InvoiceMonth",
                table: "Invoice",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }
    }
}
