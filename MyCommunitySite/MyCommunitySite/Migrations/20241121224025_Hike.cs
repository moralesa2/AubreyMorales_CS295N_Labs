using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MyCommunitySite.Migrations
{
    public partial class Hike : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AppUsers",
                keyColumn: "AppUserId",
                keyValue: 1,
                column: "SignupDate",
                value: new DateTime(2024, 11, 21, 14, 40, 25, 785, DateTimeKind.Local).AddTicks(3909));

            migrationBuilder.UpdateData(
                table: "AppUsers",
                keyColumn: "AppUserId",
                keyValue: 2,
                column: "SignupDate",
                value: new DateTime(2024, 11, 21, 14, 40, 25, 785, DateTimeKind.Local).AddTicks(3912));

            migrationBuilder.UpdateData(
                table: "AppUsers",
                keyColumn: "AppUserId",
                keyValue: 3,
                column: "SignupDate",
                value: new DateTime(2024, 11, 21, 14, 40, 25, 785, DateTimeKind.Local).AddTicks(3915));

            migrationBuilder.InsertData(
                table: "Hikes",
                columns: new[] { "HikeId", "Date", "Location" },
                values: new object[,]
                {
                    { 1, "11/08/2024", "Spencer Butte" },
                    { 2, "10/13/2024", "Ridgeline Trail - Fox Hollow to Mt. Baldy" }
                });

            migrationBuilder.UpdateData(
                table: "Messages",
                keyColumn: "MessageId",
                keyValue: 1,
                column: "TimeSent",
                value: new DateTime(2024, 11, 21, 14, 40, 25, 785, DateTimeKind.Local).AddTicks(3737));

            migrationBuilder.UpdateData(
                table: "Messages",
                keyColumn: "MessageId",
                keyValue: 2,
                column: "TimeSent",
                value: new DateTime(2024, 11, 21, 14, 40, 25, 785, DateTimeKind.Local).AddTicks(3773));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Hikes",
                keyColumn: "HikeId",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Hikes",
                keyColumn: "HikeId",
                keyValue: 2);

            migrationBuilder.UpdateData(
                table: "AppUsers",
                keyColumn: "AppUserId",
                keyValue: 1,
                column: "SignupDate",
                value: new DateTime(2024, 11, 19, 13, 8, 21, 398, DateTimeKind.Local).AddTicks(8676));

            migrationBuilder.UpdateData(
                table: "AppUsers",
                keyColumn: "AppUserId",
                keyValue: 2,
                column: "SignupDate",
                value: new DateTime(2024, 11, 19, 13, 8, 21, 398, DateTimeKind.Local).AddTicks(8703));

            migrationBuilder.UpdateData(
                table: "AppUsers",
                keyColumn: "AppUserId",
                keyValue: 3,
                column: "SignupDate",
                value: new DateTime(2024, 11, 19, 13, 8, 21, 398, DateTimeKind.Local).AddTicks(8704));

            migrationBuilder.UpdateData(
                table: "Messages",
                keyColumn: "MessageId",
                keyValue: 1,
                column: "TimeSent",
                value: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.UpdateData(
                table: "Messages",
                keyColumn: "MessageId",
                keyValue: 2,
                column: "TimeSent",
                value: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));
        }
    }
}
