using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace FillialeData.Migrations
{
    public partial class init : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Filliale",
                columns: table => new
                {
                    FillialeId = table.Column<Guid>(nullable: false),
                    FillialeName = table.Column<string>(nullable: true),
                    FillialeCode = table.Column<Guid>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Filliale", x => x.FillialeId);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Filliale_FillialeCode",
                table: "Filliale",
                column: "FillialeCode",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Filliale_FillialeName",
                table: "Filliale",
                column: "FillialeName",
                unique: true,
                filter: "[FillialeName] IS NOT NULL");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Filliale");
        }
    }
}
