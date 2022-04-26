using Microsoft.EntityFrameworkCore.Migrations;

namespace SharePrices.Migrations
{
    public partial class InitialMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Share",
                columns: table => new
                {
                    Name = table.Column<string>(nullable: false),
                    Price = table.Column<double>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Share", x => x.Name);
                });

            migrationBuilder.InsertData(
                table: "Share",
                columns: new[] { "Name", "Price" },
                values: new object[,]
                {
                    { "3M India Ltd", 21145.0 },
                    { "Aarti Drugs Ltd", 519.0 },
                    { "Tata Power", 277.80000000000001 },
                    { "HDFC Bank", 1516.75 },
                    { "Zee Entertainment", 284.75 }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Share");
        }
    }
}
