using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Leads.Infrastructure.Migrations
{
    public partial class InitialCreate : Migration
    {
        protected override void Up( MigrationBuilder migrationBuilder )
        {
            migrationBuilder.CreateTable(
                "categories",
                table => new
                {
                    id = table.Column<int>()
                        .Annotation( "MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn ),
                    name = table.Column<string>( "varchar(255)", nullable: true ),
                    parent_category_id = table.Column<int>()
                },
                constraints: table => { table.PrimaryKey( "PK_categories", x => x.id ); }
            );

            migrationBuilder.CreateTable(
                "jobs_info",
                table => new
                {
                    id = table.Column<int>()
                        .Annotation( "MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn ),
                    job_id = table.Column<int>(),
                    reference_id = table.Column<Guid>(),
                    price = table.Column<int>( "int(3)" ),
                    description = table.Column<string>( "text", nullable: true ),
                    contact_name = table.Column<string>( "varchar(255)", nullable: true ),
                    contact_phone = table.Column<string>( "varchar(255)", nullable: true ),
                    contact_email = table.Column<string>( "varchar(255)", nullable: true ),
                    suburb_name = table.Column<string>( "varchar(255)", nullable: true ),
                    suburb_postcode = table.Column<string>( "varchar(4)", nullable: true ),
                    category_name = table.Column<string>( "varchar(255)", nullable: true ),
                    job_status = table.Column<string>( "varchar(50)", nullable: true ),
                    created_at = table.Column<DateTime>( "TIMESTAMP" )
                },
                constraints: table => { table.PrimaryKey( "PK_jobs_info", x => x.id ); }
            );

            migrationBuilder.CreateTable(
                "suburbs",
                table => new
                {
                    id = table.Column<int>()
                        .Annotation( "MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn ),
                    name = table.Column<string>( "varchar(255)", nullable: true ),
                    post_code = table.Column<string>( "varchar(4)", nullable: true )
                },
                constraints: table => { table.PrimaryKey( "PK_suburbs", x => x.id ); }
            );

            migrationBuilder.CreateTable(
                "jobs",
                table => new
                {
                    id = table.Column<int>()
                        .Annotation( "MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn ),
                    status = table.Column<string>( "varchar(50)" ),
                    category_id = table.Column<int>(),
                    suburb_id = table.Column<int>(),
                    contact_name = table.Column<string>( "varchar(255)", nullable: true ),
                    contact_phone = table.Column<string>( "varchar(255)", nullable: true ),
                    contact_email = table.Column<string>( "varchar(255)", nullable: true ),
                    price = table.Column<int>( "int(3)" ),
                    description = table.Column<string>( "text", nullable: true ),
                    created_at =
                        table.Column<DateTime>( "TIMESTAMP", nullable: false, defaultValueSql: "CURRENT_TIMESTAMP" ),
                    updated_at =
                        table.Column<DateTime>( "TIMESTAMP", nullable: false, defaultValueSql: "CURRENT_TIMESTAMP" ),
                    reference_id = table.Column<Guid>()
                },
                constraints: table =>
                             {
                                 table.PrimaryKey( "PK_jobs", x => x.id );

                                 table.ForeignKey(
                                     "f_k_jobs_categories_category_id",
                                     x => x.category_id,
                                     "categories",
                                     "id",
                                     onDelete: ReferentialAction.Cascade
                                 );

                                 table.ForeignKey(
                                     "f_k_jobs_suburbs_suburb_id",
                                     x => x.suburb_id,
                                     "suburbs",
                                     "id",
                                     onDelete: ReferentialAction.Cascade
                                 );
                             }
            );

            migrationBuilder.CreateIndex(
                "idx_categories_parent_category",
                "categories",
                "parent_category_id"
            );

            migrationBuilder.CreateIndex(
                "i_x_categories_name_parent_category_id",
                "categories",
                new[] { "name", "parent_category_id" }
            );

            migrationBuilder.CreateIndex(
                "i_x_jobs_category_id",
                "jobs",
                "category_id"
            );

            migrationBuilder.CreateIndex(
                "i_x_jobs_reference_id",
                "jobs",
                "reference_id"
            );

            migrationBuilder.CreateIndex(
                "i_x_jobs_suburb_id",
                "jobs",
                "suburb_id"
            );

            migrationBuilder.CreateIndex(
                "i_x_jobs_info_job_status",
                "jobs_info",
                "job_status"
            );

            migrationBuilder.CreateIndex(
                "i_x_jobs_info_reference_id",
                "jobs_info",
                "reference_id"
            );

            migrationBuilder.CreateIndex(
                "idx_suburbs_postcode",
                "suburbs",
                "post_code"
            );

            migrationBuilder.CreateIndex(
                "i_x_suburbs_name_post_code",
                "suburbs",
                new[] { "name", "post_code" }
            );
        }

        protected override void Down( MigrationBuilder migrationBuilder )
        {
            migrationBuilder.DropTable(
                "jobs"
            );

            migrationBuilder.DropTable(
                "jobs_info"
            );

            migrationBuilder.DropTable(
                "categories"
            );

            migrationBuilder.DropTable(
                "suburbs"
            );
        }
    }
}