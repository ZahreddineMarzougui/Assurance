using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Assurance.Migrations
{
    public partial class init : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Branche",
                columns: table => new
                {
                    IdBranche = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    LibeleBranche = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CodeBranche = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Branche", x => x.IdBranche);
                });

            migrationBuilder.CreateTable(
                name: "Client",
                columns: table => new
                {
                    IdClient = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FirstName = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: false),
                    LastName = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: false),
                    CIN = table.Column<long>(type: "bigint", nullable: false),
                    Phone = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Address = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Country = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CodePostal = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Client", x => x.IdClient);
                });

            migrationBuilder.CreateTable(
                name: "TypeGarantie",
                columns: table => new
                {
                    IdTypeGa = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    LibeleTypeGa = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CodeTypeGa = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TypeGarantie", x => x.IdTypeGa);
                });

            migrationBuilder.CreateTable(
                name: "Contrat",
                columns: table => new
                {
                    IdContrat = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NContrat = table.Column<int>(type: "int", nullable: false),
                    DateAffect = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DateEcheance = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DateCreation = table.Column<DateTime>(type: "datetime2", nullable: false),
                    BrancheIdBranche = table.Column<int>(type: "int", nullable: true),
                    ClientIdClient = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Contrat", x => x.IdContrat);
                    table.ForeignKey(
                        name: "FK_Contrat_Branche_BrancheIdBranche",
                        column: x => x.BrancheIdBranche,
                        principalTable: "Branche",
                        principalColumn: "IdBranche",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Contrat_Client_ClientIdClient",
                        column: x => x.ClientIdClient,
                        principalTable: "Client",
                        principalColumn: "IdClient",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Garantie",
                columns: table => new
                {
                    IdGarantie = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    LibeleGarantie = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CodeGarantie = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    TypeGarantieIdTypeGa = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Garantie", x => x.IdGarantie);
                    table.ForeignKey(
                        name: "FK_Garantie_TypeGarantie_TypeGarantieIdTypeGa",
                        column: x => x.TypeGarantieIdTypeGa,
                        principalTable: "TypeGarantie",
                        principalColumn: "IdTypeGa",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "BrancheGarantie",
                columns: table => new
                {
                    BrancheIdBranche = table.Column<int>(type: "int", nullable: false),
                    GarantieIdGarantie = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BrancheGarantie", x => new { x.BrancheIdBranche, x.GarantieIdGarantie });
                    table.ForeignKey(
                        name: "FK_BrancheGarantie_Branche_BrancheIdBranche",
                        column: x => x.BrancheIdBranche,
                        principalTable: "Branche",
                        principalColumn: "IdBranche",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_BrancheGarantie_Garantie_GarantieIdGarantie",
                        column: x => x.GarantieIdGarantie,
                        principalTable: "Garantie",
                        principalColumn: "IdGarantie",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "TypeGarantie",
                columns: new[] { "IdTypeGa", "CodeTypeGa", "LibeleTypeGa" },
                values: new object[] { 1, "OBLIGATOIR", "Obligatoire" });

            migrationBuilder.InsertData(
                table: "TypeGarantie",
                columns: new[] { "IdTypeGa", "CodeTypeGa", "LibeleTypeGa" },
                values: new object[] { 2, "FACULTATIF", "Facultatif" });

            migrationBuilder.CreateIndex(
                name: "IX_BrancheGarantie_GarantieIdGarantie",
                table: "BrancheGarantie",
                column: "GarantieIdGarantie");

            migrationBuilder.CreateIndex(
                name: "IX_Contrat_BrancheIdBranche",
                table: "Contrat",
                column: "BrancheIdBranche");

            migrationBuilder.CreateIndex(
                name: "IX_Contrat_ClientIdClient",
                table: "Contrat",
                column: "ClientIdClient");

            migrationBuilder.CreateIndex(
                name: "IX_Garantie_TypeGarantieIdTypeGa",
                table: "Garantie",
                column: "TypeGarantieIdTypeGa");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "BrancheGarantie");

            migrationBuilder.DropTable(
                name: "Contrat");

            migrationBuilder.DropTable(
                name: "Garantie");

            migrationBuilder.DropTable(
                name: "Branche");

            migrationBuilder.DropTable(
                name: "Client");

            migrationBuilder.DropTable(
                name: "TypeGarantie");
        }
    }
}
