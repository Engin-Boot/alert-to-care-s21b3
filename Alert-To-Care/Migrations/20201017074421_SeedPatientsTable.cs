using Microsoft.EntityFrameworkCore.Migrations;

namespace Alert_To_Care.Migrations
{
    public partial class SeedPatientsTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Patients",
                columns: new[] { "PatientId", "Address", "BedId", "ContactNo", "Email", "PatientAge", "PatientName" },
                values: new object[] { "1", "abc street, swe city", "12", 987655398, "123@abc.com", 22, "Sneha" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Patients",
                keyColumn: "PatientId",
                keyValue: "1");
        }
    }
}
