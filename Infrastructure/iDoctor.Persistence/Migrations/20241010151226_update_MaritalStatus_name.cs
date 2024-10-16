using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace iDoctor.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class update_MaritalStatus_name : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Patients_MartialStatuses_MartialStatusId",
                table: "Patients");

            migrationBuilder.DropTable(
                name: "MartialStatuses");

            migrationBuilder.RenameColumn(
                name: "MartialStatusId",
                table: "Patients",
                newName: "MaritalStatusId");

            migrationBuilder.RenameIndex(
                name: "IX_Patients_MartialStatusId",
                table: "Patients",
                newName: "IX_Patients_MaritalStatusId");

            migrationBuilder.CreateTable(
                name: "MaritalStatuses",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Status = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MaritalStatuses", x => x.Id);
                });

            migrationBuilder.InsertData(
                table: "MaritalStatuses",
                columns: new[] { "Id", "Status" },
                values: new object[,]
                {
                    { 1, "Subay" },
                    { 2, "Evli" }
                });

            migrationBuilder.AddForeignKey(
                name: "FK_Patients_MaritalStatuses_MaritalStatusId",
                table: "Patients",
                column: "MaritalStatusId",
                principalTable: "MaritalStatuses",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Patients_MaritalStatuses_MaritalStatusId",
                table: "Patients");

            migrationBuilder.DropTable(
                name: "MaritalStatuses");

            migrationBuilder.RenameColumn(
                name: "MaritalStatusId",
                table: "Patients",
                newName: "MartialStatusId");

            migrationBuilder.RenameIndex(
                name: "IX_Patients_MaritalStatusId",
                table: "Patients",
                newName: "IX_Patients_MartialStatusId");

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

            migrationBuilder.InsertData(
                table: "MartialStatuses",
                columns: new[] { "Id", "Status" },
                values: new object[,]
                {
                    { 1, "Subay" },
                    { 2, "Evli" }
                });

            migrationBuilder.AddForeignKey(
                name: "FK_Patients_MartialStatuses_MartialStatusId",
                table: "Patients",
                column: "MartialStatusId",
                principalTable: "MartialStatuses",
                principalColumn: "Id");
        }
    }
}
