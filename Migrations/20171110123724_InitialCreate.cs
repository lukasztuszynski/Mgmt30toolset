using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace Mgmt30toolset.Migrations
{
    public partial class InitialCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    DateCreated = table.Column<DateTime>(type: "TEXT", nullable: false),
                    DateDeleted = table.Column<DateTime>(type: "TEXT", nullable: true),
                    DateUpdated = table.Column<DateTime>(type: "TEXT", nullable: false),
                    Email = table.Column<string>(type: "TEXT", nullable: true),
                    FirstName = table.Column<string>(type: "TEXT", nullable: true),
                    LastName = table.Column<string>(type: "TEXT", nullable: true),
                    Password = table.Column<string>(type: "TEXT", nullable: true),
                    UserCreatedId = table.Column<int>(type: "INTEGER", nullable: true),
                    UserUpdatedId = table.Column<int>(type: "INTEGER", nullable: true),
                    Username = table.Column<string>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Users_Users_UserCreatedId",
                        column: x => x.UserCreatedId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Users_Users_UserUpdatedId",
                        column: x => x.UserUpdatedId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "KudoCategories",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    DateCreated = table.Column<DateTime>(type: "TEXT", nullable: false),
                    DateDeleted = table.Column<DateTime>(type: "TEXT", nullable: true),
                    DateUpdated = table.Column<DateTime>(type: "TEXT", nullable: false),
                    Description = table.Column<string>(type: "TEXT", nullable: true),
                    Name = table.Column<string>(type: "TEXT", nullable: true),
                    UserCreatedId = table.Column<int>(type: "INTEGER", nullable: true),
                    UserUpdatedId = table.Column<int>(type: "INTEGER", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_KudoCategories", x => x.Id);
                    table.ForeignKey(
                        name: "FK_KudoCategories_Users_UserCreatedId",
                        column: x => x.UserCreatedId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_KudoCategories_Users_UserUpdatedId",
                        column: x => x.UserUpdatedId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Kudos",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    CategoryId = table.Column<int>(type: "INTEGER", nullable: true),
                    Content = table.Column<string>(type: "TEXT", nullable: true),
                    DateCreated = table.Column<DateTime>(type: "TEXT", nullable: false),
                    DateDeleted = table.Column<DateTime>(type: "TEXT", nullable: true),
                    DateUpdated = table.Column<DateTime>(type: "TEXT", nullable: false),
                    ReceiverId = table.Column<int>(type: "INTEGER", nullable: true),
                    SenderId = table.Column<int>(type: "INTEGER", nullable: true),
                    UserCreatedId = table.Column<int>(type: "INTEGER", nullable: true),
                    UserUpdatedId = table.Column<int>(type: "INTEGER", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Kudos", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Kudos_KudoCategories_CategoryId",
                        column: x => x.CategoryId,
                        principalTable: "KudoCategories",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Kudos_Users_ReceiverId",
                        column: x => x.ReceiverId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Kudos_Users_SenderId",
                        column: x => x.SenderId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Kudos_Users_UserCreatedId",
                        column: x => x.UserCreatedId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Kudos_Users_UserUpdatedId",
                        column: x => x.UserUpdatedId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_KudoCategories_UserCreatedId",
                table: "KudoCategories",
                column: "UserCreatedId");

            migrationBuilder.CreateIndex(
                name: "IX_KudoCategories_UserUpdatedId",
                table: "KudoCategories",
                column: "UserUpdatedId");

            migrationBuilder.CreateIndex(
                name: "IX_Kudos_CategoryId",
                table: "Kudos",
                column: "CategoryId");

            migrationBuilder.CreateIndex(
                name: "IX_Kudos_ReceiverId",
                table: "Kudos",
                column: "ReceiverId");

            migrationBuilder.CreateIndex(
                name: "IX_Kudos_SenderId",
                table: "Kudos",
                column: "SenderId");

            migrationBuilder.CreateIndex(
                name: "IX_Kudos_UserCreatedId",
                table: "Kudos",
                column: "UserCreatedId");

            migrationBuilder.CreateIndex(
                name: "IX_Kudos_UserUpdatedId",
                table: "Kudos",
                column: "UserUpdatedId");

            migrationBuilder.CreateIndex(
                name: "IX_Users_UserCreatedId",
                table: "Users",
                column: "UserCreatedId");

            migrationBuilder.CreateIndex(
                name: "IX_Users_UserUpdatedId",
                table: "Users",
                column: "UserUpdatedId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Kudos");

            migrationBuilder.DropTable(
                name: "KudoCategories");

            migrationBuilder.DropTable(
                name: "Users");
        }
    }
}
