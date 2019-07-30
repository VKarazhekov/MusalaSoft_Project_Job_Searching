using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace JobSearching.Data.Migrations
{
    public partial class Secondary : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Employers",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    FirstName = table.Column<string>(nullable: false, maxLength:15),
                    MiddleName = table.Column<string>(nullable: false, maxLength: 15),
                    LastName = table.Column<string>(nullable: false, maxLength: 15),
                    Age = table.Column<int>(nullable: false),
                    CurrentAddress = table.Column<string>(nullable: false,maxLength:100),
                    CompanyName = table.Column<string>(nullable: false, maxLength:60),
                    ContactEmail = table.Column<string>(nullable: false, maxLength:30),
                    ContactPhone = table.Column<string>(nullable: false, maxLength:12),
                    RegisteredOn = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Employers", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Volunteers",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Username = table.Column<string>(nullable: false, maxLength:20),
                    Password = table.Column<string>(nullable: false, maxLength: 20),
                    FirstName = table.Column<string>(nullable: false, maxLength: 15),
                    LastName = table.Column<string>(nullable: false, maxLength: 15),
                    Age = table.Column<int>(nullable: false),
                    ContactInformation = table.Column<string>(nullable: false, maxLength:100),
                    RegisteredOn = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Volunteers", x => x.Id);
                    table.UniqueConstraint("UQ_Volunteers_Username", x => x.Username);
                });

            migrationBuilder.CreateTable(
                name: "JobAds",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    PositionName = table.Column<string>(nullable: false, maxLength:20),
                    EmployerId = table.Column<int>(nullable: false),
                    Description = table.Column<string>(nullable: true, maxLength:500)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_JobAds", x => x.Id);
                    table.ForeignKey(
                        name: "FK_JobAd_Employer",
                        column: x => x.EmployerId,
                        principalTable: "Employers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "JobVolunteer",
                columns: table => new
                {
                    JobAdId = table.Column<int>(nullable: false),
                    VolunteerId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_JobVolunteer", x => new { x.JobAdId, x.VolunteerId });
                    table.ForeignKey(
                        name: "FK_JobVolunteer_JobAds_JobAdId",
                        column: x => x.JobAdId,
                        principalTable: "JobAds",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_JobVolunteer_Volunteers_VolunteerId",
                        column: x => x.VolunteerId,
                        principalTable: "Volunteers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_JobAds_EmployerId",
                table: "JobAds",
                column: "EmployerId");

            migrationBuilder.CreateIndex(
                name: "IX_JobVolunteer_VolunteerId",
                table: "JobVolunteer",
                column: "VolunteerId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "JobVolunteer");

            migrationBuilder.DropTable(
                name: "JobAds");

            migrationBuilder.DropTable(
                name: "Volunteers");

            migrationBuilder.DropTable(
                name: "Employers");
        }
    }
}
