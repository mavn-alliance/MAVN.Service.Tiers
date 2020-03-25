using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Lykke.Service.Tiers.MsSqlRepositories.Migrations
{
    public partial class Money18 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "threshold",
                schema: "tiers",
                table: "tiers",
                nullable: false,
                oldClrType: typeof(int));

            migrationBuilder.AddColumn<string>(
                name: "sum_bonus_awarded",
                schema: "tiers",
                table: "customer_tiers",
                nullable: false,
                defaultValue: "");

            migrationBuilder.CreateTable(
                name: "customer_bonuses",
                schema: "tiers",
                columns: table => new
                {
                    customer_id = table.Column<Guid>(nullable: false),
                    id = table.Column<Guid>(nullable: false),
                    total_awarded_bonuses = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_customer_bonuses", x => x.customer_id);
                    table.UniqueConstraint("AK_customer_bonuses_id", x => x.id);
                });

            migrationBuilder.UpdateData(
                schema: "tiers",
                table: "tiers",
                keyColumn: "id",
                keyValue: new Guid("4c3cd4ce-98eb-487d-bef8-7e0ee3801ecc"),
                column: "threshold",
                value: "300000000000000000000");

            migrationBuilder.UpdateData(
                schema: "tiers",
                table: "tiers",
                keyColumn: "id",
                keyValue: new Guid("af3804ef-faf2-47b0-b6f6-66100f3bcdd4"),
                column: "threshold",
                value: "100000000000000000000");

            migrationBuilder.UpdateData(
                schema: "tiers",
                table: "tiers",
                keyColumn: "id",
                keyValue: new Guid("df6e1941-0828-4424-9ed5-451d73139bed"),
                column: "threshold",
                value: "200000000000000000000");

            migrationBuilder.UpdateData(
                schema: "tiers",
                table: "tiers",
                keyColumn: "id",
                keyValue: new Guid("e5538c22-3f19-489a-8eed-0549b84a47d2"),
                column: "threshold",
                value: "0");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "customer_bonuses",
                schema: "tiers");

            migrationBuilder.DropColumn(
                name: "sum_bonus_awarded",
                schema: "tiers",
                table: "customer_tiers");

            migrationBuilder.AlterColumn<int>(
                name: "threshold",
                schema: "tiers",
                table: "tiers",
                nullable: false,
                oldClrType: typeof(string));

            migrationBuilder.UpdateData(
                schema: "tiers",
                table: "tiers",
                keyColumn: "id",
                keyValue: new Guid("4c3cd4ce-98eb-487d-bef8-7e0ee3801ecc"),
                column: "threshold",
                value: 600000000);

            migrationBuilder.UpdateData(
                schema: "tiers",
                table: "tiers",
                keyColumn: "id",
                keyValue: new Guid("af3804ef-faf2-47b0-b6f6-66100f3bcdd4"),
                column: "threshold",
                value: 100000000);

            migrationBuilder.UpdateData(
                schema: "tiers",
                table: "tiers",
                keyColumn: "id",
                keyValue: new Guid("df6e1941-0828-4424-9ed5-451d73139bed"),
                column: "threshold",
                value: 250000000);

            migrationBuilder.UpdateData(
                schema: "tiers",
                table: "tiers",
                keyColumn: "id",
                keyValue: new Guid("e5538c22-3f19-489a-8eed-0549b84a47d2"),
                column: "threshold",
                value: 0);
        }
    }
}
