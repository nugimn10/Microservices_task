using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

namespace CustomerServices.Migrations
{
<<<<<<< HEAD:CustomerServices/Migrations/20200310163614_intialcustomer2.cs
    public partial class intialcustomer2 : Migration
=======
    public partial class initialcustomernew : Migration
>>>>>>> 046bf1de229e55fe39b0957264faa60b0c550157:CustomerServices/Migrations/20200310112647_initialcustomernew.cs
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Customer",
                columns: table => new
                {
                    id = table.Column<int>(nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    fullname = table.Column<string>(nullable: true),
                    username = table.Column<string>(nullable: true),
                    birthdate = table.Column<DateTime>(nullable: false),
                    passowrd = table.Column<string>(nullable: true),
                    gender = table.Column<int>(nullable: false),
                    kelamin = table.Column<string>(nullable: true),
                    email = table.Column<string>(nullable: true),
                    phoneNumber = table.Column<string>(nullable: true),
                    created_at = table.Column<long>(nullable: false),
                    updated_at = table.Column<long>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Customer", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "Customer_Payment_Cards",
                columns: table => new
                {
                    id = table.Column<int>(nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    customer_id = table.Column<int>(nullable: false),
                    name_no_card = table.Column<string>(nullable: true),
                    exp_month = table.Column<string>(nullable: true),
                    exp_year = table.Column<string>(nullable: true),
                    postal_code = table.Column<int>(nullable: false),
                    credit_card_number = table.Column<string>(nullable: true),
                    created_at = table.Column<long>(nullable: false),
                    updated_at = table.Column<long>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Customer_Payment_Cards", x => x.id);
                    table.ForeignKey(
                        name: "FK_Customer_Payment_Cards_Customer_customer_id",
                        column: x => x.customer_id,
                        principalTable: "Customer",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Customer_Payment_Cards_customer_id",
                table: "Customer_Payment_Cards",
                column: "customer_id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Customer_Payment_Cards");

            migrationBuilder.DropTable(
                name: "Customer");
        }
    }
}
