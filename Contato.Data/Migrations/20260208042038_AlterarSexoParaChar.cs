using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MedTeste.Data.Migrations
{
    /// <inheritdoc />
    public partial class AlterarSexoParaChar : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<char>(
                name: "Sexo",
                table: "Contatos",
                type: "TEXT",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "INTEGER");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<int>(
                name: "Sexo",
                table: "Contatos",
                type: "INTEGER",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(char),
                oldType: "TEXT",
                oldNullable: true);
        }
    }
}
