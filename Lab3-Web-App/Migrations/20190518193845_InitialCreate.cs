using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Lab3_Web_App.Migrations
{
    public partial class InitialCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            //migrationBuilder.CreateTable(
            //    name: "Movies",
            //    columns: table => new
            //    {
            //        Id = table.Column<int>(nullable: false)
            //            .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
            //        Title = table.Column<string>(nullable: true),
            //        Duration = table.Column<int>(nullable: false),
            //        Description = table.Column<string>(nullable: true),
            //        Genre = table.Column<string>(nullable: true),
            //        YearOfRelease = table.Column<int>(nullable: false),
            //        Director = table.Column<string>(nullable: true),
            //        DateAdded = table.Column<DateTime>(nullable: false),
            //        Rating = table.Column<int>(nullable: false),
            //        Watched = table.Column<bool>(nullable: false)
            //    },
            //    constraints: table =>
            //    {
            //        table.PrimaryKey("PK_Movies", x => x.Id);
            //    });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Movies");
        }
    }
}
