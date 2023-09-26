using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Team.Data.Migrations
{
    public partial class AddUserTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RoleId = table.Column<int>(type: "int", nullable: false),
                    FirstName = table.Column<string>(type: "Varchar(250)", maxLength: 250, nullable: false),
                    LastName = table.Column<string>(type: "Varchar(250)", maxLength: 250, nullable: false),
                    Password = table.Column<string>(type: "Varchar(250)", maxLength: 250, nullable: false),
                    TotalMatchesPlayed = table.Column<int>(type: "int", nullable: true),
                    ContactNumber = table.Column<string>(type: "Varchar(250)", maxLength: 250, nullable: false),
                    DOB = table.Column<string>(type: "Varchar(250)", maxLength: 250, nullable: false),
                    Height = table.Column<float>(type: "real", nullable: true),
                    Weight = table.Column<float>(type: "real", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Users");
        }
    }
}
