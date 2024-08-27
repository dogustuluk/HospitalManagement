using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace HospitalManagement.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class mig_9 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "BedNumber",
                table: "Beds",
                newName: "RoomBedNumber");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "RoomBedNumber",
                table: "Beds",
                newName: "BedNumber");
        }
    }
}
