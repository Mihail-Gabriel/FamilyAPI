using Microsoft.EntityFrameworkCore.Migrations;

namespace FamilyAPI.Migrations
{
    public partial class InitialCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Jobs",
                columns: table => new
                {
                    JobTitle = table.Column<string>(type: "TEXT", nullable: false),
                    Salary = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Jobs", x => new { x.Salary, x.JobTitle });
                });

            migrationBuilder.CreateTable(
                name: "Persons",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    FirstName = table.Column<string>(type: "TEXT", nullable: false),
                    LastName = table.Column<string>(type: "TEXT", nullable: false),
                    HairColor = table.Column<string>(type: "TEXT", nullable: false),
                    EyeColor = table.Column<string>(type: "TEXT", nullable: false),
                    Age = table.Column<int>(type: "INTEGER", nullable: false),
                    Weight = table.Column<float>(type: "REAL", nullable: false),
                    Height = table.Column<int>(type: "INTEGER", nullable: false),
                    Sex = table.Column<string>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Persons", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Adults",
                columns: table => new
                {
                    PersonaId = table.Column<int>(type: "INTEGER", nullable: true),
                    AdultJobSalary = table.Column<int>(type: "INTEGER", nullable: true),
                    AdultJobJobTitle = table.Column<string>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.ForeignKey(
                        name: "FK_Adults_Jobs_AdultJobSalary_AdultJobJobTitle",
                        columns: x => new { x.AdultJobSalary, x.AdultJobJobTitle },
                        principalTable: "Jobs",
                        principalColumns: new[] { "Salary", "JobTitle" },
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Adults_Persons_PersonaId",
                        column: x => x.PersonaId,
                        principalTable: "Persons",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Adults_AdultJobSalary_AdultJobJobTitle",
                table: "Adults",
                columns: new[] { "AdultJobSalary", "AdultJobJobTitle" });

            migrationBuilder.CreateIndex(
                name: "IX_Adults_PersonaId",
                table: "Adults",
                column: "PersonaId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Adults");

            migrationBuilder.DropTable(
                name: "Jobs");

            migrationBuilder.DropTable(
                name: "Persons");
        }
    }
}
