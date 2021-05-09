﻿// <auto-generated />
using System;
using FamilyAPI.DataAccess;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace FamilyAPI.Migrations
{
    [DbContext(typeof(FamilyDbContext))]
    [Migration("20210509121210_ThirdUpdate-User")]
    partial class ThirdUpdateUser
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "5.0.5");

            modelBuilder.Entity("Models.Adult", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("AdultJobJobTitle")
                        .HasColumnType("TEXT");

                    b.Property<int?>("AdultJobSalary")
                        .HasColumnType("INTEGER");

                    b.Property<int?>("PersonaId")
                        .HasColumnType("INTEGER");

                    b.HasKey("Id");

                    b.HasIndex("PersonaId");

                    b.HasIndex("AdultJobSalary", "AdultJobJobTitle");

                    b.ToTable("Adults");
                });

            modelBuilder.Entity("Models.Job", b =>
                {
                    b.Property<int>("Salary")
                        .HasColumnType("INTEGER");

                    b.Property<string>("JobTitle")
                        .HasColumnType("TEXT");

                    b.HasKey("Salary", "JobTitle");

                    b.ToTable("Jobs");
                });

            modelBuilder.Entity("Models.Person", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<int>("Age")
                        .HasColumnType("INTEGER");

                    b.Property<string>("EyeColor")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("HairColor")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<int>("Height")
                        .HasColumnType("INTEGER");

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("Sex")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<float>("Weight")
                        .HasColumnType("REAL");

                    b.HasKey("Id");

                    b.ToTable("Persons");
                });

            modelBuilder.Entity("Models.User", b =>
                {
                    b.Property<string>("UserName")
                        .HasColumnType("TEXT");

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("Role")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.HasKey("UserName");

                    b.ToTable("Users");
                });

            modelBuilder.Entity("Models.Adult", b =>
                {
                    b.HasOne("Models.Person", "Persona")
                        .WithMany()
                        .HasForeignKey("PersonaId");

                    b.HasOne("Models.Job", "AdultJob")
                        .WithMany()
                        .HasForeignKey("AdultJobSalary", "AdultJobJobTitle");

                    b.Navigation("AdultJob");

                    b.Navigation("Persona");
                });
#pragma warning restore 612, 618
        }
    }
}
