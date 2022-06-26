using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace vanb.Migrations
{
    public partial class InitialCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "TecajiRazmjene",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "TEXT", nullable: false),
                    DatumPrimjene = table.Column<string>(type: "TEXT", nullable: true),
                    BrojTecajnice = table.Column<string>(type: "TEXT", nullable: true),
                    Drzava = table.Column<string>(type: "TEXT", nullable: true),
                    DrzavaIso = table.Column<string>(type: "TEXT", nullable: true),
                    SifraValute = table.Column<string>(type: "TEXT", nullable: true),
                    Valuta = table.Column<string>(type: "TEXT", nullable: true),
                    Jedinica = table.Column<string>(type: "TEXT", nullable: true),
                    SrednjiTecaj = table.Column<string>(type: "TEXT", nullable: true),
                    ProdajniTecaj = table.Column<string>(type: "TEXT", nullable: true),
                    KupovniTecaj = table.Column<string>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TecajiRazmjene", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "TecajiRazmjene");
        }
    }
}
