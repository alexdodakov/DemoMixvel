using DemoMixvel.Database.Seeder;
using Microsoft.EntityFrameworkCore.Migrations;

namespace DemoMixvel.Database.Migrations;
public partial class InitialCreate : Migration
{
    protected override void Up(MigrationBuilder migrationBuilder)
    {
        migrationBuilder.CreateTable(
            name: "Routes",
            columns: table => new
            {
                Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                Origin = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
                Destination = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
                OriginDateTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                DestinationDateTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                Price = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                TimeLimit = table.Column<DateTime>(type: "datetime2", nullable: false)
            },
            constraints: table =>
            {
                table.PrimaryKey("PK_Routes", x => x.Id);
                table.CheckConstraint("CK_Route_Dates", "[OriginDateTime] < [DestinationDateTime]");
                table.CheckConstraint("CK_Route_Price", "[Price] >= 0");
            });

        migrationBuilder.CreateIndex(
            name: "IX_Routes_Origin_Destination_OriginDateTime",
            table: "Routes",
            columns: new[] { "Origin", "Destination", "OriginDateTime" });

        for (int i = 0; i < RouteSeedData.Routes.GetLength(0); i++)
        {
            migrationBuilder.InsertData(
                table: "Routes",
                columns: new[] {
                        "Id", "Origin", "Destination",
                        "OriginDateTime", "DestinationDateTime",
                        "Price", "TimeLimit"
                },
                values: new object[] {
                        RouteSeedData.Routes[i, 0],
                        RouteSeedData.Routes[i, 1],
                        RouteSeedData.Routes[i, 2],
                        RouteSeedData.Routes[i, 3],
                        RouteSeedData.Routes[i, 4],
                        RouteSeedData.Routes[i, 5],
                        RouteSeedData.Routes[i, 6]
                }
            );
        }
    }

    protected override void Down(MigrationBuilder migrationBuilder)
    {
        migrationBuilder.DropTable(
            name: "Routes");
    }
}
