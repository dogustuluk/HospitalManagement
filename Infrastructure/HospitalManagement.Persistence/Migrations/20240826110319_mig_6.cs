using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace HospitalManagement.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class mig_6 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AppRoleAuthority_AspNetUsers_AppUserId",
                table: "AppRoleAuthority");

            migrationBuilder.DropIndex(
                name: "IX_AppRoleAuthority_AppUserId",
                table: "AppRoleAuthority");

            migrationBuilder.DropColumn(
                name: "AppPermissionId",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "AppRoleId",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "AppUserId",
                table: "AppRoleAuthority");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "AppPermissionId",
                table: "AspNetUsers",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "AppRoleId",
                table: "AspNetUsers",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "AppUserId",
                table: "AppRoleAuthority",
                type: "integer",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_AppRoleAuthority_AppUserId",
                table: "AppRoleAuthority",
                column: "AppUserId");

            migrationBuilder.AddForeignKey(
                name: "FK_AppRoleAuthority_AspNetUsers_AppUserId",
                table: "AppRoleAuthority",
                column: "AppUserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id");
        }
    }
}
