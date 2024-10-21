using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Cqrs.Migrations
{
    public partial class initialcreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Students",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Name = table.Column<string>(type: "TEXT", nullable: false),
                    Age = table.Column<int>(type: "INTEGER", nullable: false),
                    Number = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Students", x => x.Id);
                });

            migrationBuilder.InsertData(
                table: "Students",
                columns: new[] { "Id", "Age", "Name", "Number" },
                values: new object[] { 1, 25, "Ferhat", 1 });

            migrationBuilder.InsertData(
                table: "Students",
                columns: new[] { "Id", "Age", "Name", "Number" },
                values: new object[] { 2, 25, "Betül", 2 });

            migrationBuilder.InsertData(
                table: "Students",
                columns: new[] { "Id", "Age", "Name", "Number" },
                values: new object[] { 3, 31, "Osman", 3 });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Students");
        }
    }
}
