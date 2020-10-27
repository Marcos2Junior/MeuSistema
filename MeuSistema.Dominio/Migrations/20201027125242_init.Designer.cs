﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using MySystem.Domain.DataContext;

namespace MySystem.Domain.Migrations
{
    [DbContext(typeof(MySystemDbContext))]
    [Migration("20201027125242_init")]
    partial class init
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "3.1.9")
                .HasAnnotation("Relational:MaxIdentifierLength", 64);

            modelBuilder.Entity("MySystem.Domain.Entitys.KeyAcess", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<DateTime>("Date")
                        .HasColumnType("datetime(6)");

                    b.Property<DateTime>("Expire")
                        .HasColumnType("datetime(6)");

                    b.Property<int>("IdFileKey")
                        .HasColumnType("int");

                    b.Property<string>("Key")
                        .HasColumnType("longtext CHARACTER SET utf8mb4");

                    b.HasKey("Id");

                    b.ToTable("KeyAcesses");
                });

            modelBuilder.Entity("MySystem.Domain.Entitys.User", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<DateTime>("Date")
                        .HasColumnType("datetime(6)");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("varchar(100) CHARACTER SET utf8mb4")
                        .HasMaxLength(100);

                    b.Property<int>("KeyAcessId")
                        .HasColumnType("int");

                    b.Property<long>("MobilePhone")
                        .HasColumnType("bigint")
                        .HasMaxLength(15);

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("varchar(100) CHARACTER SET utf8mb4")
                        .HasMaxLength(100);

                    b.Property<string>("Nick")
                        .HasColumnType("varchar(10) CHARACTER SET utf8mb4")
                        .HasMaxLength(10);

                    b.Property<bool>("NotifyEmail")
                        .HasColumnType("tinyint(1)");

                    b.Property<bool>("NotifyMobilePhone")
                        .HasColumnType("tinyint(1)");

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasColumnType("varchar(50) CHARACTER SET utf8mb4")
                        .HasMaxLength(50);

                    b.Property<int>("Role")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("KeyAcessId");

                    b.ToTable("Users");
                });

            modelBuilder.Entity("MySystem.Domain.Entitys.User", b =>
                {
                    b.HasOne("MySystem.Domain.Entitys.KeyAcess", "KeyAcess")
                        .WithMany()
                        .HasForeignKey("KeyAcessId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });
#pragma warning restore 612, 618
        }
    }
}
