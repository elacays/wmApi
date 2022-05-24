using Microsoft.EntityFrameworkCore.Migrations;

namespace WordApi.Migrations
{
    public partial class initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "WordDefinitions",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    WordDef = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    LngId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_WordDefinitions", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "WordMeanings",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Meaning = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    LngId = table.Column<int>(type: "int", nullable: false),
                    WordDefinitionId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_WordMeanings", x => x.Id);
                    table.ForeignKey(
                        name: "FK_WordMeanings_WordDefinitions_WordDefinitionId",
                        column: x => x.WordDefinitionId,
                        principalTable: "WordDefinitions",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_WordMeanings_WordDefinitionId",
                table: "WordMeanings",
                column: "WordDefinitionId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "WordMeanings");

            migrationBuilder.DropTable(
                name: "WordDefinitions");
        }
    }
}
