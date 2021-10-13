using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace EfCoreNestedOwnedEntitiesProblem.Migrations
{
    public partial class NoChangeMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "MyOtherProp_LvlTwo_LvlThree_LvlTwoLvlOneEntityOneId",
                table: "EntityTwos");

            migrationBuilder.AddColumn<int>(
                name: "MyProp_LvlTwo_LvlThree_MyInteger",
                table: "EntityOnes",
                type: "int",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "MyProp_LvlTwo_LvlThree_MyInteger",
                table: "EntityOnes");

            migrationBuilder.AddColumn<Guid>(
                name: "MyOtherProp_LvlTwo_LvlThree_LvlTwoLvlOneEntityOneId",
                table: "EntityTwos",
                type: "uniqueidentifier",
                nullable: true);
        }
    }
}
