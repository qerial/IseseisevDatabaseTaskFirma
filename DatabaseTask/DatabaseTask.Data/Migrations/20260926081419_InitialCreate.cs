using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DatabaseTask.Data.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Intranet",
                columns: table => new
                {
                    IntranetId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    EmployeeId = table.Column<int>(type: "int", nullable: false),
                    CompanyId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Intranet", x => x.IntranetId);
                });

            migrationBuilder.CreateTable(
                name: "Anonymous",
                columns: table => new
                {
                    AnonymousId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    IntranetId = table.Column<int>(type: "int", nullable: false),
                    HintId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Anonymous", x => x.AnonymousId);
                    table.ForeignKey(
                        name: "FK_Anonymous_Intranet_IntranetId",
                        column: x => x.IntranetId,
                        principalTable: "Intranet",
                        principalColumn: "IntranetId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Company",
                columns: table => new
                {
                    CompanyId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    OfficeId = table.Column<int>(type: "int", nullable: false),
                    IntranetId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Company", x => x.CompanyId);
                    table.ForeignKey(
                        name: "FK_Company_Intranet_IntranetId",
                        column: x => x.IntranetId,
                        principalTable: "Intranet",
                        principalColumn: "IntranetId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Hint",
                columns: table => new
                {
                    HintId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    AnonymousId = table.Column<int>(type: "int", nullable: false),
                    HintMessage = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Hint", x => x.HintId);
                    table.ForeignKey(
                        name: "FK_Hint_Anonymous_AnonymousId",
                        column: x => x.AnonymousId,
                        principalTable: "Anonymous",
                        principalColumn: "AnonymousId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Office",
                columns: table => new
                {
                    OfficeId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CompanyId = table.Column<int>(type: "int", nullable: false),
                    intranetId = table.Column<int>(type: "int", nullable: false),
                    AddressID = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Office", x => x.OfficeId);
                    table.ForeignKey(
                        name: "FK_Office_Company_CompanyId",
                        column: x => x.CompanyId,
                        principalTable: "Company",
                        principalColumn: "CompanyId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Office_Intranet_intranetId",
                        column: x => x.intranetId,
                        principalTable: "Intranet",
                        principalColumn: "IntranetId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Children",
                columns: table => new
                {
                    ChildrenId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ParentId = table.Column<int>(type: "int", nullable: false),
                    FirstName = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    LastName = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    Age = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Children", x => x.ChildrenId);
                });

            migrationBuilder.CreateTable(
                name: "Employee",
                columns: table => new
                {
                    EmployeeId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    SickPapersListId = table.Column<int>(type: "int", nullable: false),
                    JobTypeListId = table.Column<int>(type: "int", nullable: false),
                    VacationListId = table.Column<int>(type: "int", nullable: false),
                    HealthControlListId = table.Column<int>(type: "int", nullable: false),
                    PermissionsId = table.Column<int>(type: "int", nullable: false),
                    AnonymousId = table.Column<int>(type: "int", nullable: false),
                    OfficeId = table.Column<int>(type: "int", nullable: false),
                    ParentId = table.Column<int>(type: "int", nullable: false),
                    ChildrenId = table.Column<int>(type: "int", nullable: false),
                    FirstName = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    LastName = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    Age = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Employee", x => x.EmployeeId);
                    table.ForeignKey(
                        name: "FK_Employee_Anonymous_AnonymousId",
                        column: x => x.AnonymousId,
                        principalTable: "Anonymous",
                        principalColumn: "AnonymousId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Employee_Children_ChildrenId",
                        column: x => x.ChildrenId,
                        principalTable: "Children",
                        principalColumn: "ChildrenId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Employee_Office_OfficeId",
                        column: x => x.OfficeId,
                        principalTable: "Office",
                        principalColumn: "OfficeId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "HealthControlList",
                columns: table => new
                {
                    HealthControlListId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    EmployeeId = table.Column<int>(type: "int", nullable: false),
                    HealthState = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    HealthControlDate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_HealthControlList", x => x.HealthControlListId);
                    table.ForeignKey(
                        name: "FK_HealthControlList_Employee_EmployeeId",
                        column: x => x.EmployeeId,
                        principalTable: "Employee",
                        principalColumn: "EmployeeId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "JobTypeList",
                columns: table => new
                {
                    JobTypeListId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    EmployeeId = table.Column<int>(type: "int", nullable: false),
                    Job = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_JobTypeList", x => x.JobTypeListId);
                    table.ForeignKey(
                        name: "FK_JobTypeList_Employee_EmployeeId",
                        column: x => x.EmployeeId,
                        principalTable: "Employee",
                        principalColumn: "EmployeeId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Lending",
                columns: table => new
                {
                    LendingId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    EmployeeId = table.Column<int>(type: "int", nullable: false),
                    LendingStart = table.Column<DateTime>(type: "datetime2", nullable: false),
                    LendingEnd = table.Column<DateTime>(type: "datetime2", nullable: false),
                    LendingItems = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    LendingMessage = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Lending", x => x.LendingId);
                    table.ForeignKey(
                        name: "FK_Lending_Employee_EmployeeId",
                        column: x => x.EmployeeId,
                        principalTable: "Employee",
                        principalColumn: "EmployeeId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Parents",
                columns: table => new
                {
                    ParentId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ChildrenID = table.Column<int>(type: "int", nullable: false),
                    EmployeeId = table.Column<int>(type: "int", nullable: false),
                    FirstName = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    LastName = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    Age = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Parents", x => x.ParentId);
                    table.ForeignKey(
                        name: "FK_Parents_Employee_EmployeeId",
                        column: x => x.EmployeeId,
                        principalTable: "Employee",
                        principalColumn: "EmployeeId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Request",
                columns: table => new
                {
                    RequestId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    EmployeeId = table.Column<int>(type: "int", nullable: false),
                    RequestMessage = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Request", x => x.RequestId);
                    table.ForeignKey(
                        name: "FK_Request_Employee_EmployeeId",
                        column: x => x.EmployeeId,
                        principalTable: "Employee",
                        principalColumn: "EmployeeId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "SickPapersList",
                columns: table => new
                {
                    SickPapersListId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    EmployeeId = table.Column<int>(type: "int", nullable: false),
                    SickReasoningMessage = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
                    SickStart = table.Column<DateTime>(type: "datetime2", nullable: false),
                    SickEnd = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SickPapersList", x => x.SickPapersListId);
                    table.ForeignKey(
                        name: "FK_SickPapersList_Employee_EmployeeId",
                        column: x => x.EmployeeId,
                        principalTable: "Employee",
                        principalColumn: "EmployeeId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "VacationList",
                columns: table => new
                {
                    VacationListId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    EmployeeId = table.Column<int>(type: "int", nullable: false),
                    VacationStart = table.Column<DateTime>(type: "datetime2", nullable: false),
                    VacationEnd = table.Column<DateTime>(type: "datetime2", nullable: false),
                    VacationDaysMax = table.Column<int>(type: "int", nullable: false),
                    ChildrenId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_VacationList", x => x.VacationListId);
                    table.ForeignKey(
                        name: "FK_VacationList_Children_ChildrenId",
                        column: x => x.ChildrenId,
                        principalTable: "Children",
                        principalColumn: "ChildrenId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_VacationList_Employee_EmployeeId",
                        column: x => x.EmployeeId,
                        principalTable: "Employee",
                        principalColumn: "EmployeeId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Permissions",
                columns: table => new
                {
                    PermissionsId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    EmployeeId = table.Column<int>(type: "int", nullable: false),
                    LendingId = table.Column<int>(type: "int", nullable: false),
                    HintId = table.Column<int>(type: "int", nullable: false),
                    RequestId = table.Column<int>(type: "int", nullable: false),
                    AnonymousId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Permissions", x => x.PermissionsId);
                    table.ForeignKey(
                        name: "FK_Permissions_Anonymous_AnonymousId",
                        column: x => x.AnonymousId,
                        principalTable: "Anonymous",
                        principalColumn: "AnonymousId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Permissions_Employee_EmployeeId",
                        column: x => x.EmployeeId,
                        principalTable: "Employee",
                        principalColumn: "EmployeeId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Permissions_Hint_HintId",
                        column: x => x.HintId,
                        principalTable: "Hint",
                        principalColumn: "HintId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Permissions_Lending_LendingId",
                        column: x => x.LendingId,
                        principalTable: "Lending",
                        principalColumn: "LendingId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Permissions_Request_RequestId",
                        column: x => x.RequestId,
                        principalTable: "Request",
                        principalColumn: "RequestId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Anonymous_IntranetId",
                table: "Anonymous",
                column: "IntranetId");

            migrationBuilder.CreateIndex(
                name: "IX_Children_ParentId",
                table: "Children",
                column: "ParentId");

            migrationBuilder.CreateIndex(
                name: "IX_Company_IntranetId",
                table: "Company",
                column: "IntranetId");

            migrationBuilder.CreateIndex(
                name: "IX_Employee_AnonymousId",
                table: "Employee",
                column: "AnonymousId");

            migrationBuilder.CreateIndex(
                name: "IX_Employee_ChildrenId",
                table: "Employee",
                column: "ChildrenId");

            migrationBuilder.CreateIndex(
                name: "IX_Employee_OfficeId",
                table: "Employee",
                column: "OfficeId");

            migrationBuilder.CreateIndex(
                name: "IX_HealthControlList_EmployeeId",
                table: "HealthControlList",
                column: "EmployeeId");

            migrationBuilder.CreateIndex(
                name: "IX_Hint_AnonymousId",
                table: "Hint",
                column: "AnonymousId");

            migrationBuilder.CreateIndex(
                name: "IX_JobTypeList_EmployeeId",
                table: "JobTypeList",
                column: "EmployeeId");

            migrationBuilder.CreateIndex(
                name: "IX_Lending_EmployeeId",
                table: "Lending",
                column: "EmployeeId");

            migrationBuilder.CreateIndex(
                name: "IX_Office_CompanyId",
                table: "Office",
                column: "CompanyId");

            migrationBuilder.CreateIndex(
                name: "IX_Office_intranetId",
                table: "Office",
                column: "intranetId");

            migrationBuilder.CreateIndex(
                name: "IX_Parents_EmployeeId",
                table: "Parents",
                column: "EmployeeId");

            migrationBuilder.CreateIndex(
                name: "IX_Permissions_AnonymousId",
                table: "Permissions",
                column: "AnonymousId");

            migrationBuilder.CreateIndex(
                name: "IX_Permissions_EmployeeId",
                table: "Permissions",
                column: "EmployeeId");

            migrationBuilder.CreateIndex(
                name: "IX_Permissions_HintId",
                table: "Permissions",
                column: "HintId");

            migrationBuilder.CreateIndex(
                name: "IX_Permissions_LendingId",
                table: "Permissions",
                column: "LendingId");

            migrationBuilder.CreateIndex(
                name: "IX_Permissions_RequestId",
                table: "Permissions",
                column: "RequestId");

            migrationBuilder.CreateIndex(
                name: "IX_Request_EmployeeId",
                table: "Request",
                column: "EmployeeId");

            migrationBuilder.CreateIndex(
                name: "IX_SickPapersList_EmployeeId",
                table: "SickPapersList",
                column: "EmployeeId");

            migrationBuilder.CreateIndex(
                name: "IX_VacationList_ChildrenId",
                table: "VacationList",
                column: "ChildrenId");

            migrationBuilder.CreateIndex(
                name: "IX_VacationList_EmployeeId",
                table: "VacationList",
                column: "EmployeeId");

            migrationBuilder.AddForeignKey(
                name: "FK_Children_Parents_ParentId",
                table: "Children",
                column: "ParentId",
                principalTable: "Parents",
                principalColumn: "ParentId",
                onDelete: ReferentialAction.Restrict);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Anonymous_Intranet_IntranetId",
                table: "Anonymous");

            migrationBuilder.DropForeignKey(
                name: "FK_Company_Intranet_IntranetId",
                table: "Company");

            migrationBuilder.DropForeignKey(
                name: "FK_Office_Intranet_intranetId",
                table: "Office");

            migrationBuilder.DropForeignKey(
                name: "FK_Children_Parents_ParentId",
                table: "Children");

            migrationBuilder.DropTable(
                name: "HealthControlList");

            migrationBuilder.DropTable(
                name: "JobTypeList");

            migrationBuilder.DropTable(
                name: "Permissions");

            migrationBuilder.DropTable(
                name: "SickPapersList");

            migrationBuilder.DropTable(
                name: "VacationList");

            migrationBuilder.DropTable(
                name: "Hint");

            migrationBuilder.DropTable(
                name: "Lending");

            migrationBuilder.DropTable(
                name: "Request");

            migrationBuilder.DropTable(
                name: "Intranet");

            migrationBuilder.DropTable(
                name: "Parents");

            migrationBuilder.DropTable(
                name: "Employee");

            migrationBuilder.DropTable(
                name: "Anonymous");

            migrationBuilder.DropTable(
                name: "Children");

            migrationBuilder.DropTable(
                name: "Office");

            migrationBuilder.DropTable(
                name: "Company");
        }
    }
}
