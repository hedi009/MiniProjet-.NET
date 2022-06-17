﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using miniProjet.Models;

#nullable disable

namespace miniProjet.Migrations
{
    [DbContext(typeof(EmployeContext))]
    [Migration("20220601234942_InitialCreate")]
    partial class InitialCreate
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.5")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("miniProjet.Models.Employe", b =>
                {
                    b.Property<int>("EmployeId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("EmployeId"), 1L, 1);

                    b.Property<int>("Age")
                        .HasColumnType("int");

                    b.Property<DateTime>("BirthDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("EmployeName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("EntrepriseID")
                        .HasColumnType("int");

                    b.HasKey("EmployeId");

                    b.HasIndex("EntrepriseID");

                    b.ToTable("Employes");
                });

            modelBuilder.Entity("miniProjet.Models.Entreprise", b =>
                {
                    b.Property<int>("EntrepriseID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("EntrepriseID"), 1L, 1);

                    b.Property<string>("EntrepriseAdress")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("EntrepriseName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("EntrepriseID");

                    b.ToTable("Entreprises");
                });

            modelBuilder.Entity("miniProjet.Models.Employe", b =>
                {
                    b.HasOne("miniProjet.Models.Entreprise", "Entreprise")
                        .WithMany("Employes")
                        .HasForeignKey("EntrepriseID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Entreprise");
                });

            modelBuilder.Entity("miniProjet.Models.Entreprise", b =>
                {
                    b.Navigation("Employes");
                });
#pragma warning restore 612, 618
        }
    }
}