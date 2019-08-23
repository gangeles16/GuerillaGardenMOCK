﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using gorillatree.Models;

namespace gorillatree.Migrations
{
    [DbContext(typeof(HomeContext))]
    [Migration("20190529181811_NEWMIGRATIONS")]
    partial class NEWMIGRATIONS
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.1.4-rtm-31024")
                .HasAnnotation("Relational:MaxIdentifierLength", 64);

            modelBuilder.Entity("gorillatree.Models.Tree", b =>
                {
                    b.Property<int>("TreeId")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Attributes");

                    b.Property<string>("CareInstructions");

                    b.Property<DateTime>("CreatedAt");

                    b.Property<int>("FlowerType");

                    b.Property<string>("Fruit");

                    b.Property<int>("Gender");

                    b.Property<string>("GrowthHabit");

                    b.Property<string>("Location")
                        .IsRequired();

                    b.Property<int>("TreeType");

                    b.Property<DateTime>("UpdatedAt");

                    b.Property<int>("UserId");

                    b.HasKey("TreeId");

                    b.HasIndex("UserId");

                    b.ToTable("Trees");
                });

            modelBuilder.Entity("gorillatree.Models.User", b =>
                {
                    b.Property<int>("UserId")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("ComparePassword")
                        .IsRequired();

                    b.Property<DateTime>("CreatedAt");

                    b.Property<string>("Email")
                        .IsRequired();

                    b.Property<string>("FirstName")
                        .IsRequired();

                    b.Property<string>("LastName")
                        .IsRequired();

                    b.Property<string>("Password")
                        .IsRequired();

                    b.Property<DateTime>("UpdatedAt");

                    b.HasKey("UserId");

                    b.ToTable("Users");
                });

            modelBuilder.Entity("gorillatree.Models.Tree", b =>
                {
                    b.HasOne("gorillatree.Models.User", "Planter")
                        .WithMany("mytrees")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade);
                });
#pragma warning restore 612, 618
        }
    }
}