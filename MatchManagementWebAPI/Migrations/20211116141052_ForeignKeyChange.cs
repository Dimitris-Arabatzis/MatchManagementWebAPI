using Microsoft.EntityFrameworkCore.Migrations;

namespace MatchManagementWebAPI.Migrations
{
    public partial class ForeignKeyChange : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_MatchOdds_Matches_MatchId",
                table: "MatchOdds");

            migrationBuilder.AlterColumn<string>(
                name: "Specifier",
                table: "MatchOdds",
                type: "nvarchar(24)",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<int>(
                name: "MatchId",
                table: "MatchOdds",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_MatchOdds_Matches_MatchId",
                table: "MatchOdds",
                column: "MatchId",
                principalTable: "Matches",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_MatchOdds_Matches_MatchId",
                table: "MatchOdds");

            migrationBuilder.AlterColumn<int>(
                name: "Specifier",
                table: "MatchOdds",
                type: "int",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(24)");

            migrationBuilder.AlterColumn<int>(
                name: "MatchId",
                table: "MatchOdds",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddForeignKey(
                name: "FK_MatchOdds_Matches_MatchId",
                table: "MatchOdds",
                column: "MatchId",
                principalTable: "Matches",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
