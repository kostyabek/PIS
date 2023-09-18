using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace PIS.Core.Migrations;

/// <inheritdoc />
public partial class SeedTypePrs : Migration
{
    /// <inheritdoc />
    protected override void Up(MigrationBuilder migrationBuilder)
    {
        migrationBuilder.InsertData(
            table: "TypePrs",
            columns: new[] { "CdTp", "NmTp" },
            values: new object[,]
            {
                { 1, "виріб" },
                { 2, "вузол (агрегат, збірка)" },
                { 3, "деталь власного виробництва" },
                { 4, "покупний (комплектувальний) предмет" }
            });
    }

    /// <inheritdoc />
    protected override void Down(MigrationBuilder migrationBuilder)
    {
        migrationBuilder.DeleteData(
            table: "TypePrs",
            keyColumn: "CdTp",
            keyValue: 1);

        migrationBuilder.DeleteData(
            table: "TypePrs",
            keyColumn: "CdTp",
            keyValue: 2);

        migrationBuilder.DeleteData(
            table: "TypePrs",
            keyColumn: "CdTp",
            keyValue: 3);

        migrationBuilder.DeleteData(
            table: "TypePrs",
            keyColumn: "CdTp",
            keyValue: 4);
    }
}
