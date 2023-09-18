using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PIS.Core.Migrations;

/// <inheritdoc />
public partial class InitialMigration : Migration
{
    /// <inheritdoc />
    protected override void Up(MigrationBuilder migrationBuilder)
    {
        migrationBuilder.CreateTable(
            name: "TypePrs",
            columns: table => new
            {
                CdTp = table.Column<int>(type: "int", nullable: false)
                    .Annotation("SqlServer:Identity", "1, 1"),
                NmTp = table.Column<string>(type: "nvarchar(150)", nullable: false)
            },
            constraints: table =>
            {
                table.PrimaryKey("PK_TypePrs", x => x.CdTp);
            });

        migrationBuilder.CreateTable(
            name: "GLPRs",
            columns: table => new
            {
                CdPr = table.Column<string>(type: "nvarchar(450)", nullable: false),
                NmPr = table.Column<string>(type: "nvarchar(150)", nullable: false),
                CdTp = table.Column<int>(type: "int", nullable: false)
            },
            constraints: table =>
            {
                table.PrimaryKey("PK_GLPRs", x => x.CdPr);
                table.ForeignKey(
                    name: "FK_GLPRs_TypePrs_CdTp",
                    column: x => x.CdTp,
                    principalTable: "TypePrs",
                    principalColumn: "CdTp",
                    onDelete: ReferentialAction.Restrict);
            });

        migrationBuilder.CreateTable(
            name: "Specs",
            columns: table => new
            {
                CdSb = table.Column<string>(type: "nvarchar(450)", nullable: false),
                CdKp = table.Column<string>(type: "nvarchar(450)", nullable: false),
                QtyKp = table.Column<int>(type: "int", nullable: false)
            },
            constraints: table =>
            {
                table.PrimaryKey("PK_Specs", x => new { x.CdSb, x.CdKp });
                table.ForeignKey(
                    name: "FK_Specs_GLPRs_CdKp",
                    column: x => x.CdKp,
                    principalTable: "GLPRs",
                    principalColumn: "CdPr",
                    onDelete: ReferentialAction.Restrict);
                table.ForeignKey(
                    name: "FK_Specs_GLPRs_CdSb",
                    column: x => x.CdSb,
                    principalTable: "GLPRs",
                    principalColumn: "CdPr",
                    onDelete: ReferentialAction.Restrict);
            });

        migrationBuilder.CreateIndex(
            name: "IX_GLPRs_CdTp",
            table: "GLPRs",
            column: "CdTp");

        migrationBuilder.CreateIndex(
            name: "IX_Specs_CdKp",
            table: "Specs",
            column: "CdKp");
    }

    /// <inheritdoc />
    protected override void Down(MigrationBuilder migrationBuilder)
    {
        migrationBuilder.DropTable(
            name: "Specs");

        migrationBuilder.DropTable(
            name: "GLPRs");

        migrationBuilder.DropTable(
            name: "TypePrs");
    }
}
