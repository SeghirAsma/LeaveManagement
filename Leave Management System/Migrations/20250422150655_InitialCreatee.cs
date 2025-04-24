using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Leave_Management_System.Migrations
{
    public partial class InitialCreatee : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Employees",
                keyColumn: "Id",
                keyValue: 1,
                column: "JoiningDate",
                value: new DateTime(2025, 4, 22, 17, 6, 55, 521, DateTimeKind.Local).AddTicks(6618));

            migrationBuilder.UpdateData(
                table: "Employees",
                keyColumn: "Id",
                keyValue: 2,
                column: "JoiningDate",
                value: new DateTime(2025, 4, 22, 17, 6, 55, 521, DateTimeKind.Local).AddTicks(6654));

            migrationBuilder.UpdateData(
                table: "LeaveRequests",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedAt", "EndDate", "StartDate" },
                values: new object[] { new DateTime(2025, 4, 22, 17, 6, 55, 521, DateTimeKind.Local).AddTicks(6789), new DateTime(2025, 4, 27, 17, 6, 55, 521, DateTimeKind.Local).AddTicks(6787), new DateTime(2025, 4, 22, 17, 6, 55, 521, DateTimeKind.Local).AddTicks(6783) });

            migrationBuilder.UpdateData(
                table: "LeaveRequests",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedAt", "EndDate", "StartDate" },
                values: new object[] { new DateTime(2025, 4, 22, 17, 6, 55, 521, DateTimeKind.Local).AddTicks(6796), new DateTime(2025, 4, 26, 17, 6, 55, 521, DateTimeKind.Local).AddTicks(6794), new DateTime(2025, 4, 22, 17, 6, 55, 521, DateTimeKind.Local).AddTicks(6792) });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Employees",
                keyColumn: "Id",
                keyValue: 1,
                column: "JoiningDate",
                value: new DateTime(2025, 4, 22, 16, 53, 31, 264, DateTimeKind.Local).AddTicks(7130));

            migrationBuilder.UpdateData(
                table: "Employees",
                keyColumn: "Id",
                keyValue: 2,
                column: "JoiningDate",
                value: new DateTime(2025, 4, 22, 16, 53, 31, 264, DateTimeKind.Local).AddTicks(7163));

            migrationBuilder.UpdateData(
                table: "LeaveRequests",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedAt", "EndDate", "StartDate" },
                values: new object[] { new DateTime(2025, 4, 22, 16, 53, 31, 264, DateTimeKind.Local).AddTicks(7273), new DateTime(2025, 4, 27, 16, 53, 31, 264, DateTimeKind.Local).AddTicks(7271), new DateTime(2025, 4, 22, 16, 53, 31, 264, DateTimeKind.Local).AddTicks(7268) });

            migrationBuilder.UpdateData(
                table: "LeaveRequests",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedAt", "EndDate", "StartDate" },
                values: new object[] { new DateTime(2025, 4, 22, 16, 53, 31, 264, DateTimeKind.Local).AddTicks(7279), new DateTime(2025, 4, 26, 16, 53, 31, 264, DateTimeKind.Local).AddTicks(7277), new DateTime(2025, 4, 22, 16, 53, 31, 264, DateTimeKind.Local).AddTicks(7276) });
        }
    }
}
