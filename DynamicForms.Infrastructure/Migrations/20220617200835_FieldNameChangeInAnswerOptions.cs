using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DynamicForms.Infrastructure.Migrations
{
    public partial class FieldNameChangeInAnswerOptions : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AnswerOptions_Questions_QuestionGroupId",
                table: "AnswerOptions");

            migrationBuilder.RenameColumn(
                name: "QuestionGroupId",
                table: "AnswerOptions",
                newName: "QuestionId");

            migrationBuilder.RenameIndex(
                name: "IX_AnswerOptions_QuestionGroupId",
                table: "AnswerOptions",
                newName: "IX_AnswerOptions_QuestionId");

            migrationBuilder.AddForeignKey(
                name: "FK_AnswerOptions_Questions_QuestionId",
                table: "AnswerOptions",
                column: "QuestionId",
                principalTable: "Questions",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AnswerOptions_Questions_QuestionId",
                table: "AnswerOptions");

            migrationBuilder.RenameColumn(
                name: "QuestionId",
                table: "AnswerOptions",
                newName: "QuestionGroupId");

            migrationBuilder.RenameIndex(
                name: "IX_AnswerOptions_QuestionId",
                table: "AnswerOptions",
                newName: "IX_AnswerOptions_QuestionGroupId");

            migrationBuilder.AddForeignKey(
                name: "FK_AnswerOptions_Questions_QuestionGroupId",
                table: "AnswerOptions",
                column: "QuestionGroupId",
                principalTable: "Questions",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
