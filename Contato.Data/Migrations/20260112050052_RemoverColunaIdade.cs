using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MedTeste.Data.Migrations
{
    /// <inheritdoc />
    public partial class RemoverColunaIdade : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Idade",
                table: "Contatos");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "Idade",
                table: "Contatos",
                type: "INTEGER",
                nullable: false,
                defaultValue: 0);
        }
    }
}
