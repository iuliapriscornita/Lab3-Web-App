using Microsoft.EntityFrameworkCore.Migrations;

namespace Lab3_Web_App.Migrations
{
    public partial class AddCommentsForMovie : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "MovieId",
                table: "Coments",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Coments_MovieId",
                table: "Coments",
                column: "MovieId");

            migrationBuilder.AddForeignKey(
                name: "FK_Coments_Movies_MovieId",
                table: "Coments",
                column: "MovieId",
                principalTable: "Movies",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Coments_Movies_MovieId",
                table: "Coments");

            migrationBuilder.DropIndex(
                name: "IX_Coments_MovieId",
                table: "Coments");

            migrationBuilder.DropColumn(
                name: "MovieId",
                table: "Coments");
        }
    }
}
