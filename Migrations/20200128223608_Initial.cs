using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace MessageBoard.Migrations
{
    public partial class Initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Messages",
                columns: table => new
                {
                    MessageId = table.Column<int>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Body = table.Column<string>(nullable: true),
                    Subject = table.Column<string>(nullable: true),
                    User = table.Column<string>(nullable: true),
                    Date = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Messages", x => x.MessageId);
                });

            migrationBuilder.InsertData(
                table: "Messages",
                columns: new[] { "MessageId", "Body", "Date", "Subject", "User" },
                values: new object[] { 1, "egg", "01/01/01", "Music", "eggLover69" });

            migrationBuilder.InsertData(
                table: "Messages",
                columns: new[] { "MessageId", "Body", "Date", "Subject", "User" },
                values: new object[] { 2, "egg", "10/23/97", "Memes", "doug" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Messages");
        }
    }
}
