using Microsoft.EntityFrameworkCore.Migrations;

namespace ContactsApp.Migrations
{
    public partial class Initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "ContactTypes",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ContactTypes", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "Groups",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Groups", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "Contacts",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    GroupID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Contacts", x => x.ID);
                    table.ForeignKey(
                        name: "FK_Contacts_Groups_GroupID",
                        column: x => x.GroupID,
                        principalTable: "Groups",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ContactContactTypes",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ContactID = table.Column<int>(type: "int", nullable: false),
                    ContactTypeID = table.Column<int>(type: "int", nullable: false),
                    Number = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ContactContactTypes", x => x.ID);
                    table.ForeignKey(
                        name: "FK_ContactContactTypes_Contacts_ContactID",
                        column: x => x.ContactID,
                        principalTable: "Contacts",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ContactContactTypes_ContactTypes_ContactTypeID",
                        column: x => x.ContactTypeID,
                        principalTable: "ContactTypes",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "ContactTypes",
                columns: new[] { "ID", "Name" },
                values: new object[,]
                {
                    { 1, "Móvil" },
                    { 2, "Trabajo" }
                });

            migrationBuilder.InsertData(
                table: "Groups",
                columns: new[] { "ID", "Name" },
                values: new object[,]
                {
                    { 1, "Familia" },
                    { 2, "Amigos" }
                });

            migrationBuilder.InsertData(
                table: "Contacts",
                columns: new[] { "ID", "Email", "GroupID", "Name" },
                values: new object[] { 1, "holguinjean1@gmail.com", 1, "Jean Carlos Holguin Berihuete" });

            migrationBuilder.InsertData(
                table: "Contacts",
                columns: new[] { "ID", "Email", "GroupID", "Name" },
                values: new object[] { 2, "jhanssel@gmail.com", 1, "Jhanssel Holguin Berihuete" });

            migrationBuilder.InsertData(
                table: "ContactContactTypes",
                columns: new[] { "ID", "ContactID", "ContactTypeID", "Number" },
                values: new object[,]
                {
                    { 1, 1, 1, "8098854086" },
                    { 2, 1, 2, "8098854085" },
                    { 3, 2, 1, "8098854186" },
                    { 4, 2, 2, "8098854185" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_ContactContactTypes_ContactID",
                table: "ContactContactTypes",
                column: "ContactID");

            migrationBuilder.CreateIndex(
                name: "IX_ContactContactTypes_ContactTypeID",
                table: "ContactContactTypes",
                column: "ContactTypeID");

            migrationBuilder.CreateIndex(
                name: "IX_Contacts_GroupID",
                table: "Contacts",
                column: "GroupID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ContactContactTypes");

            migrationBuilder.DropTable(
                name: "Contacts");

            migrationBuilder.DropTable(
                name: "ContactTypes");

            migrationBuilder.DropTable(
                name: "Groups");
        }
    }
}
