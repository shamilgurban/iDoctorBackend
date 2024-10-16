using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace iDoctor.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class added_specialty_table_and_updated_doctor_table : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "ClinicAddress",
                table: "Doctors",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ClinicName",
                table: "Doctors",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "SpecialtyId",
                table: "Doctors",
                type: "int",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "Specialties",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Specialties", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Doctors_SpecialtyId",
                table: "Doctors",
                column: "SpecialtyId");

            migrationBuilder.AddForeignKey(
                name: "FK_Doctors_Specialties_SpecialtyId",
                table: "Doctors",
                column: "SpecialtyId",
                principalTable: "Specialties",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Doctors_Specialties_SpecialtyId",
                table: "Doctors");

            migrationBuilder.DropTable(
                name: "Specialties");

            migrationBuilder.DropIndex(
                name: "IX_Doctors_SpecialtyId",
                table: "Doctors");

            migrationBuilder.DropColumn(
                name: "ClinicAddress",
                table: "Doctors");

            migrationBuilder.DropColumn(
                name: "ClinicName",
                table: "Doctors");

            migrationBuilder.DropColumn(
                name: "SpecialtyId",
                table: "Doctors");
        }
    }
}
