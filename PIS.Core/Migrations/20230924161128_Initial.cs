using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace PIS.Core.Migrations
{
    /// <inheritdoc />
    public partial class Initial : Migration
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
                    CdPr = table.Column<string>(type: "nvarchar(5)", nullable: false),
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
                    CdSb = table.Column<string>(type: "nvarchar(5)", nullable: false),
                    CdKp = table.Column<string>(type: "nvarchar(5)", nullable: false),
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

            migrationBuilder.CreateTable(
                name: "StrRozvs",
                columns: table => new
                {
                    CdVyr = table.Column<string>(type: "nvarchar(5)", nullable: false),
                    CdSb = table.Column<string>(type: "nvarchar(5)", nullable: false),
                    CdKp = table.Column<string>(type: "nvarchar(5)", nullable: false),
                    QtyKp = table.Column<int>(type: "int", nullable: false),
                    RivNb = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_StrRozvs", x => new { x.CdKp, x.CdSb, x.CdVyr });
                    table.ForeignKey(
                        name: "FK_StrRozvs_GLPRs_CdKp",
                        column: x => x.CdKp,
                        principalTable: "GLPRs",
                        principalColumn: "CdPr",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_StrRozvs_GLPRs_CdSb",
                        column: x => x.CdSb,
                        principalTable: "GLPRs",
                        principalColumn: "CdPr",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_StrRozvs_GLPRs_CdVyr",
                        column: x => x.CdVyr,
                        principalTable: "GLPRs",
                        principalColumn: "CdPr",
                        onDelete: ReferentialAction.Restrict);
                });

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

            migrationBuilder.CreateIndex(
                name: "IX_GLPRs_CdTp",
                table: "GLPRs",
                column: "CdTp");

            migrationBuilder.CreateIndex(
                name: "IX_Specs_CdKp",
                table: "Specs",
                column: "CdKp");

            migrationBuilder.CreateIndex(
                name: "IX_StrRozvs_CdSb",
                table: "StrRozvs",
                column: "CdSb");

            migrationBuilder.CreateIndex(
                name: "IX_StrRozvs_CdVyr",
                table: "StrRozvs",
                column: "CdVyr");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Specs");

            migrationBuilder.DropTable(
                name: "StrRozvs");

            migrationBuilder.DropTable(
                name: "GLPRs");

            migrationBuilder.DropTable(
                name: "TypePrs");
        }
    }
}
