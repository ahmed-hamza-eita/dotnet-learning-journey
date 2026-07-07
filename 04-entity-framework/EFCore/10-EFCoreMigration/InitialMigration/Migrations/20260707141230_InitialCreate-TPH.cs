using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace InitialMigration.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreateTPH : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Discriminator",
                table: "Participants");

            migrationBuilder.AddColumn<string>(
                name: "ParticipantType",
                table: "Participants",
                type: "VARCHAR(4)",
                maxLength: 4,
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ParticipantType",
                table: "Participants");

            migrationBuilder.AddColumn<string>(
                name: "Discriminator",
                table: "Participants",
                type: "nvarchar(13)",
                maxLength: 13,
                nullable: false,
                defaultValue: "");
        }
    }
}
