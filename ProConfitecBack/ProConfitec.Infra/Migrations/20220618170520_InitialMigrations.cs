using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace ProConfitec.Infra.Migrations
{
    public partial class InitialMigrations : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "tb_scholarity",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tb_scholarity", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "tb_school_records",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    TypeFile = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tb_school_records", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "tb_user",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Surname = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    BirthDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ScholarityId = table.Column<int>(type: "int", nullable: false),
                    SchoolRecordsId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tb_user", x => x.Id);
                    table.ForeignKey(
                        name: "FK_tb_user_tb_scholarity_ScholarityId",
                        column: x => x.ScholarityId,
                        principalTable: "tb_scholarity",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_tb_user_tb_school_records_SchoolRecordsId",
                        column: x => x.SchoolRecordsId,
                        principalTable: "tb_school_records",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "tb_scholarity",
                columns: new[] { "Id", "Description" },
                values: new object[,]
                {
                    { 1, "Infantil" },
                    { 2, "Fundamental" },
                    { 3, "Médio" },
                    { 4, "Superior" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_tb_user_ScholarityId",
                table: "tb_user",
                column: "ScholarityId");

            migrationBuilder.CreateIndex(
                name: "IX_tb_user_SchoolRecordsId",
                table: "tb_user",
                column: "SchoolRecordsId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "tb_user");

            migrationBuilder.DropTable(
                name: "tb_scholarity");

            migrationBuilder.DropTable(
                name: "tb_school_records");
        }
    }
}
