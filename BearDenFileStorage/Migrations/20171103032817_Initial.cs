using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore.Migrations;

namespace BearDenFileStorage.Migrations
{
    public partial class Initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "FilesContent",
                columns: table => new
                {
                    FileId = table.Column<Guid>(nullable: false),
                    ContentType = table.Column<string>(nullable: true),
                    FileContent = table.Column<byte[]>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FilesContent", x => x.FileId);
                });

            migrationBuilder.CreateTable(
                name: "FilesInfo",
                columns: table => new
                {
                    FileId = table.Column<Guid>(nullable: false),
                    Filename = table.Column<string>(nullable: true),
                    LastEdit = table.Column<DateTime>(nullable: false),
                    Owner = table.Column<string>(nullable: true),
                    Size = table.Column<long>(nullable: false),
                    UploadTime = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FilesInfo", x => x.FileId);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "FilesContent");

            migrationBuilder.DropTable(
                name: "FilesInfo");
        }
    }
}
