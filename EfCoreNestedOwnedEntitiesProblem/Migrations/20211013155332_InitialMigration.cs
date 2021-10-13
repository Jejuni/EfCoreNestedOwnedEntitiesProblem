using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace EfCoreNestedOwnedEntitiesProblem.Migrations
{
    public partial class InitialMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "EntityOnes",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    MyProp_LvlTwo_LvlThree_MyInteger = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EntityOnes", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "EntityTwos",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    MyOtherProp_LvlTwo_LvlThree_MyInteger = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EntityTwos", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "EntityOnes");

            migrationBuilder.DropTable(
                name: "EntityTwos");
        }
    }
}
