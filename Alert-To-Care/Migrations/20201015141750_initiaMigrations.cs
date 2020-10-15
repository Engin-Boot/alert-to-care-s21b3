using Microsoft.EntityFrameworkCore.Migrations;

namespace Alert_To_Care.Migrations
{
    public partial class initiaMigrations : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Icu",
                columns: table => new
                {
                    IcuId = table.Column<string>(nullable: false),
                    TotalNoOfBeds = table.Column<int>(nullable: false),
                    NumberOfRows = table.Column<int>(nullable: false),
                    NumberOfColumns = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Icu", x => x.IcuId);
                });

            migrationBuilder.CreateTable(
                name: "Patients",
                columns: table => new
                {
                    PatientId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    BedId = table.Column<int>(nullable: false),
                    PatientName = table.Column<string>(nullable: true),
                    PatientAge = table.Column<string>(nullable: true),
                    Email = table.Column<string>(nullable: true),
                    ContactNo = table.Column<string>(nullable: true),
                    Address = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Patients", x => x.PatientId);
                });

            migrationBuilder.CreateTable(
                name: "Beds",
                columns: table => new
                {
                    BedId = table.Column<string>(nullable: false),
                    BedStatus = table.Column<string>(nullable: true),
                    PatientId = table.Column<int>(nullable: false),
                    IcuId = table.Column<string>(nullable: true),
                    BedRow = table.Column<int>(nullable: false),
                    BedColumn = table.Column<int>(nullable: false),
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

            migrationBuilder.CreateIndex(
                name: "IX_Beds_IcuDataModelIcuId",
                table: "Beds",
                column: "IcuDataModelIcuId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Beds");

            migrationBuilder.DropTable(
                name: "Patients");

            migrationBuilder.DropTable(
                name: "Icu");
        }
    }
}
