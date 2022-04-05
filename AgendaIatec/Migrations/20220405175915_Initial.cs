using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AgendaIatec.Migrations
{
    public partial class Initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "AgendaModels",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nome = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Tipo = table.Column<string>(type: "nvarchar(1)", nullable: false),
                    Descricao = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: true),
                    Data = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Local = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AgendaModels", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "UsuarioModels",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nome = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DataNascimento = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Senha = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Genero = table.Column<string>(type: "nvarchar(1)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UsuarioModels", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AgendaModelUsuarioModel",
                columns: table => new
                {
                    AgendaModelId = table.Column<int>(type: "int", nullable: false),
                    UsuarioModelId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AgendaModelUsuarioModel", x => new { x.AgendaModelId, x.UsuarioModelId });
                    table.ForeignKey(
                        name: "FK_AgendaModelUsuarioModel_AgendaModels_AgendaModelId",
                        column: x => x.AgendaModelId,
                        principalTable: "AgendaModels",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AgendaModelUsuarioModel_UsuarioModels_UsuarioModelId",
                        column: x => x.UsuarioModelId,
                        principalTable: "UsuarioModels",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_AgendaModelUsuarioModel_UsuarioModelId",
                table: "AgendaModelUsuarioModel",
                column: "UsuarioModelId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AgendaModelUsuarioModel");

            migrationBuilder.DropTable(
                name: "AgendaModels");

            migrationBuilder.DropTable(
                name: "UsuarioModels");
        }
    }
}
