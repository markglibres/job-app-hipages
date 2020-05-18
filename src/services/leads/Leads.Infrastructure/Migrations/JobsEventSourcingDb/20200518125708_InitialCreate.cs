using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Leads.Infrastructure.Migrations.JobsEventSourcingDb
{
    public partial class InitialCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "job_events",
                columns: table => new
                {
                    id = table.Column<int>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    event_id = table.Column<Guid>(nullable: false),
                    reference_id = table.Column<Guid>(nullable: false),
                    event_type = table.Column<string>(nullable: true),
                    event_name = table.Column<string>(nullable: true),
                    event_data = table.Column<string>(type: "JSON", nullable: true),
                    date_created = table.Column<DateTime>(type: "TIMESTAMP", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_job_events", x => x.id);
                });

            migrationBuilder.CreateIndex(
                name: "i_x_job_events_event_id",
                table: "job_events",
                column: "event_id");

            migrationBuilder.CreateIndex(
                name: "i_x_job_events_event_name",
                table: "job_events",
                column: "event_name");

            migrationBuilder.CreateIndex(
                name: "i_x_job_events_reference_id",
                table: "job_events",
                column: "reference_id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "job_events");
        }
    }
}
