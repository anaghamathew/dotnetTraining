using Microsoft.EntityFrameworkCore.Migrations;

namespace RestaurentAppNew.Migrations
{
    public partial class ingredientscheck : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "IngredientsId",
                table: "Food",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "Ingredients",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Recipe = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Ingredients", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Food_IngredientsId",
                table: "Food",
                column: "IngredientsId",
                unique: true,
                filter: "[IngredientsId] IS NOT NULL");

            migrationBuilder.AddForeignKey(
                name: "FK_Food_Ingredients_IngredientsId",
                table: "Food",
                column: "IngredientsId",
                principalTable: "Ingredients",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Food_Ingredients_IngredientsId",
                table: "Food");

            migrationBuilder.DropTable(
                name: "Ingredients");

            migrationBuilder.DropIndex(
                name: "IX_Food_IngredientsId",
                table: "Food");

            migrationBuilder.DropColumn(
                name: "IngredientsId",
                table: "Food");
        }
    }
}
