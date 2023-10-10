using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Team.Data.Migrations
{
    public partial class AddIsActiveMemberColumn : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "IsActiveMember",
                table: "Users",
                type: "nvarchar(1)",
                nullable: false,
                defaultValue: "");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IsActiveMember",
                table: "Users");
        }
    }
}
