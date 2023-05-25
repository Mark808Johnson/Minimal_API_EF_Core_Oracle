using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Minimal_API_EF_Core_Oracle.Migrations
{
    /// <inheritdoc />
    public partial class Updated_Id_Column : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<int>(
                name: "ID",
                schema: "DEMODOTNET",
                table: "TODOITEM",
                type: "NUMBER(10,0)",
                nullable: false,
                oldClrType: typeof(decimal),
                oldType: "NUMBER")
                .Annotation("Oracle:Identity", "START WITH 1 INCREMENT BY 1")
                .OldAnnotation("Oracle:Identity", "START WITH 1 INCREMENT BY 1");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<decimal>(
                name: "ID",
                schema: "DEMODOTNET",
                table: "TODOITEM",
                type: "NUMBER",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "NUMBER(10,0)")
                .Annotation("Oracle:Identity", "START WITH 1 INCREMENT BY 1")
                .OldAnnotation("Oracle:Identity", "START WITH 1 INCREMENT BY 1");
        }
    }
}
