using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Leave_Management_System.Migrations
{
    public partial class InitDataSeed2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Employees",
                keyColumn: "Id",
                keyValue: 1,
                column: "JoiningDate",
                value: new DateTime(2025, 4, 22, 18, 11, 35, 76, DateTimeKind.Local).AddTicks(2513));

            migrationBuilder.UpdateData(
                table: "Employees",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "FullName", "JoiningDate" },
                values: new object[] { "John Doee", new DateTime(2025, 4, 22, 18, 11, 35, 76, DateTimeKind.Local).AddTicks(2543) });

            migrationBuilder.InsertData(
                table: "Employees",
                columns: new[] { "Id", "Department", "FullName", "JoiningDate" },
                values: new object[] { 3, "Auto", "aLEX aLEX", new DateTime(2025, 4, 22, 18, 11, 35, 76, DateTimeKind.Local).AddTicks(2545) });

            migrationBuilder.UpdateData(
                table: "LeaveRequests",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedAt", "EndDate", "StartDate" },
                values: new object[] { new DateTime(2025, 4, 22, 18, 11, 35, 76, DateTimeKind.Local).AddTicks(2658), new DateTime(2025, 4, 27, 18, 11, 35, 76, DateTimeKind.Local).AddTicks(2656), new DateTime(2025, 4, 22, 18, 11, 35, 76, DateTimeKind.Local).AddTicks(2653) });

            migrationBuilder.UpdateData(
                table: "LeaveRequests",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedAt", "EndDate", "StartDate" },
                values: new object[] { new DateTime(2025, 4, 22, 18, 11, 35, 76, DateTimeKind.Local).AddTicks(2664), new DateTime(2025, 4, 26, 18, 11, 35, 76, DateTimeKind.Local).AddTicks(2662), new DateTime(2025, 4, 22, 18, 11, 35, 76, DateTimeKind.Local).AddTicks(2661) });

            migrationBuilder.InsertData(
                table: "LeaveRequests",
                columns: new[] { "Id", "CreatedAt", "EmployeeId", "EndDate", "LeaveType", "Reason", "StartDate", "Status" },
                values: new object[] { 3, new DateTime(2025, 4, 22, 18, 11, 35, 76, DateTimeKind.Local).AddTicks(2670), 3, new DateTime(2025, 4, 26, 18, 11, 35, 76, DateTimeKind.Local).AddTicks(2668), 2, "Vacation", new DateTime(2025, 4, 22, 18, 11, 35, 76, DateTimeKind.Local).AddTicks(2666), 2 });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "LeaveRequests",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Employees",
                keyColumn: "Id",
                keyValue: 3);

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
                columns: new[] { "FullName", "JoiningDate" },
                values: new object[] { "John Doe", new DateTime(2025, 4, 22, 17, 52, 41, 727, DateTimeKind.Local).AddTicks(1550) });

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
    }
}
