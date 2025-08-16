using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class StartProjectAws : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.EnsureSchema(
                name: "domain");

            migrationBuilder.EnsureSchema(
                name: "security");

            migrationBuilder.CreateTable(
                name: "Customer",
                schema: "domain",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false, comment: "Chave para o cliente"),
                    TypeCustomer = table.Column<string>(type: "varchar", maxLength: 2, nullable: false, comment: "Tipo do Usuário [PJ|PF]"),
                    Name = table.Column<string>(type: "varchar", maxLength: 50, nullable: false, comment: "Nome para identificar o cliente"),
                    Document = table.Column<string>(type: "varchar", maxLength: 18, nullable: false, comment: "Documento para identificar o cliente 000.000.000-00 | 00.000.000/0000-00"),
                    Email = table.Column<string>(type: "varchar", maxLength: 100, nullable: true, comment: "Email para identificar o cliente"),
                    Phone = table.Column<string>(type: "varchar", maxLength: 15, nullable: true, comment: "Phone para identificar o cliente (00) 99999-9999 | (00) 9999-9999"),
                    Address = table.Column<string>(type: "varchar", maxLength: 200, nullable: true, comment: "Logradouro para localização o cliente"),
                    Estado = table.Column<string>(type: "varchar", maxLength: 2, nullable: true, comment: "Estado para localização o cliente"),
                    City = table.Column<string>(type: "varchar", maxLength: 50, nullable: true, comment: "Cidade para localização o cliente"),
                    Neighborhood = table.Column<string>(type: "varchar", maxLength: 50, nullable: true, comment: "Bairro para localização o cliente"),
                    Complement = table.Column<string>(type: "varchar", maxLength: 100, nullable: true, comment: "Complemento para localização o cliente"),
                    ZipCode = table.Column<string>(type: "varchar", maxLength: 9, nullable: true, comment: "Cep para localização o cliente 29000-000"),
                    CreatedAt = table.Column<DateTime>(type: "timestamptz", nullable: false, defaultValueSql: "CURRENT_TIMESTAMP AT TIME ZONE 'America/Sao_Paulo'", comment: "Data de criação no fuso horário do Brasil"),
                    Status = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_customer", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "User",
                schema: "security",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false, comment: "Chave para o usuário"),
                    Login = table.Column<string>(type: "varchar", maxLength: 20, nullable: false, comment: "Login para identificar o usuário"),
                    Password = table.Column<string>(type: "varchar", maxLength: 6, nullable: false, comment: "Password para altenticar o usuário"),
                    Description = table.Column<string>(type: "varchar", maxLength: 50, nullable: false, comment: "Description para identificar o usuário"),
                    Status = table.Column<short>(type: "smallint", nullable: false, defaultValue: (short)2, comment: "Status 0-Inativo 1-Ativo 2-EmAnalise"),
                    CreatedAt = table.Column<DateTime>(type: "timestamptz", nullable: false, defaultValueSql: "CURRENT_TIMESTAMP AT TIME ZONE 'America/Sao_Paulo'", comment: "Data de criação no fuso horário do Brasil")
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_user", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Equipament",
                schema: "domain",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false, comment: "Id do equipamento"),
                    Tag = table.Column<string>(type: "varchar", maxLength: 20, nullable: false, comment: "Tag para identificar do equipamento"),
                    Queue = table.Column<string>(type: "varchar", maxLength: 10, nullable: false, comment: "Indica a fila que o equipamento escuta"),
                    Port = table.Column<short>(type: "smallint", maxLength: 30, nullable: false, comment: "Para indicar a porta na qual o equipamento será acionado"),
                    CustomerId = table.Column<Guid>(type: "uuid", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_equipament", x => x.Id);
                    table.ForeignKey(
                        name: "fk_customer",
                        column: x => x.CustomerId,
                        principalSchema: "domain",
                        principalTable: "Customer",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "UserCustomer",
                schema: "domain",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    UserId = table.Column<Guid>(type: "uuid", nullable: false),
                    CustomerId = table.Column<Guid>(type: "uuid", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_usercustomer", x => x.Id);
                    table.ForeignKey(
                        name: "fk_customer_usercustomer",
                        column: x => x.CustomerId,
                        principalSchema: "domain",
                        principalTable: "Customer",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "fk_user_usercustomer",
                        column: x => x.UserId,
                        principalSchema: "security",
                        principalTable: "User",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Task",
                schema: "domain",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false, comment: "Chave para identificar a tarefa")
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    TaskName = table.Column<string>(type: "varchar", maxLength: 50, nullable: false, comment: "Nome para identificar nome tarefa"),
                    Action = table.Column<string>(type: "varchar", maxLength: 10, nullable: false, comment: "Ação para identificar comportamento da placa"),
                    Expression = table.Column<string>(type: "varchar", maxLength: 30, nullable: false, comment: "Expressão cron para a programação"),
                    TaskJobId = table.Column<string>(type: "varchar", maxLength: 50, nullable: false, comment: "Identificação da task cadastrada"),
                    TaskLegend = table.Column<string>(type: "text", nullable: false),
                    EquipamentId = table.Column<Guid>(type: "uuid", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_task", x => x.Id);
                    table.ForeignKey(
                        name: "fk_equip_task",
                        column: x => x.EquipamentId,
                        principalSchema: "domain",
                        principalTable: "Equipament",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "idx_document_unique",
                schema: "domain",
                table: "Customer",
                column: "Document",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "idx_customerid",
                schema: "domain",
                table: "Equipament",
                column: "CustomerId");

            migrationBuilder.CreateIndex(
                name: "idx_tagcust_unique",
                schema: "domain",
                table: "Equipament",
                columns: new[] { "Tag", "Port" },
                unique: true);

            migrationBuilder.CreateIndex(
                name: "idx_task_unique",
                schema: "domain",
                table: "Task",
                columns: new[] { "Action", "Expression", "EquipamentId" },
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Task_EquipamentId",
                schema: "domain",
                table: "Task",
                column: "EquipamentId");

            migrationBuilder.CreateIndex(
                name: "IX_UserCustomer_CustomerId",
                schema: "domain",
                table: "UserCustomer",
                column: "CustomerId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_UserCustomer_UserId",
                schema: "domain",
                table: "UserCustomer",
                column: "UserId",
                unique: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Task",
                schema: "domain");

            migrationBuilder.DropTable(
                name: "UserCustomer",
                schema: "domain");

            migrationBuilder.DropTable(
                name: "Equipament",
                schema: "domain");

            migrationBuilder.DropTable(
                name: "User",
                schema: "security");

            migrationBuilder.DropTable(
                name: "Customer",
                schema: "domain");
        }
    }
}
