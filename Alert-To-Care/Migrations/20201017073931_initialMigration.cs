using Microsoft.EntityFrameworkCore.Migrations;

namespace Alert_To_Care.Migrations
{
    public partial class initialMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Beds",
                columns: table => new
                {
                    BedId = table.Column<string>(nullable: false),
                    BedStatus = table.Column<bool>(nullable: false),
                    PatientId = table.Column<string>(nullable: true),
                    IcuId = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Beds", x => x.BedId);
                });

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
                name: "Patients",
                columns: table => new
                {
                    PatientId = table.Column<string>(nullable: false),
                    BedId = table.Column<string>(nullable: true),
                    PatientName = table.Column<string>(nullable: true),
                    PatientAge = table.Column<int>(nullable: false),
                    Email = table.Column<string>(nullable: true),
                    ContactNo = table.Column<int>(maxLength: 10, nullable: false),
                    Address = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Patients", x => x.PatientId);
                });

            migrationBuilder.CreateTable(
                name: "Vitals",
                columns: table => new
                {
                    PatientId = table.Column<string>(nullable: false),
                    PatientBedId = table.Column<string>(nullable: true),
                    Bpm = table.Column<float>(nullable: false),
                    Spo2 = table.Column<float>(nullable: false),
                    RespRate = table.Column<float>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Vitals", x => x.PatientId);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Beds");

            migrationBuilder.DropTable(
                name: "Icu");

            migrationBuilder.DropTable(
                name: "Patients");

            migrationBuilder.DropTable(
                name: "Vitals");
        }
    }
}
