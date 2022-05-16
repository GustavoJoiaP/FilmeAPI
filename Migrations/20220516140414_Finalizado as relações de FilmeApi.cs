using Microsoft.EntityFrameworkCore.Migrations;

namespace FilmesAPI.Migrations
{
    public partial class FinalizadoasrelaçõesdeFilmeApi : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "TempoDuracao",
                table: "Sessoes",
                newName: "HorarioDeEncerramento");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "HorarioDeEncerramento",
                table: "Sessoes",
                newName: "TempoDuracao");
        }
    }
}
