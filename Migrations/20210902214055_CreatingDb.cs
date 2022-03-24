using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace WebApplication1.Migrations
{
    public partial class CreatingDb : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "payment",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    description = table.Column<string>(type: "nvarchar(37)", maxLength: 37, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_payment", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "Room_Type",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    description = table.Column<string>(type: "nvarchar(37)", maxLength: 37, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Room_Type", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "Clients",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    fullname = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    place = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    job = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    rooms = table.Column<int>(type: "int", nullable: false),
                    Room_TypeId = table.Column<int>(type: "int", nullable: false),
                    phoneNumber1 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    phoneNumber2 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    National_Id = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    email = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    password = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Reservation_time = table.Column<DateTime>(type: "datetime2", nullable: false),
                    birthDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Arriving_time = table.Column<DateTime>(type: "datetime2", nullable: false),
                    LeavingTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    creationDateTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    updateDateTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    PaymentId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Clients", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Clients_payment_PaymentId",
                        column: x => x.PaymentId,
                        principalTable: "payment",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Clients_Room_Type_Room_TypeId",
                        column: x => x.Room_TypeId,
                        principalTable: "Room_Type",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Clients_PaymentId",
                table: "Clients",
                column: "PaymentId");

            migrationBuilder.CreateIndex(
                name: "IX_Clients_Room_TypeId",
                table: "Clients",
                column: "Room_TypeId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Clients");

            migrationBuilder.DropTable(
                name: "payment");

            migrationBuilder.DropTable(
                name: "Room_Type");
        }
    }
}
