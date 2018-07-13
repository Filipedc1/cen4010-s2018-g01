using Microsoft.EntityFrameworkCore.Migrations;

namespace SnapshotsData.Migrations
{
    public partial class PopulateStatusTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql("INSERT INTO Status (Name, Description) VALUES ('Reported', 'Issue has been reported') ");
            migrationBuilder.Sql("INSERT INTO Status (Name, Description) VALUES ('In Process', 'Issue is currently being resolved') ");
            migrationBuilder.Sql("INSERT INTO Status (Name, Description) VALUES ('Resolved', 'Issue has been resolved') ");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {

        }
    }
}
