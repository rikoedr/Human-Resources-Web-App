using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace API.Migrations
{
    public partial class SecondDbMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_tb_employees_email",
                table: "tb_employees");

            migrationBuilder.DeleteData(
                table: "job_history",
                keyColumn: "guid",
                keyValue: new Guid("21caa0f5-0386-4642-a4fd-eb1c02cabfb7"));

            migrationBuilder.DeleteData(
                table: "job_history",
                keyColumn: "guid",
                keyValue: new Guid("430613f7-7919-4140-84f4-e69957fc6d18"));

            migrationBuilder.DeleteData(
                table: "job_history",
                keyColumn: "guid",
                keyValue: new Guid("b41980c1-b5d8-4e55-b1cb-b31ba5258062"));

            migrationBuilder.DeleteData(
                table: "tb_account_roles",
                keyColumn: "guid",
                keyValue: new Guid("21b7f5a1-2440-48bf-839d-58e54a217767"));

            migrationBuilder.DeleteData(
                table: "tb_account_roles",
                keyColumn: "guid",
                keyValue: new Guid("4b22fe67-6317-43c3-b1c7-fbce518d6e54"));

            migrationBuilder.DeleteData(
                table: "tb_account_roles",
                keyColumn: "guid",
                keyValue: new Guid("f32701bd-f7fb-4034-80fc-2e07199c68d0"));

            migrationBuilder.DropColumn(
                name: "email",
                table: "tb_employees");

            migrationBuilder.AddColumn<string>(
                name: "email",
                table: "tb_accounts",
                type: "nvarchar(100)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.InsertData(
                table: "job_history",
                columns: new[] { "guid", "created_date", "employee_guid", "end_date", "job_guid", "modified_date", "start_date" },
                values: new object[,]
                {
                    { new Guid("17fe41e0-8f89-4dd9-b428-0df82f511eb5"), new DateTime(2023, 11, 28, 18, 20, 28, 189, DateTimeKind.Local).AddTicks(4137), new Guid("0c05eaec-3052-40b2-badd-8e69153a8c50"), new DateTime(2023, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new Guid("25abd2bc-c0fe-411a-ba24-f26cbae523c2"), new DateTime(2023, 11, 28, 18, 20, 28, 189, DateTimeKind.Local).AddTicks(4137), new DateTime(2020, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("5c3d8c03-561d-48f4-815e-6a5517ff9cd5"), new DateTime(2023, 11, 28, 18, 20, 28, 189, DateTimeKind.Local).AddTicks(4150), new Guid("5bc27f65-a3ec-41cf-a1a7-701b4b674653"), null, new Guid("a3b9dd56-768a-45f7-99e1-8b42e9c8847f"), new DateTime(2023, 11, 28, 18, 20, 28, 189, DateTimeKind.Local).AddTicks(4150), new DateTime(2018, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("9942b924-53cd-4c27-9ca3-e46bca92b75a"), new DateTime(2023, 11, 28, 18, 20, 28, 189, DateTimeKind.Local).AddTicks(4126), new Guid("03e53d0a-09fe-42d3-80eb-3a80339f679d"), null, new Guid("1105117d-ed96-4206-bd43-0e13b7342770"), new DateTime(2023, 11, 28, 18, 20, 28, 189, DateTimeKind.Local).AddTicks(4127), new DateTime(2021, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) }
                });

            migrationBuilder.InsertData(
                table: "tb_account_roles",
                columns: new[] { "guid", "account_guid", "created_date", "modified_date", "role_guid" },
                values: new object[,]
                {
                    { new Guid("06142e7c-a9ef-47bc-9c7a-87553b5d3b8d"), new Guid("5bc27f65-a3ec-41cf-a1a7-701b4b674653"), new DateTime(2023, 11, 28, 18, 20, 28, 189, DateTimeKind.Local).AddTicks(4003), new DateTime(2023, 11, 28, 18, 20, 28, 189, DateTimeKind.Local).AddTicks(4003), new Guid("aca8df20-f7d1-464c-947a-b22bc96c2394") },
                    { new Guid("914ae5ba-a980-46e7-927c-71f82589157b"), new Guid("03e53d0a-09fe-42d3-80eb-3a80339f679d"), new DateTime(2023, 11, 28, 18, 20, 28, 189, DateTimeKind.Local).AddTicks(3931), new DateTime(2023, 11, 28, 18, 20, 28, 189, DateTimeKind.Local).AddTicks(3936), new Guid("aad98c8c-c71e-46f4-99c1-2d073ecb467f") },
                    { new Guid("ca3c3fef-ed8c-4c2e-a8e3-5810afeaee74"), new Guid("0c05eaec-3052-40b2-badd-8e69153a8c50"), new DateTime(2023, 11, 28, 18, 20, 28, 189, DateTimeKind.Local).AddTicks(3975), new DateTime(2023, 11, 28, 18, 20, 28, 189, DateTimeKind.Local).AddTicks(3976), new Guid("8d1da011-8574-4be4-9f64-657254f764d6") }
                });

            migrationBuilder.UpdateData(
                table: "tb_accounts",
                keyColumn: "guid",
                keyValue: new Guid("03e53d0a-09fe-42d3-80eb-3a80339f679d"),
                columns: new[] { "created_date", "email", "modified_date", "otp_expired_time", "password" },
                values: new object[] { new DateTime(2023, 11, 28, 18, 20, 27, 314, DateTimeKind.Local).AddTicks(4838), "john.doe@example.com", new DateTime(2023, 11, 28, 18, 20, 27, 314, DateTimeKind.Local).AddTicks(4839), new DateTime(2023, 11, 28, 18, 20, 27, 314, DateTimeKind.Local).AddTicks(4840), "$2a$12$mvo2XQ5OGmiYMXdhsNEv5uHtl2D0BVfz/yEaZO6xmPtJzQgoJIFEm" });

            migrationBuilder.UpdateData(
                table: "tb_accounts",
                keyColumn: "guid",
                keyValue: new Guid("0c05eaec-3052-40b2-badd-8e69153a8c50"),
                columns: new[] { "created_date", "email", "modified_date", "otp_expired_time", "password" },
                values: new object[] { new DateTime(2023, 11, 28, 18, 20, 27, 610, DateTimeKind.Local).AddTicks(6064), "jane.smith@example.com", new DateTime(2023, 11, 28, 18, 20, 27, 610, DateTimeKind.Local).AddTicks(6065), new DateTime(2023, 11, 28, 18, 20, 27, 610, DateTimeKind.Local).AddTicks(6066), "$2a$12$2HIg78Ra3XYp3OgNYlKo0.rdcVkESeGojVEp0mrMKwaQDU5dGbXRW" });

            migrationBuilder.UpdateData(
                table: "tb_accounts",
                keyColumn: "guid",
                keyValue: new Guid("5bc27f65-a3ec-41cf-a1a7-701b4b674653"),
                columns: new[] { "created_date", "email", "modified_date", "otp_expired_time", "password" },
                values: new object[] { new DateTime(2023, 11, 28, 18, 20, 27, 908, DateTimeKind.Local).AddTicks(121), "bob.johnson@example.com", new DateTime(2023, 11, 28, 18, 20, 27, 908, DateTimeKind.Local).AddTicks(122), new DateTime(2023, 11, 28, 18, 20, 27, 908, DateTimeKind.Local).AddTicks(123), "$2a$12$dE8nYE5UDZUyI3F78G/96.CncktYpQSYXLhkM5TuuWQuJBjpSeis6" });

            migrationBuilder.UpdateData(
                table: "tb_departments",
                keyColumn: "guid",
                keyValue: new Guid("7644ad73-57b6-4640-9e8d-f929ba01e694"),
                columns: new[] { "created_date", "modified_date" },
                values: new object[] { new DateTime(2023, 11, 28, 18, 20, 27, 314, DateTimeKind.Local).AddTicks(4583), new DateTime(2023, 11, 28, 18, 20, 27, 314, DateTimeKind.Local).AddTicks(4595) });

            migrationBuilder.UpdateData(
                table: "tb_departments",
                keyColumn: "guid",
                keyValue: new Guid("9e0e4c05-cde2-4900-88f9-2a2b8ee0dad6"),
                columns: new[] { "created_date", "modified_date" },
                values: new object[] { new DateTime(2023, 11, 28, 18, 20, 27, 314, DateTimeKind.Local).AddTicks(4597), new DateTime(2023, 11, 28, 18, 20, 27, 314, DateTimeKind.Local).AddTicks(4598) });

            migrationBuilder.UpdateData(
                table: "tb_departments",
                keyColumn: "guid",
                keyValue: new Guid("e8246140-6e0a-488e-b451-9321b6694736"),
                columns: new[] { "created_date", "modified_date" },
                values: new object[] { new DateTime(2023, 11, 28, 18, 20, 27, 314, DateTimeKind.Local).AddTicks(4600), new DateTime(2023, 11, 28, 18, 20, 27, 314, DateTimeKind.Local).AddTicks(4600) });

            migrationBuilder.UpdateData(
                table: "tb_employees",
                keyColumn: "guid",
                keyValue: new Guid("03e53d0a-09fe-42d3-80eb-3a80339f679d"),
                columns: new[] { "created_date", "modified_date" },
                values: new object[] { new DateTime(2023, 11, 28, 18, 20, 27, 314, DateTimeKind.Local).AddTicks(4788), new DateTime(2023, 11, 28, 18, 20, 27, 314, DateTimeKind.Local).AddTicks(4788) });

            migrationBuilder.UpdateData(
                table: "tb_employees",
                keyColumn: "guid",
                keyValue: new Guid("0c05eaec-3052-40b2-badd-8e69153a8c50"),
                columns: new[] { "created_date", "modified_date" },
                values: new object[] { new DateTime(2023, 11, 28, 18, 20, 27, 314, DateTimeKind.Local).AddTicks(4799), new DateTime(2023, 11, 28, 18, 20, 27, 314, DateTimeKind.Local).AddTicks(4800) });

            migrationBuilder.UpdateData(
                table: "tb_employees",
                keyColumn: "guid",
                keyValue: new Guid("5bc27f65-a3ec-41cf-a1a7-701b4b674653"),
                columns: new[] { "created_date", "modified_date" },
                values: new object[] { new DateTime(2023, 11, 28, 18, 20, 27, 314, DateTimeKind.Local).AddTicks(4807), new DateTime(2023, 11, 28, 18, 20, 27, 314, DateTimeKind.Local).AddTicks(4807) });

            migrationBuilder.UpdateData(
                table: "tb_jobs",
                keyColumn: "guid",
                keyValue: new Guid("1105117d-ed96-4206-bd43-0e13b7342770"),
                columns: new[] { "created_date", "modified_date" },
                values: new object[] { new DateTime(2023, 11, 28, 18, 20, 27, 314, DateTimeKind.Local).AddTicks(4732), new DateTime(2023, 11, 28, 18, 20, 27, 314, DateTimeKind.Local).AddTicks(4733) });

            migrationBuilder.UpdateData(
                table: "tb_jobs",
                keyColumn: "guid",
                keyValue: new Guid("25abd2bc-c0fe-411a-ba24-f26cbae523c2"),
                columns: new[] { "created_date", "modified_date" },
                values: new object[] { new DateTime(2023, 11, 28, 18, 20, 27, 314, DateTimeKind.Local).AddTicks(4736), new DateTime(2023, 11, 28, 18, 20, 27, 314, DateTimeKind.Local).AddTicks(4736) });

            migrationBuilder.UpdateData(
                table: "tb_jobs",
                keyColumn: "guid",
                keyValue: new Guid("a3b9dd56-768a-45f7-99e1-8b42e9c8847f"),
                columns: new[] { "created_date", "modified_date" },
                values: new object[] { new DateTime(2023, 11, 28, 18, 20, 27, 314, DateTimeKind.Local).AddTicks(4739), new DateTime(2023, 11, 28, 18, 20, 27, 314, DateTimeKind.Local).AddTicks(4739) });

            migrationBuilder.UpdateData(
                table: "tb_roles",
                keyColumn: "guid",
                keyValue: new Guid("8d1da011-8574-4be4-9f64-657254f764d6"),
                columns: new[] { "created_date", "modified_date" },
                values: new object[] { new DateTime(2023, 11, 28, 18, 20, 27, 314, DateTimeKind.Local).AddTicks(4766), new DateTime(2023, 11, 28, 18, 20, 27, 314, DateTimeKind.Local).AddTicks(4766) });

            migrationBuilder.UpdateData(
                table: "tb_roles",
                keyColumn: "guid",
                keyValue: new Guid("aad98c8c-c71e-46f4-99c1-2d073ecb467f"),
                columns: new[] { "created_date", "modified_date" },
                values: new object[] { new DateTime(2023, 11, 28, 18, 20, 27, 314, DateTimeKind.Local).AddTicks(4762), new DateTime(2023, 11, 28, 18, 20, 27, 314, DateTimeKind.Local).AddTicks(4763) });

            migrationBuilder.UpdateData(
                table: "tb_roles",
                keyColumn: "guid",
                keyValue: new Guid("aca8df20-f7d1-464c-947a-b22bc96c2394"),
                columns: new[] { "created_date", "modified_date" },
                values: new object[] { new DateTime(2023, 11, 28, 18, 20, 27, 314, DateTimeKind.Local).AddTicks(4769), new DateTime(2023, 11, 28, 18, 20, 27, 314, DateTimeKind.Local).AddTicks(4769) });

            migrationBuilder.CreateIndex(
                name: "IX_tb_accounts_email",
                table: "tb_accounts",
                column: "email",
                unique: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_tb_accounts_email",
                table: "tb_accounts");

            migrationBuilder.DeleteData(
                table: "job_history",
                keyColumn: "guid",
                keyValue: new Guid("17fe41e0-8f89-4dd9-b428-0df82f511eb5"));

            migrationBuilder.DeleteData(
                table: "job_history",
                keyColumn: "guid",
                keyValue: new Guid("5c3d8c03-561d-48f4-815e-6a5517ff9cd5"));

            migrationBuilder.DeleteData(
                table: "job_history",
                keyColumn: "guid",
                keyValue: new Guid("9942b924-53cd-4c27-9ca3-e46bca92b75a"));

            migrationBuilder.DeleteData(
                table: "tb_account_roles",
                keyColumn: "guid",
                keyValue: new Guid("06142e7c-a9ef-47bc-9c7a-87553b5d3b8d"));

            migrationBuilder.DeleteData(
                table: "tb_account_roles",
                keyColumn: "guid",
                keyValue: new Guid("914ae5ba-a980-46e7-927c-71f82589157b"));

            migrationBuilder.DeleteData(
                table: "tb_account_roles",
                keyColumn: "guid",
                keyValue: new Guid("ca3c3fef-ed8c-4c2e-a8e3-5810afeaee74"));

            migrationBuilder.DropColumn(
                name: "email",
                table: "tb_accounts");

            migrationBuilder.AddColumn<string>(
                name: "email",
                table: "tb_employees",
                type: "nvarchar(50)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.InsertData(
                table: "job_history",
                columns: new[] { "guid", "created_date", "employee_guid", "end_date", "job_guid", "modified_date", "start_date" },
                values: new object[,]
                {
                    { new Guid("21caa0f5-0386-4642-a4fd-eb1c02cabfb7"), new DateTime(2023, 11, 28, 15, 56, 32, 140, DateTimeKind.Local).AddTicks(7303), new Guid("5bc27f65-a3ec-41cf-a1a7-701b4b674653"), null, new Guid("a3b9dd56-768a-45f7-99e1-8b42e9c8847f"), new DateTime(2023, 11, 28, 15, 56, 32, 140, DateTimeKind.Local).AddTicks(7304), new DateTime(2018, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("430613f7-7919-4140-84f4-e69957fc6d18"), new DateTime(2023, 11, 28, 15, 56, 32, 140, DateTimeKind.Local).AddTicks(7277), new Guid("03e53d0a-09fe-42d3-80eb-3a80339f679d"), null, new Guid("1105117d-ed96-4206-bd43-0e13b7342770"), new DateTime(2023, 11, 28, 15, 56, 32, 140, DateTimeKind.Local).AddTicks(7277), new DateTime(2021, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("b41980c1-b5d8-4e55-b1cb-b31ba5258062"), new DateTime(2023, 11, 28, 15, 56, 32, 140, DateTimeKind.Local).AddTicks(7287), new Guid("0c05eaec-3052-40b2-badd-8e69153a8c50"), new DateTime(2023, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new Guid("25abd2bc-c0fe-411a-ba24-f26cbae523c2"), new DateTime(2023, 11, 28, 15, 56, 32, 140, DateTimeKind.Local).AddTicks(7287), new DateTime(2020, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) }
                });

            migrationBuilder.InsertData(
                table: "tb_account_roles",
                columns: new[] { "guid", "account_guid", "created_date", "modified_date", "role_guid" },
                values: new object[,]
                {
                    { new Guid("21b7f5a1-2440-48bf-839d-58e54a217767"), new Guid("03e53d0a-09fe-42d3-80eb-3a80339f679d"), new DateTime(2023, 11, 28, 15, 56, 32, 140, DateTimeKind.Local).AddTicks(7125), new DateTime(2023, 11, 28, 15, 56, 32, 140, DateTimeKind.Local).AddTicks(7135), new Guid("aad98c8c-c71e-46f4-99c1-2d073ecb467f") },
                    { new Guid("4b22fe67-6317-43c3-b1c7-fbce518d6e54"), new Guid("0c05eaec-3052-40b2-badd-8e69153a8c50"), new DateTime(2023, 11, 28, 15, 56, 32, 140, DateTimeKind.Local).AddTicks(7218), new DateTime(2023, 11, 28, 15, 56, 32, 140, DateTimeKind.Local).AddTicks(7218), new Guid("8d1da011-8574-4be4-9f64-657254f764d6") },
                    { new Guid("f32701bd-f7fb-4034-80fc-2e07199c68d0"), new Guid("5bc27f65-a3ec-41cf-a1a7-701b4b674653"), new DateTime(2023, 11, 28, 15, 56, 32, 140, DateTimeKind.Local).AddTicks(7237), new DateTime(2023, 11, 28, 15, 56, 32, 140, DateTimeKind.Local).AddTicks(7237), new Guid("aca8df20-f7d1-464c-947a-b22bc96c2394") }
                });

            migrationBuilder.UpdateData(
                table: "tb_accounts",
                keyColumn: "guid",
                keyValue: new Guid("03e53d0a-09fe-42d3-80eb-3a80339f679d"),
                columns: new[] { "created_date", "modified_date", "otp_expired_time", "password" },
                values: new object[] { new DateTime(2023, 11, 28, 15, 56, 31, 266, DateTimeKind.Local).AddTicks(3428), new DateTime(2023, 11, 28, 15, 56, 31, 266, DateTimeKind.Local).AddTicks(3428), new DateTime(2023, 11, 28, 15, 56, 31, 266, DateTimeKind.Local).AddTicks(3430), "$2a$12$8fjEx9lE0OJb7VM9BywuiOPOgjyrDakSF4st7pfN6t168UYjCkUhK" });

            migrationBuilder.UpdateData(
                table: "tb_accounts",
                keyColumn: "guid",
                keyValue: new Guid("0c05eaec-3052-40b2-badd-8e69153a8c50"),
                columns: new[] { "created_date", "modified_date", "otp_expired_time", "password" },
                values: new object[] { new DateTime(2023, 11, 28, 15, 56, 31, 557, DateTimeKind.Local).AddTicks(9222), new DateTime(2023, 11, 28, 15, 56, 31, 557, DateTimeKind.Local).AddTicks(9223), new DateTime(2023, 11, 28, 15, 56, 31, 557, DateTimeKind.Local).AddTicks(9224), "$2a$12$QeHrOplxXxXVXimRWOhq.eVY0PmHHmPnteeWw7J7CZUvQ.2W3Llgy" });

            migrationBuilder.UpdateData(
                table: "tb_accounts",
                keyColumn: "guid",
                keyValue: new Guid("5bc27f65-a3ec-41cf-a1a7-701b4b674653"),
                columns: new[] { "created_date", "modified_date", "otp_expired_time", "password" },
                values: new object[] { new DateTime(2023, 11, 28, 15, 56, 31, 853, DateTimeKind.Local).AddTicks(7979), new DateTime(2023, 11, 28, 15, 56, 31, 853, DateTimeKind.Local).AddTicks(7979), new DateTime(2023, 11, 28, 15, 56, 31, 853, DateTimeKind.Local).AddTicks(7981), "$2a$12$W1Qt0xvWfhrvXPVW7RiPiesGggw.T8/vamQm7u3Cl0LcSI..zde8a" });

            migrationBuilder.UpdateData(
                table: "tb_departments",
                keyColumn: "guid",
                keyValue: new Guid("7644ad73-57b6-4640-9e8d-f929ba01e694"),
                columns: new[] { "created_date", "modified_date" },
                values: new object[] { new DateTime(2023, 11, 28, 15, 56, 31, 266, DateTimeKind.Local).AddTicks(3181), new DateTime(2023, 11, 28, 15, 56, 31, 266, DateTimeKind.Local).AddTicks(3187) });

            migrationBuilder.UpdateData(
                table: "tb_departments",
                keyColumn: "guid",
                keyValue: new Guid("9e0e4c05-cde2-4900-88f9-2a2b8ee0dad6"),
                columns: new[] { "created_date", "modified_date" },
                values: new object[] { new DateTime(2023, 11, 28, 15, 56, 31, 266, DateTimeKind.Local).AddTicks(3190), new DateTime(2023, 11, 28, 15, 56, 31, 266, DateTimeKind.Local).AddTicks(3191) });

            migrationBuilder.UpdateData(
                table: "tb_departments",
                keyColumn: "guid",
                keyValue: new Guid("e8246140-6e0a-488e-b451-9321b6694736"),
                columns: new[] { "created_date", "modified_date" },
                values: new object[] { new DateTime(2023, 11, 28, 15, 56, 31, 266, DateTimeKind.Local).AddTicks(3193), new DateTime(2023, 11, 28, 15, 56, 31, 266, DateTimeKind.Local).AddTicks(3194) });

            migrationBuilder.UpdateData(
                table: "tb_employees",
                keyColumn: "guid",
                keyValue: new Guid("03e53d0a-09fe-42d3-80eb-3a80339f679d"),
                columns: new[] { "created_date", "email", "modified_date" },
                values: new object[] { new DateTime(2023, 11, 28, 15, 56, 31, 266, DateTimeKind.Local).AddTicks(3350), "john.doe@example.com", new DateTime(2023, 11, 28, 15, 56, 31, 266, DateTimeKind.Local).AddTicks(3351) });

            migrationBuilder.UpdateData(
                table: "tb_employees",
                keyColumn: "guid",
                keyValue: new Guid("0c05eaec-3052-40b2-badd-8e69153a8c50"),
                columns: new[] { "created_date", "email", "modified_date" },
                values: new object[] { new DateTime(2023, 11, 28, 15, 56, 31, 266, DateTimeKind.Local).AddTicks(3362), "jane.smith@example.com", new DateTime(2023, 11, 28, 15, 56, 31, 266, DateTimeKind.Local).AddTicks(3363) });

            migrationBuilder.UpdateData(
                table: "tb_employees",
                keyColumn: "guid",
                keyValue: new Guid("5bc27f65-a3ec-41cf-a1a7-701b4b674653"),
                columns: new[] { "created_date", "email", "modified_date" },
                values: new object[] { new DateTime(2023, 11, 28, 15, 56, 31, 266, DateTimeKind.Local).AddTicks(3370), "bob.johnson@example.com", new DateTime(2023, 11, 28, 15, 56, 31, 266, DateTimeKind.Local).AddTicks(3370) });

            migrationBuilder.UpdateData(
                table: "tb_jobs",
                keyColumn: "guid",
                keyValue: new Guid("1105117d-ed96-4206-bd43-0e13b7342770"),
                columns: new[] { "created_date", "modified_date" },
                values: new object[] { new DateTime(2023, 11, 28, 15, 56, 31, 266, DateTimeKind.Local).AddTicks(3299), new DateTime(2023, 11, 28, 15, 56, 31, 266, DateTimeKind.Local).AddTicks(3299) });

            migrationBuilder.UpdateData(
                table: "tb_jobs",
                keyColumn: "guid",
                keyValue: new Guid("25abd2bc-c0fe-411a-ba24-f26cbae523c2"),
                columns: new[] { "created_date", "modified_date" },
                values: new object[] { new DateTime(2023, 11, 28, 15, 56, 31, 266, DateTimeKind.Local).AddTicks(3303), new DateTime(2023, 11, 28, 15, 56, 31, 266, DateTimeKind.Local).AddTicks(3304) });

            migrationBuilder.UpdateData(
                table: "tb_jobs",
                keyColumn: "guid",
                keyValue: new Guid("a3b9dd56-768a-45f7-99e1-8b42e9c8847f"),
                columns: new[] { "created_date", "modified_date" },
                values: new object[] { new DateTime(2023, 11, 28, 15, 56, 31, 266, DateTimeKind.Local).AddTicks(3307), new DateTime(2023, 11, 28, 15, 56, 31, 266, DateTimeKind.Local).AddTicks(3307) });

            migrationBuilder.UpdateData(
                table: "tb_roles",
                keyColumn: "guid",
                keyValue: new Guid("8d1da011-8574-4be4-9f64-657254f764d6"),
                columns: new[] { "created_date", "modified_date" },
                values: new object[] { new DateTime(2023, 11, 28, 15, 56, 31, 266, DateTimeKind.Local).AddTicks(3330), new DateTime(2023, 11, 28, 15, 56, 31, 266, DateTimeKind.Local).AddTicks(3330) });

            migrationBuilder.UpdateData(
                table: "tb_roles",
                keyColumn: "guid",
                keyValue: new Guid("aad98c8c-c71e-46f4-99c1-2d073ecb467f"),
                columns: new[] { "created_date", "modified_date" },
                values: new object[] { new DateTime(2023, 11, 28, 15, 56, 31, 266, DateTimeKind.Local).AddTicks(3327), new DateTime(2023, 11, 28, 15, 56, 31, 266, DateTimeKind.Local).AddTicks(3327) });

            migrationBuilder.UpdateData(
                table: "tb_roles",
                keyColumn: "guid",
                keyValue: new Guid("aca8df20-f7d1-464c-947a-b22bc96c2394"),
                columns: new[] { "created_date", "modified_date" },
                values: new object[] { new DateTime(2023, 11, 28, 15, 56, 31, 266, DateTimeKind.Local).AddTicks(3334), new DateTime(2023, 11, 28, 15, 56, 31, 266, DateTimeKind.Local).AddTicks(3335) });

            migrationBuilder.CreateIndex(
                name: "IX_tb_employees_email",
                table: "tb_employees",
                column: "email",
                unique: true);
        }
    }
}
