﻿using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace GloboTicket.TicketManagement.Persistence.Migrations
{
    public partial class County : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "CountyId",
                table: "Counties",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.UpdateData(
                table: "Events",
                keyColumn: "EventId",
                keyValue: new Guid("1babd057-e980-4cb3-9cd2-7fdd9e525668"),
                column: "Date",
                value: new DateTime(2025, 2, 12, 0, 0, 12, 463, DateTimeKind.Local).AddTicks(2771));

            migrationBuilder.UpdateData(
                table: "Events",
                keyColumn: "EventId",
                keyValue: new Guid("3448d5a4-0f72-4dd7-bf15-c14a46b26c00"),
                column: "Date",
                value: new DateTime(2025, 1, 12, 0, 0, 12, 463, DateTimeKind.Local).AddTicks(2645));

            migrationBuilder.UpdateData(
                table: "Events",
                keyColumn: "EventId",
                keyValue: new Guid("62787623-4c52-43fe-b0c9-b7044fb5929b"),
                column: "Date",
                value: new DateTime(2024, 8, 12, 0, 0, 12, 463, DateTimeKind.Local).AddTicks(2751));

            migrationBuilder.UpdateData(
                table: "Events",
                keyColumn: "EventId",
                keyValue: new Guid("adc42c09-08c1-4d2c-9f96-2d15bb1af299"),
                column: "Date",
                value: new DateTime(2024, 12, 12, 0, 0, 12, 463, DateTimeKind.Local).AddTicks(2790));

            migrationBuilder.UpdateData(
                table: "Events",
                keyColumn: "EventId",
                keyValue: new Guid("b419a7ca-3321-4f38-be8e-4d7b6a529319"),
                column: "Date",
                value: new DateTime(2024, 8, 12, 0, 0, 12, 463, DateTimeKind.Local).AddTicks(2730));

            migrationBuilder.UpdateData(
                table: "Events",
                keyColumn: "EventId",
                keyValue: new Guid("ee272f8b-6096-4cb6-8625-bb4bb2d89e8b"),
                column: "Date",
                value: new DateTime(2024, 10, 12, 0, 0, 12, 461, DateTimeKind.Local).AddTicks(6680));

            migrationBuilder.UpdateData(
                table: "Orders",
                keyColumn: "Id",
                keyValue: new Guid("3dcb3ea0-80b1-4781-b5c0-4d85c41e55a6"),
                column: "OrderPlaced",
                value: new DateTime(2024, 4, 12, 0, 0, 12, 463, DateTimeKind.Local).AddTicks(3898));

            migrationBuilder.UpdateData(
                table: "Orders",
                keyColumn: "Id",
                keyValue: new Guid("771cca4b-066c-4ac7-b3df-4d12837fe7e0"),
                column: "OrderPlaced",
                value: new DateTime(2024, 4, 12, 0, 0, 12, 463, DateTimeKind.Local).AddTicks(3881));

            migrationBuilder.UpdateData(
                table: "Orders",
                keyColumn: "Id",
                keyValue: new Guid("7e94bc5b-71a5-4c8c-bc3b-71bb7976237e"),
                column: "OrderPlaced",
                value: new DateTime(2024, 4, 12, 0, 0, 12, 463, DateTimeKind.Local).AddTicks(3475));

            migrationBuilder.UpdateData(
                table: "Orders",
                keyColumn: "Id",
                keyValue: new Guid("86d3a045-b42d-4854-8150-d6a374948b6e"),
                column: "OrderPlaced",
                value: new DateTime(2024, 4, 12, 0, 0, 12, 463, DateTimeKind.Local).AddTicks(3850));

            migrationBuilder.UpdateData(
                table: "Orders",
                keyColumn: "Id",
                keyValue: new Guid("ba0eb0ef-b69b-46fd-b8e2-41b4178ae7cb"),
                column: "OrderPlaced",
                value: new DateTime(2024, 4, 12, 0, 0, 12, 463, DateTimeKind.Local).AddTicks(3949));

            migrationBuilder.UpdateData(
                table: "Orders",
                keyColumn: "Id",
                keyValue: new Guid("e6a2679c-79a3-4ef1-a478-6f4c91b405b6"),
                column: "OrderPlaced",
                value: new DateTime(2024, 4, 12, 0, 0, 12, 463, DateTimeKind.Local).AddTicks(3916));

            migrationBuilder.UpdateData(
                table: "Orders",
                keyColumn: "Id",
                keyValue: new Guid("f5a6a3a0-4227-4973-abb5-a63fbe725923"),
                column: "OrderPlaced",
                value: new DateTime(2024, 4, 12, 0, 0, 12, 463, DateTimeKind.Local).AddTicks(3934));

            migrationBuilder.CreateIndex(
                name: "IX_Works_CityId",
                table: "Works",
                column: "CityId");

            migrationBuilder.CreateIndex(
                name: "IX_Works_CountyId",
                table: "Works",
                column: "CountyId");

            migrationBuilder.CreateIndex(
                name: "IX_WorkCategoryTypes_WorkId",
                table: "WorkCategoryTypes",
                column: "WorkId");

            migrationBuilder.AddForeignKey(
                name: "FK_WorkCategoryTypes_Works_WorkId",
                table: "WorkCategoryTypes",
                column: "WorkId",
                principalTable: "Works",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Works_Cities_CityId",
                table: "Works",
                column: "CityId",
                principalTable: "Cities",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Works_Counties_CountyId",
                table: "Works",
                column: "CountyId",
                principalTable: "Counties",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_WorkCategoryTypes_Works_WorkId",
                table: "WorkCategoryTypes");

            migrationBuilder.DropForeignKey(
                name: "FK_Works_Cities_CityId",
                table: "Works");

            migrationBuilder.DropForeignKey(
                name: "FK_Works_Counties_CountyId",
                table: "Works");

            migrationBuilder.DropIndex(
                name: "IX_Works_CityId",
                table: "Works");

            migrationBuilder.DropIndex(
                name: "IX_Works_CountyId",
                table: "Works");

            migrationBuilder.DropIndex(
                name: "IX_WorkCategoryTypes_WorkId",
                table: "WorkCategoryTypes");

            migrationBuilder.DropColumn(
                name: "CountyId",
                table: "Counties");

            migrationBuilder.UpdateData(
                table: "Events",
                keyColumn: "EventId",
                keyValue: new Guid("1babd057-e980-4cb3-9cd2-7fdd9e525668"),
                column: "Date",
                value: new DateTime(2024, 11, 21, 11, 47, 31, 937, DateTimeKind.Local).AddTicks(2951));

            migrationBuilder.UpdateData(
                table: "Events",
                keyColumn: "EventId",
                keyValue: new Guid("3448d5a4-0f72-4dd7-bf15-c14a46b26c00"),
                column: "Date",
                value: new DateTime(2024, 10, 21, 11, 47, 31, 937, DateTimeKind.Local).AddTicks(2548));

            migrationBuilder.UpdateData(
                table: "Events",
                keyColumn: "EventId",
                keyValue: new Guid("62787623-4c52-43fe-b0c9-b7044fb5929b"),
                column: "Date",
                value: new DateTime(2024, 5, 21, 11, 47, 31, 937, DateTimeKind.Local).AddTicks(2886));

            migrationBuilder.UpdateData(
                table: "Events",
                keyColumn: "EventId",
                keyValue: new Guid("adc42c09-08c1-4d2c-9f96-2d15bb1af299"),
                column: "Date",
                value: new DateTime(2024, 9, 21, 11, 47, 31, 937, DateTimeKind.Local).AddTicks(3030));

            migrationBuilder.UpdateData(
                table: "Events",
                keyColumn: "EventId",
                keyValue: new Guid("b419a7ca-3321-4f38-be8e-4d7b6a529319"),
                column: "Date",
                value: new DateTime(2024, 5, 21, 11, 47, 31, 937, DateTimeKind.Local).AddTicks(2812));

            migrationBuilder.UpdateData(
                table: "Events",
                keyColumn: "EventId",
                keyValue: new Guid("ee272f8b-6096-4cb6-8625-bb4bb2d89e8b"),
                column: "Date",
                value: new DateTime(2024, 7, 21, 11, 47, 31, 933, DateTimeKind.Local).AddTicks(3988));

            migrationBuilder.UpdateData(
                table: "Orders",
                keyColumn: "Id",
                keyValue: new Guid("3dcb3ea0-80b1-4781-b5c0-4d85c41e55a6"),
                column: "OrderPlaced",
                value: new DateTime(2024, 1, 21, 11, 47, 31, 937, DateTimeKind.Local).AddTicks(7012));

            migrationBuilder.UpdateData(
                table: "Orders",
                keyColumn: "Id",
                keyValue: new Guid("771cca4b-066c-4ac7-b3df-4d12837fe7e0"),
                column: "OrderPlaced",
                value: new DateTime(2024, 1, 21, 11, 47, 31, 937, DateTimeKind.Local).AddTicks(6944));

            migrationBuilder.UpdateData(
                table: "Orders",
                keyColumn: "Id",
                keyValue: new Guid("7e94bc5b-71a5-4c8c-bc3b-71bb7976237e"),
                column: "OrderPlaced",
                value: new DateTime(2024, 1, 21, 11, 47, 31, 937, DateTimeKind.Local).AddTicks(5443));

            migrationBuilder.UpdateData(
                table: "Orders",
                keyColumn: "Id",
                keyValue: new Guid("86d3a045-b42d-4854-8150-d6a374948b6e"),
                column: "OrderPlaced",
                value: new DateTime(2024, 1, 21, 11, 47, 31, 937, DateTimeKind.Local).AddTicks(6827));

            migrationBuilder.UpdateData(
                table: "Orders",
                keyColumn: "Id",
                keyValue: new Guid("ba0eb0ef-b69b-46fd-b8e2-41b4178ae7cb"),
                column: "OrderPlaced",
                value: new DateTime(2024, 1, 21, 11, 47, 31, 937, DateTimeKind.Local).AddTicks(7340));

            migrationBuilder.UpdateData(
                table: "Orders",
                keyColumn: "Id",
                keyValue: new Guid("e6a2679c-79a3-4ef1-a478-6f4c91b405b6"),
                column: "OrderPlaced",
                value: new DateTime(2024, 1, 21, 11, 47, 31, 937, DateTimeKind.Local).AddTicks(7078));

            migrationBuilder.UpdateData(
                table: "Orders",
                keyColumn: "Id",
                keyValue: new Guid("f5a6a3a0-4227-4973-abb5-a63fbe725923"),
                column: "OrderPlaced",
                value: new DateTime(2024, 1, 21, 11, 47, 31, 937, DateTimeKind.Local).AddTicks(7272));
        }
    }
}
