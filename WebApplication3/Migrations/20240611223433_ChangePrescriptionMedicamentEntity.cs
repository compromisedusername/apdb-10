using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WebApplication3.Migrations
{
    /// <inheritdoc />
    public partial class ChangePrescriptionMedicamentEntity : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "MedicamentPrescription");

            migrationBuilder.CreateTable(
                name: "prescription_medicament",
                columns: table => new
                {
                    IdMedicament = table.Column<int>(type: "int", nullable: false),
                    IdPrescription = table.Column<int>(type: "int", nullable: false),
                    Dose = table.Column<int>(type: "int", nullable: true),
                    Details = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_prescription_medicament", x => new { x.IdMedicament, x.IdPrescription });
                    table.ForeignKey(
                        name: "FK_prescription_medicament_medicament_IdMedicament",
                        column: x => x.IdMedicament,
                        principalTable: "medicament",
                        principalColumn: "IdMedicament",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_prescription_medicament_prescriptions_IdPrescription",
                        column: x => x.IdPrescription,
                        principalTable: "prescriptions",
                        principalColumn: "IdPrescription",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_prescription_medicament_IdPrescription",
                table: "prescription_medicament",
                column: "IdPrescription");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "prescription_medicament");

            migrationBuilder.CreateTable(
                name: "MedicamentPrescription",
                columns: table => new
                {
                    MedicamentsIdMedicament = table.Column<int>(type: "int", nullable: false),
                    PrescriptionsIdPrescription = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MedicamentPrescription", x => new { x.MedicamentsIdMedicament, x.PrescriptionsIdPrescription });
                    table.ForeignKey(
                        name: "FK_MedicamentPrescription_medicament_MedicamentsIdMedicament",
                        column: x => x.MedicamentsIdMedicament,
                        principalTable: "medicament",
                        principalColumn: "IdMedicament",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_MedicamentPrescription_prescriptions_PrescriptionsIdPrescription",
                        column: x => x.PrescriptionsIdPrescription,
                        principalTable: "prescriptions",
                        principalColumn: "IdPrescription",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_MedicamentPrescription_PrescriptionsIdPrescription",
                table: "MedicamentPrescription",
                column: "PrescriptionsIdPrescription");
        }
    }
}
