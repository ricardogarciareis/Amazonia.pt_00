using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Amazonia.DAL.Migrations
{
    public partial class ComplementoModeloAdicionadaLivros : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AudioLivros");

            migrationBuilder.DropTable(
                name: "LivroDigitals");

            migrationBuilder.DropTable(
                name: "LivroImpressos");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Periodicos",
                table: "Periodicos");

            migrationBuilder.RenameTable(
                name: "Periodicos",
                newName: "Livros");

            migrationBuilder.AlterColumn<DateTime>(
                name: "DataLancamento",
                table: "Livros",
                type: "datetime2",
                nullable: true,
                oldClrType: typeof(DateTime),
                oldType: "datetime2");

            migrationBuilder.AddColumn<float>(
                name: "Altura",
                table: "Livros",
                type: "real",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Discriminator",
                table: "Livros",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<int>(
                name: "DuracaoLivroEmMinutos",
                table: "Livros",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "FormatoFicheiro",
                table: "Livros",
                type: "nvarchar(5)",
                maxLength: 5,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "InformacoesLicenca",
                table: "Livros",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<float>(
                name: "Largura",
                table: "Livros",
                type: "real",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "LivroDigital_FormatoFicheiro",
                table: "Livros",
                type: "nvarchar(5)",
                maxLength: 5,
                nullable: true);

            migrationBuilder.AddColumn<float>(
                name: "Peso",
                table: "Livros",
                type: "real",
                nullable: true);

            migrationBuilder.AddColumn<float>(
                name: "Profundidade",
                table: "Livros",
                type: "real",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "QuantidadePaginas",
                table: "Livros",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "TamanhoEmMB",
                table: "Livros",
                type: "int",
                nullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_Livros",
                table: "Livros",
                column: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_Livros",
                table: "Livros");

            migrationBuilder.DropColumn(
                name: "Altura",
                table: "Livros");

            migrationBuilder.DropColumn(
                name: "Discriminator",
                table: "Livros");

            migrationBuilder.DropColumn(
                name: "DuracaoLivroEmMinutos",
                table: "Livros");

            migrationBuilder.DropColumn(
                name: "FormatoFicheiro",
                table: "Livros");

            migrationBuilder.DropColumn(
                name: "InformacoesLicenca",
                table: "Livros");

            migrationBuilder.DropColumn(
                name: "Largura",
                table: "Livros");

            migrationBuilder.DropColumn(
                name: "LivroDigital_FormatoFicheiro",
                table: "Livros");

            migrationBuilder.DropColumn(
                name: "Peso",
                table: "Livros");

            migrationBuilder.DropColumn(
                name: "Profundidade",
                table: "Livros");

            migrationBuilder.DropColumn(
                name: "QuantidadePaginas",
                table: "Livros");

            migrationBuilder.DropColumn(
                name: "TamanhoEmMB",
                table: "Livros");

            migrationBuilder.RenameTable(
                name: "Livros",
                newName: "Periodicos");

            migrationBuilder.AlterColumn<DateTime>(
                name: "DataLancamento",
                table: "Periodicos",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldNullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_Periodicos",
                table: "Periodicos",
                column: "Id");

            migrationBuilder.CreateTable(
                name: "AudioLivros",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Autor = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    Descricao = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DuracaoLivroEmMinutos = table.Column<int>(type: "int", nullable: true),
                    FormatoFicheiro = table.Column<string>(type: "nvarchar(5)", maxLength: 5, nullable: false),
                    Idioma = table.Column<int>(type: "int", nullable: false),
                    Nome = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AudioLivros", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "LivroDigitals",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Autor = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    Descricao = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    FormatoFicheiro = table.Column<string>(type: "nvarchar(5)", maxLength: 5, nullable: false),
                    Idioma = table.Column<int>(type: "int", nullable: false),
                    InformacoesLicenca = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Nome = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    TamanhoEmMB = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LivroDigitals", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "LivroImpressos",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Altura = table.Column<float>(type: "real", nullable: false),
                    Autor = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    Descricao = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Idioma = table.Column<int>(type: "int", nullable: false),
                    Largura = table.Column<float>(type: "real", nullable: false),
                    Nome = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    Peso = table.Column<float>(type: "real", nullable: false),
                    Profundidade = table.Column<float>(type: "real", nullable: false),
                    QuantidadePaginas = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LivroImpressos", x => x.Id);
                });
        }
    }
}
