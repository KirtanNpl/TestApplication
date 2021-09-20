using Microsoft.EntityFrameworkCore.Migrations;

namespace Infrastructure.Migrations
{
    public partial class new1 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "EmployeeQualification",
                columns: table => new
                {
                    Empl_id = table.Column<long>(type: "bigint", nullable: false),
                    Qualification_id = table.Column<long>(type: "bigint", nullable: false),
                    Marks = table.Column<decimal>(type: "decimal(18,2)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EmployeeQualification", x => x.Empl_id);
                    table.ForeignKey(
                        name: "FK_EmployeeQualification_Employee_Empl_id",
                        column: x => x.Empl_id,
                        principalTable: "Employee",
                        principalColumn: "Employee_Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_EmployeeQualification_QualificationList_Qualification_id",
                        column: x => x.Qualification_id,
                        principalTable: "QualificationList",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_EmployeeQualification_Qualification_id",
                table: "EmployeeQualification",
                column: "Qualification_id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "EmployeeQualification");
        }
    }
}
