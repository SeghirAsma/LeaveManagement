using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Leave_Management_System.Migrations
{
    public partial class InitDataSeed : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Employees",
                keyColumn: "Id",
                keyValue: 1,
                column: "JoiningDate",
                value: new DateTime(2025, 4, 22, 17, 52, 41, 727, DateTimeKind.Local).AddTicks(1516));

            migrationBuilder.UpdateData(
                table: "Employees",
                keyColumn: "Id",
                keyValue: 2,
                column: "JoiningDate",
                value: new DateTime(2025, 4, 22, 17, 52, 41, 727, DateTimeKind.Local).AddTicks(1550));

            migrationBuilder.UpdateData(
                table: "LeaveRequests",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedAt", "EndDate", "StartDate" },
                values: new object[] { new DateTime(2025, 4, 22, 17, 52, 41, 727, DateTimeKind.Local).AddTicks(1658), new DateTime(2025, 4, 27, 17, 52, 41, 727, DateTimeKind.Local).AddTicks(1656), new DateTime(2025, 4, 22, 17, 52, 41, 727, DateTimeKind.Local).AddTicks(1653) });

            migrationBuilder.UpdateData(
                table: "LeaveRequests",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedAt", "EndDate", "StartDate" },
                values: new object[] { new DateTime(2025, 4, 22, 17, 52, 41, 727, DateTimeKind.Local).AddTicks(1664), new DateTime(2025, 4, 26, 17, 52, 41, 727, DateTimeKind.Local).AddTicks(1662), new DateTime(2025, 4, 22, 17, 52, 41, 727, DateTimeKind.Local).AddTicks(1661) });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Employees",
                keyColumn: "Id",
                keyValue: 1,
                column: "JoiningDate",
                value: new DateTime(2025, 4, 22, 17, 9, 45, 933, DateTimeKind.Local).AddTicks(1654));

            migrationBuilder.UpdateData(
                table: "Employees",
                keyColumn: "Id",
                keyValue: 2,
                column: "JoiningDate",
                value: new DateTime(2025, 4, 22, 17, 9, 45, 933, DateTimeKind.Local).AddTicks(1702));

            migrationBuilder.UpdateData(
                table: "LeaveRequests",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedAt", "EndDate", "StartDate" },
                values: new object[] { new DateTime(2025, 4, 22, 17, 9, 45, 933, DateTimeKind.Local).AddTicks(1864), new DateTime(2025, 4, 27, 17, 9, 45, 933, DateTimeKind.Local).AddTicks(1860), new DateTime(2025, 4, 22, 17, 9, 45, 933, DateTimeKind.Local).AddTicks(1856) });

            migrationBuilder.UpdateData(
                table: "LeaveRequests",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedAt", "EndDate", "StartDate" },
                values: new object[] { new DateTime(2025, 4, 22, 17, 9, 45, 933, DateTimeKind.Local).AddTicks(1874), new DateTime(2025, 4, 26, 17, 9, 45, 933, DateTimeKind.Local).AddTicks(1871), new DateTime(2025, 4, 22, 17, 9, 45, 933, DateTimeKind.Local).AddTicks(1868) });
        }
    }
}
