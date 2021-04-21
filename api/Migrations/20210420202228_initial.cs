using Microsoft.EntityFrameworkCore.Migrations;

namespace api.Migrations
{
    public partial class initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Boat",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Speed = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Boat", x => x.Id);
                });

            migrationBuilder.InsertData(
                table: "Boat",
                columns: new[] { "Id", "Name", "Speed" },
                values: new object[] { 1, "Speedboat", "30" });

            migrationBuilder.InsertData(
                table: "Boat",
                columns: new[] { "Id", "Name", "Speed" },
                values: new object[] { 2, "Sailboat", "15" });

            migrationBuilder.InsertData(
                table: "Boat",
                columns: new[] { "Id", "Name", "Speed" },
                values: new object[] { 3, "Cargo ship", "5" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Boat");
        }
    }
}
