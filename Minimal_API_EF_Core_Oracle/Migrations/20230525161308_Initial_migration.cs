using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Minimal_API_EF_Core_Oracle.Migrations
{
    /// <inheritdoc />
    public partial class Initial_migration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.EnsureSchema(
                name: "DEMODOTNET");

            migrationBuilder.CreateSequence(
                name: "TODOITEM_SEQ",
                schema: "DEMODOTNET");

            migrationBuilder.CreateTable(
                name: "TODOITEM",
                schema: "DEMODOTNET",
                columns: table => new
                {
                    ID = table.Column<decimal>(type: "NUMBER", nullable: false)
                        .Annotation("Oracle:Identity", "START WITH 1 INCREMENT BY 1"),
                    DESCRIPTION = table.Column<string>(type: "VARCHAR2(4000)", unicode: false, nullable: false),
                    CREATION_TS = table.Column<DateTimeOffset>(type: "TIMESTAMP(6) WITH TIME ZONE", nullable: false, defaultValueSql: "CURRENT_TIMESTAMP"),
                    DONE = table.Column<bool>(type: "NUMBER(1)", precision: 1, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("SYS_C006997", x => x.ID);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "TODOITEM",
                schema: "DEMODOTNET");

            migrationBuilder.DropSequence(
                name: "TODOITEM_SEQ",
                schema: "DEMODOTNET");
        }
    }
}
