﻿using Microsoft.EntityFrameworkCore.Migrations;

namespace Yngdieng.Backend.Migrations
{
    public partial class NewSpeakerFields : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "ancestral_home",
                table: "speakers",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "display_name_source",
                table: "speakers",
                nullable: false,
                defaultValue: "");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ancestral_home",
                table: "speakers");

            migrationBuilder.DropColumn(
                name: "display_name_source",
                table: "speakers");
        }
    }
}
