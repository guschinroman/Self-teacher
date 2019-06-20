using Microsoft.EntityFrameworkCore.Migrations;

namespace SelfTeacher.Service.Migrations
{
    public partial class AddVkAccessTokenToUser : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "AccessTokenVk",
                table: "Users",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "AccessTokenVk",
                table: "Users");
        }
    }
}
