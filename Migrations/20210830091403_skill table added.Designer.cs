﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using OneToOneRelation.Models;

namespace OneToOneRelation.Migrations
{
    [DbContext(typeof(DataContext))]
    [Migration("20210830091403_skill table added")]
    partial class skilltableadded
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.9")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("OneToOneRelation.Models.Department", b =>
                {
                    b.Property<int>("DepartmentId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("DepartmentName")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("DepartmentId");

                    b.ToTable("departments");
                });

            modelBuilder.Entity("OneToOneRelation.Models.Employee", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("DelStatus")
                        .IsRequired()
                        .HasColumnType("nvarchar(1)");

                    b.Property<int>("DepartmentId")
                        .HasColumnType("int");

                    b.Property<string>("Designation")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("HireDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.HasKey("Id");

                    b.HasIndex("DepartmentId");

                    b.ToTable("employee");
                });

            modelBuilder.Entity("OneToOneRelation.Models.Skill", b =>
                {
                    b.Property<int>("skillId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("EmployeeId")
                        .HasColumnType("int");

                    b.Property<string>("skillName")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("skillId");

                    b.HasIndex("EmployeeId");

                    b.ToTable("Skill");
                });

            modelBuilder.Entity("OneToOneRelation.Models.Employee", b =>
                {
                    b.HasOne("OneToOneRelation.Models.Department", "dept")
                        .WithMany()
                        .HasForeignKey("DepartmentId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("dept");
                });

            modelBuilder.Entity("OneToOneRelation.Models.Skill", b =>
                {
                    b.HasOne("OneToOneRelation.Models.Employee", "emp")
                        .WithMany("Skills")
                        .HasForeignKey("EmployeeId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("emp");
                });

            modelBuilder.Entity("OneToOneRelation.Models.Employee", b =>
                {
                    b.Navigation("Skills");
                });
#pragma warning restore 612, 618
        }
    }
}