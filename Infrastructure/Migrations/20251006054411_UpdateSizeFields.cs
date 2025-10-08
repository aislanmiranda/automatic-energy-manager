using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class UpdateSizeFields : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "Password",
                schema: "security",
                table: "User",
                type: "varchar(6)",
                nullable: false,
                comment: "Password para altenticar o usuário",
                oldClrType: typeof(string),
                oldType: "varchar",
                oldMaxLength: 6,
                oldComment: "Password para altenticar o usuário");

            migrationBuilder.AlterColumn<string>(
                name: "Login",
                schema: "security",
                table: "User",
                type: "varchar(20)",
                nullable: false,
                comment: "Login para identificar o usuário",
                oldClrType: typeof(string),
                oldType: "varchar",
                oldMaxLength: 20,
                oldComment: "Login para identificar o usuário");

            migrationBuilder.AlterColumn<string>(
                name: "Description",
                schema: "security",
                table: "User",
                type: "varchar(50)",
                nullable: false,
                comment: "Description para identificar o usuário",
                oldClrType: typeof(string),
                oldType: "varchar",
                oldMaxLength: 50,
                oldComment: "Description para identificar o usuário");

            migrationBuilder.AlterColumn<string>(
                name: "TaskName",
                schema: "domain",
                table: "Task",
                type: "varchar(50)",
                nullable: false,
                comment: "Nome para identificar nome tarefa",
                oldClrType: typeof(string),
                oldType: "varchar",
                oldMaxLength: 50,
                oldComment: "Nome para identificar nome tarefa");

            migrationBuilder.AlterColumn<string>(
                name: "TaskJobId",
                schema: "domain",
                table: "Task",
                type: "varchar(50)",
                nullable: false,
                comment: "Identificação da task cadastrada",
                oldClrType: typeof(string),
                oldType: "varchar",
                oldMaxLength: 50,
                oldComment: "Identificação da task cadastrada")
                .Annotation("Relational:ColumnOrder", 4)
                .OldAnnotation("Relational:ColumnOrder", 5);

            migrationBuilder.AlterColumn<string>(
                name: "Expression",
                schema: "domain",
                table: "Task",
                type: "varchar(30)",
                nullable: false,
                comment: "Expressão cron para a programação",
                oldClrType: typeof(string),
                oldType: "varchar",
                oldMaxLength: 30,
                oldComment: "Expressão cron para a programação")
                .Annotation("Relational:ColumnOrder", 3)
                .OldAnnotation("Relational:ColumnOrder", 4);

            migrationBuilder.AlterColumn<string>(
                name: "Action",
                schema: "domain",
                table: "Task",
                type: "varchar(10)",
                nullable: false,
                comment: "Ação para identificar comportamento da placa",
                oldClrType: typeof(string),
                oldType: "varchar",
                oldMaxLength: 10,
                oldComment: "Ação para identificar comportamento da placa");

            migrationBuilder.AlterColumn<string>(
                name: "Tag",
                schema: "domain",
                table: "Equipament",
                type: "varchar(20)",
                nullable: false,
                comment: "Tag para identificar do equipamento",
                oldClrType: typeof(string),
                oldType: "varchar",
                oldMaxLength: 20,
                oldComment: "Tag para identificar do equipamento");

            migrationBuilder.AlterColumn<string>(
                name: "Queue",
                schema: "domain",
                table: "Equipament",
                type: "varchar(30)",
                nullable: false,
                comment: "Indica a fila que o equipamento escuta",
                oldClrType: typeof(string),
                oldType: "varchar",
                oldMaxLength: 10,
                oldComment: "Indica a fila que o equipamento escuta");

            migrationBuilder.AlterColumn<string>(
                name: "ZipCode",
                schema: "domain",
                table: "Customer",
                type: "varchar(9)",
                nullable: true,
                comment: "Cep para localização o cliente 29000-000",
                oldClrType: typeof(string),
                oldType: "varchar",
                oldMaxLength: 9,
                oldNullable: true,
                oldComment: "Cep para localização o cliente 29000-000");

            migrationBuilder.AlterColumn<string>(
                name: "TypeCustomer",
                schema: "domain",
                table: "Customer",
                type: "varchar(2)",
                nullable: false,
                comment: "Tipo do Usuário [PJ|PF]",
                oldClrType: typeof(string),
                oldType: "varchar",
                oldMaxLength: 2,
                oldComment: "Tipo do Usuário [PJ|PF]");

            migrationBuilder.AlterColumn<string>(
                name: "Phone",
                schema: "domain",
                table: "Customer",
                type: "varchar(15)",
                nullable: false,
                defaultValue: "",
                comment: "Phone para identificar o cliente (00) 99999-9999 | (00) 9999-9999",
                oldClrType: typeof(string),
                oldType: "varchar",
                oldMaxLength: 15,
                oldNullable: true,
                oldComment: "Phone para identificar o cliente (00) 99999-9999 | (00) 9999-9999");

            migrationBuilder.AlterColumn<string>(
                name: "Neighborhood",
                schema: "domain",
                table: "Customer",
                type: "varchar(50)",
                nullable: true,
                comment: "Bairro para localização o cliente",
                oldClrType: typeof(string),
                oldType: "varchar",
                oldMaxLength: 50,
                oldNullable: true,
                oldComment: "Bairro para localização o cliente");

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                schema: "domain",
                table: "Customer",
                type: "varchar(50)",
                nullable: false,
                comment: "Nome para identificar o cliente",
                oldClrType: typeof(string),
                oldType: "varchar",
                oldMaxLength: 50,
                oldComment: "Nome para identificar o cliente");

            migrationBuilder.AlterColumn<string>(
                name: "Estado",
                schema: "domain",
                table: "Customer",
                type: "varchar(2)",
                nullable: true,
                comment: "Estado para localização o cliente",
                oldClrType: typeof(string),
                oldType: "varchar",
                oldMaxLength: 2,
                oldNullable: true,
                oldComment: "Estado para localização o cliente");

            migrationBuilder.AlterColumn<string>(
                name: "Email",
                schema: "domain",
                table: "Customer",
                type: "varchar(100)",
                nullable: true,
                comment: "Email para identificar o cliente",
                oldClrType: typeof(string),
                oldType: "varchar",
                oldMaxLength: 100,
                oldNullable: true,
                oldComment: "Email para identificar o cliente");

            migrationBuilder.AlterColumn<string>(
                name: "Document",
                schema: "domain",
                table: "Customer",
                type: "varchar(18)",
                nullable: true,
                comment: "Documento para identificar o cliente 000.000.000-00 | 00.000.000/0000-00",
                oldClrType: typeof(string),
                oldType: "varchar",
                oldMaxLength: 18,
                oldComment: "Documento para identificar o cliente 000.000.000-00 | 00.000.000/0000-00");

            migrationBuilder.AlterColumn<string>(
                name: "Complement",
                schema: "domain",
                table: "Customer",
                type: "varchar(100)",
                nullable: true,
                comment: "Complemento para localização o cliente",
                oldClrType: typeof(string),
                oldType: "varchar",
                oldMaxLength: 100,
                oldNullable: true,
                oldComment: "Complemento para localização o cliente");

            migrationBuilder.AlterColumn<string>(
                name: "City",
                schema: "domain",
                table: "Customer",
                type: "varchar(50)",
                nullable: true,
                comment: "Cidade para localização o cliente",
                oldClrType: typeof(string),
                oldType: "varchar",
                oldMaxLength: 50,
                oldNullable: true,
                oldComment: "Cidade para localização o cliente");

            migrationBuilder.AlterColumn<string>(
                name: "Address",
                schema: "domain",
                table: "Customer",
                type: "varchar(200)",
                nullable: true,
                comment: "Logradouro para localização o cliente",
                oldClrType: typeof(string),
                oldType: "varchar",
                oldMaxLength: 200,
                oldNullable: true,
                oldComment: "Logradouro para localização o cliente");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "Password",
                schema: "security",
                table: "User",
                type: "varchar",
                maxLength: 6,
                nullable: false,
                comment: "Password para altenticar o usuário",
                oldClrType: typeof(string),
                oldType: "varchar(6)",
                oldComment: "Password para altenticar o usuário");

            migrationBuilder.AlterColumn<string>(
                name: "Login",
                schema: "security",
                table: "User",
                type: "varchar",
                maxLength: 20,
                nullable: false,
                comment: "Login para identificar o usuário",
                oldClrType: typeof(string),
                oldType: "varchar(20)",
                oldComment: "Login para identificar o usuário");

            migrationBuilder.AlterColumn<string>(
                name: "Description",
                schema: "security",
                table: "User",
                type: "varchar",
                maxLength: 50,
                nullable: false,
                comment: "Description para identificar o usuário",
                oldClrType: typeof(string),
                oldType: "varchar(50)",
                oldComment: "Description para identificar o usuário");

            migrationBuilder.AlterColumn<string>(
                name: "TaskName",
                schema: "domain",
                table: "Task",
                type: "varchar",
                maxLength: 50,
                nullable: false,
                comment: "Nome para identificar nome tarefa",
                oldClrType: typeof(string),
                oldType: "varchar(50)",
                oldComment: "Nome para identificar nome tarefa");

            migrationBuilder.AlterColumn<string>(
                name: "TaskJobId",
                schema: "domain",
                table: "Task",
                type: "varchar",
                maxLength: 50,
                nullable: false,
                comment: "Identificação da task cadastrada",
                oldClrType: typeof(string),
                oldType: "varchar(50)",
                oldComment: "Identificação da task cadastrada")
                .Annotation("Relational:ColumnOrder", 5)
                .OldAnnotation("Relational:ColumnOrder", 4);

            migrationBuilder.AlterColumn<string>(
                name: "Expression",
                schema: "domain",
                table: "Task",
                type: "varchar",
                maxLength: 30,
                nullable: false,
                comment: "Expressão cron para a programação",
                oldClrType: typeof(string),
                oldType: "varchar(30)",
                oldComment: "Expressão cron para a programação")
                .Annotation("Relational:ColumnOrder", 4)
                .OldAnnotation("Relational:ColumnOrder", 3);

            migrationBuilder.AlterColumn<string>(
                name: "Action",
                schema: "domain",
                table: "Task",
                type: "varchar",
                maxLength: 10,
                nullable: false,
                comment: "Ação para identificar comportamento da placa",
                oldClrType: typeof(string),
                oldType: "varchar(10)",
                oldComment: "Ação para identificar comportamento da placa");

            migrationBuilder.AlterColumn<string>(
                name: "Tag",
                schema: "domain",
                table: "Equipament",
                type: "varchar",
                maxLength: 20,
                nullable: false,
                comment: "Tag para identificar do equipamento",
                oldClrType: typeof(string),
                oldType: "varchar(20)",
                oldComment: "Tag para identificar do equipamento");

            migrationBuilder.AlterColumn<string>(
                name: "Queue",
                schema: "domain",
                table: "Equipament",
                type: "varchar",
                maxLength: 10,
                nullable: false,
                comment: "Indica a fila que o equipamento escuta",
                oldClrType: typeof(string),
                oldType: "varchar(30)",
                oldComment: "Indica a fila que o equipamento escuta");

            migrationBuilder.AlterColumn<string>(
                name: "ZipCode",
                schema: "domain",
                table: "Customer",
                type: "varchar",
                maxLength: 9,
                nullable: true,
                comment: "Cep para localização o cliente 29000-000",
                oldClrType: typeof(string),
                oldType: "varchar(9)",
                oldNullable: true,
                oldComment: "Cep para localização o cliente 29000-000");

            migrationBuilder.AlterColumn<string>(
                name: "TypeCustomer",
                schema: "domain",
                table: "Customer",
                type: "varchar",
                maxLength: 2,
                nullable: false,
                comment: "Tipo do Usuário [PJ|PF]",
                oldClrType: typeof(string),
                oldType: "varchar(2)",
                oldComment: "Tipo do Usuário [PJ|PF]");

            migrationBuilder.AlterColumn<string>(
                name: "Phone",
                schema: "domain",
                table: "Customer",
                type: "varchar",
                maxLength: 15,
                nullable: true,
                comment: "Phone para identificar o cliente (00) 99999-9999 | (00) 9999-9999",
                oldClrType: typeof(string),
                oldType: "varchar(15)",
                oldComment: "Phone para identificar o cliente (00) 99999-9999 | (00) 9999-9999");

            migrationBuilder.AlterColumn<string>(
                name: "Neighborhood",
                schema: "domain",
                table: "Customer",
                type: "varchar",
                maxLength: 50,
                nullable: true,
                comment: "Bairro para localização o cliente",
                oldClrType: typeof(string),
                oldType: "varchar(50)",
                oldNullable: true,
                oldComment: "Bairro para localização o cliente");

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                schema: "domain",
                table: "Customer",
                type: "varchar",
                maxLength: 50,
                nullable: false,
                comment: "Nome para identificar o cliente",
                oldClrType: typeof(string),
                oldType: "varchar(50)",
                oldComment: "Nome para identificar o cliente");

            migrationBuilder.AlterColumn<string>(
                name: "Estado",
                schema: "domain",
                table: "Customer",
                type: "varchar",
                maxLength: 2,
                nullable: true,
                comment: "Estado para localização o cliente",
                oldClrType: typeof(string),
                oldType: "varchar(2)",
                oldNullable: true,
                oldComment: "Estado para localização o cliente");

            migrationBuilder.AlterColumn<string>(
                name: "Email",
                schema: "domain",
                table: "Customer",
                type: "varchar",
                maxLength: 100,
                nullable: true,
                comment: "Email para identificar o cliente",
                oldClrType: typeof(string),
                oldType: "varchar(100)",
                oldNullable: true,
                oldComment: "Email para identificar o cliente");

            migrationBuilder.AlterColumn<string>(
                name: "Document",
                schema: "domain",
                table: "Customer",
                type: "varchar",
                maxLength: 18,
                nullable: false,
                defaultValue: "",
                comment: "Documento para identificar o cliente 000.000.000-00 | 00.000.000/0000-00",
                oldClrType: typeof(string),
                oldType: "varchar(18)",
                oldNullable: true,
                oldComment: "Documento para identificar o cliente 000.000.000-00 | 00.000.000/0000-00");

            migrationBuilder.AlterColumn<string>(
                name: "Complement",
                schema: "domain",
                table: "Customer",
                type: "varchar",
                maxLength: 100,
                nullable: true,
                comment: "Complemento para localização o cliente",
                oldClrType: typeof(string),
                oldType: "varchar(100)",
                oldNullable: true,
                oldComment: "Complemento para localização o cliente");

            migrationBuilder.AlterColumn<string>(
                name: "City",
                schema: "domain",
                table: "Customer",
                type: "varchar",
                maxLength: 50,
                nullable: true,
                comment: "Cidade para localização o cliente",
                oldClrType: typeof(string),
                oldType: "varchar(50)",
                oldNullable: true,
                oldComment: "Cidade para localização o cliente");

            migrationBuilder.AlterColumn<string>(
                name: "Address",
                schema: "domain",
                table: "Customer",
                type: "varchar",
                maxLength: 200,
                nullable: true,
                comment: "Logradouro para localização o cliente",
                oldClrType: typeof(string),
                oldType: "varchar(200)",
                oldNullable: true,
                oldComment: "Logradouro para localização o cliente");
        }
    }
}
