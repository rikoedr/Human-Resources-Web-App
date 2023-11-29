using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace API.Migrations
{
    public partial class FirstDbMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "tb_jobs",
                columns: table => new
                {
                    guid = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    code = table.Column<string>(type: "nvarchar(3)", nullable: false),
                    name = table.Column<string>(type: "nvarchar(50)", nullable: false),
                    min_salary = table.Column<int>(type: "int", nullable: false),
                    max_salary = table.Column<int>(type: "int", nullable: false),
                    created_date = table.Column<DateTime>(type: "datetime2", nullable: false),
                    modified_date = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tb_jobs", x => x.guid);
                });

            migrationBuilder.CreateTable(
                name: "tb_roles",
                columns: table => new
                {
                    guid = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    name = table.Column<string>(type: "nvarchar(20)", nullable: false),
                    created_date = table.Column<DateTime>(type: "datetime2", nullable: false),
                    modified_date = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tb_roles", x => x.guid);
                });

            migrationBuilder.CreateTable(
                name: "job_history",
                columns: table => new
                {
                    guid = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    employee_guid = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    job_guid = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    start_date = table.Column<DateTime>(type: "datetime2", nullable: false),
                    end_date = table.Column<DateTime>(type: "datetime2", nullable: true),
                    created_date = table.Column<DateTime>(type: "datetime2", nullable: false),
                    modified_date = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_job_history", x => x.guid);
                    table.ForeignKey(
                        name: "FK_job_history_tb_jobs_job_guid",
                        column: x => x.job_guid,
                        principalTable: "tb_jobs",
                        principalColumn: "guid");
                });

            migrationBuilder.CreateTable(
                name: "tb_account_roles",
                columns: table => new
                {
                    guid = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    account_guid = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    role_guid = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    created_date = table.Column<DateTime>(type: "datetime2", nullable: false),
                    modified_date = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tb_account_roles", x => x.guid);
                    table.ForeignKey(
                        name: "FK_tb_account_roles_tb_roles_role_guid",
                        column: x => x.role_guid,
                        principalTable: "tb_roles",
                        principalColumn: "guid",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "tb_accounts",
                columns: table => new
                {
                    guid = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    password = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    is_disabled = table.Column<bool>(type: "bit", nullable: false),
                    otp = table.Column<int>(type: "int", nullable: false),
                    is_otp_used = table.Column<bool>(type: "bit", nullable: false),
                    otp_expired_time = table.Column<DateTime>(type: "datetime2", nullable: false),
                    created_date = table.Column<DateTime>(type: "datetime2", nullable: false),
                    modified_date = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tb_accounts", x => x.guid);
                });

            migrationBuilder.CreateTable(
                name: "tb_departments",
                columns: table => new
                {
                    guid = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    code = table.Column<string>(type: "nvarchar(2)", nullable: false),
                    name = table.Column<string>(type: "nvarchar(30)", nullable: false),
                    manager_guid = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    created_date = table.Column<DateTime>(type: "datetime2", nullable: false),
                    modified_date = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tb_departments", x => x.guid);
                });

            migrationBuilder.CreateTable(
                name: "tb_employees",
                columns: table => new
                {
                    guid = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    first_name = table.Column<string>(type: "nvarchar(50)", nullable: false),
                    last_name = table.Column<string>(type: "nvarchar(50)", nullable: true),
                    birth_date = table.Column<DateTime>(type: "datetime2", nullable: false),
                    hiring_date = table.Column<DateTime>(type: "datetime2", nullable: false),
                    gender = table.Column<int>(type: "int", nullable: false),
                    email = table.Column<string>(type: "nvarchar(50)", nullable: false),
                    phone_number = table.Column<string>(type: "nvarchar(50)", nullable: false),
                    department_guid = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    job_guid = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    created_date = table.Column<DateTime>(type: "datetime2", nullable: false),
                    modified_date = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tb_employees", x => x.guid);
                    table.ForeignKey(
                        name: "FK_tb_employees_tb_departments_department_guid",
                        column: x => x.department_guid,
                        principalTable: "tb_departments",
                        principalColumn: "guid",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_tb_employees_tb_jobs_job_guid",
                        column: x => x.job_guid,
                        principalTable: "tb_jobs",
                        principalColumn: "guid",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "tb_departments",
                columns: new[] { "guid", "code", "created_date", "manager_guid", "modified_date", "name" },
                values: new object[,]
                {
                    { new Guid("7644ad73-57b6-4640-9e8d-f929ba01e694"), "01", new DateTime(2023, 11, 28, 15, 56, 31, 266, DateTimeKind.Local).AddTicks(3181), null, new DateTime(2023, 11, 28, 15, 56, 31, 266, DateTimeKind.Local).AddTicks(3187), "Finance" },
                    { new Guid("9e0e4c05-cde2-4900-88f9-2a2b8ee0dad6"), "06", new DateTime(2023, 11, 28, 15, 56, 31, 266, DateTimeKind.Local).AddTicks(3190), null, new DateTime(2023, 11, 28, 15, 56, 31, 266, DateTimeKind.Local).AddTicks(3191), "Information Technology" },
                    { new Guid("e8246140-6e0a-488e-b451-9321b6694736"), "07", new DateTime(2023, 11, 28, 15, 56, 31, 266, DateTimeKind.Local).AddTicks(3193), null, new DateTime(2023, 11, 28, 15, 56, 31, 266, DateTimeKind.Local).AddTicks(3194), "Human Resources" }
                });

            migrationBuilder.InsertData(
                table: "tb_jobs",
                columns: new[] { "guid", "code", "created_date", "max_salary", "min_salary", "modified_date", "name" },
                values: new object[,]
                {
                    { new Guid("1105117d-ed96-4206-bd43-0e13b7342770"), "101", new DateTime(2023, 11, 28, 15, 56, 31, 266, DateTimeKind.Local).AddTicks(3299), 7500000, 5000000, new DateTime(2023, 11, 28, 15, 56, 31, 266, DateTimeKind.Local).AddTicks(3299), "Financial Analyst" },
                    { new Guid("25abd2bc-c0fe-411a-ba24-f26cbae523c2"), "601", new DateTime(2023, 11, 28, 15, 56, 31, 266, DateTimeKind.Local).AddTicks(3303), 8000000, 6000000, new DateTime(2023, 11, 28, 15, 56, 31, 266, DateTimeKind.Local).AddTicks(3304), "Software Developer" },
                    { new Guid("a3b9dd56-768a-45f7-99e1-8b42e9c8847f"), "701", new DateTime(2023, 11, 28, 15, 56, 31, 266, DateTimeKind.Local).AddTicks(3307), 7000000, 5000000, new DateTime(2023, 11, 28, 15, 56, 31, 266, DateTimeKind.Local).AddTicks(3307), "Recruitment Specialist" }
                });

            migrationBuilder.InsertData(
                table: "tb_roles",
                columns: new[] { "guid", "created_date", "modified_date", "name" },
                values: new object[,]
                {
                    { new Guid("8d1da011-8574-4be4-9f64-657254f764d6"), new DateTime(2023, 11, 28, 15, 56, 31, 266, DateTimeKind.Local).AddTicks(3330), new DateTime(2023, 11, 28, 15, 56, 31, 266, DateTimeKind.Local).AddTicks(3330), "Manager" },
                    { new Guid("aad98c8c-c71e-46f4-99c1-2d073ecb467f"), new DateTime(2023, 11, 28, 15, 56, 31, 266, DateTimeKind.Local).AddTicks(3327), new DateTime(2023, 11, 28, 15, 56, 31, 266, DateTimeKind.Local).AddTicks(3327), "Staff" },
                    { new Guid("aca8df20-f7d1-464c-947a-b22bc96c2394"), new DateTime(2023, 11, 28, 15, 56, 31, 266, DateTimeKind.Local).AddTicks(3334), new DateTime(2023, 11, 28, 15, 56, 31, 266, DateTimeKind.Local).AddTicks(3335), "Admin" }
                });

            migrationBuilder.InsertData(
                table: "tb_employees",
                columns: new[] { "guid", "birth_date", "created_date", "department_guid", "email", "first_name", "gender", "hiring_date", "job_guid", "last_name", "modified_date", "phone_number" },
                values: new object[] { new Guid("03e53d0a-09fe-42d3-80eb-3a80339f679d"), new DateTime(1990, 5, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2023, 11, 28, 15, 56, 31, 266, DateTimeKind.Local).AddTicks(3350), new Guid("7644ad73-57b6-4640-9e8d-f929ba01e694"), "john.doe@example.com", "John", 1, new DateTime(2020, 10, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new Guid("1105117d-ed96-4206-bd43-0e13b7342770"), "Doe", new DateTime(2023, 11, 28, 15, 56, 31, 266, DateTimeKind.Local).AddTicks(3351), "+123456789" });

            migrationBuilder.InsertData(
                table: "tb_employees",
                columns: new[] { "guid", "birth_date", "created_date", "department_guid", "email", "first_name", "gender", "hiring_date", "job_guid", "last_name", "modified_date", "phone_number" },
                values: new object[] { new Guid("0c05eaec-3052-40b2-badd-8e69153a8c50"), new DateTime(1985, 8, 25, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2023, 11, 28, 15, 56, 31, 266, DateTimeKind.Local).AddTicks(3362), new Guid("9e0e4c05-cde2-4900-88f9-2a2b8ee0dad6"), "jane.smith@example.com", "Jane", 0, new DateTime(2019, 7, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), new Guid("25abd2bc-c0fe-411a-ba24-f26cbae523c2"), "Smith", new DateTime(2023, 11, 28, 15, 56, 31, 266, DateTimeKind.Local).AddTicks(3363), "+987654321" });

            migrationBuilder.InsertData(
                table: "tb_employees",
                columns: new[] { "guid", "birth_date", "created_date", "department_guid", "email", "first_name", "gender", "hiring_date", "job_guid", "last_name", "modified_date", "phone_number" },
                values: new object[] { new Guid("5bc27f65-a3ec-41cf-a1a7-701b4b674653"), new DateTime(1982, 3, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2023, 11, 28, 15, 56, 31, 266, DateTimeKind.Local).AddTicks(3370), new Guid("e8246140-6e0a-488e-b451-9321b6694736"), "bob.johnson@example.com", "Bob", 1, new DateTime(2018, 4, 20, 0, 0, 0, 0, DateTimeKind.Unspecified), new Guid("a3b9dd56-768a-45f7-99e1-8b42e9c8847f"), "Johnson", new DateTime(2023, 11, 28, 15, 56, 31, 266, DateTimeKind.Local).AddTicks(3370), "+1122334455" });

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
                table: "tb_accounts",
                columns: new[] { "guid", "created_date", "is_disabled", "is_otp_used", "modified_date", "otp", "otp_expired_time", "password" },
                values: new object[,]
                {
                    { new Guid("03e53d0a-09fe-42d3-80eb-3a80339f679d"), new DateTime(2023, 11, 28, 15, 56, 31, 266, DateTimeKind.Local).AddTicks(3428), false, true, new DateTime(2023, 11, 28, 15, 56, 31, 266, DateTimeKind.Local).AddTicks(3428), 123456, new DateTime(2023, 11, 28, 15, 56, 31, 266, DateTimeKind.Local).AddTicks(3430), "$2a$12$8fjEx9lE0OJb7VM9BywuiOPOgjyrDakSF4st7pfN6t168UYjCkUhK" },
                    { new Guid("0c05eaec-3052-40b2-badd-8e69153a8c50"), new DateTime(2023, 11, 28, 15, 56, 31, 557, DateTimeKind.Local).AddTicks(9222), false, true, new DateTime(2023, 11, 28, 15, 56, 31, 557, DateTimeKind.Local).AddTicks(9223), 123456, new DateTime(2023, 11, 28, 15, 56, 31, 557, DateTimeKind.Local).AddTicks(9224), "$2a$12$QeHrOplxXxXVXimRWOhq.eVY0PmHHmPnteeWw7J7CZUvQ.2W3Llgy" },
                    { new Guid("5bc27f65-a3ec-41cf-a1a7-701b4b674653"), new DateTime(2023, 11, 28, 15, 56, 31, 853, DateTimeKind.Local).AddTicks(7979), false, true, new DateTime(2023, 11, 28, 15, 56, 31, 853, DateTimeKind.Local).AddTicks(7979), 123456, new DateTime(2023, 11, 28, 15, 56, 31, 853, DateTimeKind.Local).AddTicks(7981), "$2a$12$W1Qt0xvWfhrvXPVW7RiPiesGggw.T8/vamQm7u3Cl0LcSI..zde8a" }
                });

            migrationBuilder.InsertData(
                table: "tb_account_roles",
                columns: new[] { "guid", "account_guid", "created_date", "modified_date", "role_guid" },
                values: new object[] { new Guid("21b7f5a1-2440-48bf-839d-58e54a217767"), new Guid("03e53d0a-09fe-42d3-80eb-3a80339f679d"), new DateTime(2023, 11, 28, 15, 56, 32, 140, DateTimeKind.Local).AddTicks(7125), new DateTime(2023, 11, 28, 15, 56, 32, 140, DateTimeKind.Local).AddTicks(7135), new Guid("aad98c8c-c71e-46f4-99c1-2d073ecb467f") });

            migrationBuilder.InsertData(
                table: "tb_account_roles",
                columns: new[] { "guid", "account_guid", "created_date", "modified_date", "role_guid" },
                values: new object[] { new Guid("4b22fe67-6317-43c3-b1c7-fbce518d6e54"), new Guid("0c05eaec-3052-40b2-badd-8e69153a8c50"), new DateTime(2023, 11, 28, 15, 56, 32, 140, DateTimeKind.Local).AddTicks(7218), new DateTime(2023, 11, 28, 15, 56, 32, 140, DateTimeKind.Local).AddTicks(7218), new Guid("8d1da011-8574-4be4-9f64-657254f764d6") });

            migrationBuilder.InsertData(
                table: "tb_account_roles",
                columns: new[] { "guid", "account_guid", "created_date", "modified_date", "role_guid" },
                values: new object[] { new Guid("f32701bd-f7fb-4034-80fc-2e07199c68d0"), new Guid("5bc27f65-a3ec-41cf-a1a7-701b4b674653"), new DateTime(2023, 11, 28, 15, 56, 32, 140, DateTimeKind.Local).AddTicks(7237), new DateTime(2023, 11, 28, 15, 56, 32, 140, DateTimeKind.Local).AddTicks(7237), new Guid("aca8df20-f7d1-464c-947a-b22bc96c2394") });

            migrationBuilder.CreateIndex(
                name: "IX_job_history_employee_guid",
                table: "job_history",
                column: "employee_guid");

            migrationBuilder.CreateIndex(
                name: "IX_job_history_job_guid",
                table: "job_history",
                column: "job_guid");

            migrationBuilder.CreateIndex(
                name: "IX_tb_account_roles_account_guid",
                table: "tb_account_roles",
                column: "account_guid");

            migrationBuilder.CreateIndex(
                name: "IX_tb_account_roles_role_guid",
                table: "tb_account_roles",
                column: "role_guid");

            migrationBuilder.CreateIndex(
                name: "IX_tb_departments_code",
                table: "tb_departments",
                column: "code",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_tb_departments_manager_guid",
                table: "tb_departments",
                column: "manager_guid",
                unique: true,
                filter: "[manager_guid] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_tb_departments_name",
                table: "tb_departments",
                column: "name",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_tb_employees_department_guid",
                table: "tb_employees",
                column: "department_guid");

            migrationBuilder.CreateIndex(
                name: "IX_tb_employees_email",
                table: "tb_employees",
                column: "email",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_tb_employees_job_guid",
                table: "tb_employees",
                column: "job_guid");

            migrationBuilder.CreateIndex(
                name: "IX_tb_employees_phone_number",
                table: "tb_employees",
                column: "phone_number",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_tb_jobs_name",
                table: "tb_jobs",
                column: "name",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_tb_roles_name",
                table: "tb_roles",
                column: "name",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_job_history_tb_employees_employee_guid",
                table: "job_history",
                column: "employee_guid",
                principalTable: "tb_employees",
                principalColumn: "guid",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_tb_account_roles_tb_accounts_account_guid",
                table: "tb_account_roles",
                column: "account_guid",
                principalTable: "tb_accounts",
                principalColumn: "guid",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_tb_accounts_tb_employees_guid",
                table: "tb_accounts",
                column: "guid",
                principalTable: "tb_employees",
                principalColumn: "guid",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_tb_departments_tb_employees_manager_guid",
                table: "tb_departments",
                column: "manager_guid",
                principalTable: "tb_employees",
                principalColumn: "guid",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_tb_departments_tb_employees_manager_guid",
                table: "tb_departments");

            migrationBuilder.DropTable(
                name: "job_history");

            migrationBuilder.DropTable(
                name: "tb_account_roles");

            migrationBuilder.DropTable(
                name: "tb_accounts");

            migrationBuilder.DropTable(
                name: "tb_roles");

            migrationBuilder.DropTable(
                name: "tb_employees");

            migrationBuilder.DropTable(
                name: "tb_departments");

            migrationBuilder.DropTable(
                name: "tb_jobs");
        }
    }
}
