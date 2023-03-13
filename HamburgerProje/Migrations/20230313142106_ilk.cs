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
                    Toplam = table.Column<double>(type: "float", nullable: false)
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
                name: "EkstraSiparis",
                columns: table => new
                {
                    EkstralarId = table.Column<int>(type: "int", nullable: false),
                    SiparislerId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EkstraSiparis", x => new { x.EkstralarId, x.SiparislerId });
                    table.ForeignKey(
                        name: "FK_EkstraSiparis_Ekstralar_EkstralarId",
                        column: x => x.EkstralarId,
                        principalTable: "Ekstralar",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_EkstraSiparis_Siparisler_SiparislerId",
                        column: x => x.SiparislerId,
                        principalTable: "Siparisler",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "HamburgerSiparis",
                columns: table => new
                {
                    HamburgerlerId = table.Column<int>(type: "int", nullable: false),
                    SiparislerId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_HamburgerSiparis", x => new { x.HamburgerlerId, x.SiparislerId });
                    table.ForeignKey(
                        name: "FK_HamburgerSiparis_Hamburgerler_HamburgerlerId",
                        column: x => x.HamburgerlerId,
                        principalTable: "Hamburgerler",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_HamburgerSiparis_Siparisler_SiparislerId",
                        column: x => x.SiparislerId,
                        principalTable: "Siparisler",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "IcecekSiparis",
                columns: table => new
                {
                    IceceklerId = table.Column<int>(type: "int", nullable: false),
                    SiparislerId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_IcecekSiparis", x => new { x.IceceklerId, x.SiparislerId });
                    table.ForeignKey(
                        name: "FK_IcecekSiparis_Icecekler_IceceklerId",
                        column: x => x.IceceklerId,
                        principalTable: "Icecekler",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_IcecekSiparis_Siparisler_SiparislerId",
                        column: x => x.SiparislerId,
                        principalTable: "Siparisler",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "MenuSiparis",
                columns: table => new
                {
                    MenulerId = table.Column<int>(type: "int", nullable: false),
                    SiparislerId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MenuSiparis", x => new { x.MenulerId, x.SiparislerId });
                    table.ForeignKey(
                        name: "FK_MenuSiparis_Menuler_MenulerId",
                        column: x => x.MenulerId,
                        principalTable: "Menuler",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_MenuSiparis_Siparisler_SiparislerId",
                        column: x => x.SiparislerId,
                        principalTable: "Siparisler",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "SiparisSos",
                columns: table => new
                {
                    SiparislerId = table.Column<int>(type: "int", nullable: false),
                    SoslarId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SiparisSos", x => new { x.SiparislerId, x.SoslarId });
                    table.ForeignKey(
                        name: "FK_SiparisSos_Siparisler_SiparislerId",
                        column: x => x.SiparislerId,
                        principalTable: "Siparisler",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_SiparisSos_Soslar_SoslarId",
                        column: x => x.SoslarId,
                        principalTable: "Soslar",
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

            migrationBuilder.CreateIndex(
                name: "IX_EkstraMenuler_EkstraId",
                table: "EkstraMenuler",
                column: "EkstraId");

            migrationBuilder.CreateIndex(
                name: "IX_EkstraMenuler_MenuId",
                table: "EkstraMenuler",
                column: "MenuId");

            migrationBuilder.CreateIndex(
                name: "IX_EkstraSiparis_SiparislerId",
                table: "EkstraSiparis",
                column: "SiparislerId");

            migrationBuilder.CreateIndex(
                name: "IX_HamburgerMenuler_HamburgerId",
                table: "HamburgerMenuler",
                column: "HamburgerId");

            migrationBuilder.CreateIndex(
                name: "IX_HamburgerMenuler_MenuId",
                table: "HamburgerMenuler",
                column: "MenuId");

            migrationBuilder.CreateIndex(
                name: "IX_HamburgerSiparis_SiparislerId",
                table: "HamburgerSiparis",
                column: "SiparislerId");

            migrationBuilder.CreateIndex(
                name: "IX_IcecekMenuler_IcecekId",
                table: "IcecekMenuler",
                column: "IcecekId");

            migrationBuilder.CreateIndex(
                name: "IX_IcecekMenuler_MenuId",
                table: "IcecekMenuler",
                column: "MenuId");

            migrationBuilder.CreateIndex(
                name: "IX_IcecekSiparis_SiparislerId",
                table: "IcecekSiparis",
                column: "SiparislerId");

            migrationBuilder.CreateIndex(
                name: "IX_MenuSiparis_SiparislerId",
                table: "MenuSiparis",
                column: "SiparislerId");

            migrationBuilder.CreateIndex(
                name: "IX_SiparisSos_SoslarId",
                table: "SiparisSos",
                column: "SoslarId");

            migrationBuilder.CreateIndex(
                name: "IX_SosMenuler_MenuId",
                table: "SosMenuler",
                column: "MenuId");

            migrationBuilder.CreateIndex(
                name: "IX_SosMenuler_SosId",
                table: "SosMenuler",
                column: "SosId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "EkstraMenuler");

            migrationBuilder.DropTable(
                name: "EkstraSiparis");

            migrationBuilder.DropTable(
                name: "HamburgerMenuler");

            migrationBuilder.DropTable(
                name: "HamburgerSiparis");

            migrationBuilder.DropTable(
                name: "IcecekMenuler");

            migrationBuilder.DropTable(
                name: "IcecekSiparis");

            migrationBuilder.DropTable(
                name: "MenuSiparis");

            migrationBuilder.DropTable(
                name: "SiparisSos");

            migrationBuilder.DropTable(
                name: "SosMenuler");

            migrationBuilder.DropTable(
                name: "Ekstralar");

            migrationBuilder.DropTable(
                name: "Hamburgerler");

            migrationBuilder.DropTable(
                name: "Icecekler");

            migrationBuilder.DropTable(
                name: "Siparisler");

            migrationBuilder.DropTable(
                name: "Menuler");

            migrationBuilder.DropTable(
                name: "Soslar");
        }
    }
}
