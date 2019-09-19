using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace CHSYesWebApp.Migrations.ServiceForm
{
    public partial class userID_Status : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "ServiceForm",
                columns: table => new
                {
                    ServiceFormId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    ServiceDate = table.Column<DateTime>(nullable: false),
                    HourOfService = table.Column<double>(nullable: false),
                    ServiceDescription = table.Column<string>(nullable: true),
                    RewardedForService = table.Column<bool>(nullable: false),
                    StudentSignature = table.Column<string>(nullable: true),
                    OrganizationName = table.Column<string>(nullable: true),
                    OrganizationPhone = table.Column<string>(nullable: true),
                    OrganizationWebSite = table.Column<string>(nullable: true),
                    OrganizationStreetAddress = table.Column<string>(nullable: true),
                    SponsorName = table.Column<string>(nullable: true),
                    SponsorEmail = table.Column<string>(nullable: true),
                    ParentSignature = table.Column<string>(nullable: true),
                    Status = table.Column<int>(nullable: false),
                    OwnerID = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ServiceForm", x => x.ServiceFormId);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ServiceForm");
        }
    }
}
