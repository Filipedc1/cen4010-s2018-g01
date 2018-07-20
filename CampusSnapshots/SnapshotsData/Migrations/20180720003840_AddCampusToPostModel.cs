using Microsoft.EntityFrameworkCore.Migrations;

namespace SnapshotsData.Migrations
{
    public partial class AddCampusToPostModel : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "CampusId",
                table: "Posts",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Posts_CampusId",
                table: "Posts",
                column: "CampusId");

            migrationBuilder.AddForeignKey(
                name: "FK_Posts_Campus_CampusId",
                table: "Posts",
                column: "CampusId",
                principalTable: "Campus",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Posts_Campus_CampusId",
                table: "Posts");

            migrationBuilder.DropIndex(
                name: "IX_Posts_CampusId",
                table: "Posts");

            migrationBuilder.DropColumn(
                name: "CampusId",
                table: "Posts");
        }
    }
}
