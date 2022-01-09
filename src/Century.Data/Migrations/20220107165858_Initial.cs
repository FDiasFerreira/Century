using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Century.Data.Migrations
{
    public partial class Initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Tb_Categories",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ProductId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Active = table.Column<bool>(type: "bit", nullable: false),
                    Name = table.Column<string>(type: "varchar(200)", nullable: false),
                    Product = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    InsertDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdateDate = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Tb_Categories", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Tb_Suppliers",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Active = table.Column<string>(type: "varchar(200)", nullable: false),
                    FantasyName = table.Column<string>(type: "varchar(200)", nullable: false),
                    Name = table.Column<string>(type: "varchar(200)", nullable: false),
                    SupplierType = table.Column<string>(type: "varchar(200)", nullable: false),
                    Document = table.Column<string>(type: "varchar(14)", nullable: false),
                    BirthDate = table.Column<string>(type: "varchar(200)", nullable: false),
                    InsertDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdateDate = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Tb_Suppliers", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Tb_Addresses",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    SupplierId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ZipCode = table.Column<string>(type: "varchar(8)", nullable: false),
                    Street = table.Column<string>(type: "varchar(200)", nullable: false),
                    Number = table.Column<string>(type: "varchar(10)", nullable: false),
                    Complement = table.Column<string>(type: "varchar(200)", nullable: true),
                    Reference = table.Column<string>(type: "varchar(200)", nullable: true),
                    Neighborhood = table.Column<string>(type: "varchar(50)", nullable: false),
                    City = table.Column<string>(type: "varchar(50)", nullable: false),
                    State = table.Column<string>(type: "varchar(50)", nullable: false),
                    InsertDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdateDate = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Tb_Addresses", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Tb_Addresses_Tb_Suppliers_SupplierId",
                        column: x => x.SupplierId,
                        principalTable: "Tb_Suppliers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Tb_E-mails",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    SupplierId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    EmailAddress = table.Column<string>(type: "varchar(100)", nullable: false),
                    InsertDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdateDate = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Tb_E-mails", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Tb_E-mails_Tb_Suppliers_SupplierId",
                        column: x => x.SupplierId,
                        principalTable: "Tb_Suppliers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Tb_Phones",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    SupplierId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Ddd = table.Column<string>(type: "varchar(2)", nullable: false),
                    Number = table.Column<string>(type: "varchar(9)", nullable: false),
                    InsertDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdateDate = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Tb_Phones", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Tb_Phones_Tb_Suppliers_SupplierId",
                        column: x => x.SupplierId,
                        principalTable: "Tb_Suppliers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Tb_Produtos",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    SupplierId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CategoryId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "varchar(200)", nullable: false),
                    BarCode = table.Column<string>(type: "varchar(13)", nullable: false),
                    QuantityStock = table.Column<string>(type: "varchar(200)", nullable: false),
                    Active = table.Column<bool>(type: "bit", nullable: false),
                    PriceSales = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    PricePurchase = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    ImagePath = table.Column<string>(type: "varchar(200)", nullable: false),
                    InsertDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdateDate = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Tb_Produtos", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Tb_Produtos_Tb_Categories_CategoryId",
                        column: x => x.CategoryId,
                        principalTable: "Tb_Categories",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Tb_Produtos_Tb_Suppliers_SupplierId",
                        column: x => x.SupplierId,
                        principalTable: "Tb_Suppliers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Tb_Addresses_SupplierId",
                table: "Tb_Addresses",
                column: "SupplierId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Tb_E-mails_SupplierId",
                table: "Tb_E-mails",
                column: "SupplierId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Tb_Phones_SupplierId",
                table: "Tb_Phones",
                column: "SupplierId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Tb_Produtos_CategoryId",
                table: "Tb_Produtos",
                column: "CategoryId");

            migrationBuilder.CreateIndex(
                name: "IX_Tb_Produtos_SupplierId",
                table: "Tb_Produtos",
                column: "SupplierId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Tb_Addresses");

            migrationBuilder.DropTable(
                name: "Tb_E-mails");

            migrationBuilder.DropTable(
                name: "Tb_Phones");

            migrationBuilder.DropTable(
                name: "Tb_Produtos");

            migrationBuilder.DropTable(
                name: "Tb_Categories");

            migrationBuilder.DropTable(
                name: "Tb_Suppliers");
        }
    }
}
