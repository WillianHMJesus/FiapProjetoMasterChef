using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace Repository.Migrations
{
    public partial class Atualizacao : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Comentario_Receita_ReceitaId",
                table: "Comentario");

            migrationBuilder.DropPrimaryKey(
                name: "PK_ReceitaCategoria",
                table: "ReceitaCategoria");

            migrationBuilder.DropIndex(
                name: "IX_ReceitaCategoria_ReceitaId",
                table: "ReceitaCategoria");

            migrationBuilder.DropIndex(
                name: "IX_Comentario_ReceitaId",
                table: "Comentario");

            migrationBuilder.DropColumn(
                name: "CreatedOn",
                table: "Usuario");

            migrationBuilder.DropColumn(
                name: "UpdatedOn",
                table: "Usuario");

            migrationBuilder.DropColumn(
                name: "Id",
                table: "ReceitaCategoria");

            migrationBuilder.DropColumn(
                name: "CaminhoImagem",
                table: "Receita");

            migrationBuilder.DropColumn(
                name: "CreatedOn",
                table: "Receita");

            migrationBuilder.DropColumn(
                name: "InfoAdicional",
                table: "Receita");

            migrationBuilder.DropColumn(
                name: "UpdatedOn",
                table: "Receita");

            migrationBuilder.DropColumn(
                name: "ComentarioTexto",
                table: "Comentario");

            migrationBuilder.DropColumn(
                name: "CreatedOn",
                table: "Comentario");

            migrationBuilder.DropColumn(
                name: "ReceitaId",
                table: "Comentario");

            migrationBuilder.RenameColumn(
                name: "Username",
                table: "Usuario",
                newName: "UserName");

            migrationBuilder.AddColumn<DateTime>(
                name: "Criacao",
                table: "Usuario",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<string>(
                name: "DiretorioImagem",
                table: "Receita",
                type: "nvarchar(200)",
                maxLength: 200,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "InformacaoAdicional",
                table: "Receita",
                type: "nvarchar(200)",
                maxLength: 200,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<DateTime>(
                name: "Criacao",
                table: "Comentario",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<int>(
                name: "ReceitaForeignKey",
                table: "Comentario",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "Texto",
                table: "Comentario",
                type: "nvarchar(200)",
                maxLength: 200,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddPrimaryKey(
                name: "PK_ReceitaCategoria",
                table: "ReceitaCategoria",
                columns: new[] { "ReceitaId", "CategoriaId" });

            migrationBuilder.CreateIndex(
                name: "IX_Comentario_ReceitaForeignKey",
                table: "Comentario",
                column: "ReceitaForeignKey");

            migrationBuilder.AddForeignKey(
                name: "FK_Comentario_Receita_ReceitaForeignKey",
                table: "Comentario",
                column: "ReceitaForeignKey",
                principalTable: "Receita",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Comentario_Receita_ReceitaForeignKey",
                table: "Comentario");

            migrationBuilder.DropPrimaryKey(
                name: "PK_ReceitaCategoria",
                table: "ReceitaCategoria");

            migrationBuilder.DropIndex(
                name: "IX_Comentario_ReceitaForeignKey",
                table: "Comentario");

            migrationBuilder.DropColumn(
                name: "Criacao",
                table: "Usuario");

            migrationBuilder.DropColumn(
                name: "DiretorioImagem",
                table: "Receita");

            migrationBuilder.DropColumn(
                name: "InformacaoAdicional",
                table: "Receita");

            migrationBuilder.DropColumn(
                name: "Criacao",
                table: "Comentario");

            migrationBuilder.DropColumn(
                name: "ReceitaForeignKey",
                table: "Comentario");

            migrationBuilder.DropColumn(
                name: "Texto",
                table: "Comentario");

            migrationBuilder.RenameColumn(
                name: "UserName",
                table: "Usuario",
                newName: "Username");

            migrationBuilder.AddColumn<DateTime>(
                name: "CreatedOn",
                table: "Usuario",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "UpdatedOn",
                table: "Usuario",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "Id",
                table: "ReceitaCategoria",
                nullable: false,
                defaultValue: 0)
                .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            migrationBuilder.AddColumn<string>(
                name: "CaminhoImagem",
                table: "Receita",
                maxLength: 200,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<DateTime>(
                name: "CreatedOn",
                table: "Receita",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "InfoAdicional",
                table: "Receita",
                maxLength: 200,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<DateTime>(
                name: "UpdatedOn",
                table: "Receita",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ComentarioTexto",
                table: "Comentario",
                maxLength: 200,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<DateTime>(
                name: "CreatedOn",
                table: "Comentario",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "ReceitaId",
                table: "Comentario",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddPrimaryKey(
                name: "PK_ReceitaCategoria",
                table: "ReceitaCategoria",
                column: "Id");

            migrationBuilder.CreateIndex(
                name: "IX_ReceitaCategoria_ReceitaId",
                table: "ReceitaCategoria",
                column: "ReceitaId");

            migrationBuilder.CreateIndex(
                name: "IX_Comentario_ReceitaId",
                table: "Comentario",
                column: "ReceitaId");

            migrationBuilder.AddForeignKey(
                name: "FK_Comentario_Receita_ReceitaId",
                table: "Comentario",
                column: "ReceitaId",
                principalTable: "Receita",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
