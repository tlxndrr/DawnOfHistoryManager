using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace DawnOfHistoryManager.Migrations
{
    public partial class Iteration1Tables : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Advancements",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false),
                    Name = table.Column<string>(nullable: true),
                    BaseCost = table.Column<int>(nullable: false),
                    Points = table.Column<int>(nullable: false),
                    IsArt = table.Column<bool>(nullable: false),
                    IsCivic = table.Column<bool>(nullable: false),
                    IsCraft = table.Column<bool>(nullable: false),
                    IsReligion = table.Column<bool>(nullable: false),
                    IsScience = table.Column<bool>(nullable: false),
                    CreditArt = table.Column<int>(nullable: false),
                    CreditCivic = table.Column<int>(nullable: false),
                    CreditCraft = table.Column<int>(nullable: false),
                    CreditReligion = table.Column<int>(nullable: false),
                    CreditScience = table.Column<int>(nullable: false),
                    CreditAdvancementId = table.Column<int>(nullable: true),
                    CreditAdvancementValue = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Advancements", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Civs",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(nullable: true),
                    AstStone = table.Column<int>(nullable: false),
                    AstEarlyBronze = table.Column<int>(nullable: false),
                    AstLateBronze = table.Column<int>(nullable: false),
                    AstEarlyIron = table.Column<int>(nullable: false),
                    AstLateIron = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Civs", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Abilities",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    AdvancementId = table.Column<int>(nullable: false),
                    RulesText = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Abilities", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Abilities_Advancements_AdvancementId",
                        column: x => x.AdvancementId,
                        principalTable: "Advancements",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ActiveCivs",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    CivId = table.Column<int>(nullable: false),
                    GameName = table.Column<string>(nullable: true),
                    Cities = table.Column<int>(nullable: false),
                    AstPosition = table.Column<int>(nullable: false),
                    CurrentPhase = table.Column<int>(nullable: false),
                    SpendLimit = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ActiveCivs", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ActiveCivs_Civs_CivId",
                        column: x => x.CivId,
                        principalTable: "Civs",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "OwnedAdvancements",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    ActiveCivId = table.Column<int>(nullable: false),
                    AdvancementId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OwnedAdvancements", x => x.Id);
                    table.ForeignKey(
                        name: "FK_OwnedAdvancements_ActiveCivs_ActiveCivId",
                        column: x => x.ActiveCivId,
                        principalTable: "ActiveCivs",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_OwnedAdvancements_Advancements_AdvancementId",
                        column: x => x.AdvancementId,
                        principalTable: "Advancements",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Abilities_AdvancementId",
                table: "Abilities",
                column: "AdvancementId");

            migrationBuilder.CreateIndex(
                name: "IX_ActiveCivs_CivId",
                table: "ActiveCivs",
                column: "CivId");

            migrationBuilder.CreateIndex(
                name: "IX_OwnedAdvancements_ActiveCivId",
                table: "OwnedAdvancements",
                column: "ActiveCivId");

            migrationBuilder.CreateIndex(
                name: "IX_OwnedAdvancements_AdvancementId",
                table: "OwnedAdvancements",
                column: "AdvancementId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Abilities");

            migrationBuilder.DropTable(
                name: "OwnedAdvancements");

            migrationBuilder.DropTable(
                name: "ActiveCivs");

            migrationBuilder.DropTable(
                name: "Advancements");

            migrationBuilder.DropTable(
                name: "Civs");
        }
    }
}
