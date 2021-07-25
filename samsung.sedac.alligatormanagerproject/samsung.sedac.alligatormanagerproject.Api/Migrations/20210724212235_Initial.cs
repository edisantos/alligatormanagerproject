using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace samsung.sedac.alligatormanagerproject.Api.Migrations
{
    public partial class Initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Projetos",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Data = table.Column<DateTime>(type: "datetime", nullable: false),
                    Solicitante = table.Column<string>(type: "varchar(50)", maxLength: 50, nullable: false),
                    DepartamentoId = table.Column<int>(type: "int", nullable: false),
                    Titulo = table.Column<string>(type: "varchar(50)", maxLength: 50, nullable: false),
                    Descricao = table.Column<string>(type: "varchar(300)", maxLength: 300, nullable: false),
                    UrlFluxograma = table.Column<string>(type: "varchar(100)", maxLength: 100, nullable: false),
                    IsApproved = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Projetos", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Projetos");
        }
    }
}
