using Microsoft.EntityFrameworkCore.Migrations;

namespace SnapshotsData.Migrations
{
    public partial class PopulateCampusTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql("INSERT INTO Campus (Name, Address, PhoneNumber) VALUES ('Boca Raton', '777 Glades Road, Boca Raton, FL 33431', '561.297.3000')");
            migrationBuilder.Sql("INSERT INTO Campus (Name, Address, PhoneNumber) VALUES ('Dania Beach', '101 North Beach Road, Dania Beach, FL 33004', '954.924.7000')");
            migrationBuilder.Sql("INSERT INTO Campus (Name, Address, PhoneNumber) VALUES ('Davie', '3200 College Avenue, Davie, FL 33314', '954.236.1000')");
            migrationBuilder.Sql("INSERT INTO Campus (Name, Address, PhoneNumber) VALUES ('Fort Lauderdale', '111 East Las Olas Blvd., Fort Lauderdale, FL 33301', '954.236.1000')");
            migrationBuilder.Sql("INSERT INTO Campus (Name, Address, PhoneNumber) VALUES ('Harbor Branch', '5600 US 1 North, Fort Pierce, FL 34946', '772.242.2400')");
            migrationBuilder.Sql("INSERT INTO Campus (Name, Address, PhoneNumber) VALUES ('Jupiter', '5353 Parkside Drive, Jupiter, FL 33458', '561.799.8500')");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {

        }
    }
}
