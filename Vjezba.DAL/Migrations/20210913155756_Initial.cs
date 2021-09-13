using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Vjezba.DAL.Migrations
{
    public partial class Initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "AspNetRoles",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    NormalizedName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    ConcurrencyStamp = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetRoles", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUsers",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Surname = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    JMBG = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    OIB = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    UserName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    NormalizedUserName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    Email = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    NormalizedEmail = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    EmailConfirmed = table.Column<bool>(type: "bit", nullable: false),
                    PasswordHash = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SecurityStamp = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ConcurrencyStamp = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PhoneNumber = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PhoneNumberConfirmed = table.Column<bool>(type: "bit", nullable: false),
                    TwoFactorEnabled = table.Column<bool>(type: "bit", nullable: false),
                    LockoutEnd = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: true),
                    LockoutEnabled = table.Column<bool>(type: "bit", nullable: false),
                    AccessFailedCount = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUsers", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "kupac",
                columns: table => new
                {
                    IDKupac = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Naziv = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Adresa = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Grad = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Drzava = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    OIB = table.Column<long>(type: "bigint", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_kupac", x => x.IDKupac);
                });

            migrationBuilder.CreateTable(
                name: "poduzece",
                columns: table => new
                {
                    IDPoduzece = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Naziv = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Adresa = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Grad = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Drzava = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Tel = table.Column<int>(type: "int", nullable: false),
                    Mob = table.Column<int>(type: "int", nullable: false),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    OIB = table.Column<long>(type: "bigint", nullable: false),
                    OdgovornaOsoba = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ZiroRacun = table.Column<int>(type: "int", nullable: false),
                    Banka = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PDV = table.Column<int>(type: "int", nullable: false),
                    Biljeska = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_poduzece", x => x.IDPoduzece);
                });

            migrationBuilder.CreateTable(
                name: "proizvod",
                columns: table => new
                {
                    IDProizvod = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Naziv = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    MjernaJedinica = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Cijena = table.Column<int>(type: "int", nullable: false),
                    OznakaGrupe = table.Column<string>(type: "nvarchar(1)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_proizvod", x => x.IDProizvod);
                });

            migrationBuilder.CreateTable(
                name: "usluga",
                columns: table => new
                {
                    IDUsluga = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Naziv = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Cijena = table.Column<int>(type: "int", nullable: false),
                    MjernaJedinica = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    OznakaGrupe = table.Column<string>(type: "nvarchar(1)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_usluga", x => x.IDUsluga);
                });

            migrationBuilder.CreateTable(
                name: "AspNetRoleClaims",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RoleId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ClaimType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ClaimValue = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetRoleClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AspNetRoleClaims_AspNetRoles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "AspNetRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserClaims",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ClaimType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ClaimValue = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AspNetUserClaims_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserLogins",
                columns: table => new
                {
                    LoginProvider = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ProviderKey = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ProviderDisplayName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserLogins", x => new { x.LoginProvider, x.ProviderKey });
                    table.ForeignKey(
                        name: "FK_AspNetUserLogins_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserRoles",
                columns: table => new
                {
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    RoleId = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserRoles", x => new { x.UserId, x.RoleId });
                    table.ForeignKey(
                        name: "FK_AspNetUserRoles_AspNetRoles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "AspNetRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AspNetUserRoles_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserTokens",
                columns: table => new
                {
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    LoginProvider = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Value = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserTokens", x => new { x.UserId, x.LoginProvider, x.Name });
                    table.ForeignKey(
                        name: "FK_AspNetUserTokens_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "korisnik",
                columns: table => new
                {
                    IDKorisnik = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Ime = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Prezime = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Password = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    LicencaExp = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Vrsta = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Poduzece = table.Column<int>(type: "int", nullable: true),
                    Aktivan = table.Column<bool>(type: "bit", nullable: false),
                    AktivanLink = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_korisnik", x => x.IDKorisnik);
                    table.ForeignKey(
                        name: "FK_korisnik_poduzece_Poduzece",
                        column: x => x.Poduzece,
                        principalTable: "poduzece",
                        principalColumn: "IDPoduzece",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "racun",
                columns: table => new
                {
                    IDRacun = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Datum = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Poduzece = table.Column<int>(type: "int", nullable: true),
                    Korisnik = table.Column<int>(type: "int", nullable: true),
                    Naslov = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Iznos = table.Column<int>(type: "int", nullable: false),
                    PDV = table.Column<int>(type: "int", nullable: false),
                    Oznaka = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    VrijemeIzdavanja = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_racun", x => x.IDRacun);
                    table.ForeignKey(
                        name: "FK_racun_korisnik_Korisnik",
                        column: x => x.Korisnik,
                        principalTable: "korisnik",
                        principalColumn: "IDKorisnik",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_racun_poduzece_Poduzece",
                        column: x => x.Poduzece,
                        principalTable: "poduzece",
                        principalColumn: "IDPoduzece",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "racunStavka",
                columns: table => new
                {
                    IDRacunStavka = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Datum = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Racun = table.Column<int>(type: "int", nullable: true),
                    Usluga = table.Column<int>(type: "int", nullable: true),
                    Kolicina = table.Column<int>(type: "int", nullable: false),
                    Cijena = table.Column<int>(type: "int", nullable: false),
                    Rabat = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_racunStavka", x => x.IDRacunStavka);
                    table.ForeignKey(
                        name: "FK_racunStavka_racun_Racun",
                        column: x => x.Racun,
                        principalTable: "racun",
                        principalColumn: "IDRacun",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_racunStavka_usluga_Usluga",
                        column: x => x.Usluga,
                        principalTable: "usluga",
                        principalColumn: "IDUsluga",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.InsertData(
                table: "korisnik",
                columns: new[] { "IDKorisnik", "Aktivan", "AktivanLink", "Email", "Ime", "LicencaExp", "Password", "Poduzece", "Prezime", "Vrsta" },
                values: new object[,]
                {
                    { 1, true, "AktivanLink", "IvanB@gmail.com", "Ivan", new DateTime(2021, 9, 13, 17, 57, 56, 1, DateTimeKind.Local).AddTicks(5920), "!1Ivan123", null, "Bockal", "ObicanKorisnik" },
                    { 2, false, "AktivanLink2", "IvanB2@gmail.com", "Ivan2", new DateTime(2021, 9, 13, 17, 57, 56, 4, DateTimeKind.Local).AddTicks(5483), "!1Ivan123", null, "Bockal2", "ObicanKorisnik" },
                    { 3, true, "AktivanLink3", "IvanB3@gmail.com", "Ivan3", new DateTime(2021, 9, 13, 17, 57, 56, 4, DateTimeKind.Local).AddTicks(5602), "!1Ivan123", null, "Bockal3", "NeobicanKorisnik" }
                });

            migrationBuilder.InsertData(
                table: "kupac",
                columns: new[] { "IDKupac", "Adresa", "Drzava", "Grad", "Naziv", "OIB" },
                values: new object[,]
                {
                    { 1, "Zagorska3", "Hrvatska", "Konjscina", "Ivan", 12345678912L },
                    { 2, "Zagorska34", "Hrvatska2", "Konjscina2", "Ivan2", 12345678956L },
                    { 3, "Zagorska35", "Hrvatska3", "Konjscina3", "Ivan3", 12345678987L }
                });

            migrationBuilder.InsertData(
                table: "proizvod",
                columns: new[] { "IDProizvod", "Cijena", "MjernaJedinica", "Naziv", "OznakaGrupe" },
                values: new object[,]
                {
                    { 1, 45, "KN", "Mjesana Pizza", " " },
                    { 2, 55, "KN", "Classic Pizza", " " },
                    { 3, 60, "KN", "Slavonska Jumbo Pizza", " " }
                });

            migrationBuilder.CreateIndex(
                name: "IX_AspNetRoleClaims_RoleId",
                table: "AspNetRoleClaims",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "RoleNameIndex",
                table: "AspNetRoles",
                column: "NormalizedName",
                unique: true,
                filter: "[NormalizedName] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserClaims_UserId",
                table: "AspNetUserClaims",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserLogins_UserId",
                table: "AspNetUserLogins",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserRoles_RoleId",
                table: "AspNetUserRoles",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "EmailIndex",
                table: "AspNetUsers",
                column: "NormalizedEmail");

            migrationBuilder.CreateIndex(
                name: "UserNameIndex",
                table: "AspNetUsers",
                column: "NormalizedUserName",
                unique: true,
                filter: "[NormalizedUserName] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_korisnik_Poduzece",
                table: "korisnik",
                column: "Poduzece");

            migrationBuilder.CreateIndex(
                name: "IX_racun_Korisnik",
                table: "racun",
                column: "Korisnik");

            migrationBuilder.CreateIndex(
                name: "IX_racun_Poduzece",
                table: "racun",
                column: "Poduzece");

            migrationBuilder.CreateIndex(
                name: "IX_racunStavka_Racun",
                table: "racunStavka",
                column: "Racun");

            migrationBuilder.CreateIndex(
                name: "IX_racunStavka_Usluga",
                table: "racunStavka",
                column: "Usluga");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AspNetRoleClaims");

            migrationBuilder.DropTable(
                name: "AspNetUserClaims");

            migrationBuilder.DropTable(
                name: "AspNetUserLogins");

            migrationBuilder.DropTable(
                name: "AspNetUserRoles");

            migrationBuilder.DropTable(
                name: "AspNetUserTokens");

            migrationBuilder.DropTable(
                name: "kupac");

            migrationBuilder.DropTable(
                name: "proizvod");

            migrationBuilder.DropTable(
                name: "racunStavka");

            migrationBuilder.DropTable(
                name: "AspNetRoles");

            migrationBuilder.DropTable(
                name: "AspNetUsers");

            migrationBuilder.DropTable(
                name: "racun");

            migrationBuilder.DropTable(
                name: "usluga");

            migrationBuilder.DropTable(
                name: "korisnik");

            migrationBuilder.DropTable(
                name: "poduzece");
        }
    }
}
