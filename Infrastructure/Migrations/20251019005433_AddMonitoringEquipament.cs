using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class AddMonitoringEquipament : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Monitoring",
                schema: "domain",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false, comment: "Id Monitoring"),
                    Action = table.Column<string>(type: "varchar(3)", nullable: false, comment: "Para identificar a ação do equipamento [ON | OFF]"),
                    DateAction = table.Column<DateTime>(type: "timestamptz", nullable: false, defaultValueSql: "CURRENT_TIMESTAMP AT TIME ZONE 'America/Sao_Paulo'", comment: "Data de criação no fuso horário do Brasil"),
                    CustomerId = table.Column<Guid>(type: "uuid", nullable: false),
                    EquipamentId = table.Column<Guid>(type: "uuid", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_monitoring", x => x.Id);
                    table.ForeignKey(
                        name: "fk_customer",
                        column: x => x.CustomerId,
                        principalSchema: "domain",
                        principalTable: "Customer",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "fk_equipament",
                        column: x => x.EquipamentId,
                        principalSchema: "domain",
                        principalTable: "Equipament",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "idx_customer_equipament",
                schema: "domain",
                table: "Monitoring",
                columns: new[] { "CustomerId", "EquipamentId" });

            migrationBuilder.CreateIndex(
                name: "IX_Monitoring_EquipamentId",
                schema: "domain",
                table: "Monitoring",
                column: "EquipamentId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "fk_customer",
                schema: "domain",
                table: "Equipament");

            migrationBuilder.DropTable(
                name: "Monitoring",
                schema: "domain");
        }
    }
}
