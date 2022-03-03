using Microsoft.EntityFrameworkCore.Migrations;

namespace PhoneBook.Migrations
{
    public partial class RelacionamentoCategoryWithPhoneNumbernew : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "Fk_PhoneNumner_Contact",
                table: "PhoneNumber");

            migrationBuilder.AddForeignKey(
                name: "Fk_PhoneNumber_Category",
                table: "PhoneNumber",
                column: "CategoriesId",
                principalTable: "Category",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "Fk_PhoneNumber_Category",
                table: "PhoneNumber");

            migrationBuilder.AddForeignKey(
                name: "Fk_PhoneNumner_Contact",
                table: "PhoneNumber",
                column: "CategoriesId",
                principalTable: "Category",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
