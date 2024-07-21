using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace ProConsult.Migrations
{
    /// <inheritdoc />
    public partial class initalApp : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Discriminator",
                table: "AspNetUsers",
                type: "nvarchar(21)",
                maxLength: 21,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Name",
                table: "AspNetUsers",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "Patients",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "VARCHAR(50)", nullable: false),
                    Document = table.Column<string>(type: "NVARCHAR(11)", nullable: false),
                    Mail = table.Column<string>(type: "VARCHAR(50)", nullable: false),
                    Mobile = table.Column<string>(type: "NVARCHAR(11)", nullable: false),
                    BirthDate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Patients", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Specialists",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "VARCHAR(60)", nullable: false),
                    Description = table.Column<string>(type: "NVARCHAR(150)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Specialists", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Doctors",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "VARCHAR(50)", nullable: false),
                    Document = table.Column<string>(type: "NVARCHAR(11)", nullable: false),
                    Crm = table.Column<string>(type: "NVARCHAR(8)", nullable: false),
                    Mobile = table.Column<string>(type: "NVARCHAR(11)", nullable: false),
                    RegisterDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    SpecialistId = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    SpecialistId1 = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Doctors", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Doctors_Specialists_SpecialistId1",
                        column: x => x.SpecialistId1,
                        principalTable: "Specialists",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Appointments",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false),
                    Note = table.Column<string>(type: "VARCHAR(250)", nullable: false),
                    PatientId = table.Column<int>(type: "int", nullable: false),
                    DoctorId = table.Column<int>(type: "int", nullable: false),
                    AppointmentDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    AppointmentHour = table.Column<TimeSpan>(type: "time", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Appointments", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Appointments_Doctors_Id",
                        column: x => x.Id,
                        principalTable: "Doctors",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Appointments_Patients_Id",
                        column: x => x.Id,
                        principalTable: "Patients",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "00043fbd-e5e1-49eb-8e36-837561d584f1", null, "Doctor", "DOCTOR" },
                    { "8305f33b-5412-47d0-b4ab-17cf6867f2e2", null, "Attendant", "ATTENDANT" }
                });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Discriminator", "Email", "EmailConfirmed", "LockoutEnabled", "LockoutEnd", "Name", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[] { "95433ac4-2fe9-468f-b80d-b05ec3724d1d", 0, "759a8b5d-5687-4522-b306-e826cc11e712", "Attendant", "proconsulta@hotmail.com.br", true, false, null, "Pro Consulta", "PROCONSULTA@HOTMAIL.COM.BR", "PROCONSULTA@HOTMAIL.COM.BR", "AQAAAAIAAYagAAAAEOLWBOPAGDnbVvOsZkqj+TxzCxQPO+/aYzXuG+0OmVHZUcjX239qZqJg4h7HNrlDwg==", null, false, "bdff5a0d-cb1d-4c74-ae78-5c0792f2c764", false, "proconsulta@hotmail.com.br" });

            migrationBuilder.InsertData(
                table: "Specialists",
                columns: new[] { "Id", "Description", "Name" },
                values: new object[,]
                {
                    { 1, "Especialidade médica que trata doenças do coração e do sistema cardiovascular.", "Cardiologia" },
                    { 2, "Especialidade médica que trata doenças da pele, cabelo e unhas.", "Dermatologia" },
                    { 3, "Especialidade médica que trata doenças do sistema digestivo.", "Gastroenterologia" },
                    { 4, "Especialidade médica que trata doenças do sistema nervoso.", "Neurologia" },
                    { 5, "Especialidade médica que trata doenças e lesões do sistema musculoesquelético.", "Ortopedia" },
                    { 6, "Especialidade médica que trata de crianças e adolescentes.", "Pediatria" },
                    { 7, "Especialidade médica que trata de doenças mentais e distúrbios emocionais.", "Psiquiatria" },
                    { 8, "Especialidade médica que trata doenças dos olhos.", "Oftalmologia" },
                    { 9, "Especialidade médica que trata do sistema reprodutor feminino.", "Ginecologia" },
                    { 10, "Especialidade médica que trata do câncer.", "Oncologia" }
                });

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "RoleId", "UserId" },
                values: new object[] { "8305f33b-5412-47d0-b4ab-17cf6867f2e2", "95433ac4-2fe9-468f-b80d-b05ec3724d1d" });

            migrationBuilder.CreateIndex(
                name: "IX_Doctors_Crm",
                table: "Doctors",
                column: "Crm",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Doctors_Document",
                table: "Doctors",
                column: "Document",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Doctors_SpecialistId1",
                table: "Doctors",
                column: "SpecialistId1");

            migrationBuilder.CreateIndex(
                name: "IX_Patients_Document",
                table: "Patients",
                column: "Document",
                unique: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Appointments");

            migrationBuilder.DropTable(
                name: "Doctors");

            migrationBuilder.DropTable(
                name: "Patients");

            migrationBuilder.DropTable(
                name: "Specialists");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "00043fbd-e5e1-49eb-8e36-837561d584f1");

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "8305f33b-5412-47d0-b4ab-17cf6867f2e2", "95433ac4-2fe9-468f-b80d-b05ec3724d1d" });

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "8305f33b-5412-47d0-b4ab-17cf6867f2e2");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "95433ac4-2fe9-468f-b80d-b05ec3724d1d");

            migrationBuilder.DropColumn(
                name: "Discriminator",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "Name",
                table: "AspNetUsers");
        }
    }
}
