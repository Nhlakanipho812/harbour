using Microsoft.EntityFrameworkCore.Migrations;

namespace api.Migrations
{
    public partial class referenceCode : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "RecordCode",
                table: "BoatTransaction",
                type: "nvarchar(max)",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "RecordCode",
                table: "BoatTransaction");
        }
    }
}
