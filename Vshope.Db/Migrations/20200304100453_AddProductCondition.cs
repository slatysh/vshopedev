using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Vshope.Db.Migrations
{
    public partial class AddProductCondition : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "ProductConditionId",
                table: "Companies",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "ProductConditions",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    IsDeleted = table.Column<bool>(nullable: false),
                    CreatedDate = table.Column<DateTimeOffset>(nullable: false),
                    ModifiedDate = table.Column<DateTimeOffset>(nullable: false),
                    Name = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProductConditions", x => x.Id);
                });

            migrationBuilder.InsertData(
                table: "ProductConditions",
                columns: new[] { "Id", "CreatedDate", "IsDeleted", "ModifiedDate", "Name" },
                values: new object[] { 1, new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), false, new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), "Новый" });

            migrationBuilder.InsertData(
                table: "ProductConditions",
                columns: new[] { "Id", "CreatedDate", "IsDeleted", "ModifiedDate", "Name" },
                values: new object[] { 2, new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), false, new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), "Б/у" });

            migrationBuilder.CreateIndex(
                name: "IX_Companies_ProductConditionId",
                table: "Companies",
                column: "ProductConditionId");

            migrationBuilder.AddForeignKey(
                name: "FK_Companies_ProductConditions_ProductConditionId",
                table: "Companies",
                column: "ProductConditionId",
                principalTable: "ProductConditions",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Companies_ProductConditions_ProductConditionId",
                table: "Companies");

            migrationBuilder.DropTable(
                name: "ProductConditions");

            migrationBuilder.DropIndex(
                name: "IX_Companies_ProductConditionId",
                table: "Companies");

            migrationBuilder.DropColumn(
                name: "ProductConditionId",
                table: "Companies");
        }
    }
}
