using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace Mgmt30toolset.Migrations
{
    public partial class _Bonuses : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Bonuses",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    DateCreated = table.Column<DateTime>(type: "TEXT", nullable: false),
                    DateDeleted = table.Column<DateTime>(type: "TEXT", nullable: true),
                    DateUpdated = table.Column<DateTime>(type: "TEXT", nullable: false),
                    Description = table.Column<string>(type: "TEXT", nullable: true),
                    ReceiverId = table.Column<int>(type: "INTEGER", nullable: true),
                    SenderId = table.Column<int>(type: "INTEGER", nullable: true),
                    UserCreatedId = table.Column<int>(type: "INTEGER", nullable: true),
                    UserUpdatedId = table.Column<int>(type: "INTEGER", nullable: true),
                    Value = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Bonuses", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Bonuses_Users_ReceiverId",
                        column: x => x.ReceiverId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Bonuses_Users_SenderId",
                        column: x => x.SenderId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Bonuses_Users_UserCreatedId",
                        column: x => x.UserCreatedId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Bonuses_Users_UserUpdatedId",
                        column: x => x.UserUpdatedId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "BonusTags",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    BonusId = table.Column<int>(type: "INTEGER", nullable: true),
                    DateCreated = table.Column<DateTime>(type: "TEXT", nullable: false),
                    DateDeleted = table.Column<DateTime>(type: "TEXT", nullable: true),
                    DateUpdated = table.Column<DateTime>(type: "TEXT", nullable: false),
                    UserCreatedId = table.Column<int>(type: "INTEGER", nullable: true),
                    UserUpdatedId = table.Column<int>(type: "INTEGER", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BonusTags", x => x.Id);
                    table.ForeignKey(
                        name: "FK_BonusTags_Bonuses_BonusId",
                        column: x => x.BonusId,
                        principalTable: "Bonuses",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_BonusTags_Users_UserCreatedId",
                        column: x => x.UserCreatedId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_BonusTags_Users_UserUpdatedId",
                        column: x => x.UserUpdatedId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Bonuses_ReceiverId",
                table: "Bonuses",
                column: "ReceiverId");

            migrationBuilder.CreateIndex(
                name: "IX_Bonuses_SenderId",
                table: "Bonuses",
                column: "SenderId");

            migrationBuilder.CreateIndex(
                name: "IX_Bonuses_UserCreatedId",
                table: "Bonuses",
                column: "UserCreatedId");

            migrationBuilder.CreateIndex(
                name: "IX_Bonuses_UserUpdatedId",
                table: "Bonuses",
                column: "UserUpdatedId");

            migrationBuilder.CreateIndex(
                name: "IX_BonusTags_BonusId",
                table: "BonusTags",
                column: "BonusId");

            migrationBuilder.CreateIndex(
                name: "IX_BonusTags_UserCreatedId",
                table: "BonusTags",
                column: "UserCreatedId");

            migrationBuilder.CreateIndex(
                name: "IX_BonusTags_UserUpdatedId",
                table: "BonusTags",
                column: "UserUpdatedId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "BonusTags");

            migrationBuilder.DropTable(
                name: "Bonuses");
        }
    }
}
