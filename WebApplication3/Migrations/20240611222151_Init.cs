using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WebApplication3.Migrations
{
    /// <inheritdoc />
    public partial class Init : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "doctor",
                columns: table => new
                {
                    IdDoctor = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FirstName = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    LastName = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_doctor", x => x.IdDoctor);
                });

            migrationBuilder.CreateTable(
                name: "medicament",
                columns: table => new
                {
                    IdMedicament = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Description = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Type = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_medicament", x => x.IdMedicament);
                });

            migrationBuilder.CreateTable(
                name: "prescriptions",
                columns: table => new
                {
                    IdPrescription = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Date = table.Column<string>(type: "nvarchar(max)", rowVersion: true, nullable: false),
                    DueDate = table.Column<string>(type: "nvarchar(max)", rowVersion: true, nullable: false),
                    IdPatient = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    IdDoctor = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DoctorIdDoctor = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_prescriptions", x => x.IdPrescription);
                    table.ForeignKey(
                        name: "FK_prescriptions_doctor_DoctorIdDoctor",
                        column: x => x.DoctorIdDoctor,
                        principalTable: "doctor",
                        principalColumn: "IdDoctor");
                });

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

            migrationBuilder.CreateIndex(
                name: "IX_prescriptions_DoctorIdDoctor",
                table: "prescriptions",
                column: "DoctorIdDoctor");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "MedicamentPrescription");

            migrationBuilder.DropTable(
                name: "medicament");

            migrationBuilder.DropTable(
                name: "prescriptions");

            migrationBuilder.DropTable(
                name: "doctor");
        }
    }
}
