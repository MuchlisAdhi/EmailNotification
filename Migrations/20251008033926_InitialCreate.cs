using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EmailNotification.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.EnsureSchema(
                name: "Transaction");

            migrationBuilder.CreateTable(
                name: "tbtemaillog",
                schema: "Transaction",
                columns: table => new
                {
                    Key = table.Column<Guid>(type: "uuid", nullable: false),
                    SenderEmail = table.Column<string>(type: "character varying(255)", maxLength: 255, nullable: false),
                    SenderName = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: false),
                    RecipientEmail = table.Column<string>(type: "character varying(255)", maxLength: 255, nullable: false),
                    ReceiverName = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: false),
                    Subject = table.Column<string>(type: "character varying(255)", maxLength: 255, nullable: false),
                    Body = table.Column<string>(type: "text", nullable: false),
                    SentAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: false, defaultValueSql: "CURRENT_TIMESTAMP AT TIME ZONE 'Asia/Jakarta'")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tbtemaillog", x => x.Key);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "tbtemaillog",
                schema: "Transaction");
        }
    }
}
