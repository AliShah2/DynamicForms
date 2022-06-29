using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DynamicForms.Infrastructure.Migrations
{
    public partial class AddedSupportProvision : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Answers_SupportProvision_SupportProvisionId",
                table: "Answers");

            migrationBuilder.DropForeignKey(
                name: "FK_SupportProvision_SupportTypes_SupportTypeId",
                table: "SupportProvision");

            migrationBuilder.DropPrimaryKey(
                name: "PK_SupportProvision",
                table: "SupportProvision");

            migrationBuilder.RenameTable(
                name: "SupportProvision",
                newName: "SupportProvisions");

            migrationBuilder.RenameIndex(
                name: "IX_SupportProvision_SupportTypeId",
                table: "SupportProvisions",
                newName: "IX_SupportProvisions_SupportTypeId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_SupportProvisions",
                table: "SupportProvisions",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Answers_SupportProvisions_SupportProvisionId",
                table: "Answers",
                column: "SupportProvisionId",
                principalTable: "SupportProvisions",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_SupportProvisions_SupportTypes_SupportTypeId",
                table: "SupportProvisions",
                column: "SupportTypeId",
                principalTable: "SupportTypes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Answers_SupportProvisions_SupportProvisionId",
                table: "Answers");

            migrationBuilder.DropForeignKey(
                name: "FK_SupportProvisions_SupportTypes_SupportTypeId",
                table: "SupportProvisions");

            migrationBuilder.DropPrimaryKey(
                name: "PK_SupportProvisions",
                table: "SupportProvisions");

            migrationBuilder.RenameTable(
                name: "SupportProvisions",
                newName: "SupportProvision");

            migrationBuilder.RenameIndex(
                name: "IX_SupportProvisions_SupportTypeId",
                table: "SupportProvision",
                newName: "IX_SupportProvision_SupportTypeId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_SupportProvision",
                table: "SupportProvision",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Answers_SupportProvision_SupportProvisionId",
                table: "Answers",
                column: "SupportProvisionId",
                principalTable: "SupportProvision",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_SupportProvision_SupportTypes_SupportTypeId",
                table: "SupportProvision",
                column: "SupportTypeId",
                principalTable: "SupportTypes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
