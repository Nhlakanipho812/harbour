using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace api.Migrations
{
    public partial class newTable_boatTransactions : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<int>(
                name: "Speed",
                table: "Boat",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.CreateTable(
                name: "BoatTransaction",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ArrivalTimeAtOpenSea = table.Column<TimeSpan>(type: "time", nullable: false),
                    DepartureTimeAtOpenSea = table.Column<TimeSpan>(type: "time", nullable: false),
                    ArrivalTimeAtHarbour = table.Column<TimeSpan>(type: "time", nullable: false),
                    TransactionDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Reference = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BoatTransaction", x => x.Id);
                });

            migrationBuilder.UpdateData(
                table: "Boat",
                keyColumn: "Id",
                keyValue: 1,
                column: "Speed",
                value: 30);

            migrationBuilder.UpdateData(
                table: "Boat",
                keyColumn: "Id",
                keyValue: 2,
                column: "Speed",
                value: 15);

            migrationBuilder.UpdateData(
                table: "Boat",
                keyColumn: "Id",
                keyValue: 3,
                column: "Speed",
                value: 5);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "BoatTransaction");

            migrationBuilder.AlterColumn<string>(
                name: "Speed",
                table: "Boat",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.UpdateData(
                table: "Boat",
                keyColumn: "Id",
                keyValue: 1,
                column: "Speed",
                value: "30");

            migrationBuilder.UpdateData(
                table: "Boat",
                keyColumn: "Id",
                keyValue: 2,
                column: "Speed",
                value: "15");

            migrationBuilder.UpdateData(
                table: "Boat",
                keyColumn: "Id",
                keyValue: 3,
                column: "Speed",
                value: "5");
        }
    }
}
