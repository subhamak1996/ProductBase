using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ProductBase.Server.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Reg",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    UserName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    EmailId = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Password = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    MobileNo = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Reg", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "productdetails",
                columns: table => new
                {
                    PDId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    PTId = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ProductNameName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ProductDescription = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_productdetails", x => x.PDId);
                });

            migrationBuilder.CreateTable(
                name: "producttype",
                columns: table => new
                {
                    PTId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ProductTypeName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ProductTypeDescription = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_producttype", x => x.PTId);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Reg");

            migrationBuilder.DropTable(
                name: "productdetails");

            migrationBuilder.DropTable(
                name: "producttype");
        }
    }
}
