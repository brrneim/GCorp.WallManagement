using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace GloboTicket.TicketManagement.Persistence.Migrations
{
    public partial class Customercommentforeignkeys : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CategoryTypes_Customers_CustomerId",
                table: "CategoryTypes");

            migrationBuilder.DropIndex(
                name: "IX_CategoryTypes_CustomerId",
                table: "CategoryTypes");

            migrationBuilder.DropColumn(
                name: "CommentCount",
                table: "Customers");

            migrationBuilder.DropColumn(
                name: "Rating",
                table: "Customers");

            migrationBuilder.DropColumn(
                name: "CustomerId",
                table: "CategoryTypes");

            migrationBuilder.UpdateData(
                table: "Events",
                keyColumn: "EventId",
                keyValue: new Guid("1babd057-e980-4cb3-9cd2-7fdd9e525668"),
                column: "Date",
                value: new DateTime(2025, 2, 19, 22, 26, 7, 875, DateTimeKind.Local).AddTicks(1601));

            migrationBuilder.UpdateData(
                table: "Events",
                keyColumn: "EventId",
                keyValue: new Guid("3448d5a4-0f72-4dd7-bf15-c14a46b26c00"),
                column: "Date",
                value: new DateTime(2025, 1, 19, 22, 26, 7, 875, DateTimeKind.Local).AddTicks(1462));

            migrationBuilder.UpdateData(
                table: "Events",
                keyColumn: "EventId",
                keyValue: new Guid("62787623-4c52-43fe-b0c9-b7044fb5929b"),
                column: "Date",
                value: new DateTime(2024, 8, 19, 22, 26, 7, 875, DateTimeKind.Local).AddTicks(1582));

            migrationBuilder.UpdateData(
                table: "Events",
                keyColumn: "EventId",
                keyValue: new Guid("adc42c09-08c1-4d2c-9f96-2d15bb1af299"),
                column: "Date",
                value: new DateTime(2024, 12, 19, 22, 26, 7, 875, DateTimeKind.Local).AddTicks(1673));

            migrationBuilder.UpdateData(
                table: "Events",
                keyColumn: "EventId",
                keyValue: new Guid("b419a7ca-3321-4f38-be8e-4d7b6a529319"),
                column: "Date",
                value: new DateTime(2024, 8, 19, 22, 26, 7, 875, DateTimeKind.Local).AddTicks(1558));

            migrationBuilder.UpdateData(
                table: "Events",
                keyColumn: "EventId",
                keyValue: new Guid("ee272f8b-6096-4cb6-8625-bb4bb2d89e8b"),
                column: "Date",
                value: new DateTime(2024, 10, 19, 22, 26, 7, 873, DateTimeKind.Local).AddTicks(3948));

            migrationBuilder.UpdateData(
                table: "Orders",
                keyColumn: "Id",
                keyValue: new Guid("3dcb3ea0-80b1-4781-b5c0-4d85c41e55a6"),
                column: "OrderPlaced",
                value: new DateTime(2024, 4, 19, 22, 26, 7, 875, DateTimeKind.Local).AddTicks(2898));

            migrationBuilder.UpdateData(
                table: "Orders",
                keyColumn: "Id",
                keyValue: new Guid("771cca4b-066c-4ac7-b3df-4d12837fe7e0"),
                column: "OrderPlaced",
                value: new DateTime(2024, 4, 19, 22, 26, 7, 875, DateTimeKind.Local).AddTicks(2882));

            migrationBuilder.UpdateData(
                table: "Orders",
                keyColumn: "Id",
                keyValue: new Guid("7e94bc5b-71a5-4c8c-bc3b-71bb7976237e"),
                column: "OrderPlaced",
                value: new DateTime(2024, 4, 19, 22, 26, 7, 875, DateTimeKind.Local).AddTicks(2423));

            migrationBuilder.UpdateData(
                table: "Orders",
                keyColumn: "Id",
                keyValue: new Guid("86d3a045-b42d-4854-8150-d6a374948b6e"),
                column: "OrderPlaced",
                value: new DateTime(2024, 4, 19, 22, 26, 7, 875, DateTimeKind.Local).AddTicks(2844));

            migrationBuilder.UpdateData(
                table: "Orders",
                keyColumn: "Id",
                keyValue: new Guid("ba0eb0ef-b69b-46fd-b8e2-41b4178ae7cb"),
                column: "OrderPlaced",
                value: new DateTime(2024, 4, 19, 22, 26, 7, 875, DateTimeKind.Local).AddTicks(2947));

            migrationBuilder.UpdateData(
                table: "Orders",
                keyColumn: "Id",
                keyValue: new Guid("e6a2679c-79a3-4ef1-a478-6f4c91b405b6"),
                column: "OrderPlaced",
                value: new DateTime(2024, 4, 19, 22, 26, 7, 875, DateTimeKind.Local).AddTicks(2914));

            migrationBuilder.UpdateData(
                table: "Orders",
                keyColumn: "Id",
                keyValue: new Guid("f5a6a3a0-4227-4973-abb5-a63fbe725923"),
                column: "OrderPlaced",
                value: new DateTime(2024, 4, 19, 22, 26, 7, 875, DateTimeKind.Local).AddTicks(2932));

            migrationBuilder.CreateIndex(
                name: "IX_CustomerComments_CommentCustomerId",
                table: "CustomerComments",
                column: "CommentCustomerId");

            migrationBuilder.AddForeignKey(
                name: "FK_CustomerComments_Customers_CommentCustomerId",
                table: "CustomerComments",
                column: "CommentCustomerId",
                principalTable: "Customers",
                principalColumn: "Id",
                onDelete: ReferentialAction.NoAction);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CustomerComments_Customers_CommentCustomerId",
                table: "CustomerComments");

            migrationBuilder.DropIndex(
                name: "IX_CustomerComments_CommentCustomerId",
                table: "CustomerComments");

            migrationBuilder.AddColumn<decimal>(
                name: "CommentCount",
                table: "Customers",
                type: "decimal(18,2)",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddColumn<decimal>(
                name: "Rating",
                table: "Customers",
                type: "decimal(18,2)",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddColumn<Guid>(
                name: "CustomerId",
                table: "CategoryTypes",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.UpdateData(
                table: "Events",
                keyColumn: "EventId",
                keyValue: new Guid("1babd057-e980-4cb3-9cd2-7fdd9e525668"),
                column: "Date",
                value: new DateTime(2025, 2, 19, 9, 47, 45, 80, DateTimeKind.Local).AddTicks(9735));

            migrationBuilder.UpdateData(
                table: "Events",
                keyColumn: "EventId",
                keyValue: new Guid("3448d5a4-0f72-4dd7-bf15-c14a46b26c00"),
                column: "Date",
                value: new DateTime(2025, 1, 19, 9, 47, 45, 80, DateTimeKind.Local).AddTicks(9592));

            migrationBuilder.UpdateData(
                table: "Events",
                keyColumn: "EventId",
                keyValue: new Guid("62787623-4c52-43fe-b0c9-b7044fb5929b"),
                column: "Date",
                value: new DateTime(2024, 8, 19, 9, 47, 45, 80, DateTimeKind.Local).AddTicks(9716));

            migrationBuilder.UpdateData(
                table: "Events",
                keyColumn: "EventId",
                keyValue: new Guid("adc42c09-08c1-4d2c-9f96-2d15bb1af299"),
                column: "Date",
                value: new DateTime(2024, 12, 19, 9, 47, 45, 80, DateTimeKind.Local).AddTicks(9757));

            migrationBuilder.UpdateData(
                table: "Events",
                keyColumn: "EventId",
                keyValue: new Guid("b419a7ca-3321-4f38-be8e-4d7b6a529319"),
                column: "Date",
                value: new DateTime(2024, 8, 19, 9, 47, 45, 80, DateTimeKind.Local).AddTicks(9693));

            migrationBuilder.UpdateData(
                table: "Events",
                keyColumn: "EventId",
                keyValue: new Guid("ee272f8b-6096-4cb6-8625-bb4bb2d89e8b"),
                column: "Date",
                value: new DateTime(2024, 10, 19, 9, 47, 45, 79, DateTimeKind.Local).AddTicks(1621));

            migrationBuilder.UpdateData(
                table: "Orders",
                keyColumn: "Id",
                keyValue: new Guid("3dcb3ea0-80b1-4781-b5c0-4d85c41e55a6"),
                column: "OrderPlaced",
                value: new DateTime(2024, 4, 19, 9, 47, 45, 81, DateTimeKind.Local).AddTicks(1095));

            migrationBuilder.UpdateData(
                table: "Orders",
                keyColumn: "Id",
                keyValue: new Guid("771cca4b-066c-4ac7-b3df-4d12837fe7e0"),
                column: "OrderPlaced",
                value: new DateTime(2024, 4, 19, 9, 47, 45, 81, DateTimeKind.Local).AddTicks(1058));

            migrationBuilder.UpdateData(
                table: "Orders",
                keyColumn: "Id",
                keyValue: new Guid("7e94bc5b-71a5-4c8c-bc3b-71bb7976237e"),
                column: "OrderPlaced",
                value: new DateTime(2024, 4, 19, 9, 47, 45, 81, DateTimeKind.Local).AddTicks(568));

            migrationBuilder.UpdateData(
                table: "Orders",
                keyColumn: "Id",
                keyValue: new Guid("86d3a045-b42d-4854-8150-d6a374948b6e"),
                column: "OrderPlaced",
                value: new DateTime(2024, 4, 19, 9, 47, 45, 81, DateTimeKind.Local).AddTicks(1021));

            migrationBuilder.UpdateData(
                table: "Orders",
                keyColumn: "Id",
                keyValue: new Guid("ba0eb0ef-b69b-46fd-b8e2-41b4178ae7cb"),
                column: "OrderPlaced",
                value: new DateTime(2024, 4, 19, 9, 47, 45, 81, DateTimeKind.Local).AddTicks(1152));

            migrationBuilder.UpdateData(
                table: "Orders",
                keyColumn: "Id",
                keyValue: new Guid("e6a2679c-79a3-4ef1-a478-6f4c91b405b6"),
                column: "OrderPlaced",
                value: new DateTime(2024, 4, 19, 9, 47, 45, 81, DateTimeKind.Local).AddTicks(1114));

            migrationBuilder.UpdateData(
                table: "Orders",
                keyColumn: "Id",
                keyValue: new Guid("f5a6a3a0-4227-4973-abb5-a63fbe725923"),
                column: "OrderPlaced",
                value: new DateTime(2024, 4, 19, 9, 47, 45, 81, DateTimeKind.Local).AddTicks(1134));

            migrationBuilder.CreateIndex(
                name: "IX_CategoryTypes_CustomerId",
                table: "CategoryTypes",
                column: "CustomerId");

            migrationBuilder.AddForeignKey(
                name: "FK_CategoryTypes_Customers_CustomerId",
                table: "CategoryTypes",
                column: "CustomerId",
                principalTable: "Customers",
                principalColumn: "Id",
                onDelete: ReferentialAction.NoAction);
        }
    }
}
