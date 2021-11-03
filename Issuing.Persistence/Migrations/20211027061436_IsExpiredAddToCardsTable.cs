using Microsoft.EntityFrameworkCore.Migrations;

namespace Issuing.Persistence.Migrations
{
    public partial class IsExpiredAddToCardsTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "IsExpired",
                table: "Cards",
                type: "INTEGER",
                nullable: false,
                defaultValue: false);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IsExpired",
                table: "Cards");
        }
    }
}
