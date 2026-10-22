using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace UTB.Casino.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class migraceseedu : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Customer",
                columns: new[] { "Id", "BankAccountId", "Email", "FirstName", "LastName", "PhoneNumber", "UserName" },
                values: new object[,]
                {
                    { 1, 1, "sugoma@seznam.cz", "Sugoma", "Nuts", "+35988888888", "bigdickRandy67" },
                    { 2, 4, "number12COCK@seznam.cz", "BUSSSS", "Raketak", "+9807969795", "ballz" }
                });

            migrationBuilder.InsertData(
                table: "Game",
                columns: new[] { "Id", "AltPicture", "Cost", "Description", "Name", "Picture" },
                values: new object[,]
                {
                    { 1, "FreeSpinMashine", 50.0, "You can spin the cool wheel and save up for your Mortgage", "FreeSpin", "/fotecka" },
                    { 2, "Wheel", 100.0, "You can win", "Roulette", "/fotecka" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Customer",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Customer",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Game",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Game",
                keyColumn: "Id",
                keyValue: 2);
        }
    }
}
