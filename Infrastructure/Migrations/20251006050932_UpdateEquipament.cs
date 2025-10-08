using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class UpdateEquipament : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<short>(
                name: "Active",
                schema: "domain",
                table: "Equipament",
                type: "smallint",
                maxLength: 1,
                nullable: false,
                defaultValue: (short)0,
                comment: "Para indicar se o equipamento está o o registro ativo")
                .Annotation("Relational:ColumnOrder", 5);

            migrationBuilder.AddColumn<short>(
                name: "OnOff",
                schema: "domain",
                table: "Equipament",
                type: "smallint",
                maxLength: 1,
                nullable: false,
                defaultValue: (short)0,
                comment: "Para indicar se o equipamento está ligado ou desligado")
                .Annotation("Relational:ColumnOrder", 4);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Active",
                schema: "domain",
                table: "Equipament");

            migrationBuilder.DropColumn(
                name: "OnOff",
                schema: "domain",
                table: "Equipament");
        }
    }
}
