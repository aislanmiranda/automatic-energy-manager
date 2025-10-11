using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class UpdateFieldTaskTable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "TaskJobId",
                schema: "domain",
                table: "Task",
                type: "varchar(80)",
                nullable: false,
                comment: "Identificação da task cadastrada",
                oldClrType: typeof(string),
                oldType: "varchar(50)",
                oldComment: "Identificação da task cadastrada");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "TaskJobId",
                schema: "domain",
                table: "Task",
                type: "varchar(50)",
                nullable: false,
                comment: "Identificação da task cadastrada",
                oldClrType: typeof(string),
                oldType: "varchar(80)",
                oldComment: "Identificação da task cadastrada");
        }
    }
}
