using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace vanb.Migrations
{
    public partial class remove_complex_key : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_TecajiRazmjene_BrojTecajnice_SifraValute",
                table: "TecajiRazmjene");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateIndex(
                name: "IX_TecajiRazmjene_BrojTecajnice_SifraValute",
                table: "TecajiRazmjene",
                columns: new[] { "BrojTecajnice", "SifraValute" },
                unique: true);
        }
    }
}
