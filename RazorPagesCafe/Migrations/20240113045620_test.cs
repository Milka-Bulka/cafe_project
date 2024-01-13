using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace RazorPagesCafe.Migrations
{
    /// <inheritdoc />
    public partial class test : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterDatabase()
                .Annotation("Npgsql:Enum:place", "place")
                .Annotation("Npgsql:Enum:status", "status")
                .Annotation("Npgsql:Enum:stop_list", "stop_list");

            migrationBuilder.CreateTable(
                name: "ingredient",
                columns: table => new
                {
                    id_ingredient = table.Column<int>(type: "integer", nullable: false),
                    name = table.Column<string>(type: "character varying(25)", maxLength: 25, nullable: false),
                    calories = table.Column<decimal>(type: "numeric(6,2)", precision: 6, scale: 2, nullable: false),
                    unit = table.Column<string>(type: "character varying(10)", maxLength: 10, nullable: false),
                    remainder = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("ingredient_pkey", x => x.id_ingredient);
                });

            migrationBuilder.CreateTable(
                name: "menu",
                columns: table => new
                {
                    menu_view = table.Column<string>(type: "character varying(20)", maxLength: 20, nullable: false),
                    time_of_action = table.Column<DateTime>(type: "timestamp without time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("menu_pkey", x => x.menu_view);
                });

            migrationBuilder.CreateTable(
                name: "visitor",
                columns: table => new
                {
                    id_visitor = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    name = table.Column<string>(type: "character varying(20)", maxLength: 20, nullable: false),
                    telephone = table.Column<string>(type: "character varying(11)", maxLength: 11, nullable: false),
                    d_of_b = table.Column<DateOnly>(type: "date", nullable: false),
                    bonuses = table.Column<int>(type: "integer", nullable: false, defaultValue: 0)
                },
                constraints: table =>
                {
                    table.PrimaryKey("visitor_pkey", x => x.id_visitor);
                });

            migrationBuilder.CreateTable(
                name: "dish",
                columns: table => new
                {
                    id_position = table.Column<int>(type: "integer", nullable: false),
                    name = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: false),
                    quantity_in_order = table.Column<int>(type: "integer", nullable: false),
                    cooking_course = table.Column<int>(type: "integer", nullable: false),
                    menu_view = table.Column<string>(type: "character varying(20)", maxLength: 20, nullable: false),
                    description = table.Column<string>(type: "varchar(200)", nullable: false),
                    calories = table.Column<decimal>(type: "numeric(6,2)", precision: 6, scale: 2, nullable: false),
                    amount = table.Column<decimal>(type: "money", precision: 8, scale: 2, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("dish_pkey", x => x.id_position);
                    table.ForeignKey(
                        name: "dish_menu_view_fkey",
                        column: x => x.menu_view,
                        principalTable: "menu",
                        principalColumn: "menu_view",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "orderr",
                columns: table => new
                {
                    id_order = table.Column<int>(type: "integer", nullable: false),
                    id_table = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    id_visitor = table.Column<int>(type: "integer", nullable: false),
                    number_of_visitor = table.Column<int>(type: "integer", nullable: false),
                    order_time = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    total_amount = table.Column<decimal>(type: "money", precision: 8, scale: 2, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("orderr_pkey", x => x.id_order);
                    table.ForeignKey(
                        name: "orderr_id_visitor_fkey",
                        column: x => x.id_visitor,
                        principalTable: "visitor",
                        principalColumn: "id_visitor",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "contents_of_dish",
                columns: table => new
                {
                    id_ingredient = table.Column<int>(type: "integer", nullable: false),
                    id_position = table.Column<int>(type: "integer", nullable: false),
                    quantity = table.Column<double>(type: "double precision", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("contents_of_dish_pkey", x => new { x.id_ingredient, x.id_position });
                    table.ForeignKey(
                        name: "contents_of_dish_id_ingredient_fkey",
                        column: x => x.id_ingredient,
                        principalTable: "ingredient",
                        principalColumn: "id_ingredient",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "contents_of_dish_id_position_fkey",
                        column: x => x.id_position,
                        principalTable: "dish",
                        principalColumn: "id_position",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "contents_of_order",
                columns: table => new
                {
                    id_order = table.Column<int>(type: "integer", nullable: false),
                    comment = table.Column<string>(type: "varchar(500)", nullable: false),
                    id_position = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.ForeignKey(
                        name: "contents_of_order_id_order_fkey",
                        column: x => x.id_order,
                        principalTable: "orderr",
                        principalColumn: "id_order",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "contents_of_order_id_position_fkey",
                        column: x => x.id_position,
                        principalTable: "dish",
                        principalColumn: "id_position",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_contents_of_dish_id_position",
                table: "contents_of_dish",
                column: "id_position");

            migrationBuilder.CreateIndex(
                name: "IX_contents_of_order_id_order",
                table: "contents_of_order",
                column: "id_order");

            migrationBuilder.CreateIndex(
                name: "IX_contents_of_order_id_position",
                table: "contents_of_order",
                column: "id_position");

            migrationBuilder.CreateIndex(
                name: "IX_dish_menu_view",
                table: "dish",
                column: "menu_view");

            migrationBuilder.CreateIndex(
                name: "IX_orderr_id_visitor",
                table: "orderr",
                column: "id_visitor");

            migrationBuilder.CreateIndex(
                name: "unique_telephone",
                table: "visitor",
                column: "telephone",
                unique: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "contents_of_dish");

            migrationBuilder.DropTable(
                name: "contents_of_order");

            migrationBuilder.DropTable(
                name: "ingredient");

            migrationBuilder.DropTable(
                name: "orderr");

            migrationBuilder.DropTable(
                name: "dish");

            migrationBuilder.DropTable(
                name: "visitor");

            migrationBuilder.DropTable(
                name: "menu");
        }
    }
}
