using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class UpdateFieldsCustomer : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "ZipCode",
                schema: "domain",
                table: "Customer",
                type: "varchar(9)",
                nullable: false,
                defaultValue: "",
                comment: "Cep para localização o cliente 29000-000",
                oldClrType: typeof(string),
                oldType: "varchar(9)",
                oldNullable: true,
                oldComment: "Cep para localização o cliente 29000-000")
                .Annotation("Relational:ColumnOrder", 12)
                .OldAnnotation("Relational:ColumnOrder", 11);

            migrationBuilder.AlterColumn<string>(
                name: "Neighborhood",
                schema: "domain",
                table: "Customer",
                type: "varchar(50)",
                nullable: true,
                comment: "Bairro para localização o cliente",
                oldClrType: typeof(string),
                oldType: "varchar(50)",
                oldNullable: true,
                oldComment: "Bairro para localização o cliente")
                .Annotation("Relational:ColumnOrder", 10)
                .OldAnnotation("Relational:ColumnOrder", 9);

            migrationBuilder.AlterColumn<string>(
                name: "Estado",
                schema: "domain",
                table: "Customer",
                type: "varchar(2)",
                nullable: true,
                comment: "Estado para localização o cliente",
                oldClrType: typeof(string),
                oldType: "varchar(2)",
                oldNullable: true,
                oldComment: "Estado para localização o cliente")
                .Annotation("Relational:ColumnOrder", 8)
                .OldAnnotation("Relational:ColumnOrder", 7);

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedAt",
                schema: "domain",
                table: "Customer",
                type: "timestamptz",
                nullable: false,
                defaultValueSql: "CURRENT_TIMESTAMP AT TIME ZONE 'America/Sao_Paulo'",
                comment: "Data de criação no fuso horário do Brasil",
                oldClrType: typeof(DateTime),
                oldType: "timestamptz",
                oldDefaultValueSql: "CURRENT_TIMESTAMP AT TIME ZONE 'America/Sao_Paulo'",
                oldComment: "Data de criação no fuso horário do Brasil")
                .Annotation("Relational:ColumnOrder", 13)
                .OldAnnotation("Relational:ColumnOrder", 14);

            migrationBuilder.AlterColumn<string>(
                name: "Complement",
                schema: "domain",
                table: "Customer",
                type: "varchar(100)",
                nullable: true,
                comment: "Complemento para localização o cliente",
                oldClrType: typeof(string),
                oldType: "varchar(100)",
                oldNullable: true,
                oldComment: "Complemento para localização o cliente")
                .Annotation("Relational:ColumnOrder", 11)
                .OldAnnotation("Relational:ColumnOrder", 10);

            migrationBuilder.AlterColumn<string>(
                name: "City",
                schema: "domain",
                table: "Customer",
                type: "varchar(50)",
                nullable: true,
                comment: "Cidade para localização o cliente",
                oldClrType: typeof(string),
                oldType: "varchar(50)",
                oldNullable: true,
                oldComment: "Cidade para localização o cliente")
                .Annotation("Relational:ColumnOrder", 9)
                .OldAnnotation("Relational:ColumnOrder", 8);

            migrationBuilder.AlterColumn<string>(
                name: "Address",
                schema: "domain",
                table: "Customer",
                type: "varchar(200)",
                nullable: true,
                comment: "Logradouro para localização do cliente",
                oldClrType: typeof(string),
                oldType: "varchar(200)",
                oldNullable: true,
                oldComment: "Logradouro para localização o cliente");

            migrationBuilder.AddColumn<string>(
                name: "Number",
                schema: "domain",
                table: "Customer",
                type: "varchar(10)",
                nullable: false,
                defaultValue: "",
                comment: "Número para localização do cliente")
                .Annotation("Relational:ColumnOrder", 7);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Number",
                schema: "domain",
                table: "Customer");

            migrationBuilder.AlterColumn<string>(
                name: "ZipCode",
                schema: "domain",
                table: "Customer",
                type: "varchar(9)",
                nullable: true,
                comment: "Cep para localização o cliente 29000-000",
                oldClrType: typeof(string),
                oldType: "varchar(9)",
                oldComment: "Cep para localização o cliente 29000-000")
                .Annotation("Relational:ColumnOrder", 11)
                .OldAnnotation("Relational:ColumnOrder", 12);

            migrationBuilder.AlterColumn<string>(
                name: "Neighborhood",
                schema: "domain",
                table: "Customer",
                type: "varchar(50)",
                nullable: true,
                comment: "Bairro para localização o cliente",
                oldClrType: typeof(string),
                oldType: "varchar(50)",
                oldNullable: true,
                oldComment: "Bairro para localização o cliente")
                .Annotation("Relational:ColumnOrder", 9)
                .OldAnnotation("Relational:ColumnOrder", 10);

            migrationBuilder.AlterColumn<string>(
                name: "Estado",
                schema: "domain",
                table: "Customer",
                type: "varchar(2)",
                nullable: true,
                comment: "Estado para localização o cliente",
                oldClrType: typeof(string),
                oldType: "varchar(2)",
                oldNullable: true,
                oldComment: "Estado para localização o cliente")
                .Annotation("Relational:ColumnOrder", 7)
                .OldAnnotation("Relational:ColumnOrder", 8);

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedAt",
                schema: "domain",
                table: "Customer",
                type: "timestamptz",
                nullable: false,
                defaultValueSql: "CURRENT_TIMESTAMP AT TIME ZONE 'America/Sao_Paulo'",
                comment: "Data de criação no fuso horário do Brasil",
                oldClrType: typeof(DateTime),
                oldType: "timestamptz",
                oldDefaultValueSql: "CURRENT_TIMESTAMP AT TIME ZONE 'America/Sao_Paulo'",
                oldComment: "Data de criação no fuso horário do Brasil")
                .Annotation("Relational:ColumnOrder", 14)
                .OldAnnotation("Relational:ColumnOrder", 13);

            migrationBuilder.AlterColumn<string>(
                name: "Complement",
                schema: "domain",
                table: "Customer",
                type: "varchar(100)",
                nullable: true,
                comment: "Complemento para localização o cliente",
                oldClrType: typeof(string),
                oldType: "varchar(100)",
                oldNullable: true,
                oldComment: "Complemento para localização o cliente")
                .Annotation("Relational:ColumnOrder", 10)
                .OldAnnotation("Relational:ColumnOrder", 11);

            migrationBuilder.AlterColumn<string>(
                name: "City",
                schema: "domain",
                table: "Customer",
                type: "varchar(50)",
                nullable: true,
                comment: "Cidade para localização o cliente",
                oldClrType: typeof(string),
                oldType: "varchar(50)",
                oldNullable: true,
                oldComment: "Cidade para localização o cliente")
                .Annotation("Relational:ColumnOrder", 8)
                .OldAnnotation("Relational:ColumnOrder", 9);

            migrationBuilder.AlterColumn<string>(
                name: "Address",
                schema: "domain",
                table: "Customer",
                type: "varchar(200)",
                nullable: true,
                comment: "Logradouro para localização o cliente",
                oldClrType: typeof(string),
                oldType: "varchar(200)",
                oldNullable: true,
                oldComment: "Logradouro para localização do cliente");
        }
    }
}
