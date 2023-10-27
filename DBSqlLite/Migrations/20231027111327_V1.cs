using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace DBSqlLite.Migrations
{
    public partial class V1 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "TaskSQLiteModel",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    Realizada = table.Column<bool>(nullable: false),
                    NomeTask = table.Column<string>(nullable: true),
                    ObservacaoTask = table.Column<string>(nullable: true),
                    DataInicioTask = table.Column<DateTime>(nullable: false),
                    DataFimTask = table.Column<DateTime>(nullable: false),
                    InsertID = table.Column<Guid>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TaskSQLiteModel", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "UsuarioSQLiteModel",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    Nome = table.Column<string>(nullable: true),
                    IniciandoNoAplicativo = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UsuarioSQLiteModel", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "TaskSQLiteModel");

            migrationBuilder.DropTable(
                name: "UsuarioSQLiteModel");
        }
    }
}
