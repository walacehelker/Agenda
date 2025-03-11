using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Context.Migrations
{
    /// <inheritdoc />
    public partial class inicial : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "cad_pessoas",
                columns: table => new
                {
                    id = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    nome_completo = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
                    cpf = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    rg = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    NomeMae = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    data_nascimento = table.Column<DateTime>(type: "datetime2", nullable: false),
                    crm = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    paciente = table.Column<bool>(type: "bit", nullable: false, defaultValue: true),
                    data_cadastro = table.Column<DateTime>(type: "datetime2", nullable: false),
                    excluido = table.Column<bool>(type: "bit", nullable: false),
                    data_exclusao = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_cad_pessoas", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "tipos_atendimentos",
                columns: table => new
                {
                    id = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    nome = table.Column<string>(type: "nvarchar(75)", maxLength: 75, nullable: false),
                    descricao = table.Column<string>(type: "nvarchar(400)", maxLength: 400, nullable: false),
                    data_cadastro = table.Column<DateTime>(type: "datetime2", nullable: false),
                    excluido = table.Column<bool>(type: "bit", nullable: false),
                    data_exclusao = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tipos_atendimentos", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "usuario_login",
                columns: table => new
                {
                    id = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    usuario = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    email = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    senha = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    PessoaId = table.Column<string>(type: "nvarchar(50)", nullable: false),
                    data_cadastro = table.Column<DateTime>(type: "datetime2", nullable: false),
                    excluido = table.Column<bool>(type: "bit", nullable: false),
                    data_exclusao = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_usuario_login", x => x.id);
                    table.ForeignKey(
                        name: "FK_usuario_login_cad_pessoas_PessoaId",
                        column: x => x.PessoaId,
                        principalTable: "cad_pessoas",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "atendimentos",
                columns: table => new
                {
                    id = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    descricao = table.Column<string>(type: "nvarchar(400)", maxLength: 400, nullable: false),
                    data_atendimento = table.Column<DateTime>(type: "datetime2", nullable: false),
                    id_pessoa = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    id_tipo_atendimento = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    data_cadastro = table.Column<DateTime>(type: "datetime2", nullable: false),
                    excluido = table.Column<bool>(type: "bit", nullable: false),
                    data_exclusao = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_atendimentos", x => x.id);
                    table.ForeignKey(
                        name: "FK_atendimentos_cad_pessoas_id_pessoa",
                        column: x => x.id_pessoa,
                        principalTable: "cad_pessoas",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_atendimentos_tipos_atendimentos_id_tipo_atendimento",
                        column: x => x.id_tipo_atendimento,
                        principalTable: "tipos_atendimentos",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_atendimentos_id_pessoa",
                table: "atendimentos",
                column: "id_pessoa");

            migrationBuilder.CreateIndex(
                name: "IX_atendimentos_id_tipo_atendimento",
                table: "atendimentos",
                column: "id_tipo_atendimento");

            migrationBuilder.CreateIndex(
                name: "IX_usuario_login_PessoaId",
                table: "usuario_login",
                column: "PessoaId",
                unique: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "atendimentos");

            migrationBuilder.DropTable(
                name: "usuario_login");

            migrationBuilder.DropTable(
                name: "tipos_atendimentos");

            migrationBuilder.DropTable(
                name: "cad_pessoas");
        }
    }
}
