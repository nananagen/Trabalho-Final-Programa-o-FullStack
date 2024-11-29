using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace server_coworking.Migrations
{
    /// <inheritdoc />
    public partial class AddUsuarioToReserva : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Data",
                table: "Reservas");

            migrationBuilder.RenameColumn(
                name: "Horario",
                table: "Reservas",
                newName: "DataHora");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "DataHora",
                table: "Reservas",
                newName: "Horario");

            migrationBuilder.AddColumn<DateTime>(
                name: "Data",
                table: "Reservas",
                type: "TEXT",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));
        }
    }
}
