using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace HospitalManagement.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class mig_3 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Prescriptions_TreatmentPlans_TreatmentPlanId1",
                table: "Prescriptions");

            migrationBuilder.DropIndex(
                name: "IX_Prescriptions_TreatmentPlanId1",
                table: "Prescriptions");

            migrationBuilder.DropColumn(
                name: "TreatmentPlanId1",
                table: "Prescriptions");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "TreatmentPlanId1",
                table: "Prescriptions",
                type: "integer",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Prescriptions_TreatmentPlanId1",
                table: "Prescriptions",
                column: "TreatmentPlanId1");

            migrationBuilder.AddForeignKey(
                name: "FK_Prescriptions_TreatmentPlans_TreatmentPlanId1",
                table: "Prescriptions",
                column: "TreatmentPlanId1",
                principalTable: "TreatmentPlans",
                principalColumn: "Id");
        }
    }
}
