using Microsoft.EntityFrameworkCore.Migrations;

namespace Dotnet_Rpg.Migrations
{
    public partial class SkillSeeding : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Skills",
                columns: new[] { "Id", "Damage", "Name" },
                values: new object[,]
                {
                    { 1, 9000, "Multi-Shadow-Clone Jutsu" },
                    { 2, 10000, "Chidori" },
                    { 3, 8000, "Tsukuyomi" },
                    { 4, 5000, "Hirudora" },
                    { 5, 8000, "Flying Thunder God" },
                    { 6, 6000, "Byakugou No Jutsu" },
                    { 7, 4000, "Rasengan" },
                    { 8, 7000, "Raikiri" },
                    { 9, 3000, "Chakra Enhanced Strength" },
                    { 10, 2500, "Shadow Imitation Jutsu" }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Skills",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Skills",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Skills",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Skills",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Skills",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Skills",
                keyColumn: "Id",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "Skills",
                keyColumn: "Id",
                keyValue: 7);

            migrationBuilder.DeleteData(
                table: "Skills",
                keyColumn: "Id",
                keyValue: 8);

            migrationBuilder.DeleteData(
                table: "Skills",
                keyColumn: "Id",
                keyValue: 9);

            migrationBuilder.DeleteData(
                table: "Skills",
                keyColumn: "Id",
                keyValue: 10);
        }
    }
}
