using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class Client : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "BillIdBill",
                table: "Users",
                type: "INTEGER",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Discriminator",
                table: "Users",
                type: "TEXT",
                maxLength: 8,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "IdClient",
                table: "Users",
                type: "TEXT",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Users_BillIdBill",
                table: "Users",
                column: "BillIdBill");

            migrationBuilder.AddForeignKey(
                name: "FK_Users_Bills_BillIdBill",
                table: "Users",
                column: "BillIdBill",
                principalTable: "Bills",
                principalColumn: "IdBill",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Users_Bills_BillIdBill",
                table: "Users");

            migrationBuilder.DropIndex(
                name: "IX_Users_BillIdBill",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "BillIdBill",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "Discriminator",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "IdClient",
                table: "Users");
        }
    }
}
