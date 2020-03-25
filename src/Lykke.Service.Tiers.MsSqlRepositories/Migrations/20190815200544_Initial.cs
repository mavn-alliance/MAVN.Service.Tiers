using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Lykke.Service.Tiers.MsSqlRepositories.Migrations
{
    public partial class Initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.EnsureSchema(
                name: "tiers");

            migrationBuilder.CreateTable(
                name: "tiers",
                schema: "tiers",
                columns: table => new
                {
                    id = table.Column<Guid>(nullable: false),
                    name = table.Column<string>(type: "nvarchar(50)", nullable: false),
                    threshold = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tiers", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "customer_tiers",
                schema: "tiers",
                columns: table => new
                {
                    customer_id = table.Column<Guid>(nullable: false),
                    tier_id = table.Column<Guid>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_customer_tiers", x => x.customer_id);
                    table.ForeignKey(
                        name: "FK_customer_tiers_tiers_tier_id",
                        column: x => x.tier_id,
                        principalSchema: "tiers",
                        principalTable: "tiers",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                schema: "tiers",
                table: "tiers",
                columns: new[] { "id", "name", "threshold" },
                values: new object[,]
                {
                    { new Guid("e5538c22-3f19-489a-8eed-0549b84a47d2"), "Black", 0 },
                    { new Guid("af3804ef-faf2-47b0-b6f6-66100f3bcdd4"), "Silver", 100000000 },
                    { new Guid("df6e1941-0828-4424-9ed5-451d73139bed"), "Gold", 250000000 },
                    { new Guid("4c3cd4ce-98eb-487d-bef8-7e0ee3801ecc"), "Platinum", 600000000 }
                });

            migrationBuilder.CreateIndex(
                name: "IX_customer_tiers_tier_id",
                schema: "tiers",
                table: "customer_tiers",
                column: "tier_id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "customer_tiers",
                schema: "tiers");

            migrationBuilder.DropTable(
                name: "tiers",
                schema: "tiers");
        }
    }
}
