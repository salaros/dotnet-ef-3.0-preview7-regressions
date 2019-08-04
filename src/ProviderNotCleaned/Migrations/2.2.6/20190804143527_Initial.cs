using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace ProviderNotCleaned.Migrations._2._2._6
{
    public partial class Initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "DummyModel",
                columns: table => new
                {
                    Id = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    RequiredField = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DummyModel", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "UniqueIdModel",
                columns: table => new
                {
                    UniqueId = table.Column<string>(maxLength: 36, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UniqueIdModel", x => x.UniqueId);
                });

            migrationBuilder.InsertData(
                table: "UniqueIdModel",
                column: "UniqueId",
                value: "8ac4b5f4-eac9-4fc7-b7a4-6a3ba0ae3556");

            migrationBuilder.InsertData(
                table: "UniqueIdModel",
                column: "UniqueId",
                value: "509f3452-649f-4255-abb4-3608f3aa25db");

            migrationBuilder.CreateIndex(
                name: "IX_UniqueIdModel_UniqueId",
                table: "UniqueIdModel",
                column: "UniqueId",
                unique: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "DummyModel");

            migrationBuilder.DropTable(
                name: "UniqueIdModel");
        }
    }
}
