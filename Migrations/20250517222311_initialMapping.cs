using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Smart_Yard_Manager.Migrations
{
    /// <inheritdoc />
    public partial class initialMapping : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "SENSORS",
                columns: table => new
                {
                    ID = table.Column<Guid>(type: "RAW(16)", nullable: false),
                    NAME = table.Column<string>(type: "NVARCHAR2(100)", maxLength: 100, nullable: false),
                    SECTION = table.Column<int>(type: "NUMBER(10)", nullable: false),
                    ACTIVE = table.Column<int>(type: "NUMBER(10)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SENSORS", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "MOVIMENTS",
                columns: table => new
                {
                    ID = table.Column<Guid>(type: "RAW(16)", nullable: false),
                    PLACA_MOTO = table.Column<string>(type: "NVARCHAR2(20)", maxLength: 20, nullable: false),
                    DATA_HORA = table.Column<DateTime>(type: "TIMESTAMP(7)", nullable: false),
                    SENSOR_ID = table.Column<Guid>(type: "RAW(16)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MOVIMENTS", x => x.ID);
                    table.ForeignKey(
                        name: "FK_MOVIMENTS_SENSORS_SENSOR_ID",
                        column: x => x.SENSOR_ID,
                        principalTable: "SENSORS",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_MOVIMENTS_SENSOR_ID",
                table: "MOVIMENTS",
                column: "SENSOR_ID");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "MOVIMENTS");

            migrationBuilder.DropTable(
                name: "SENSORS");
        }
    }
}
