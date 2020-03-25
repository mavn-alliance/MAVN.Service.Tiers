using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Lykke.Service.Tiers.MsSqlRepositories.Migrations
{
    public partial class CorrectTiersValues : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
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
            migrationBuilder.UpdateData(
                schema: "tiers",
                table: "tiers",
                keyColumn: "id",
                keyValue: new Guid("e5538c22-3f19-489a-8eed-0549b84a47d2"),
                column: "threshold",
                value: "0");
        }
    }
}
