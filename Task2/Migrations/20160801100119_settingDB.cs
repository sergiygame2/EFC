using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore.Migrations;

namespace EF_CMS.Migrations
{
    public partial class settingDB : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Pages",
                columns: table => new
                {
                    PageID = table.Column<int>(nullable: false)
                        .Annotation("Autoincrement", true),
                    AddedDate = table.Column<DateTime>(nullable: false),
                    Content = table.Column<string>(nullable: true),
                    Description = table.Column<string>(nullable: true),
                    Title = table.Column<string>(nullable: true),
                    UrlName = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Pages", x => x.PageID);
                });

            migrationBuilder.CreateTable(
                name: "Links",
                columns: table => new
                {
                    NLId = table.Column<int>(nullable: false)
                        .Annotation("Autoincrement", true),
                    NavLinkTitle = table.Column<string>(nullable: true),
                    PageId = table.Column<int>(nullable: false),
                    ParentLinkId = table.Column<int>(nullable: false),
                    Position = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Links", x => x.NLId);
                    table.ForeignKey(
                        name: "FK_Links_Pages_PageId",
                        column: x => x.PageId,
                        principalTable: "Pages",
                        principalColumn: "PageID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Links_Links_ParentLinkId",
                        column: x => x.ParentLinkId,
                        principalTable: "Links",
                        principalColumn: "NLId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "RelPages",
                columns: table => new
                {
                    RowId = table.Column<int>(nullable: false)
                        .Annotation("Autoincrement", true),
                    Page1PageID = table.Column<int>(nullable: true),
                    Page2PageID = table.Column<int>(nullable: true),
                    PageId1 = table.Column<int>(nullable: false),
                    PageId2 = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RelPages", x => x.RowId);
                    table.ForeignKey(
                        name: "FK_RelPages_Pages_Page1PageID",
                        column: x => x.PageId1,
                        principalTable: "Pages",
                        principalColumn: "PageId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_RelPages_Pages_Page2PageID",
                        column: x => x.PageId2,
                        principalTable: "Pages",
                        principalColumn: "PageId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Links_PageId",
                table: "Links",
                column: "PageId");

            migrationBuilder.CreateIndex(
                name: "IX_Links_ParentLinkId",
                table: "Links",
                column: "ParentLinkId");

            migrationBuilder.CreateIndex(
                name: "IX_RelPages_Page1PageID",
                table: "RelPages",
                column: "Page1PageID");

            migrationBuilder.CreateIndex(
                name: "IX_RelPages_Page2PageID",
                table: "RelPages",
                column: "Page2PageID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Links");

            migrationBuilder.DropTable(
                name: "RelPages");

            migrationBuilder.DropTable(
                name: "Pages");
        }
    }
}
