using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace HamburgerProje.Migrations
{
    public partial class ilk : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Ekstralar",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Ad = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Fiyat = table.Column<double>(type: "float", nullable: false),
                    Adet = table.Column<int>(type: "int", nullable: false),
                    Resim = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Ekstralar", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Hamburgerler",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Ad = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Adet = table.Column<int>(type: "int", nullable: false),
                    Fiyat = table.Column<double>(type: "float", nullable: false),
                    Resim = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Hamburgerler", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Icecekler",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Ad = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Adet = table.Column<int>(type: "int", nullable: false),
                    Fiyat = table.Column<double>(type: "float", nullable: false),
                    Resim = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Icecekler", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Menuler",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Ad = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Fiyat = table.Column<double>(type: "float", nullable: false),
                    Adet = table.Column<int>(type: "int", nullable: false),
                    Resim = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Menuler", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Siparisler",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Toplam = table.Column<double>(type: "float", nullable: false),
                    OdendiMi = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Siparisler", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Soslar",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Ad = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Adet = table.Column<int>(type: "int", nullable: false),
                    Fiyat = table.Column<double>(type: "float", nullable: false),
                    Resim = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Soslar", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "EkstraMenuler",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    MenuId = table.Column<int>(type: "int", nullable: false),
                    EkstraId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EkstraMenuler", x => x.Id);
                    table.ForeignKey(
                        name: "FK_EkstraMenuler_Ekstralar_EkstraId",
                        column: x => x.EkstraId,
                        principalTable: "Ekstralar",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_EkstraMenuler_Menuler_MenuId",
                        column: x => x.MenuId,
                        principalTable: "Menuler",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "HamburgerMenuler",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    MenuId = table.Column<int>(type: "int", nullable: false),
                    HamburgerId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_HamburgerMenuler", x => x.Id);
                    table.ForeignKey(
                        name: "FK_HamburgerMenuler_Hamburgerler_HamburgerId",
                        column: x => x.HamburgerId,
                        principalTable: "Hamburgerler",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_HamburgerMenuler_Menuler_MenuId",
                        column: x => x.MenuId,
                        principalTable: "Menuler",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "IcecekMenuler",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    MenuId = table.Column<int>(type: "int", nullable: false),
                    IcecekId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_IcecekMenuler", x => x.Id);
                    table.ForeignKey(
                        name: "FK_IcecekMenuler_Icecekler_IcecekId",
                        column: x => x.IcecekId,
                        principalTable: "Icecekler",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_IcecekMenuler_Menuler_MenuId",
                        column: x => x.MenuId,
                        principalTable: "Menuler",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "EkstraSiparisler",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    EkstraId = table.Column<int>(type: "int", nullable: false),
                    SiparisId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EkstraSiparisler", x => x.Id);
                    table.ForeignKey(
                        name: "FK_EkstraSiparisler_Ekstralar_EkstraId",
                        column: x => x.EkstraId,
                        principalTable: "Ekstralar",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_EkstraSiparisler_Siparisler_SiparisId",
                        column: x => x.SiparisId,
                        principalTable: "Siparisler",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "HamburgerSiparisler",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    HamburgerId = table.Column<int>(type: "int", nullable: false),
                    SiparisId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_HamburgerSiparisler", x => x.Id);
                    table.ForeignKey(
                        name: "FK_HamburgerSiparisler_Hamburgerler_HamburgerId",
                        column: x => x.HamburgerId,
                        principalTable: "Hamburgerler",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_HamburgerSiparisler_Siparisler_SiparisId",
                        column: x => x.SiparisId,
                        principalTable: "Siparisler",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "IcecekSiparisler",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    IcecekId = table.Column<int>(type: "int", nullable: false),
                    SiparisId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_IcecekSiparisler", x => x.Id);
                    table.ForeignKey(
                        name: "FK_IcecekSiparisler_Icecekler_IcecekId",
                        column: x => x.IcecekId,
                        principalTable: "Icecekler",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_IcecekSiparisler_Siparisler_SiparisId",
                        column: x => x.SiparisId,
                        principalTable: "Siparisler",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "MenuSiparisler",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    MenuId = table.Column<int>(type: "int", nullable: false),
                    SiparisId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MenuSiparisler", x => x.Id);
                    table.ForeignKey(
                        name: "FK_MenuSiparisler_Menuler_MenuId",
                        column: x => x.MenuId,
                        principalTable: "Menuler",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_MenuSiparisler_Siparisler_SiparisId",
                        column: x => x.SiparisId,
                        principalTable: "Siparisler",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "SosMenuler",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    MenuId = table.Column<int>(type: "int", nullable: false),
                    SosId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SosMenuler", x => x.Id);
                    table.ForeignKey(
                        name: "FK_SosMenuler_Menuler_MenuId",
                        column: x => x.MenuId,
                        principalTable: "Menuler",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_SosMenuler_Soslar_SosId",
                        column: x => x.SosId,
                        principalTable: "Soslar",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "SosSiparisler",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    SosId = table.Column<int>(type: "int", nullable: false),
                    SiparisId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SosSiparisler", x => x.Id);
                    table.ForeignKey(
                        name: "FK_SosSiparisler_Siparisler_SiparisId",
                        column: x => x.SiparisId,
                        principalTable: "Siparisler",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_SosSiparisler_Soslar_SosId",
                        column: x => x.SosId,
                        principalTable: "Soslar",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_EkstraMenuler_EkstraId",
                table: "EkstraMenuler",
                column: "EkstraId");

            migrationBuilder.CreateIndex(
                name: "IX_EkstraMenuler_MenuId",
                table: "EkstraMenuler",
                column: "MenuId");

            migrationBuilder.CreateIndex(
                name: "IX_EkstraSiparisler_EkstraId",
                table: "EkstraSiparisler",
                column: "EkstraId");

            migrationBuilder.CreateIndex(
                name: "IX_EkstraSiparisler_SiparisId",
                table: "EkstraSiparisler",
                column: "SiparisId");

            migrationBuilder.CreateIndex(
                name: "IX_HamburgerMenuler_HamburgerId",
                table: "HamburgerMenuler",
                column: "HamburgerId");

            migrationBuilder.CreateIndex(
                name: "IX_HamburgerMenuler_MenuId",
                table: "HamburgerMenuler",
                column: "MenuId");

            migrationBuilder.CreateIndex(
                name: "IX_HamburgerSiparisler_HamburgerId",
                table: "HamburgerSiparisler",
                column: "HamburgerId");

            migrationBuilder.CreateIndex(
                name: "IX_HamburgerSiparisler_SiparisId",
                table: "HamburgerSiparisler",
                column: "SiparisId");

            migrationBuilder.CreateIndex(
                name: "IX_IcecekMenuler_IcecekId",
                table: "IcecekMenuler",
                column: "IcecekId");

            migrationBuilder.CreateIndex(
                name: "IX_IcecekMenuler_MenuId",
                table: "IcecekMenuler",
                column: "MenuId");

            migrationBuilder.CreateIndex(
                name: "IX_IcecekSiparisler_IcecekId",
                table: "IcecekSiparisler",
                column: "IcecekId");

            migrationBuilder.CreateIndex(
                name: "IX_IcecekSiparisler_SiparisId",
                table: "IcecekSiparisler",
                column: "SiparisId");

            migrationBuilder.CreateIndex(
                name: "IX_MenuSiparisler_MenuId",
                table: "MenuSiparisler",
                column: "MenuId");

            migrationBuilder.CreateIndex(
                name: "IX_MenuSiparisler_SiparisId",
                table: "MenuSiparisler",
                column: "SiparisId");

            migrationBuilder.CreateIndex(
                name: "IX_SosMenuler_MenuId",
                table: "SosMenuler",
                column: "MenuId");

            migrationBuilder.CreateIndex(
                name: "IX_SosMenuler_SosId",
                table: "SosMenuler",
                column: "SosId");

            migrationBuilder.CreateIndex(
                name: "IX_SosSiparisler_SiparisId",
                table: "SosSiparisler",
                column: "SiparisId");

            migrationBuilder.CreateIndex(
                name: "IX_SosSiparisler_SosId",
                table: "SosSiparisler",
                column: "SosId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "EkstraMenuler");

            migrationBuilder.DropTable(
                name: "EkstraSiparisler");

            migrationBuilder.DropTable(
                name: "HamburgerMenuler");

            migrationBuilder.DropTable(
                name: "HamburgerSiparisler");

            migrationBuilder.DropTable(
                name: "IcecekMenuler");

            migrationBuilder.DropTable(
                name: "IcecekSiparisler");

            migrationBuilder.DropTable(
                name: "MenuSiparisler");

            migrationBuilder.DropTable(
                name: "SosMenuler");

            migrationBuilder.DropTable(
                name: "SosSiparisler");

            migrationBuilder.DropTable(
                name: "Ekstralar");

            migrationBuilder.DropTable(
                name: "Hamburgerler");

            migrationBuilder.DropTable(
                name: "Icecekler");

            migrationBuilder.DropTable(
                name: "Menuler");

            migrationBuilder.DropTable(
                name: "Siparisler");

            migrationBuilder.DropTable(
                name: "Soslar");
        }
    }
}
