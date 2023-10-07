using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PIS.Core.Migrations
{
    /// <inheritdoc />
    public partial class UpdateStrRozvKey : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_StrRozvs",
                table: "StrRozvs");

            migrationBuilder.AddPrimaryKey(
                name: "PK_StrRozvs",
                table: "StrRozvs",
                columns: new[] { "CdKp", "CdSb", "CdVyr", "RivNb" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_StrRozvs",
                table: "StrRozvs");

            migrationBuilder.AddPrimaryKey(
                name: "PK_StrRozvs",
                table: "StrRozvs",
                columns: new[] { "CdKp", "CdSb", "CdVyr" });
        }
    }
}
