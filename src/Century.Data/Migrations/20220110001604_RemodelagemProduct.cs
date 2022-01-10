using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Century.Data.Migrations
{
    public partial class RemodelagemProduct : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Tb_Produtos_Tb_Categories_CategoryId",
                table: "Tb_Produtos");

            migrationBuilder.AlterColumn<Guid>(
                name: "CategoryId",
                table: "Tb_Produtos",
                type: "uniqueidentifier",
                nullable: true,
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier");

            migrationBuilder.AddForeignKey(
                name: "FK_Tb_Produtos_Tb_Categories_CategoryId",
                table: "Tb_Produtos",
                column: "CategoryId",
                principalTable: "Tb_Categories",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Tb_Produtos_Tb_Categories_CategoryId",
                table: "Tb_Produtos");

            migrationBuilder.AlterColumn<Guid>(
                name: "CategoryId",
                table: "Tb_Produtos",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"),
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Tb_Produtos_Tb_Categories_CategoryId",
                table: "Tb_Produtos",
                column: "CategoryId",
                principalTable: "Tb_Categories",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
