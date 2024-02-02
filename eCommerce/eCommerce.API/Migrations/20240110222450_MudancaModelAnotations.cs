using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace eCommerce.API.Migrations
{
    public partial class MudancaModelAnotations : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Contatos_Usuarios_UsuarioId",
                table: "Contatos");

            migrationBuilder.DropForeignKey(
                name: "FK_DepartamentoUsuario_Usuarios_UsuariosId",
                table: "DepartamentoUsuario");

            migrationBuilder.DropForeignKey(
                name: "FK_EnderecosEntrega_Usuarios_UsuarioId",
                table: "EnderecosEntrega");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Usuarios",
                table: "Usuarios");

            migrationBuilder.RenameTable(
                name: "Usuarios",
                newName: "TB_USUARIOS");

            migrationBuilder.RenameColumn(
                name: "UsuarioId",
                table: "Contatos",
                newName: "IdentificadorUsuario");

            migrationBuilder.RenameIndex(
                name: "IX_Contatos_UsuarioId",
                table: "Contatos",
                newName: "IX_Contatos_IdentificadorUsuario");

            migrationBuilder.RenameColumn(
                name: "Rg",
                table: "TB_USUARIOS",
                newName: "Registro_Geral");

            migrationBuilder.AlterColumn<string>(
                name: "Sexo",
                table: "TB_USUARIOS",
                type: "nvarchar(15)",
                maxLength: 15,
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Nome",
                table: "TB_USUARIOS",
                type: "nvarchar(450)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<string>(
                name: "Email",
                table: "TB_USUARIOS",
                type: "nvarchar(450)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<string>(
                name: "Cpf",
                table: "TB_USUARIOS",
                type: "nvarchar(450)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<int>(
                name: "Id",
                table: "TB_USUARIOS",
                type: "int",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int")
                .OldAnnotation("SqlServer:Identity", "1, 1");

            migrationBuilder.AddColumn<int>(
                name: "Matricula",
                table: "TB_USUARIOS",
                type: "int",
                nullable: false,
                defaultValue: 0)
                .Annotation("SqlServer:Identity", "1, 1");

            migrationBuilder.AddPrimaryKey(
                name: "PK_TB_USUARIOS",
                table: "TB_USUARIOS",
                column: "Id");

            migrationBuilder.CreateTable(
                name: "Pedido",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ClienteId = table.Column<int>(type: "int", nullable: false),
                    ColaboradorId = table.Column<int>(type: "int", nullable: false),
                    SupervisorId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Pedido", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Pedido_TB_USUARIOS_ClienteId",
                        column: x => x.ClienteId,
                        principalTable: "TB_USUARIOS",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Pedido_TB_USUARIOS_ColaboradorId",
                        column: x => x.ColaboradorId,
                        principalTable: "TB_USUARIOS",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Pedido_TB_USUARIOS_SupervisorId",
                        column: x => x.SupervisorId,
                        principalTable: "TB_USUARIOS",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_EMAIL_UNICO",
                table: "TB_USUARIOS",
                column: "Email",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_TB_USUARIOS_Nome_Cpf",
                table: "TB_USUARIOS",
                columns: new[] { "Nome", "Cpf" });

            migrationBuilder.CreateIndex(
                name: "IX_Pedido_ClienteId",
                table: "Pedido",
                column: "ClienteId");

            migrationBuilder.CreateIndex(
                name: "IX_Pedido_ColaboradorId",
                table: "Pedido",
                column: "ColaboradorId");

            migrationBuilder.CreateIndex(
                name: "IX_Pedido_SupervisorId",
                table: "Pedido",
                column: "SupervisorId");

            migrationBuilder.AddForeignKey(
                name: "FK_Contatos_TB_USUARIOS_IdentificadorUsuario",
                table: "Contatos",
                column: "IdentificadorUsuario",
                principalTable: "TB_USUARIOS",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_DepartamentoUsuario_TB_USUARIOS_UsuariosId",
                table: "DepartamentoUsuario",
                column: "UsuariosId",
                principalTable: "TB_USUARIOS",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_EnderecosEntrega_TB_USUARIOS_UsuarioId",
                table: "EnderecosEntrega",
                column: "UsuarioId",
                principalTable: "TB_USUARIOS",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Contatos_TB_USUARIOS_IdentificadorUsuario",
                table: "Contatos");

            migrationBuilder.DropForeignKey(
                name: "FK_DepartamentoUsuario_TB_USUARIOS_UsuariosId",
                table: "DepartamentoUsuario");

            migrationBuilder.DropForeignKey(
                name: "FK_EnderecosEntrega_TB_USUARIOS_UsuarioId",
                table: "EnderecosEntrega");

            migrationBuilder.DropTable(
                name: "Pedido");

            migrationBuilder.DropPrimaryKey(
                name: "PK_TB_USUARIOS",
                table: "TB_USUARIOS");

            migrationBuilder.DropIndex(
                name: "IX_EMAIL_UNICO",
                table: "TB_USUARIOS");

            migrationBuilder.DropIndex(
                name: "IX_TB_USUARIOS_Nome_Cpf",
                table: "TB_USUARIOS");

            migrationBuilder.DropColumn(
                name: "Matricula",
                table: "TB_USUARIOS");

            migrationBuilder.RenameTable(
                name: "TB_USUARIOS",
                newName: "Usuarios");

            migrationBuilder.RenameColumn(
                name: "IdentificadorUsuario",
                table: "Contatos",
                newName: "UsuarioId");

            migrationBuilder.RenameIndex(
                name: "IX_Contatos_IdentificadorUsuario",
                table: "Contatos",
                newName: "IX_Contatos_UsuarioId");

            migrationBuilder.RenameColumn(
                name: "Registro_Geral",
                table: "Usuarios",
                newName: "Rg");

            migrationBuilder.AlterColumn<string>(
                name: "Sexo",
                table: "Usuarios",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(15)",
                oldMaxLength: 15);

            migrationBuilder.AlterColumn<string>(
                name: "Nome",
                table: "Usuarios",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)");

            migrationBuilder.AlterColumn<string>(
                name: "Email",
                table: "Usuarios",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)");

            migrationBuilder.AlterColumn<string>(
                name: "Cpf",
                table: "Usuarios",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)");

            migrationBuilder.AlterColumn<int>(
                name: "Id",
                table: "Usuarios",
                type: "int",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int")
                .Annotation("SqlServer:Identity", "1, 1");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Usuarios",
                table: "Usuarios",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Contatos_Usuarios_UsuarioId",
                table: "Contatos",
                column: "UsuarioId",
                principalTable: "Usuarios",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_DepartamentoUsuario_Usuarios_UsuariosId",
                table: "DepartamentoUsuario",
                column: "UsuariosId",
                principalTable: "Usuarios",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_EnderecosEntrega_Usuarios_UsuarioId",
                table: "EnderecosEntrega",
                column: "UsuarioId",
                principalTable: "Usuarios",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
