using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace TicketApp.Migrations
{
    /// <inheritdoc />
    public partial class NazwaMigracji : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "movies",
                columns: table => new
                {
                    movieid = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    title = table.Column<string>(type: "character varying(255)", maxLength: 255, nullable: false),
                    description = table.Column<string>(type: "text", nullable: true),
                    poster = table.Column<string>(type: "character varying(255)", maxLength: 255, nullable: true),
                    duration = table.Column<TimeSpan>(type: "interval", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("movies_pkey", x => x.movieid);
                });

            migrationBuilder.CreateTable(
                name: "users",
                columns: table => new
                {
                    userid = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    firstname = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: false),
                    FirstName = table.Column<string>(type: "text", nullable: true),
                    lastname = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: false),
                    LastName = table.Column<string>(type: "text", nullable: true),
                    email = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: false),
                    password = table.Column<string>(type: "character varying(255)", maxLength: 255, nullable: false),
                    isadmin = table.Column<bool>(type: "boolean", nullable: true, defaultValueSql: "false"),
                    isregistered = table.Column<bool>(type: "boolean", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("users_pkey", x => x.userid);
                });

            migrationBuilder.CreateTable(
                name: "showtimes",
                columns: table => new
                {
                    showtimeid = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    movieid = table.Column<int>(type: "integer", nullable: true),
                    startdatetime = table.Column<DateTime>(type: "timestamp without time zone", nullable: true),
                    AvailableSeats = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("showtimes_pkey", x => x.showtimeid);
                    table.ForeignKey(
                        name: "showtimes_movieid_fkey",
                        column: x => x.movieid,
                        principalTable: "movies",
                        principalColumn: "movieid");
                });

            migrationBuilder.CreateTable(
                name: "bookings",
                columns: table => new
                {
                    bookingid = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    userid = table.Column<int>(type: "integer", nullable: true),
                    showtimeid = table.Column<int>(type: "integer", nullable: true),
                    numofseats = table.Column<int>(type: "integer", nullable: true),
                    iscancelled = table.Column<bool>(type: "boolean", nullable: true, defaultValueSql: "false"),
                    BookingDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("bookings_pkey", x => x.bookingid);
                    table.ForeignKey(
                        name: "bookings_showtimeid_fkey",
                        column: x => x.showtimeid,
                        principalTable: "showtimes",
                        principalColumn: "showtimeid");
                    table.ForeignKey(
                        name: "bookings_userid_fkey",
                        column: x => x.userid,
                        principalTable: "users",
                        principalColumn: "userid");
                });

            migrationBuilder.CreateIndex(
                name: "IX_bookings_showtimeid",
                table: "bookings",
                column: "showtimeid");

            migrationBuilder.CreateIndex(
                name: "IX_bookings_userid",
                table: "bookings",
                column: "userid");

            migrationBuilder.CreateIndex(
                name: "IX_showtimes_movieid",
                table: "showtimes",
                column: "movieid");

            migrationBuilder.CreateIndex(
                name: "users_email_key",
                table: "users",
                column: "email",
                unique: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "bookings");

            migrationBuilder.DropTable(
                name: "showtimes");

            migrationBuilder.DropTable(
                name: "users");

            migrationBuilder.DropTable(
                name: "movies");
        }
    }
}
