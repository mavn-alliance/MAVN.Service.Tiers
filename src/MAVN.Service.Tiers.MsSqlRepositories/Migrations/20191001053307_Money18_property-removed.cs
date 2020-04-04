using Microsoft.EntityFrameworkCore.Migrations;

namespace MAVN.Service.Tiers.MsSqlRepositories.Migrations
{
    public partial class Money18_propertyremoved : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "sum_bonus_awarded",
                schema: "tiers",
                table: "customer_tiers");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "sum_bonus_awarded",
                schema: "tiers",
                table: "customer_tiers",
                nullable: false,
                defaultValue: "");
        }
    }
}
