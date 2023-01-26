using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace Interviewssss.Migrations
{
    /// <inheritdoc />
    public partial class dbcon : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "suhbatOluvchis",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Yunalish = table.Column<string>(type: "text", nullable: false),
                    Fullname = table.Column<string>(type: "text", nullable: false),
                    Darajasi = table.Column<string>(type: "text", nullable: false),
                    Loyxasi = table.Column<string>(type: "text", nullable: false),
                    Tajribasi = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_suhbatOluvchis", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "topshiruvchi",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Fullname = table.Column<string>(type: "text", nullable: false),
                    Daraja = table.Column<string>(type: "text", nullable: false),
                    Tajriba = table.Column<string>(type: "text", nullable: false),
                    Tel = table.Column<string>(type: "text", nullable: false),
                    OluvchiId = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_topshiruvchi", x => x.Id);
                    table.ForeignKey(
                        name: "FK_topshiruvchi_suhbatOluvchis_OluvchiId",
                        column: x => x.OluvchiId,
                        principalTable: "suhbatOluvchis",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_topshiruvchi_OluvchiId",
                table: "topshiruvchi",
                column: "OluvchiId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "topshiruvchi");

            migrationBuilder.DropTable(
                name: "suhbatOluvchis");
        }
    }
}
