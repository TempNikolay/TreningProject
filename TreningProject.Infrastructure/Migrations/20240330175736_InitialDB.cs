using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace TreningProject.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class InitialDB : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "WeatherConditions",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    DateTime = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: false),
                    AirTemperature = table.Column<double>(type: "double precision", nullable: false),
                    RelativeHumidity = table.Column<double>(type: "double precision", nullable: false),
                    RacePoint = table.Column<double>(type: "double precision", nullable: false),
                    AtmosphericPressure = table.Column<double>(type: "double precision", nullable: true),
                    WindDirection = table.Column<string>(type: "text", nullable: true),
                    WindSpeed = table.Column<int>(type: "integer", nullable: true),
                    CloudCover = table.Column<int>(type: "integer", nullable: true),
                    LowerBound = table.Column<int>(type: "integer", nullable: true),
                    HorizontalVisibility = table.Column<int>(type: "integer", nullable: true),
                    WeatherPhenomenon = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_WeatherConditions", x => x.Id);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "WeatherConditions");
        }
    }
}
