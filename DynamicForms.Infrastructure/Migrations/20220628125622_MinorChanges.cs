using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DynamicForms.Infrastructure.Migrations
{
    public partial class MinorChanges : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Answers_AnswerOptions_AnswerOptionId",
                table: "Answers");

            migrationBuilder.DropForeignKey(
                name: "FK_Answers_supportRequests_SupportRequestId",
                table: "Answers");

            migrationBuilder.DropForeignKey(
                name: "FK_supportRequests_SupportTypes_SupportTypeId",
                table: "supportRequests");

            migrationBuilder.DropPrimaryKey(
                name: "PK_supportRequests",
                table: "supportRequests");

            migrationBuilder.DropColumn(
                name: "OptionSelected",
                table: "Answers");

            migrationBuilder.RenameTable(
                name: "supportRequests",
                newName: "SupportRequests");

            migrationBuilder.RenameIndex(
                name: "IX_supportRequests_SupportTypeId",
                table: "SupportRequests",
                newName: "IX_SupportRequests_SupportTypeId");

            migrationBuilder.RenameColumn(
                name: "AnswerOptionId",
                table: "Answers",
                newName: "AnswerOptionSelectedId");

            migrationBuilder.RenameIndex(
                name: "IX_Answers_AnswerOptionId",
                table: "Answers",
                newName: "IX_Answers_AnswerOptionSelectedId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_SupportRequests",
                table: "SupportRequests",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Answers_AnswerOptions_AnswerOptionSelectedId",
                table: "Answers",
                column: "AnswerOptionSelectedId",
                principalTable: "AnswerOptions",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Answers_SupportRequests_SupportRequestId",
                table: "Answers",
                column: "SupportRequestId",
                principalTable: "SupportRequests",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_SupportRequests_SupportTypes_SupportTypeId",
                table: "SupportRequests",
                column: "SupportTypeId",
                principalTable: "SupportTypes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Answers_AnswerOptions_AnswerOptionSelectedId",
                table: "Answers");

            migrationBuilder.DropForeignKey(
                name: "FK_Answers_SupportRequests_SupportRequestId",
                table: "Answers");

            migrationBuilder.DropForeignKey(
                name: "FK_SupportRequests_SupportTypes_SupportTypeId",
                table: "SupportRequests");

            migrationBuilder.DropPrimaryKey(
                name: "PK_SupportRequests",
                table: "SupportRequests");

            migrationBuilder.RenameTable(
                name: "SupportRequests",
                newName: "supportRequests");

            migrationBuilder.RenameIndex(
                name: "IX_SupportRequests_SupportTypeId",
                table: "supportRequests",
                newName: "IX_supportRequests_SupportTypeId");

            migrationBuilder.RenameColumn(
                name: "AnswerOptionSelectedId",
                table: "Answers",
                newName: "AnswerOptionId");

            migrationBuilder.RenameIndex(
                name: "IX_Answers_AnswerOptionSelectedId",
                table: "Answers",
                newName: "IX_Answers_AnswerOptionId");

            migrationBuilder.AddColumn<bool>(
                name: "OptionSelected",
                table: "Answers",
                type: "bit",
                nullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_supportRequests",
                table: "supportRequests",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Answers_AnswerOptions_AnswerOptionId",
                table: "Answers",
                column: "AnswerOptionId",
                principalTable: "AnswerOptions",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Answers_supportRequests_SupportRequestId",
                table: "Answers",
                column: "SupportRequestId",
                principalTable: "supportRequests",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_supportRequests_SupportTypes_SupportTypeId",
                table: "supportRequests",
                column: "SupportTypeId",
                principalTable: "SupportTypes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
