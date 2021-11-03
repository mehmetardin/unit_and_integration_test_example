using Microsoft.EntityFrameworkCore.Migrations;

namespace Issuing.Persistence.Migrations
{
    public partial class InitialCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Cards",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Guid = table.Column<long>(type: "INTEGER", nullable: false),
                    Status = table.Column<short>(type: "INTEGER", nullable: false),
                    LastUpdated = table.Column<long>(type: "INTEGER", nullable: false),
                    MemberId = table.Column<short>(type: "INTEGER", nullable: false),
                    Bin = table.Column<string>(type: "TEXT", nullable: true),
                    BinRangeGuid = table.Column<long>(type: "INTEGER", nullable: false),
                    CardNo = table.Column<string>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Cards", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Cards");
        }
    }
}
