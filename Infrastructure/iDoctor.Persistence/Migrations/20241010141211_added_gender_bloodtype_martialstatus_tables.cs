using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace iDoctor.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class added_gender_bloodtype_martialstatus_tables : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "BloodTypeId",
                table: "Patients",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "GenderId",
                table: "Patients",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "MartialStatusId",
                table: "Patients",
                type: "int",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "BloodTypes",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Type = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BloodTypes", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Genders",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Genders", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "MartialStatuses",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Status = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MartialStatuses", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Patients_BloodTypeId",
                table: "Patients",
                column: "BloodTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_Patients_GenderId",
                table: "Patients",
                column: "GenderId");

            migrationBuilder.CreateIndex(
                name: "IX_Patients_MartialStatusId",
                table: "Patients",
                column: "MartialStatusId");

            migrationBuilder.AddForeignKey(
                name: "FK_Patients_BloodTypes_BloodTypeId",
                table: "Patients",
                column: "BloodTypeId",
                principalTable: "BloodTypes",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Patients_Genders_GenderId",
                table: "Patients",
                column: "GenderId",
                principalTable: "Genders",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Patients_MartialStatuses_MartialStatusId",
                table: "Patients",
                column: "MartialStatusId",
                principalTable: "MartialStatuses",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Patients_BloodTypes_BloodTypeId",
                table: "Patients");

            migrationBuilder.DropForeignKey(
                name: "FK_Patients_Genders_GenderId",
                table: "Patients");

            migrationBuilder.DropForeignKey(
                name: "FK_Patients_MartialStatuses_MartialStatusId",
                table: "Patients");

            migrationBuilder.DropTable(
                name: "BloodTypes");

            migrationBuilder.DropTable(
                name: "Genders");

            migrationBuilder.DropTable(
                name: "MartialStatuses");

            migrationBuilder.DropIndex(
                name: "IX_Patients_BloodTypeId",
                table: "Patients");

            migrationBuilder.DropIndex(
                name: "IX_Patients_GenderId",
                table: "Patients");

            migrationBuilder.DropIndex(
                name: "IX_Patients_MartialStatusId",
                table: "Patients");

            migrationBuilder.DropColumn(
                name: "BloodTypeId",
                table: "Patients");

            migrationBuilder.DropColumn(
                name: "GenderId",
                table: "Patients");

            migrationBuilder.DropColumn(
                name: "MartialStatusId",
                table: "Patients");
        }
    }
}
