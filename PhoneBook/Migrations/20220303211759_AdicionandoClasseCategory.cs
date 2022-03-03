using Microsoft.EntityFrameworkCore.Migrations;

namespace PhoneBook.Migrations
{
    public partial class AdicionandoClasseCategory : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Category",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "NVARCHAR(80)", maxLength: 80, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Category", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ContactCategory",
                columns: table => new
                {
                    FK_ContactCategory_CategoryId = table.Column<int>(type: "int", nullable: false),
                    FK_ContactCategory_ContactId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ContactCategory", x => new { x.FK_ContactCategory_CategoryId, x.FK_ContactCategory_ContactId });
                    table.ForeignKey(
                        name: "CategoryId",
                        column: x => x.FK_ContactCategory_CategoryId,
                        principalTable: "Category",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "ContactId",
                        column: x => x.FK_ContactCategory_ContactId,
                        principalTable: "Contact",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Category_Name",
                table: "Category",
                column: "Name",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_ContactCategory_FK_ContactCategory_ContactId",
                table: "ContactCategory",
                column: "FK_ContactCategory_ContactId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ContactCategory");

            migrationBuilder.DropTable(
                name: "Category");
        }
    }
}
