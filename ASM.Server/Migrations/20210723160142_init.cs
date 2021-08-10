using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace ASM.Server.Migrations
{
    public partial class init : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Khachhangs",
                columns: table => new
                {
                    KhachhangID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FullName = table.Column<string>(type: "nvarchar(150)", maxLength: 150, nullable: false),
                    Ngaysinh = table.Column<DateTime>(type: "datetime2", nullable: true),
                    PhoneNumber = table.Column<string>(type: "varchar(15)", maxLength: 15, nullable: false),
                    EmailAddress = table.Column<string>(type: "varchar(50)", maxLength: 50, nullable: false),
                    Password = table.Column<string>(type: "varchar(50)", maxLength: 50, nullable: true),
                    ConfirmPassword = table.Column<string>(type: "varchar(50)", maxLength: 50, nullable: true),
                    Mota = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Khachhangs", x => x.KhachhangID);
                });

            migrationBuilder.CreateTable(
                name: "MonAns",
                columns: table => new
                {
                    MonAnID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: false),
                    Gia = table.Column<double>(type: "float", nullable: false),
                    Phanloai = table.Column<int>(type: "int", nullable: false),
                    Hinh = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    Mota = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: true),
                    Trangthai = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MonAns", x => x.MonAnID);
                });

            migrationBuilder.CreateTable(
                name: "Nguoidungs",
                columns: table => new
                {
                    NguoidungID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserName = table.Column<string>(type: "nvarchar(100)", nullable: false),
                    FullName = table.Column<string>(type: "nvarchar(100)", nullable: false),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Title = table.Column<string>(type: "nvarchar(100)", nullable: true),
                    DOB = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Admin = table.Column<bool>(type: "bit", nullable: false),
                    Locked = table.Column<bool>(type: "bit", nullable: false),
                    Password = table.Column<string>(type: "varchar(50)", maxLength: 50, nullable: true),
                    ConfirmPassword = table.Column<string>(type: "varchar(50)", maxLength: 50, nullable: true),
                    Role = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Nguoidungs", x => x.NguoidungID);
                });

            migrationBuilder.CreateTable(
                name: "Donhangs",
                columns: table => new
                {
                    DonhangID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    KhachhangID = table.Column<int>(type: "int", nullable: false),
                    Ngaydat = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Tongtien = table.Column<double>(type: "float", nullable: false),
                    TrangthaiDonhang = table.Column<int>(type: "int", nullable: false),
                    Ghichu = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Donhangs", x => x.DonhangID);
                    table.ForeignKey(
                        name: "FK_Donhangs_Khachhangs_KhachhangID",
                        column: x => x.KhachhangID,
                        principalTable: "Khachhangs",
                        principalColumn: "KhachhangID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "DonhangChitiets",
                columns: table => new
                {
                    ChitietID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DonhangID = table.Column<int>(type: "int", nullable: false),
                    MonAnID = table.Column<int>(type: "int", nullable: false),
                    Soluong = table.Column<int>(type: "int", nullable: false),
                    Thanhtien = table.Column<double>(type: "float", nullable: false),
                    Ghichu = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DonhangChitiets", x => x.ChitietID);
                    table.ForeignKey(
                        name: "FK_DonhangChitiets_Donhangs_DonhangID",
                        column: x => x.DonhangID,
                        principalTable: "Donhangs",
                        principalColumn: "DonhangID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_DonhangChitiets_MonAns_MonAnID",
                        column: x => x.MonAnID,
                        principalTable: "MonAns",
                        principalColumn: "MonAnID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_DonhangChitiets_DonhangID",
                table: "DonhangChitiets",
                column: "DonhangID");

            migrationBuilder.CreateIndex(
                name: "IX_DonhangChitiets_MonAnID",
                table: "DonhangChitiets",
                column: "MonAnID");

            migrationBuilder.CreateIndex(
                name: "IX_Donhangs_KhachhangID",
                table: "Donhangs",
                column: "KhachhangID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "DonhangChitiets");

            migrationBuilder.DropTable(
                name: "Nguoidungs");

            migrationBuilder.DropTable(
                name: "Donhangs");

            migrationBuilder.DropTable(
                name: "MonAns");

            migrationBuilder.DropTable(
                name: "Khachhangs");
        }
    }
}
