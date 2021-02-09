using Microsoft.EntityFrameworkCore.Migrations;

namespace MVCMovieApp.Migrations
{
    public partial class newlicc : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "LicenceDetailsId",
                table: "Movie",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "LicenceDetails",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    LicencyName = table.Column<string>(nullable: true),
                    Address1 = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LicenceDetails", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Movie_LicenceDetailsId",
                table: "Movie",
                column: "LicenceDetailsId");

            migrationBuilder.AddForeignKey(
                name: "FK_Movie_LicenceDetails_LicenceDetailsId",
                table: "Movie",
                column: "LicenceDetailsId",
                principalTable: "LicenceDetails",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Movie_LicenceDetails_LicenceDetailsId",
                table: "Movie");

            migrationBuilder.DropTable(
                name: "LicenceDetails");

            migrationBuilder.DropIndex(
                name: "IX_Movie_LicenceDetailsId",
                table: "Movie");

            migrationBuilder.DropColumn(
                name: "LicenceDetailsId",
                table: "Movie");
        }
    }
}
