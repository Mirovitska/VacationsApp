using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace IdentityApp.Data.Migrations
{
    public partial class rename : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "VacationsOwner",
                table: "Invoice",
                newName: "InvoiceOwner");

            migrationBuilder.RenameColumn(
                name: "VacationsMonth",
                table: "Invoice",
                newName: "InvoiceMonth");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "InvoiceOwner",
                table: "Invoice",
                newName: "VacationsOwner");

            migrationBuilder.RenameColumn(
                name: "InvoiceMonth",
                table: "Invoice",
                newName: "VacationsMonth");
        }
    }
}
