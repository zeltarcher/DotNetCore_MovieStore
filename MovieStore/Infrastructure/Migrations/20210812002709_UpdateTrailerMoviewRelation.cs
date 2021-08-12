using Microsoft.EntityFrameworkCore.Migrations;

namespace Infrastructure.Migrations
{
    public partial class UpdateTrailerMoviewRelation : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "MovieTrailer");

            migrationBuilder.CreateIndex(
                name: "IX_Trailer_MovieId",
                table: "Trailer",
                column: "MovieId");

            migrationBuilder.AddForeignKey(
                name: "FK_Trailer_Movie_MovieId",
                table: "Trailer",
                column: "MovieId",
                principalTable: "Movie",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Trailer_Movie_MovieId",
                table: "Trailer");

            migrationBuilder.DropIndex(
                name: "IX_Trailer_MovieId",
                table: "Trailer");

            migrationBuilder.CreateTable(
                name: "MovieTrailer",
                columns: table => new
                {
                    MovieId = table.Column<int>(type: "int", nullable: false),
                    TrailersId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MovieTrailer", x => new { x.MovieId, x.TrailersId });
                    table.ForeignKey(
                        name: "FK_MovieTrailer_Movie_MovieId",
                        column: x => x.MovieId,
                        principalTable: "Movie",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_MovieTrailer_Trailer_TrailersId",
                        column: x => x.TrailersId,
                        principalTable: "Trailer",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_MovieTrailer_TrailersId",
                table: "MovieTrailer",
                column: "TrailersId");
        }
    }
}
