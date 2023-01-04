using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace IdentityApp.Data.Migrations
{
    public partial class renameAgain : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "InvoiceMonth",
                table: "Invoice",
                newName: "VacationsMonth");

            migrationBuilder.RenameColumn(
                name: "InvoiceAmount",
                table: "Invoice",
                newName: "CountOfVacationsDay");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "VacationsMonth",
                table: "Invoice",
                newName: "InvoiceMonth");

            migrationBuilder.RenameColumn(
                name: "CountOfVacationsDay",
                table: "Invoice",
                newName: "InvoiceAmount");
        }
    }
}
