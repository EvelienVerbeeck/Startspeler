using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace StartSpelerMVC.Migrations
{
    public partial class Migration5 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Bestelling_Persoon_Persoon_ID",
                table: "Bestelling");

            migrationBuilder.DropForeignKey(
                name: "FK_Inschrijving_Evenement_Evenement_ID",
                table: "Inschrijving");

            migrationBuilder.DropForeignKey(
                name: "FK_Inschrijving_Persoon_PersonenPersoon_ID",
                table: "Inschrijving");

            migrationBuilder.DropForeignKey(
                name: "FK_Orderlijn_Bestelling_Bestelling_ID",
                table: "Orderlijn");

            migrationBuilder.DropForeignKey(
                name: "FK_Orderlijn_Product_ProductenProduct_ID",
                table: "Orderlijn");

            migrationBuilder.DropForeignKey(
                name: "FK_Persoon_Drankkaart_Drankkaart_ID",
                table: "Persoon");

            migrationBuilder.DropForeignKey(
                name: "FK_Product_ProductType_ProductType_ID",
                table: "Product");

            migrationBuilder.DropForeignKey(
                name: "FK_Product_Product_Product_ID1",
                table: "Product");

            migrationBuilder.DropIndex(
                name: "IX_Product_ProductType_ID",
                table: "Product");

            migrationBuilder.DropIndex(
                name: "IX_Product_Product_ID1",
                table: "Product");

            migrationBuilder.DropIndex(
                name: "IX_Persoon_Drankkaart_ID",
                table: "Persoon");

            migrationBuilder.DropIndex(
                name: "IX_Orderlijn_Bestelling_ID",
                table: "Orderlijn");

            migrationBuilder.DropIndex(
                name: "IX_Orderlijn_ProductenProduct_ID",
                table: "Orderlijn");

            migrationBuilder.DropIndex(
                name: "IX_Inschrijving_Evenement_ID",
                table: "Inschrijving");

            migrationBuilder.DropIndex(
                name: "IX_Inschrijving_PersonenPersoon_ID",
                table: "Inschrijving");

            migrationBuilder.DropIndex(
                name: "IX_Bestelling_Persoon_ID",
                table: "Bestelling");

            migrationBuilder.DropColumn(
                name: "ProductType_ID",
                table: "Product");

            migrationBuilder.DropColumn(
                name: "Product_ID1",
                table: "Product");

            migrationBuilder.DropColumn(
                name: "Drankkaart_ID",
                table: "Persoon");

            migrationBuilder.DropColumn(
                name: "Bestelling_ID",
                table: "Orderlijn");

            migrationBuilder.DropColumn(
                name: "ProductenProduct_ID",
                table: "Orderlijn");

            migrationBuilder.DropColumn(
                name: "Evenement_ID",
                table: "Inschrijving");

            migrationBuilder.DropColumn(
                name: "PersonenPersoon_ID",
                table: "Inschrijving");

            migrationBuilder.DropColumn(
                name: "Persoon_ID",
                table: "Bestelling");

            migrationBuilder.AddColumn<int>(
                name: "ProductTypeID",
                table: "Product",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<DateTime>(
                name: "AangemaaktDatum",
                table: "Persoon",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<int>(
                name: "DrankkaartID",
                table: "Persoon",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "UserID",
                table: "Persoon",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "BestellingID",
                table: "Orderlijn",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "ProductID",
                table: "Orderlijn",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "EvenementID",
                table: "Inschrijving",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "PersoonID",
                table: "Inschrijving",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "PersoonID",
                table: "Bestelling",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "AspNetUserTokens",
                maxLength: 128,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)");

            migrationBuilder.AlterColumn<string>(
                name: "LoginProvider",
                table: "AspNetUserTokens",
                maxLength: 128,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)");

            migrationBuilder.AlterColumn<string>(
                name: "ProviderKey",
                table: "AspNetUserLogins",
                maxLength: 128,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)");

            migrationBuilder.AlterColumn<string>(
                name: "LoginProvider",
                table: "AspNetUserLogins",
                maxLength: 128,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)");

            migrationBuilder.CreateIndex(
                name: "IX_Product_ProductTypeID",
                table: "Product",
                column: "ProductTypeID");

            migrationBuilder.CreateIndex(
                name: "IX_Persoon_DrankkaartID",
                table: "Persoon",
                column: "DrankkaartID");

            migrationBuilder.CreateIndex(
                name: "IX_Persoon_UserID",
                table: "Persoon",
                column: "UserID",
                unique: true,
                filter: "[UserID] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_Orderlijn_BestellingID",
                table: "Orderlijn",
                column: "BestellingID");

            migrationBuilder.CreateIndex(
                name: "IX_Orderlijn_ProductID",
                table: "Orderlijn",
                column: "ProductID");

            migrationBuilder.CreateIndex(
                name: "IX_Inschrijving_EvenementID",
                table: "Inschrijving",
                column: "EvenementID");

            migrationBuilder.CreateIndex(
                name: "IX_Inschrijving_PersoonID",
                table: "Inschrijving",
                column: "PersoonID");

            migrationBuilder.CreateIndex(
                name: "IX_Bestelling_PersoonID",
                table: "Bestelling",
                column: "PersoonID");

            migrationBuilder.AddForeignKey(
                name: "FK_Bestelling_Persoon_PersoonID",
                table: "Bestelling",
                column: "PersoonID",
                principalTable: "Persoon",
                principalColumn: "Persoon_ID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Inschrijving_Evenement_EvenementID",
                table: "Inschrijving",
                column: "EvenementID",
                principalTable: "Evenement",
                principalColumn: "Evenement_ID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Inschrijving_Persoon_PersoonID",
                table: "Inschrijving",
                column: "PersoonID",
                principalTable: "Persoon",
                principalColumn: "Persoon_ID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Orderlijn_Bestelling_BestellingID",
                table: "Orderlijn",
                column: "BestellingID",
                principalTable: "Bestelling",
                principalColumn: "Bestelling_ID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Orderlijn_Product_ProductID",
                table: "Orderlijn",
                column: "ProductID",
                principalTable: "Product",
                principalColumn: "Product_ID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Persoon_Drankkaart_DrankkaartID",
                table: "Persoon",
                column: "DrankkaartID",
                principalTable: "Drankkaart",
                principalColumn: "Drankkaart_ID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Persoon_AspNetUsers_UserID",
                table: "Persoon",
                column: "UserID",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Product_ProductType_ProductTypeID",
                table: "Product",
                column: "ProductTypeID",
                principalTable: "ProductType",
                principalColumn: "ProductType_ID",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Bestelling_Persoon_PersoonID",
                table: "Bestelling");

            migrationBuilder.DropForeignKey(
                name: "FK_Inschrijving_Evenement_EvenementID",
                table: "Inschrijving");

            migrationBuilder.DropForeignKey(
                name: "FK_Inschrijving_Persoon_PersoonID",
                table: "Inschrijving");

            migrationBuilder.DropForeignKey(
                name: "FK_Orderlijn_Bestelling_BestellingID",
                table: "Orderlijn");

            migrationBuilder.DropForeignKey(
                name: "FK_Orderlijn_Product_ProductID",
                table: "Orderlijn");

            migrationBuilder.DropForeignKey(
                name: "FK_Persoon_Drankkaart_DrankkaartID",
                table: "Persoon");

            migrationBuilder.DropForeignKey(
                name: "FK_Persoon_AspNetUsers_UserID",
                table: "Persoon");

            migrationBuilder.DropForeignKey(
                name: "FK_Product_ProductType_ProductTypeID",
                table: "Product");

            migrationBuilder.DropIndex(
                name: "IX_Product_ProductTypeID",
                table: "Product");

            migrationBuilder.DropIndex(
                name: "IX_Persoon_DrankkaartID",
                table: "Persoon");

            migrationBuilder.DropIndex(
                name: "IX_Persoon_UserID",
                table: "Persoon");

            migrationBuilder.DropIndex(
                name: "IX_Orderlijn_BestellingID",
                table: "Orderlijn");

            migrationBuilder.DropIndex(
                name: "IX_Orderlijn_ProductID",
                table: "Orderlijn");

            migrationBuilder.DropIndex(
                name: "IX_Inschrijving_EvenementID",
                table: "Inschrijving");

            migrationBuilder.DropIndex(
                name: "IX_Inschrijving_PersoonID",
                table: "Inschrijving");

            migrationBuilder.DropIndex(
                name: "IX_Bestelling_PersoonID",
                table: "Bestelling");

            migrationBuilder.DropColumn(
                name: "ProductTypeID",
                table: "Product");

            migrationBuilder.DropColumn(
                name: "AangemaaktDatum",
                table: "Persoon");

            migrationBuilder.DropColumn(
                name: "DrankkaartID",
                table: "Persoon");

            migrationBuilder.DropColumn(
                name: "UserID",
                table: "Persoon");

            migrationBuilder.DropColumn(
                name: "BestellingID",
                table: "Orderlijn");

            migrationBuilder.DropColumn(
                name: "ProductID",
                table: "Orderlijn");

            migrationBuilder.DropColumn(
                name: "EvenementID",
                table: "Inschrijving");

            migrationBuilder.DropColumn(
                name: "PersoonID",
                table: "Inschrijving");

            migrationBuilder.DropColumn(
                name: "PersoonID",
                table: "Bestelling");

            migrationBuilder.AddColumn<int>(
                name: "ProductType_ID",
                table: "Product",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "Product_ID1",
                table: "Product",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "Drankkaart_ID",
                table: "Persoon",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "Bestelling_ID",
                table: "Orderlijn",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "ProductenProduct_ID",
                table: "Orderlijn",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "Evenement_ID",
                table: "Inschrijving",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "PersonenPersoon_ID",
                table: "Inschrijving",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "Persoon_ID",
                table: "Bestelling",
                type: "int",
                nullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "AspNetUserTokens",
                type: "nvarchar(450)",
                nullable: false,
                oldClrType: typeof(string),
                oldMaxLength: 128);

            migrationBuilder.AlterColumn<string>(
                name: "LoginProvider",
                table: "AspNetUserTokens",
                type: "nvarchar(450)",
                nullable: false,
                oldClrType: typeof(string),
                oldMaxLength: 128);

            migrationBuilder.AlterColumn<string>(
                name: "ProviderKey",
                table: "AspNetUserLogins",
                type: "nvarchar(450)",
                nullable: false,
                oldClrType: typeof(string),
                oldMaxLength: 128);

            migrationBuilder.AlterColumn<string>(
                name: "LoginProvider",
                table: "AspNetUserLogins",
                type: "nvarchar(450)",
                nullable: false,
                oldClrType: typeof(string),
                oldMaxLength: 128);

            migrationBuilder.CreateIndex(
                name: "IX_Product_ProductType_ID",
                table: "Product",
                column: "ProductType_ID");

            migrationBuilder.CreateIndex(
                name: "IX_Product_Product_ID1",
                table: "Product",
                column: "Product_ID1");

            migrationBuilder.CreateIndex(
                name: "IX_Persoon_Drankkaart_ID",
                table: "Persoon",
                column: "Drankkaart_ID");

            migrationBuilder.CreateIndex(
                name: "IX_Orderlijn_Bestelling_ID",
                table: "Orderlijn",
                column: "Bestelling_ID");

            migrationBuilder.CreateIndex(
                name: "IX_Orderlijn_ProductenProduct_ID",
                table: "Orderlijn",
                column: "ProductenProduct_ID");

            migrationBuilder.CreateIndex(
                name: "IX_Inschrijving_Evenement_ID",
                table: "Inschrijving",
                column: "Evenement_ID");

            migrationBuilder.CreateIndex(
                name: "IX_Inschrijving_PersonenPersoon_ID",
                table: "Inschrijving",
                column: "PersonenPersoon_ID");

            migrationBuilder.CreateIndex(
                name: "IX_Bestelling_Persoon_ID",
                table: "Bestelling",
                column: "Persoon_ID");

            migrationBuilder.AddForeignKey(
                name: "FK_Bestelling_Persoon_Persoon_ID",
                table: "Bestelling",
                column: "Persoon_ID",
                principalTable: "Persoon",
                principalColumn: "Persoon_ID",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Inschrijving_Evenement_Evenement_ID",
                table: "Inschrijving",
                column: "Evenement_ID",
                principalTable: "Evenement",
                principalColumn: "Evenement_ID",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Inschrijving_Persoon_PersonenPersoon_ID",
                table: "Inschrijving",
                column: "PersonenPersoon_ID",
                principalTable: "Persoon",
                principalColumn: "Persoon_ID",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Orderlijn_Bestelling_Bestelling_ID",
                table: "Orderlijn",
                column: "Bestelling_ID",
                principalTable: "Bestelling",
                principalColumn: "Bestelling_ID",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Orderlijn_Product_ProductenProduct_ID",
                table: "Orderlijn",
                column: "ProductenProduct_ID",
                principalTable: "Product",
                principalColumn: "Product_ID",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Persoon_Drankkaart_Drankkaart_ID",
                table: "Persoon",
                column: "Drankkaart_ID",
                principalTable: "Drankkaart",
                principalColumn: "Drankkaart_ID",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Product_ProductType_ProductType_ID",
                table: "Product",
                column: "ProductType_ID",
                principalTable: "ProductType",
                principalColumn: "ProductType_ID",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Product_Product_Product_ID1",
                table: "Product",
                column: "Product_ID1",
                principalTable: "Product",
                principalColumn: "Product_ID",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
