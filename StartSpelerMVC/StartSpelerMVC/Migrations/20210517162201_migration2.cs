using Microsoft.EntityFrameworkCore.Migrations;

namespace StartSpelerMVC.Migrations
{
    public partial class migration2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Inschrijving_Evenement_EvenementID",
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
                name: "FK_Product_ProductType_ProductTypeID",
                table: "Product");

            migrationBuilder.DropPrimaryKey(
                name: "PK_ProductType",
                table: "ProductType");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Product",
                table: "Product");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Inschrijving",
                table: "Inschrijving");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Evenement",
                table: "Evenement");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Drankkaart",
                table: "Drankkaart");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Bestelling",
                table: "Bestelling");

            migrationBuilder.DropColumn(
                name: "ProductType_ID",
                table: "ProductType");

            migrationBuilder.DropColumn(
                name: "Product_ID",
                table: "Product");

            migrationBuilder.DropColumn(
                name: "Inschrijving_ID",
                table: "Inschrijving");

            migrationBuilder.DropColumn(
                name: "Evenement_ID",
                table: "Evenement");

            migrationBuilder.DropColumn(
                name: "Drankkaart_ID",
                table: "Drankkaart");

            migrationBuilder.DropColumn(
                name: "Bestelling_ID",
                table: "Bestelling");

            migrationBuilder.AddColumn<int>(
                name: "ProductTypeID",
                table: "ProductType",
                nullable: false,
                defaultValue: 0)
                .Annotation("SqlServer:Identity", "1, 1");

            migrationBuilder.AddColumn<int>(
                name: "ProductID",
                table: "Product",
                nullable: false,
                defaultValue: 0)
                .Annotation("SqlServer:Identity", "1, 1");

            migrationBuilder.AddColumn<int>(
                name: "InschrijvingID",
                table: "Inschrijving",
                nullable: false,
                defaultValue: 0)
                .Annotation("SqlServer:Identity", "1, 1");

            migrationBuilder.AddColumn<int>(
                name: "EvenementID",
                table: "Evenement",
                nullable: false,
                defaultValue: 0)
                .Annotation("SqlServer:Identity", "1, 1");

            migrationBuilder.AddColumn<int>(
                name: "DrankkaartID",
                table: "Drankkaart",
                nullable: false,
                defaultValue: 0)
                .Annotation("SqlServer:Identity", "1, 1");

            migrationBuilder.AddColumn<int>(
                name: "BestellingID",
                table: "Bestelling",
                nullable: false,
                defaultValue: 0)
                .Annotation("SqlServer:Identity", "1, 1");

            migrationBuilder.AddPrimaryKey(
                name: "PK_ProductType",
                table: "ProductType",
                column: "ProductTypeID");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Product",
                table: "Product",
                column: "ProductID");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Inschrijving",
                table: "Inschrijving",
                column: "InschrijvingID");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Evenement",
                table: "Evenement",
                column: "EvenementID");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Drankkaart",
                table: "Drankkaart",
                column: "DrankkaartID");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Bestelling",
                table: "Bestelling",
                column: "BestellingID");

            migrationBuilder.AddForeignKey(
                name: "FK_Inschrijving_Evenement_EvenementID",
                table: "Inschrijving",
                column: "EvenementID",
                principalTable: "Evenement",
                principalColumn: "EvenementID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Orderlijn_Bestelling_BestellingID",
                table: "Orderlijn",
                column: "BestellingID",
                principalTable: "Bestelling",
                principalColumn: "BestellingID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Orderlijn_Product_ProductID",
                table: "Orderlijn",
                column: "ProductID",
                principalTable: "Product",
                principalColumn: "ProductID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Persoon_Drankkaart_DrankkaartID",
                table: "Persoon",
                column: "DrankkaartID",
                principalTable: "Drankkaart",
                principalColumn: "DrankkaartID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Product_ProductType_ProductTypeID",
                table: "Product",
                column: "ProductTypeID",
                principalTable: "ProductType",
                principalColumn: "ProductTypeID",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Inschrijving_Evenement_EvenementID",
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
                name: "FK_Product_ProductType_ProductTypeID",
                table: "Product");

            migrationBuilder.DropPrimaryKey(
                name: "PK_ProductType",
                table: "ProductType");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Product",
                table: "Product");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Inschrijving",
                table: "Inschrijving");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Evenement",
                table: "Evenement");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Drankkaart",
                table: "Drankkaart");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Bestelling",
                table: "Bestelling");

            migrationBuilder.DropColumn(
                name: "ProductTypeID",
                table: "ProductType");

            migrationBuilder.DropColumn(
                name: "ProductID",
                table: "Product");

            migrationBuilder.DropColumn(
                name: "InschrijvingID",
                table: "Inschrijving");

            migrationBuilder.DropColumn(
                name: "EvenementID",
                table: "Evenement");

            migrationBuilder.DropColumn(
                name: "DrankkaartID",
                table: "Drankkaart");

            migrationBuilder.DropColumn(
                name: "BestellingID",
                table: "Bestelling");

            migrationBuilder.AddColumn<int>(
                name: "ProductType_ID",
                table: "ProductType",
                type: "int",
                nullable: false,
                defaultValue: 0)
                .Annotation("SqlServer:Identity", "1, 1");

            migrationBuilder.AddColumn<int>(
                name: "Product_ID",
                table: "Product",
                type: "int",
                nullable: false,
                defaultValue: 0)
                .Annotation("SqlServer:Identity", "1, 1");

            migrationBuilder.AddColumn<int>(
                name: "Inschrijving_ID",
                table: "Inschrijving",
                type: "int",
                nullable: false,
                defaultValue: 0)
                .Annotation("SqlServer:Identity", "1, 1");

            migrationBuilder.AddColumn<int>(
                name: "Evenement_ID",
                table: "Evenement",
                type: "int",
                nullable: false,
                defaultValue: 0)
                .Annotation("SqlServer:Identity", "1, 1");

            migrationBuilder.AddColumn<int>(
                name: "Drankkaart_ID",
                table: "Drankkaart",
                type: "int",
                nullable: false,
                defaultValue: 0)
                .Annotation("SqlServer:Identity", "1, 1");

            migrationBuilder.AddColumn<int>(
                name: "Bestelling_ID",
                table: "Bestelling",
                type: "int",
                nullable: false,
                defaultValue: 0)
                .Annotation("SqlServer:Identity", "1, 1");

            migrationBuilder.AddPrimaryKey(
                name: "PK_ProductType",
                table: "ProductType",
                column: "ProductType_ID");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Product",
                table: "Product",
                column: "Product_ID");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Inschrijving",
                table: "Inschrijving",
                column: "Inschrijving_ID");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Evenement",
                table: "Evenement",
                column: "Evenement_ID");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Drankkaart",
                table: "Drankkaart",
                column: "Drankkaart_ID");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Bestelling",
                table: "Bestelling",
                column: "Bestelling_ID");

            migrationBuilder.AddForeignKey(
                name: "FK_Inschrijving_Evenement_EvenementID",
                table: "Inschrijving",
                column: "EvenementID",
                principalTable: "Evenement",
                principalColumn: "Evenement_ID",
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
                name: "FK_Product_ProductType_ProductTypeID",
                table: "Product",
                column: "ProductTypeID",
                principalTable: "ProductType",
                principalColumn: "ProductType_ID",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
