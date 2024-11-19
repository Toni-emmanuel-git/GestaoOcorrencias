using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace GestaoOcorrencias.WebApi.Migrations
{
    /// <inheritdoc />
    public partial class Ocorrencias : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Ocorrencias",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DataAbertura = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DataOcorrencia = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Descricao = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ResponsavelAberturaId = table.Column<int>(type: "int", nullable: false),
                    Conclusao = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ResponsavelOcorrenciaId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Ocorrencias", x => x.Id);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Ocorrencias");
        }
    }
}
