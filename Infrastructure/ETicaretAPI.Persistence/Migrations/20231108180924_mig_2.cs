using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ETicaretAPI.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class mig_2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Baskets_AspNetUsers_User1Id",
                table: "Baskets");

            migrationBuilder.DropIndex(
                name: "IX_Baskets_User1Id",
                table: "Baskets");

            migrationBuilder.DropColumn(
                name: "User1Id",
                table: "Baskets");

            migrationBuilder.AddColumn<string>(
                name: "UserId",
                table: "Baskets",
                type: "text",
                nullable: false,
                defaultValue: "");

            migrationBuilder.CreateIndex(
                name: "IX_Baskets_UserId",
                table: "Baskets",
                column: "UserId");

            migrationBuilder.AddForeignKey(
                name: "FK_Baskets_AspNetUsers_UserId",
                table: "Baskets",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Baskets_AspNetUsers_UserId",
                table: "Baskets");

            migrationBuilder.DropIndex(
                name: "IX_Baskets_UserId",
                table: "Baskets");

            migrationBuilder.DropColumn(
                name: "UserId",
                table: "Baskets");

            migrationBuilder.AddColumn<string>(
                name: "User1Id",
                table: "Baskets",
                type: "text",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Baskets_User1Id",
                table: "Baskets",
                column: "User1Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Baskets_AspNetUsers_User1Id",
                table: "Baskets",
                column: "User1Id",
                principalTable: "AspNetUsers",
                principalColumn: "Id");
        }
    }
}
