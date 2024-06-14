using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace HospitalManagement.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class mig_5 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AnyParams_Doctors_DoctorId1",
                table: "AnyParams");

            migrationBuilder.DropForeignKey(
                name: "FK_AnyParams_Doctors_DoctorId2",
                table: "AnyParams");

            migrationBuilder.DropIndex(
                name: "IX_AnyParams_DoctorId1",
                table: "AnyParams");

            migrationBuilder.DropIndex(
                name: "IX_AnyParams_DoctorId2",
                table: "AnyParams");

            migrationBuilder.DropColumn(
                name: "DoctorId1",
                table: "AnyParams");

            migrationBuilder.RenameColumn(
                name: "PresctiptionId",
                table: "TreatmentPlans",
                newName: "PrescriptionId");

            migrationBuilder.RenameColumn(
                name: "DoctorId2",
                table: "AnyParams",
                newName: "ParamType");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "PrescriptionId",
                table: "TreatmentPlans",
                newName: "PresctiptionId");

            migrationBuilder.RenameColumn(
                name: "ParamType",
                table: "AnyParams",
                newName: "DoctorId2");

            migrationBuilder.AddColumn<int>(
                name: "DoctorId1",
                table: "AnyParams",
                type: "integer",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_AnyParams_DoctorId1",
                table: "AnyParams",
                column: "DoctorId1");

            migrationBuilder.CreateIndex(
                name: "IX_AnyParams_DoctorId2",
                table: "AnyParams",
                column: "DoctorId2");

            migrationBuilder.AddForeignKey(
                name: "FK_AnyParams_Doctors_DoctorId1",
                table: "AnyParams",
                column: "DoctorId1",
                principalTable: "Doctors",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_AnyParams_Doctors_DoctorId2",
                table: "AnyParams",
                column: "DoctorId2",
                principalTable: "Doctors",
                principalColumn: "Id");
        }
    }
}
