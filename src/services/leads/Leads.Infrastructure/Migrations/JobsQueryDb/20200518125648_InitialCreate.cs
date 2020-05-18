using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Leads.Infrastructure.Migrations.JobsQueryDb
{
    public partial class InitialCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "jobs_info",
                columns: table => new
                {
                    id = table.Column<int>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    job_id = table.Column<int>(nullable: false),
                    reference_id = table.Column<Guid>(nullable: false),
                    price = table.Column<int>(type: "int(3)", nullable: false),
                    description = table.Column<string>(type: "text", nullable: true),
                    contact_name = table.Column<string>(type: "varchar(255)", nullable: true),
                    contact_phone = table.Column<string>(type: "varchar(255)", nullable: true),
                    contact_email = table.Column<string>(type: "varchar(255)", nullable: true),
                    suburb_name = table.Column<string>(type: "varchar(255)", nullable: true),
                    suburb_postcode = table.Column<string>(type: "varchar(4)", nullable: true),
                    category_name = table.Column<string>(type: "varchar(255)", nullable: true),
                    job_status = table.Column<string>(type: "varchar(50)", nullable: true),
                    created_at = table.Column<DateTime>(type: "TIMESTAMP", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_jobs_info", x => x.id);
                });

            migrationBuilder.CreateIndex(
                name: "i_x_jobs_info_job_status",
                table: "jobs_info",
                column: "job_status");

            migrationBuilder.CreateIndex(
                name: "i_x_jobs_info_reference_id",
                table: "jobs_info",
                column: "reference_id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "jobs_info");
        }
    }
}
