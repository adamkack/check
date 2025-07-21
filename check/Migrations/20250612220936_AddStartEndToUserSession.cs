using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace check.Migrations
{
    /// <inheritdoc />
    public partial class AddStartEndToUserSession : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "LogoutTime",
                table: "UserSessions",
                newName: "EndTime");

            migrationBuilder.RenameColumn(
                name: "LoginTime",
                table: "UserSessions",
                newName: "StartTime");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "StartTime",
                table: "UserSessions",
                newName: "LoginTime");

            migrationBuilder.RenameColumn(
                name: "EndTime",
                table: "UserSessions",
                newName: "LogoutTime");
        }
    }
}
