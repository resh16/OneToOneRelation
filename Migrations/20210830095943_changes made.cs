using Microsoft.EntityFrameworkCore.Migrations;

namespace OneToOneRelation.Migrations
{
    public partial class changesmade : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Skill_employee_EmployeeId",
                table: "Skill");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Skill",
                table: "Skill");

            migrationBuilder.RenameTable(
                name: "Skill",
                newName: "skill");

            migrationBuilder.RenameIndex(
                name: "IX_Skill_EmployeeId",
                table: "skill",
                newName: "IX_skill_EmployeeId");

            migrationBuilder.RenameColumn(
                name: "Designation",
                table: "employee",
                newName: "Destination");

            migrationBuilder.AddPrimaryKey(
                name: "PK_skill",
                table: "skill",
                column: "skillId");

            migrationBuilder.AddForeignKey(
                name: "FK_skill_employee_EmployeeId",
                table: "skill",
                column: "EmployeeId",
                principalTable: "employee",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_skill_employee_EmployeeId",
                table: "skill");

            migrationBuilder.DropPrimaryKey(
                name: "PK_skill",
                table: "skill");

            migrationBuilder.RenameTable(
                name: "skill",
                newName: "Skill");

            migrationBuilder.RenameIndex(
                name: "IX_skill_EmployeeId",
                table: "Skill",
                newName: "IX_Skill_EmployeeId");

            migrationBuilder.RenameColumn(
                name: "Destination",
                table: "employee",
                newName: "Designation");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Skill",
                table: "Skill",
                column: "skillId");

            migrationBuilder.AddForeignKey(
                name: "FK_Skill_employee_EmployeeId",
                table: "Skill",
                column: "EmployeeId",
                principalTable: "employee",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
