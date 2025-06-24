using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MiamBurger_API.Migrations
{
    /// <inheritdoc />
    public partial class UpdateDBWIthUser : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "NbUser",
                table: "Orders",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    Number = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Firstname = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.Number);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Orders_NbUser",
                table: "Orders",
                column: "NbUser");

            migrationBuilder.AddForeignKey(
                name: "FK_Orders_Users_NbUser",
                table: "Orders",
                column: "NbUser",
                principalTable: "Users",
                principalColumn: "Number",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Orders_Users_NbUser",
                table: "Orders");

            migrationBuilder.DropTable(
                name: "Users");

            migrationBuilder.DropIndex(
                name: "IX_Orders_NbUser",
                table: "Orders");

            migrationBuilder.DropColumn(
                name: "NbUser",
                table: "Orders");
        }
    }
}
