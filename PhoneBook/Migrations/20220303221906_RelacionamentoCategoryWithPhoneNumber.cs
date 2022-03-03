using Microsoft.EntityFrameworkCore.Migrations;

namespace PhoneBook.Migrations
{
    public partial class RelacionamentoCategoryWithPhoneNumber : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_PhoneNumber_Contact",
                table: "PhoneNumber");

            migrationBuilder.AddColumn<int>(
                name: "CategoriesId",
                table: "PhoneNumber",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_PhoneNumber_CategoriesId",
                table: "PhoneNumber",
                column: "CategoriesId");

            migrationBuilder.AddForeignKey(
                name: "FK_PhoneNumber_Contact",
                table: "PhoneNumber",
                column: "ContactsId",
                principalTable: "Contact",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "Fk_PhoneNumner_Contact",
                table: "PhoneNumber",
                column: "CategoriesId",
                principalTable: "Category",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_PhoneNumber_Contact",
                table: "PhoneNumber");

            migrationBuilder.DropForeignKey(
                name: "Fk_PhoneNumner_Contact",
                table: "PhoneNumber");

            migrationBuilder.DropIndex(
                name: "IX_PhoneNumber_CategoriesId",
                table: "PhoneNumber");

            migrationBuilder.DropColumn(
                name: "CategoriesId",
                table: "PhoneNumber");

            migrationBuilder.AddForeignKey(
                name: "FK_PhoneNumber_Contact",
                table: "PhoneNumber",
                column: "ContactsId",
                principalTable: "Contact",
                principalColumn: "Id",
                onDelete: ReferentialAction.SetNull);
        }
    }
}
