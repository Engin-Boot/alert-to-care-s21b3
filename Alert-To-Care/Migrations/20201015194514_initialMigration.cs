using Microsoft.EntityFrameworkCore.Migrations;

namespace Alert_To_Care.Migrations
{
    public partial class initialMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Icu",
                columns: table => new
                {
                    IcuId = table.Column<string>(nullable: false),
                    TotalNoOfBeds = table.Column<int>(nullable: false),
                    Layout = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Icu", x => x.IcuId);
                });

            migrationBuilder.CreateTable(
                name: "VitalsDataModel",
                columns: table => new
                {
                    PatientId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PatientBedId = table.Column<int>(nullable: false),
                    Bpm = table.Column<float>(nullable: false),
                    Spo2 = table.Column<float>(nullable: false),
                    RespRate = table.Column<float>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_VitalsDataModel", x => x.PatientId);
                });

            migrationBuilder.CreateTable(
                name: "Beds",
                columns: table => new
                {
                    BedId = table.Column<string>(nullable: false),
                    BedStatus = table.Column<bool>(nullable: false),
                    PatientId = table.Column<int>(nullable: false),
                    IcuId = table.Column<string>(nullable: true),
                    IcuDataModelIcuId = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Beds", x => x.BedId);
                    table.ForeignKey(
                        name: "FK_Beds_Icu_IcuDataModelIcuId",
                        column: x => x.IcuDataModelIcuId,
                        principalTable: "Icu",
                        principalColumn: "IcuId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Patients",
                columns: table => new
                {
                    PatientId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    BedId = table.Column<int>(nullable: false),
                    PatientName = table.Column<string>(nullable: true),
                    PatientAge = table.Column<int>(nullable: false),
                    Email = table.Column<string>(nullable: true),
                    ContactNo = table.Column<int>(nullable: false),
                    Address = table.Column<string>(nullable: true),
                    vitalsPatientId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Patients", x => x.PatientId);
                    table.ForeignKey(
                        name: "FK_Patients_VitalsDataModel_vitalsPatientId",
                        column: x => x.vitalsPatientId,
                        principalTable: "VitalsDataModel",
                        principalColumn: "PatientId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Beds_IcuDataModelIcuId",
                table: "Beds",
                column: "IcuDataModelIcuId");

            migrationBuilder.CreateIndex(
                name: "IX_Patients_vitalsPatientId",
                table: "Patients",
                column: "vitalsPatientId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Beds");

            migrationBuilder.DropTable(
                name: "Patients");

            migrationBuilder.DropTable(
                name: "Icu");

            migrationBuilder.DropTable(
                name: "VitalsDataModel");
        }
    }
}
