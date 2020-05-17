using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Leads.Infrastructure.Migrations
{
    public partial class InitialCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "categories",
                columns: table => new
                {
                    id = table.Column<int>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    name = table.Column<string>(type: "varchar(255)", nullable: true),
                    parent_category_id = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_categories", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "suburbs",
                columns: table => new
                {
                    id = table.Column<int>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    name = table.Column<string>(type: "varchar(255)", nullable: true),
                    post_code = table.Column<string>(type: "varchar(4)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_suburbs", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "job",
                columns: table => new
                {
                    id = table.Column<int>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    status = table.Column<string>(type: "varchar(50)", nullable: false),
                    category_id = table.Column<int>(nullable: false),
                    suburb_id = table.Column<int>(nullable: false),
                    contact_name = table.Column<string>(type: "varchar(255)", nullable: true),
                    contact_phone = table.Column<string>(type: "varchar(255)", nullable: true),
                    contact_email = table.Column<string>(type: "varchar(255)", nullable: true),
                    price = table.Column<int>(type: "int(3)", nullable: false),
                    description = table.Column<string>(type: "text", nullable: true),
                    created_at = table.Column<DateTime>(type: "TIMESTAMP", nullable: false, defaultValueSql: "CURRENT_TIMESTAMP"),
                    updated_at = table.Column<DateTime>(type: "TIMESTAMP", nullable: false, defaultValueSql: "CURRENT_TIMESTAMP"),
                    reference_id = table.Column<Guid>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_job", x => x.id);
                    table.ForeignKey(
                        name: "f_k_job_categories_category_id",
                        column: x => x.category_id,
                        principalTable: "categories",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "f_k_job_suburbs_suburb_id",
                        column: x => x.suburb_id,
                        principalTable: "suburbs",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "idx_categories_parent_category",
                table: "categories",
                column: "parent_category_id");

            migrationBuilder.CreateIndex(
                name: "i_x_categories_name_parent_category_id",
                table: "categories",
                columns: new[] { "name", "parent_category_id" });

            migrationBuilder.CreateIndex(
                name: "i_x_job_category_id",
                table: "job",
                column: "category_id");

            migrationBuilder.CreateIndex(
                name: "i_x_job_reference_id",
                table: "job",
                column: "reference_id");

            migrationBuilder.CreateIndex(
                name: "i_x_job_suburb_id",
                table: "job",
                column: "suburb_id");

            migrationBuilder.CreateIndex(
                name: "idx_suburbs_postcode",
                table: "suburbs",
                column: "post_code");

            migrationBuilder.CreateIndex(
                name: "i_x_suburbs_name_post_code",
                table: "suburbs",
                columns: new[] { "name", "post_code" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "job");

            migrationBuilder.DropTable(
                name: "categories");

            migrationBuilder.DropTable(
                name: "suburbs");
        }
    }
}
