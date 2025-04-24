using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Leave_Management_System.Migrations
{
    public partial class InitDataSeed4 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Employees",
                keyColumn: "Id",
                keyValue: 1,
                column: "JoiningDate",
                value: new DateTime(2025, 4, 22, 18, 43, 2, 788, DateTimeKind.Local).AddTicks(5979));

            migrationBuilder.UpdateData(
                table: "Employees",
                keyColumn: "Id",
                keyValue: 2,
                column: "JoiningDate",
                value: new DateTime(2025, 4, 22, 18, 43, 2, 788, DateTimeKind.Local).AddTicks(6016));

            migrationBuilder.UpdateData(
                table: "Employees",
                keyColumn: "Id",
                keyValue: 3,
                column: "JoiningDate",
                value: new DateTime(2025, 4, 22, 18, 43, 2, 788, DateTimeKind.Local).AddTicks(6019));

            migrationBuilder.UpdateData(
                table: "LeaveRequests",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedAt", "EndDate", "StartDate" },
                values: new object[] { new DateTime(2025, 4, 22, 18, 43, 2, 788, DateTimeKind.Local).AddTicks(6130), new DateTime(2025, 4, 27, 18, 43, 2, 788, DateTimeKind.Local).AddTicks(6127), new DateTime(2025, 4, 22, 18, 43, 2, 788, DateTimeKind.Local).AddTicks(6125) });

            migrationBuilder.UpdateData(
                table: "LeaveRequests",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedAt", "EndDate", "StartDate" },
                values: new object[] { new DateTime(2025, 4, 22, 18, 43, 2, 788, DateTimeKind.Local).AddTicks(6135), new DateTime(2025, 4, 26, 18, 43, 2, 788, DateTimeKind.Local).AddTicks(6133), new DateTime(2025, 4, 22, 18, 43, 2, 788, DateTimeKind.Local).AddTicks(6132) });

            migrationBuilder.UpdateData(
                table: "LeaveRequests",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "CreatedAt", "EndDate", "StartDate" },
                values: new object[] { new DateTime(2025, 4, 22, 18, 43, 2, 788, DateTimeKind.Local).AddTicks(6140), new DateTime(2025, 4, 26, 18, 43, 2, 788, DateTimeKind.Local).AddTicks(6139), new DateTime(2025, 4, 22, 18, 43, 2, 788, DateTimeKind.Local).AddTicks(6137) });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
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
                column: "JoiningDate",
                value: new DateTime(2025, 4, 22, 18, 11, 35, 76, DateTimeKind.Local).AddTicks(2543));

            migrationBuilder.UpdateData(
                table: "Employees",
                keyColumn: "Id",
                keyValue: 3,
                column: "JoiningDate",
                value: new DateTime(2025, 4, 22, 18, 11, 35, 76, DateTimeKind.Local).AddTicks(2545));

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

            migrationBuilder.UpdateData(
                table: "LeaveRequests",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "CreatedAt", "EndDate", "StartDate" },
                values: new object[] { new DateTime(2025, 4, 22, 18, 11, 35, 76, DateTimeKind.Local).AddTicks(2670), new DateTime(2025, 4, 26, 18, 11, 35, 76, DateTimeKind.Local).AddTicks(2668), new DateTime(2025, 4, 22, 18, 11, 35, 76, DateTimeKind.Local).AddTicks(2666) });
        }
    }
}
