using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace StartSpelerMVC.Migrations
{
    public partial class InitialCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "AspNetRoles",
                columns: table => new
                {
                    Id = table.Column<string>(nullable: false),
                    Name = table.Column<string>(maxLength: 256, nullable: true),
                    NormalizedName = table.Column<string>(maxLength: 256, nullable: true),
                    ConcurrencyStamp = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetRoles", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUsers",
                columns: table => new
                {
                    Id = table.Column<string>(nullable: false),
                    UserName = table.Column<string>(maxLength: 256, nullable: true),
                    NormalizedUserName = table.Column<string>(maxLength: 256, nullable: true),
                    Email = table.Column<string>(maxLength: 256, nullable: true),
                    NormalizedEmail = table.Column<string>(maxLength: 256, nullable: true),
                    EmailConfirmed = table.Column<bool>(nullable: false),
                    PasswordHash = table.Column<string>(nullable: true),
                    SecurityStamp = table.Column<string>(nullable: true),
                    ConcurrencyStamp = table.Column<string>(nullable: true),
                    PhoneNumber = table.Column<string>(nullable: true),
                    PhoneNumberConfirmed = table.Column<bool>(nullable: false),
                    TwoFactorEnabled = table.Column<bool>(nullable: false),
                    LockoutEnd = table.Column<DateTimeOffset>(nullable: true),
                    LockoutEnabled = table.Column<bool>(nullable: false),
                    AccessFailedCount = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUsers", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Drankkaart",
                columns: table => new
                {
                    Drankkaart_ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Prijs = table.Column<decimal>(type: "Decimal(5,2)", nullable: false),
                    AantalSlots = table.Column<byte>(nullable: false),
                    Begindatum = table.Column<DateTime>(nullable: false),
                    IsBetaald = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Drankkaart", x => x.Drankkaart_ID);
                });

            migrationBuilder.CreateTable(
                name: "Evenement",
                columns: table => new
                {
                    Evenement_ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    MaxDeelnemers = table.Column<byte>(nullable: false),
                    Beschrijving = table.Column<string>(maxLength: 255, nullable: true),
                    Startuur = table.Column<DateTime>(nullable: false),
                    Einduur = table.Column<DateTime>(nullable: false),
                    Datum = table.Column<DateTime>(nullable: false),
                    Prijs = table.Column<decimal>(type: "Decimal(5,2)", nullable: false),
                    IsZichtbaar = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Evenement", x => x.Evenement_ID);
                });

            migrationBuilder.CreateTable(
                name: "ProductType",
                columns: table => new
                {
                    ProductType_ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Naam = table.Column<string>(maxLength: 20, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProductType", x => x.ProductType_ID);
                });

            migrationBuilder.CreateTable(
                name: "AspNetRoleClaims",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RoleId = table.Column<string>(nullable: false),
                    ClaimType = table.Column<string>(nullable: true),
                    ClaimValue = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetRoleClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AspNetRoleClaims_AspNetRoles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "AspNetRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserClaims",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<string>(nullable: false),
                    ClaimType = table.Column<string>(nullable: true),
                    ClaimValue = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AspNetUserClaims_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserLogins",
                columns: table => new
                {
                    LoginProvider = table.Column<string>(nullable: false),
                    ProviderKey = table.Column<string>(nullable: false),
                    ProviderDisplayName = table.Column<string>(nullable: true),
                    UserId = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserLogins", x => new { x.LoginProvider, x.ProviderKey });
                    table.ForeignKey(
                        name: "FK_AspNetUserLogins_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserRoles",
                columns: table => new
                {
                    UserId = table.Column<string>(nullable: false),
                    RoleId = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserRoles", x => new { x.UserId, x.RoleId });
                    table.ForeignKey(
                        name: "FK_AspNetUserRoles_AspNetRoles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "AspNetRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AspNetUserRoles_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserTokens",
                columns: table => new
                {
                    UserId = table.Column<string>(nullable: false),
                    LoginProvider = table.Column<string>(nullable: false),
                    Name = table.Column<string>(nullable: false),
                    Value = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserTokens", x => new { x.UserId, x.LoginProvider, x.Name });
                    table.ForeignKey(
                        name: "FK_AspNetUserTokens_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Persoon",
                columns: table => new
                {
                    Persoon_ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Voornaam = table.Column<string>(maxLength: 50, nullable: false),
                    Achternaam = table.Column<string>(maxLength: 50, nullable: false),
                    Username = table.Column<string>(maxLength: 20, nullable: false),
                    Geboortedatum = table.Column<DateTime>(nullable: false),
                    Email = table.Column<string>(nullable: false),
                    Wachtwoord = table.Column<string>(maxLength: 4, nullable: false),
                    IsActief = table.Column<bool>(nullable: false),
                    IsAdmin = table.Column<bool>(nullable: false),
                    Drankkaart_ID = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Persoon", x => x.Persoon_ID);
                    table.ForeignKey(
                        name: "FK_Persoon_Drankkaart_Drankkaart_ID",
                        column: x => x.Drankkaart_ID,
                        principalTable: "Drankkaart",
                        principalColumn: "Drankkaart_ID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Product",
                columns: table => new
                {
                    Product_ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Naam = table.Column<int>(maxLength: 50, nullable: false),
                    ProductType_ID = table.Column<int>(nullable: true),
                    Aantal = table.Column<int>(nullable: false),
                    StartDatum = table.Column<DateTime>(nullable: false),
                    EindDatum = table.Column<DateTime>(nullable: false),
                    AankoopPrijs = table.Column<decimal>(type: "Decimal(5,2)", nullable: false),
                    VerkoopPrijs = table.Column<decimal>(type: "Decimal(5,2)", nullable: false),
                    Slotwaarde = table.Column<byte>(nullable: false),
                    Alcoholpercentage = table.Column<float>(nullable: false),
                    Aantal_in_stock = table.Column<int>(nullable: false),
                    Aantal_in_Frigo = table.Column<int>(nullable: false),
                    IsZichtbaar = table.Column<bool>(nullable: false),
                    Product_ID1 = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Product", x => x.Product_ID);
                    table.ForeignKey(
                        name: "FK_Product_ProductType_ProductType_ID",
                        column: x => x.ProductType_ID,
                        principalTable: "ProductType",
                        principalColumn: "ProductType_ID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Product_Product_Product_ID1",
                        column: x => x.Product_ID1,
                        principalTable: "Product",
                        principalColumn: "Product_ID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Bestelling",
                columns: table => new
                {
                    Bestelling_ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Persoon_ID = table.Column<int>(nullable: true),
                    Prijs = table.Column<decimal>(type: "Decimal(5,2)", nullable: false),
                    Datum = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Bestelling", x => x.Bestelling_ID);
                    table.ForeignKey(
                        name: "FK_Bestelling_Persoon_Persoon_ID",
                        column: x => x.Persoon_ID,
                        principalTable: "Persoon",
                        principalColumn: "Persoon_ID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Inschrijving",
                columns: table => new
                {
                    Inschrijving_ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Evenement_ID = table.Column<int>(nullable: true),
                    PersonenPersoon_ID = table.Column<int>(nullable: true),
                    Datum = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Inschrijving", x => x.Inschrijving_ID);
                    table.ForeignKey(
                        name: "FK_Inschrijving_Evenement_Evenement_ID",
                        column: x => x.Evenement_ID,
                        principalTable: "Evenement",
                        principalColumn: "Evenement_ID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Inschrijving_Persoon_PersonenPersoon_ID",
                        column: x => x.PersonenPersoon_ID,
                        principalTable: "Persoon",
                        principalColumn: "Persoon_ID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Orderlijn",
                columns: table => new
                {
                    Orderlijn_ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ProductenProduct_ID = table.Column<int>(nullable: true),
                    Bestelling_ID = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Orderlijn", x => x.Orderlijn_ID);
                    table.ForeignKey(
                        name: "FK_Orderlijn_Bestelling_Bestelling_ID",
                        column: x => x.Bestelling_ID,
                        principalTable: "Bestelling",
                        principalColumn: "Bestelling_ID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Orderlijn_Product_ProductenProduct_ID",
                        column: x => x.ProductenProduct_ID,
                        principalTable: "Product",
                        principalColumn: "Product_ID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_AspNetRoleClaims_RoleId",
                table: "AspNetRoleClaims",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "RoleNameIndex",
                table: "AspNetRoles",
                column: "NormalizedName",
                unique: true,
                filter: "[NormalizedName] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserClaims_UserId",
                table: "AspNetUserClaims",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserLogins_UserId",
                table: "AspNetUserLogins",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserRoles_RoleId",
                table: "AspNetUserRoles",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "EmailIndex",
                table: "AspNetUsers",
                column: "NormalizedEmail");

            migrationBuilder.CreateIndex(
                name: "UserNameIndex",
                table: "AspNetUsers",
                column: "NormalizedUserName",
                unique: true,
                filter: "[NormalizedUserName] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_Bestelling_Persoon_ID",
                table: "Bestelling",
                column: "Persoon_ID");

            migrationBuilder.CreateIndex(
                name: "IX_Inschrijving_Evenement_ID",
                table: "Inschrijving",
                column: "Evenement_ID");

            migrationBuilder.CreateIndex(
                name: "IX_Inschrijving_PersonenPersoon_ID",
                table: "Inschrijving",
                column: "PersonenPersoon_ID");

            migrationBuilder.CreateIndex(
                name: "IX_Orderlijn_Bestelling_ID",
                table: "Orderlijn",
                column: "Bestelling_ID");

            migrationBuilder.CreateIndex(
                name: "IX_Orderlijn_ProductenProduct_ID",
                table: "Orderlijn",
                column: "ProductenProduct_ID");

            migrationBuilder.CreateIndex(
                name: "IX_Persoon_Drankkaart_ID",
                table: "Persoon",
                column: "Drankkaart_ID");

            migrationBuilder.CreateIndex(
                name: "IX_Product_ProductType_ID",
                table: "Product",
                column: "ProductType_ID");

            migrationBuilder.CreateIndex(
                name: "IX_Product_Product_ID1",
                table: "Product",
                column: "Product_ID1");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AspNetRoleClaims");

            migrationBuilder.DropTable(
                name: "AspNetUserClaims");

            migrationBuilder.DropTable(
                name: "AspNetUserLogins");

            migrationBuilder.DropTable(
                name: "AspNetUserRoles");

            migrationBuilder.DropTable(
                name: "AspNetUserTokens");

            migrationBuilder.DropTable(
                name: "Inschrijving");

            migrationBuilder.DropTable(
                name: "Orderlijn");

            migrationBuilder.DropTable(
                name: "AspNetRoles");

            migrationBuilder.DropTable(
                name: "AspNetUsers");

            migrationBuilder.DropTable(
                name: "Evenement");

            migrationBuilder.DropTable(
                name: "Bestelling");

            migrationBuilder.DropTable(
                name: "Product");

            migrationBuilder.DropTable(
                name: "Persoon");

            migrationBuilder.DropTable(
                name: "ProductType");

            migrationBuilder.DropTable(
                name: "Drankkaart");
        }
    }
}
