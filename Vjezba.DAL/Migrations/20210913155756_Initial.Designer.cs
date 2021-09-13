﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Vjezba.DAL;

namespace Vjezba.DAL.Migrations
{
    [DbContext(typeof(RacunModelDbContext))]
    [Migration("20210913155756_Initial")]
    partial class Initial
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .UseIdentityColumns()
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.4");

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRole", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<string>("NormalizedName")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.HasKey("Id");

                    b.HasIndex("NormalizedName")
                        .IsUnique()
                        .HasDatabaseName("RoleNameIndex")
                        .HasFilter("[NormalizedName] IS NOT NULL");

                    b.ToTable("AspNetRoles");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<string>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .UseIdentityColumn();

                    b.Property<string>("ClaimType")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ClaimValue")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("RoleId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("Id");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetRoleClaims");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<string>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .UseIdentityColumn();

                    b.Property<string>("ClaimType")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ClaimValue")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("UserId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserClaims");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<string>", b =>
                {
                    b.Property<string>("LoginProvider")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("ProviderKey")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("ProviderDisplayName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("UserId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("LoginProvider", "ProviderKey");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserLogins");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<string>", b =>
                {
                    b.Property<string>("UserId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("RoleId")
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("UserId", "RoleId");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetUserRoles");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<string>", b =>
                {
                    b.Property<string>("UserId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("LoginProvider")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("Value")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("UserId", "LoginProvider", "Name");

                    b.ToTable("AspNetUserTokens");
                });

            modelBuilder.Entity("Vjezba.Model.AppUser", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("nvarchar(450)");

                    b.Property<int>("AccessFailedCount")
                        .HasColumnType("int");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Email")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<bool>("EmailConfirmed")
                        .HasColumnType("bit");

                    b.Property<string>("JMBG")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("LockoutEnabled")
                        .HasColumnType("bit");

                    b.Property<DateTimeOffset?>("LockoutEnd")
                        .HasColumnType("datetimeoffset");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("NormalizedEmail")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<string>("NormalizedUserName")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<string>("OIB")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PasswordHash")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PhoneNumber")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("PhoneNumberConfirmed")
                        .HasColumnType("bit");

                    b.Property<string>("SecurityStamp")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Surname")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("TwoFactorEnabled")
                        .HasColumnType("bit");

                    b.Property<string>("UserName")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.HasKey("Id");

                    b.HasIndex("NormalizedEmail")
                        .HasDatabaseName("EmailIndex");

                    b.HasIndex("NormalizedUserName")
                        .IsUnique()
                        .HasDatabaseName("UserNameIndex")
                        .HasFilter("[NormalizedUserName] IS NOT NULL");

                    b.ToTable("AspNetUsers");
                });

            modelBuilder.Entity("Vjezba.Model.Korisnik", b =>
                {
                    b.Property<int>("IDKorisnik")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .UseIdentityColumn();

                    b.Property<bool>("Aktivan")
                        .HasColumnType("bit");

                    b.Property<string>("AktivanLink")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Ime")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("LicencaExp")
                        .HasColumnType("datetime2");

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("Poduzece")
                        .HasColumnType("int");

                    b.Property<string>("Prezime")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Vrsta")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("IDKorisnik");

                    b.HasIndex("Poduzece");

                    b.ToTable("korisnik");

                    b.HasData(
                        new
                        {
                            IDKorisnik = 1,
                            Aktivan = true,
                            AktivanLink = "AktivanLink",
                            Email = "IvanB@gmail.com",
                            Ime = "Ivan",
                            LicencaExp = new DateTime(2021, 9, 13, 17, 57, 56, 1, DateTimeKind.Local).AddTicks(5920),
                            Password = "!1Ivan123",
                            Prezime = "Bockal",
                            Vrsta = "ObicanKorisnik"
                        },
                        new
                        {
                            IDKorisnik = 2,
                            Aktivan = false,
                            AktivanLink = "AktivanLink2",
                            Email = "IvanB2@gmail.com",
                            Ime = "Ivan2",
                            LicencaExp = new DateTime(2021, 9, 13, 17, 57, 56, 4, DateTimeKind.Local).AddTicks(5483),
                            Password = "!1Ivan123",
                            Prezime = "Bockal2",
                            Vrsta = "ObicanKorisnik"
                        },
                        new
                        {
                            IDKorisnik = 3,
                            Aktivan = true,
                            AktivanLink = "AktivanLink3",
                            Email = "IvanB3@gmail.com",
                            Ime = "Ivan3",
                            LicencaExp = new DateTime(2021, 9, 13, 17, 57, 56, 4, DateTimeKind.Local).AddTicks(5602),
                            Password = "!1Ivan123",
                            Prezime = "Bockal3",
                            Vrsta = "NeobicanKorisnik"
                        });
                });

            modelBuilder.Entity("Vjezba.Model.Kupac", b =>
                {
                    b.Property<int>("IDKupac")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .UseIdentityColumn();

                    b.Property<string>("Adresa")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Drzava")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Grad")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Naziv")
                        .HasColumnType("nvarchar(max)");

                    b.Property<long>("OIB")
                        .HasColumnType("bigint");

                    b.HasKey("IDKupac");

                    b.ToTable("kupac");

                    b.HasData(
                        new
                        {
                            IDKupac = 1,
                            Adresa = "Zagorska3",
                            Drzava = "Hrvatska",
                            Grad = "Konjscina",
                            Naziv = "Ivan",
                            OIB = 12345678912L
                        },
                        new
                        {
                            IDKupac = 2,
                            Adresa = "Zagorska34",
                            Drzava = "Hrvatska2",
                            Grad = "Konjscina2",
                            Naziv = "Ivan2",
                            OIB = 12345678956L
                        },
                        new
                        {
                            IDKupac = 3,
                            Adresa = "Zagorska35",
                            Drzava = "Hrvatska3",
                            Grad = "Konjscina3",
                            Naziv = "Ivan3",
                            OIB = 12345678987L
                        });
                });

            modelBuilder.Entity("Vjezba.Model.Poduzece", b =>
                {
                    b.Property<int>("IDPoduzece")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .UseIdentityColumn();

                    b.Property<string>("Adresa")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Banka")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Biljeska")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Drzava")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Email")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Grad")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Mob")
                        .HasColumnType("int");

