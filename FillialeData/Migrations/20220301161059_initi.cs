using Microsoft.EntityFrameworkCore.Migrations;

namespace FillialeData.Migrations
{
    public partial class initi : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_Filliale_FillialeName",
                table: "Filliale");

            migrationBuilder.AlterColumn<string>(
                name: "FillialeName",
                table: "Filliale",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)",
                oldNullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Filliale_FillialeId",
                table: "Filliale",
                column: "FillialeId",
                unique: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_Filliale_FillialeId",
                table: "Filliale");

            migrationBuilder.AlterColumn<string>(
                name: "FillialeName",
                table: "Filliale",
                type: "nvarchar(450)",
                nullable: true,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Filliale_FillialeName",
                table: "Filliale",
                column: "FillialeName",
                unique: true,
                filter: "[FillialeName] IS NOT NULL");
        }
    }
}
