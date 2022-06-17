using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace miniProjet.Migrations
{
    public partial class InitialCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Entreprises",
                columns: table => new
                {
                    EntrepriseID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    EntrepriseName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    EntrepriseAdress = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Entreprises", x => x.EntrepriseID);
                });

            migrationBuilder.CreateTable(
                name: "Employes",
                columns: table => new
                {
                    EmployeId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    EmployeName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Age = table.Column<int>(type: "int", nullable: false),
                    BirthDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    EntrepriseID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Employes", x => x.EmployeId);
                    table.ForeignKey(
                        name: "FK_Employes_Entreprises_EntrepriseID",
                        column: x => x.EntrepriseID,
                        principalTable: "Entreprises",
                        principalColumn: "EntrepriseID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Employes_EntrepriseID",
                table: "Employes",
                column: "EntrepriseID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Employes");

            migrationBuilder.DropTable(
                name: "Entreprises");
        }
    }
}
