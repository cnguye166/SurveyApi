using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Survey.Migrations
{
    public partial class DatabaseCreation : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Surveys",
                columns: table => new
                {
                    SurveyId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Title = table.Column<string>(type: "nvarchar(60)", maxLength: 60, nullable: false),
                    Topic = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Surveys", x => x.SurveyId);
                });

            migrationBuilder.CreateTable(
                name: "Questions",
                columns: table => new
                {
                    QuestionId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Title = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    OptionalImage = table.Column<byte[]>(type: "varbinary(max)", nullable: true),
                    SurveyId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Questions", x => x.QuestionId);
                    table.ForeignKey(
                        name: "FK_Questions_Surveys_SurveyId",
                        column: x => x.SurveyId,
                        principalTable: "Surveys",
                        principalColumn: "SurveyId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Choices",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Title = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    QuestionId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Choices", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Choices_Questions_QuestionId",
                        column: x => x.QuestionId,
                        principalTable: "Questions",
                        principalColumn: "QuestionId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Surveys",
                columns: new[] { "SurveyId", "Title", "Topic" },
                values: new object[] { new Guid("3d490a70-94ce-4d15-9494-5248280c2ce3"), "COSC 3212: Survey for Exam 1", "Education" });

            migrationBuilder.InsertData(
                table: "Surveys",
                columns: new[] { "SurveyId", "Title", "Topic" },
                values: new object[] { new Guid("c9d4c053-49b6-410c-bc78-2d54a9991870"), "Top Fast Food in the United States", "Health Science" });

            migrationBuilder.InsertData(
                table: "Questions",
                columns: new[] { "QuestionId", "OptionalImage", "SurveyId", "Title" },
                values: new object[] { new Guid("021ca3c1-0deb-4afd-ae94-2159a8479811"), null, new Guid("3d490a70-94ce-4d15-9494-5248280c2ce3"), "How confident are you on binary trees?" });

            migrationBuilder.InsertData(
                table: "Questions",
                columns: new[] { "QuestionId", "OptionalImage", "SurveyId", "Title" },
                values: new object[] { new Guid("80abbca8-664d-4b20-b5de-024705497d4a"), null, new Guid("c9d4c053-49b6-410c-bc78-2d54a9991870"), "How would you rate McDonalds? (1-5)" });

            migrationBuilder.InsertData(
                table: "Questions",
                columns: new[] { "QuestionId", "OptionalImage", "SurveyId", "Title" },
                values: new object[] { new Guid("86dba8c0-d178-41e7-938c-ed49778fb52a"), null, new Guid("c9d4c053-49b6-410c-bc78-2d54a9991870"), "Out of these fast food, which have you visited the most?" });

            migrationBuilder.InsertData(
                table: "Choices",
                columns: new[] { "Id", "QuestionId", "Title" },
                values: new object[,]
                {
                    { 1, new Guid("80abbca8-664d-4b20-b5de-024705497d4a"), "0" },
                    { 2, new Guid("80abbca8-664d-4b20-b5de-024705497d4a"), "1" },
                    { 3, new Guid("80abbca8-664d-4b20-b5de-024705497d4a"), "2" },
                    { 4, new Guid("80abbca8-664d-4b20-b5de-024705497d4a"), "3" },
                    { 5, new Guid("80abbca8-664d-4b20-b5de-024705497d4a"), "4" },
                    { 6, new Guid("80abbca8-664d-4b20-b5de-024705497d4a"), "5" },
                    { 7, new Guid("86dba8c0-d178-41e7-938c-ed49778fb52a"), "Taco Bell" },
                    { 8, new Guid("86dba8c0-d178-41e7-938c-ed49778fb52a"), "McDonald's" },
                    { 9, new Guid("86dba8c0-d178-41e7-938c-ed49778fb52a"), "Burger King" },
                    { 10, new Guid("86dba8c0-d178-41e7-938c-ed49778fb52a"), "Sonic" },
                    { 11, new Guid("021ca3c1-0deb-4afd-ae94-2159a8479811"), "Not very confident" },
                    { 12, new Guid("021ca3c1-0deb-4afd-ae94-2159a8479811"), "Somewhat confident" },
                    { 13, new Guid("021ca3c1-0deb-4afd-ae94-2159a8479811"), "Very confident" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Choices_QuestionId",
                table: "Choices",
                column: "QuestionId");

            migrationBuilder.CreateIndex(
                name: "IX_Questions_SurveyId",
                table: "Questions",
                column: "SurveyId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Choices");

            migrationBuilder.DropTable(
                name: "Questions");

            migrationBuilder.DropTable(
                name: "Surveys");
        }
    }
}
