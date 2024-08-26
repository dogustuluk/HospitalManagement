using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace HospitalManagement.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class mig_5 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
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

            migrationBuilder.AddColumn<bool>(
                name: "isActive",
                table: "AspNetRoles",
                type: "boolean",
                nullable: false,
                defaultValue: false);

            migrationBuilder.CreateTable(
                name: "AppRoleAuthority",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    AppRoleId = table.Column<int>(type: "integer", nullable: false),
                    isCanView = table.Column<bool>(type: "boolean", nullable: false),
                    isCanSeeAll = table.Column<bool>(type: "boolean", nullable: false),
                    isCanInsert = table.Column<bool>(type: "boolean", nullable: false),
                    isCanApprove = table.Column<bool>(type: "boolean", nullable: false),
                    isCanUpdate = table.Column<bool>(type: "boolean", nullable: false),
                    isCanDelete = table.Column<bool>(type: "boolean", nullable: false),
                    isActive = table.Column<bool>(type: "boolean", nullable: false),
                    AppUserId = table.Column<int>(type: "integer", nullable: true),
                    Guid = table.Column<Guid>(type: "uuid", nullable: false),
                    CreatedUser = table.Column<Guid>(type: "uuid", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    UpdatedUser = table.Column<Guid>(type: "uuid", nullable: false),
                    UpdatedDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AppRoleAuthority", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AppRoleAuthority_AspNetRoles_AppRoleId",
                        column: x => x.AppRoleId,
                        principalTable: "AspNetRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AppRoleAuthority_AspNetUsers_AppUserId",
                        column: x => x.AppUserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "AppUserRole",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    UserId = table.Column<int>(type: "integer", nullable: false),
                    RoleId = table.Column<int>(type: "integer", nullable: false),
                    AppUserId = table.Column<int>(type: "integer", nullable: false),
                    AppRoleId = table.Column<int>(type: "integer", nullable: false),
                    Guid = table.Column<Guid>(type: "uuid", nullable: false),
                    CreatedUser = table.Column<Guid>(type: "uuid", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    UpdatedUser = table.Column<Guid>(type: "uuid", nullable: false),
                    UpdatedDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AppUserRole", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AppUserRole_AspNetRoles_AppRoleId",
                        column: x => x.AppRoleId,
                        principalTable: "AspNetRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AppUserRole_AspNetUsers_AppUserId",
                        column: x => x.AppUserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AppRolePermission",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    AppRoleAuthorityId = table.Column<int>(type: "integer", nullable: false),
                    ParentPermissionId = table.Column<int>(type: "integer", nullable: true),
                    PermissionName = table.Column<string>(type: "text", nullable: false),
                    PermissionLevel = table.Column<int>(type: "integer", nullable: false),
                    isActive = table.Column<int>(type: "integer", nullable: false),
                    Guid = table.Column<Guid>(type: "uuid", nullable: false),
                    CreatedUser = table.Column<Guid>(type: "uuid", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    UpdatedUser = table.Column<Guid>(type: "uuid", nullable: false),
                    UpdatedDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AppRolePermission", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AppRolePermission_AppRoleAuthority_AppRoleAuthorityId",
                        column: x => x.AppRoleAuthorityId,
                        principalTable: "AppRoleAuthority",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AppRolePermission_AppRolePermission_ParentPermissionId",
                        column: x => x.ParentPermissionId,
                        principalTable: "AppRolePermission",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_AppRoleAuthority_AppRoleId",
                table: "AppRoleAuthority",
                column: "AppRoleId");

            migrationBuilder.CreateIndex(
                name: "IX_AppRoleAuthority_AppUserId",
                table: "AppRoleAuthority",
                column: "AppUserId");

            migrationBuilder.CreateIndex(
                name: "IX_AppRolePermission_AppRoleAuthorityId",
                table: "AppRolePermission",
                column: "AppRoleAuthorityId");

            migrationBuilder.CreateIndex(
                name: "IX_AppRolePermission_ParentPermissionId",
                table: "AppRolePermission",
                column: "ParentPermissionId");

            migrationBuilder.CreateIndex(
                name: "IX_AppUserRole_AppRoleId",
                table: "AppUserRole",
                column: "AppRoleId");

            migrationBuilder.CreateIndex(
                name: "IX_AppUserRole_AppUserId",
                table: "AppUserRole",
                column: "AppUserId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AppRolePermission");

            migrationBuilder.DropTable(
                name: "AppUserRole");

            migrationBuilder.DropTable(
                name: "AppRoleAuthority");

            migrationBuilder.DropColumn(
                name: "AppPermissionId",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "AppRoleId",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "isActive",
                table: "AspNetRoles");
        }
    }
}
