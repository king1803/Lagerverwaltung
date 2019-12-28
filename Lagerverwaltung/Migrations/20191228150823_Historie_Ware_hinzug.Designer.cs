﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using SSG_Lagerverwaltung.Data;

namespace Lagerverwaltung.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    [Migration("20191228150823_Historie_Ware_hinzug")]
    partial class Historie_Ware_hinzug
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "3.1.0")
                .HasAnnotation("Relational:MaxIdentifierLength", 64);

            modelBuilder.Entity("Lagerverwaltung.Models.Hersteller", b =>
                {
                    b.Property<int>("Hersteller_Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<string>("Hersteller_Beschreibung")
                        .HasColumnType("longtext CHARACTER SET utf8mb4");

                    b.HasKey("Hersteller_Id");

                    b.ToTable("Hersteller");
                });

            modelBuilder.Entity("Lagerverwaltung.Models.Kategorie", b =>
                {
                    b.Property<string>("Kategorie_Name")
                        .HasColumnType("varchar(255) CHARACTER SET utf8mb4");

                    b.Property<string>("Kategorie_Beschreibung")
                        .HasColumnType("longtext CHARACTER SET utf8mb4");

                    b.HasKey("Kategorie_Name");

                    b.ToTable("Kategorie");
                });

            modelBuilder.Entity("Lagerverwaltung.Models.Kostenstelle", b =>
                {
                    b.Property<int>("Kostenstelle_Nr")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<string>("Kostenstelle_Beschreibung")
                        .HasColumnType("longtext CHARACTER SET utf8mb4");

                    b.HasKey("Kostenstelle_Nr");

                    b.ToTable("Kostenstelle");
                });

            modelBuilder.Entity("Lagerverwaltung.Models.Lager", b =>
                {
                    b.Property<int>("Lager_Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<string>("Lager_Beschreibung")
                        .HasColumnType("longtext CHARACTER SET utf8mb4");

                    b.HasKey("Lager_Id");

                    b.ToTable("Lager");
                });

            modelBuilder.Entity("Lagerverwaltung.Models.Lagerplatz", b =>
                {
                    b.Property<int>("Lagerplatz_Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<int>("Lager_Id")
                        .HasColumnType("int");

                    b.Property<string>("Lagerplatz_Beschreibung")
                        .HasColumnType("longtext CHARACTER SET utf8mb4");

                    b.HasKey("Lagerplatz_Id");

                    b.ToTable("Lagerplatz");
                });

            modelBuilder.Entity("Lagerverwaltung.Models.Lieferant", b =>
                {
                    b.Property<int>("Lieferant_Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<string>("Lieferant_Beschreibung")
                        .HasColumnType("longtext CHARACTER SET utf8mb4");

                    b.HasKey("Lieferant_Id");

                    b.ToTable("Lieferant");
                });

            modelBuilder.Entity("Lagerverwaltung.Models.Ware", b =>
                {
                    b.Property<int>("Ware_Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<decimal>("Anschaff_Kosten")
                        .HasColumnType("decimal(65,30)");

                    b.Property<int>("Hersteller_Id")
                        .HasColumnType("int");

                    b.Property<string>("Kategorie_Name")
                        .HasColumnType("longtext CHARACTER SET utf8mb4");

                    b.Property<int>("Kostenstelle_Nr")
                        .HasColumnType("int");

                    b.Property<int>("Lagerplatz_Id")
                        .HasColumnType("int");

                    b.Property<int>("Lieferant_Id")
                        .HasColumnType("int");

                    b.Property<decimal>("Menge")
                        .HasColumnType("decimal(65,30)");

                    b.Property<string>("Modelnr")
                        .HasColumnType("longtext CHARACTER SET utf8mb4");

                    b.Property<string>("Seriennr")
                        .HasColumnType("longtext CHARACTER SET utf8mb4");

                    b.Property<string>("User_id")
                        .HasColumnType("longtext CHARACTER SET utf8mb4");

                    b.Property<string>("Ware_Beschreibung")
                        .HasColumnType("longtext CHARACTER SET utf8mb4");

                    b.Property<DateTime>("Ware_Einlagerungsdatum")
                        .HasColumnType("datetime(6)");

                    b.HasKey("Ware_Id");

                    b.ToTable("Ware");
                });

            modelBuilder.Entity("Lagerverwaltung.Models.WareHistorie", b =>
                {
                    b.Property<int>("Ware_Id_hi")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<decimal>("Anschaff_Kosten_hi")
                        .HasColumnType("decimal(65,30)");

                    b.Property<int>("Hersteller_Id_hi")
                        .HasColumnType("int");

                    b.Property<string>("Kategorie_Name_hi")
                        .HasColumnType("longtext CHARACTER SET utf8mb4");

                    b.Property<int>("Kostenstelle_Nr_hi")
                        .HasColumnType("int");

                    b.Property<int>("Lagerplatz_Id_hi")
                        .HasColumnType("int");

                    b.Property<int>("Lieferant_Id_hi")
                        .HasColumnType("int");

                    b.Property<decimal>("Menge_hi")
                        .HasColumnType("decimal(65,30)");

                    b.Property<string>("Modelnr_hi")
                        .HasColumnType("longtext CHARACTER SET utf8mb4");

                    b.Property<string>("Seriennr_hi")
                        .HasColumnType("longtext CHARACTER SET utf8mb4");

                    b.Property<string>("User_id_hi")
                        .HasColumnType("longtext CHARACTER SET utf8mb4");

                    b.Property<DateTime>("Ware_Auslagerungsdatum_hi")
                        .HasColumnType("datetime(6)");

                    b.Property<string>("Ware_Beschreibung_hi")
                        .HasColumnType("longtext CHARACTER SET utf8mb4");

                    b.Property<DateTime>("Ware_Einlagerungsdatum_hi")
                        .HasColumnType("datetime(6)");

                    b.HasKey("Ware_Id_hi");

                    b.ToTable("WareHistorie");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRole", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("varchar(255) CHARACTER SET utf8mb4");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken()
                        .HasColumnType("longtext CHARACTER SET utf8mb4");

                    b.Property<string>("Name")
                        .HasColumnType("varchar(256) CHARACTER SET utf8mb4")
                        .HasMaxLength(256);

                    b.Property<string>("NormalizedName")
                        .HasColumnType("varchar(256) CHARACTER SET utf8mb4")
                        .HasMaxLength(256);

                    b.HasKey("Id");

                    b.HasIndex("NormalizedName")
                        .IsUnique()
                        .HasName("RoleNameIndex");

                    b.ToTable("AspNetRoles");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<string>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<string>("ClaimType")
                        .HasColumnType("longtext CHARACTER SET utf8mb4");

                    b.Property<string>("ClaimValue")
                        .HasColumnType("longtext CHARACTER SET utf8mb4");

                    b.Property<string>("RoleId")
                        .IsRequired()
                        .HasColumnType("varchar(255) CHARACTER SET utf8mb4");

                    b.HasKey("Id");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetRoleClaims");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUser", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("varchar(255) CHARACTER SET utf8mb4");

                    b.Property<int>("AccessFailedCount")
                        .HasColumnType("int");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken()
                        .HasColumnType("longtext CHARACTER SET utf8mb4");

                    b.Property<string>("Email")
                        .HasColumnType("varchar(256) CHARACTER SET utf8mb4")
                        .HasMaxLength(256);

                    b.Property<bool>("EmailConfirmed")
                        .HasColumnType("tinyint(1)");

                    b.Property<bool>("LockoutEnabled")
                        .HasColumnType("tinyint(1)");

                    b.Property<DateTimeOffset?>("LockoutEnd")
                        .HasColumnType("datetime(6)");

                    b.Property<string>("NormalizedEmail")
                        .HasColumnType("varchar(256) CHARACTER SET utf8mb4")
                        .HasMaxLength(256);

                    b.Property<string>("NormalizedUserName")
                        .HasColumnType("varchar(256) CHARACTER SET utf8mb4")
                        .HasMaxLength(256);

                    b.Property<string>("PasswordHash")
                        .HasColumnType("longtext CHARACTER SET utf8mb4");

                    b.Property<string>("PhoneNumber")
                        .HasColumnType("longtext CHARACTER SET utf8mb4");

                    b.Property<bool>("PhoneNumberConfirmed")
                        .HasColumnType("tinyint(1)");

                    b.Property<string>("SecurityStamp")
                        .HasColumnType("longtext CHARACTER SET utf8mb4");

                    b.Property<bool>("TwoFactorEnabled")
                        .HasColumnType("tinyint(1)");

                    b.Property<string>("UserName")
                        .HasColumnType("varchar(256) CHARACTER SET utf8mb4")
                        .HasMaxLength(256);

                    b.HasKey("Id");

                    b.HasIndex("NormalizedEmail")
                        .HasName("EmailIndex");

                    b.HasIndex("NormalizedUserName")
                        .IsUnique()
                        .HasName("UserNameIndex");

                    b.ToTable("AspNetUsers");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<string>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<string>("ClaimType")
                        .HasColumnType("longtext CHARACTER SET utf8mb4");

                    b.Property<string>("ClaimValue")
                        .HasColumnType("longtext CHARACTER SET utf8mb4");

                    b.Property<string>("UserId")
                        .IsRequired()
                        .HasColumnType("varchar(255) CHARACTER SET utf8mb4");

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserClaims");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<string>", b =>
                {
                    b.Property<string>("LoginProvider")
                        .HasColumnType("varchar(255) CHARACTER SET utf8mb4");

                    b.Property<string>("ProviderKey")
                        .HasColumnType("varchar(255) CHARACTER SET utf8mb4");

                    b.Property<string>("ProviderDisplayName")
                        .HasColumnType("longtext CHARACTER SET utf8mb4");

                    b.Property<string>("UserId")
                        .IsRequired()
                        .HasColumnType("varchar(255) CHARACTER SET utf8mb4");

                    b.HasKey("LoginProvider", "ProviderKey");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserLogins");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<string>", b =>
                {
                    b.Property<string>("UserId")
                        .HasColumnType("varchar(255) CHARACTER SET utf8mb4");

                    b.Property<string>("RoleId")
                        .HasColumnType("varchar(255) CHARACTER SET utf8mb4");

                    b.HasKey("UserId", "RoleId");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetUserRoles");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<string>", b =>
                {
                    b.Property<string>("UserId")
                        .HasColumnType("varchar(255) CHARACTER SET utf8mb4");

                    b.Property<string>("LoginProvider")
                        .HasColumnType("varchar(255) CHARACTER SET utf8mb4");

                    b.Property<string>("Name")
                        .HasColumnType("varchar(255) CHARACTER SET utf8mb4");

                    b.Property<string>("Value")
                        .HasColumnType("longtext CHARACTER SET utf8mb4");

                    b.HasKey("UserId", "LoginProvider", "Name");

                    b.ToTable("AspNetUserTokens");
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
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityUser", null)
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

                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });
#pragma warning restore 612, 618
        }
    }
}