                    b.Property<string>("Naziv")
                        .HasColumnType("nvarchar(max)");

                    b.Property<long>("OIB")
                        .HasColumnType("bigint");

                    b.Property<string>("OdgovornaOsoba")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("PDV")
                        .HasColumnType("int");

                    b.Property<int>("Tel")
                        .HasColumnType("int");

                    b.Property<int>("ZiroRacun")
                        .HasColumnType("int");

                    b.HasKey("IDPoduzece");

                    b.ToTable("poduzece");
                });

            modelBuilder.Entity("Vjezba.Model.Proizvod", b =>
                {
                    b.Property<int>("IDProizvod")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .UseIdentityColumn();

                    b.Property<int>("Cijena")
                        .HasColumnType("int");

                    b.Property<string>("MjernaJedinica")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Naziv")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("OznakaGrupe")
                        .IsRequired()
                        .HasColumnType("nvarchar(1)");

                    b.HasKey("IDProizvod");

                    b.ToTable("proizvod");

                    b.HasData(
                        new
                        {
                            IDProizvod = 1,
                            Cijena = 45,
                            MjernaJedinica = "KN",
                            Naziv = "Mjesana Pizza",
                            OznakaGrupe = " "
                        },
                        new
                        {
                            IDProizvod = 2,
                            Cijena = 55,
                            MjernaJedinica = "KN",
                            Naziv = "Classic Pizza",
                            OznakaGrupe = " "
                        },
                        new
                        {
                            IDProizvod = 3,
                            Cijena = 60,
                            MjernaJedinica = "KN",
                            Naziv = "Slavonska Jumbo Pizza",
                            OznakaGrupe = " "
                        });
                });

            modelBuilder.Entity("Vjezba.Model.Racun", b =>
                {
                    b.Property<int>("IDRacun")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .UseIdentityColumn();

                    b.Property<DateTime>("Datum")
                        .HasColumnType("datetime2");

                    b.Property<int>("Iznos")
                        .HasColumnType("int");

                    b.Property<int?>("Korisnik")
                        .HasColumnType("int");

                    b.Property<string>("Naslov")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Oznaka")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("PDV")
                        .HasColumnType("int");

                    b.Property<int?>("Poduzece")
                        .HasColumnType("int");

                    b.Property<DateTime>("VrijemeIzdavanja")
                        .HasColumnType("datetime2");

                    b.HasKey("IDRacun");

                    b.HasIndex("Korisnik");

                    b.HasIndex("Poduzece");

                    b.ToTable("racun");
                });

            modelBuilder.Entity("Vjezba.Model.RacunStavka", b =>
                {
                    b.Property<int>("IDRacunStavka")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .UseIdentityColumn();

                    b.Property<int>("Cijena")
                        .HasColumnType("int");

                    b.Property<DateTime>("Datum")
                        .HasColumnType("datetime2");

                    b.Property<int>("Kolicina")
                        .HasColumnType("int");

                    b.Property<int>("Rabat")
                        .HasColumnType("int");

                    b.Property<int?>("Racun")
                        .HasColumnType("int");

                    b.Property<int?>("Usluga")
                        .HasColumnType("int");

                    b.HasKey("IDRacunStavka");

                    b.HasIndex("Racun");

                    b.HasIndex("Usluga");

                    b.ToTable("racunStavka");
                });

            modelBuilder.Entity("Vjezba.Model.Usluga", b =>
                {
                    b.Property<int>("IDUsluga")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .UseIdentityColumn();

                    b.Property<int>("Cijena")
                        .HasColumnType("int");

                    b.Property<string>("MjernaJedinica")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Naziv")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("OznakaGrupe")
                        .IsRequired()
                        .HasColumnType("nvarchar(1)");

                    b.HasKey("IDUsluga");

                    b.ToTable("usluga");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityRole", null)
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<string>", b =>
                {
                    b.HasOne("Vjezba.Model.AppUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<string>", b =>
                {
                    b.HasOne("Vjezba.Model.AppUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityRole", null)
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Vjezba.Model.AppUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<string>", b =>
                {
                    b.HasOne("Vjezba.Model.AppUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Vjezba.Model.Korisnik", b =>
                {
                    b.HasOne("Vjezba.Model.Poduzece", "IDPoduzece")
                        .WithMany()
                        .HasForeignKey("Poduzece");

                    b.Navigation("IDPoduzece");
                });

            modelBuilder.Entity("Vjezba.Model.Racun", b =>
                {
                    b.HasOne("Vjezba.Model.Korisnik", "IDKorisnik")
                        .WithMany()
                        .HasForeignKey("Korisnik");

                    b.HasOne("Vjezba.Model.Poduzece", "IDPoduzece")
                        .WithMany()
                        .HasForeignKey("Poduzece");

                    b.Navigation("IDKorisnik");

                    b.Navigation("IDPoduzece");
                });

            modelBuilder.Entity("Vjezba.Model.RacunStavka", b =>
                {
                    b.HasOne("Vjezba.Model.Racun", "IDRacun")
                        .WithMany()
                        .HasForeignKey("Racun");

                    b.HasOne("Vjezba.Model.Usluga", "IDUsluga")
                        .WithMany()
                        .HasForeignKey("Usluga");

                    b.Navigation("IDRacun");

                    b.Navigation("IDUsluga");
                });
#pragma warning restore 612, 618
        }
    }
}
