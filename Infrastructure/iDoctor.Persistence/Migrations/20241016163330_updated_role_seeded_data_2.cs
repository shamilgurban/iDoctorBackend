using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace iDoctor.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class updated_role_seeded_data_2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Roles",
                columns: new[] { "Id", "Name", "UserType" },
                values: new object[] { 67, "GetPatientById", 3 });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 67);
        }
    }
}
