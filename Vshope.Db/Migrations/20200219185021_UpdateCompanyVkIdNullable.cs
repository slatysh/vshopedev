using Microsoft.EntityFrameworkCore.Migrations;

namespace Vshope.Db.Migrations
{
    public partial class UpdateCompanyVkIdNullable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<long>(
                name: "VkId",
                table: "Companies",
                nullable: true,
                oldClrType: typeof(long));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<long>(
                name: "VkId",
                table: "Companies",
                nullable: false,
                oldClrType: typeof(long),
                oldNullable: true);
        }
    }
}
