using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AlexApps.ECommerce.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class SeedingRoles : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql("Set IDENTITY_INSERT AspNetRoles ON");
            migrationBuilder.Sql("INSERT INTO AspNetRoles (Id, Name, NormalizedName) VALUES ('1', 'Admin', 'ADMIN')");
            migrationBuilder.Sql("INSERT INTO AspNetRoles (Id, Name, NormalizedName) VALUES ('2', 'Merchant', 'MERCHANT')");
            migrationBuilder.Sql("INSERT INTO AspNetRoles (Id, Name, NormalizedName) VALUES ('3', 'Customer', 'CUSTOMER')");
            migrationBuilder.Sql("Set IDENTITY_INSERT AspNetRoles OFF");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql("DELETE FROM AspNetRoles WHERE Id = '1'");
            migrationBuilder.Sql("DELETE FROM AspNetRoles WHERE Id = '2'");
            migrationBuilder.Sql("DELETE FROM AspNetRoles WHERE Id = '3'");
        }
    }
}