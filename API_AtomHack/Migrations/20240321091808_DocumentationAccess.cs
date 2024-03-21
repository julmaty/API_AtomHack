using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace API_AtomHack.Migrations
{
    /// <inheritdoc />
    public partial class DocumentationAccess : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Access",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    FileName = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    ColonyId = table.Column<int>(type: "int", nullable: false),
                    SystemId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Access", x => x.Id);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "Documentations",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    FileName = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    ColonyId = table.Column<int>(type: "int", nullable: false),
                    SystemId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Documentations", x => x.Id);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.InsertData(
                table: "Access",
                columns: new[] { "Id", "ColonyId", "FileName", "SystemId" },
                values: new object[,]
                {
                    { 1, 1, "1.docx", 1 },
                    { 2, 1, "1.docx", 2 },
                    { 3, 1, "1.docx", 3 },
                    { 4, 1, "1.docx", 4 },
                    { 5, 2, "1.docx", 3 },
                    { 6, 2, "1.docx", 4 },
                    { 7, 3, "1.docx", 1 },
                    { 8, 3, "1.docx", 2 },
                    { 9, 4, "1.docx", 2 },
                    { 10, 4, "1.docx", 3 }
                });

            migrationBuilder.InsertData(
                table: "Documentations",
                columns: new[] { "Id", "ColonyId", "FileName", "SystemId" },
                values: new object[,]
                {
                    { 1, 1, "1.docx", 1 },
                    { 2, 1, "1.docx", 2 },
                    { 3, 1, "1.docx", 3 },
                    { 4, 1, "1.docx", 4 },
                    { 5, 2, "1.docx", 3 },
                    { 6, 2, "1.docx", 4 },
                    { 7, 3, "1.docx", 1 },
                    { 8, 3, "1.docx", 2 },
                    { 9, 4, "1.docx", 2 },
                    { 10, 4, "1.docx", 3 }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Access");

            migrationBuilder.DropTable(
                name: "Documentations");
        }
    }
}
