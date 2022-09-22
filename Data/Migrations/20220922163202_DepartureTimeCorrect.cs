using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Data.Migrations
{
    public partial class DepartureTimeCorrect : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "DepatureDate",
                table: "FlightSchedules",
                newName: "DepatureDateTime");

            migrationBuilder.AddColumn<DateTime>(
                name: "ArrivalDateTime",
                table: "FlightSchedules",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ArrivalDateTime",
                table: "FlightSchedules");

            migrationBuilder.RenameColumn(
                name: "DepatureDateTime",
                table: "FlightSchedules",
                newName: "DepatureDate");
        }
    }
}
