﻿// <auto-generated />
using System;
using Assurance.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace Assurance.Migrations
{
    [DbContext(typeof(AssuranceContext))]
    [Migration("20220602232534_init")]
    partial class init
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.17")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("Assurance.Models.EF.Branche", b =>
                {
                    b.Property<int>("IdBranche")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("CodeBranche")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("LibeleBranche")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("IdBranche");

                    b.ToTable("Branche");
                });

            modelBuilder.Entity("Assurance.Models.EF.Client", b =>
                {
                    b.Property<int>("IdClient")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Address")
                        .HasColumnType("nvarchar(max)");

                    b.Property<long>("CIN")
                        .HasColumnType("bigint");

                    b.Property<int?>("CodePostal")
                        .HasColumnType("int");

                    b.Property<string>("Country")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasMaxLength(30)
                        .HasColumnType("nvarchar(30)");

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasMaxLength(30)
                        .HasColumnType("nvarchar(30)");

                    b.Property<string>("Phone")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.HasKey("IdClient");

                    b.ToTable("Client");
                });

            modelBuilder.Entity("Assurance.Models.EF.Contrat", b =>
                {
                    b.Property<int>("IdContrat")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int?>("BrancheIdBranche")
                        .HasColumnType("int");

                    b.Property<int?>("ClientIdClient")
                        .HasColumnType("int");

                    b.Property<DateTime>("DateAffect")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("DateCreation")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("DateEcheance")
                        .HasColumnType("datetime2");

                    b.Property<int>("NContrat")
                        .HasColumnType("int");

                    b.HasKey("IdContrat");

                    b.HasIndex("BrancheIdBranche");

                    b.HasIndex("ClientIdClient");

                    b.ToTable("Contrat");
                });

            modelBuilder.Entity("Assurance.Models.EF.Garantie", b =>
                {
                    b.Property<int>("IdGarantie")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("CodeGarantie")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("LibeleGarantie")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("TypeGarantieIdTypeGa")
                        .HasColumnType("int");

                    b.HasKey("IdGarantie");

                    b.HasIndex("TypeGarantieIdTypeGa");

                    b.ToTable("Garantie");
                });

            modelBuilder.Entity("Assurance.Models.EF.TypeGarantie", b =>
                {
                    b.Property<int>("IdTypeGa")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("CodeTypeGa")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("LibeleTypeGa")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("IdTypeGa");

                    b.ToTable("TypeGarantie");

                    b.HasData(
                        new
                        {
                            IdTypeGa = 1,
                            CodeTypeGa = "OBLIGATOIR",
                            LibeleTypeGa = "Obligatoire"
                        },
                        new
                        {
                            IdTypeGa = 2,
                            CodeTypeGa = "FACULTATIF",
                            LibeleTypeGa = "Facultatif"
                        });
                });

            modelBuilder.Entity("BrancheGarantie", b =>
                {
                    b.Property<int>("BrancheIdBranche")
                        .HasColumnType("int");

                    b.Property<int>("GarantieIdGarantie")
                        .HasColumnType("int");

                    b.HasKey("BrancheIdBranche", "GarantieIdGarantie");

                    b.HasIndex("GarantieIdGarantie");

                    b.ToTable("BrancheGarantie");
                });

            modelBuilder.Entity("Assurance.Models.EF.Contrat", b =>
                {
                    b.HasOne("Assurance.Models.EF.Branche", "Branche")
                        .WithMany("Contrat")
                        .HasForeignKey("BrancheIdBranche");

                    b.HasOne("Assurance.Models.EF.Client", "Client")
                        .WithMany("Contrat")
                        .HasForeignKey("ClientIdClient");

                    b.Navigation("Branche");

                    b.Navigation("Client");
                });

            modelBuilder.Entity("Assurance.Models.EF.Garantie", b =>
                {
                    b.HasOne("Assurance.Models.EF.TypeGarantie", "TypeGarantie")
                        .WithMany()
                        .HasForeignKey("TypeGarantieIdTypeGa");

                    b.Navigation("TypeGarantie");
                });

            modelBuilder.Entity("BrancheGarantie", b =>
                {
                    b.HasOne("Assurance.Models.EF.Branche", null)
                        .WithMany()
                        .HasForeignKey("BrancheIdBranche")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Assurance.Models.EF.Garantie", null)
                        .WithMany()
                        .HasForeignKey("GarantieIdGarantie")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Assurance.Models.EF.Branche", b =>
                {
                    b.Navigation("Contrat");
                });

            modelBuilder.Entity("Assurance.Models.EF.Client", b =>
                {
                    b.Navigation("Contrat");
                });
#pragma warning restore 612, 618
        }
    }
}