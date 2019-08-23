﻿using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace gorillatree.Migrations
{
    public partial class NewMigrationdoestreetypematter4 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "Image",
                table: "Trees",
                nullable: true,
                oldClrType: typeof(byte[]),
                oldNullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<byte[]>(
                name: "Image",
                table: "Trees",
                nullable: true,
                oldClrType: typeof(string),
                oldNullable: true);
        }
    }
}
