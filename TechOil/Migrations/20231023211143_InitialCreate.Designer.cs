﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using TechOil.DataAccess;

#nullable disable

namespace TechOil.Migrations
{
    [DbContext(typeof(ApiContext))]
    [Migration("20231023211143_InitialCreate")]
    partial class InitialCreate
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.12")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("TechOil.Models.Proyecto", b =>
                {
                    b.Property<int?>("codProyecto")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int?>("codProyecto"));

                    b.Property<string>("direccion")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("estado")
                        .HasColumnType("int");

                    b.Property<string>("nombre")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("codProyecto");

                    b.ToTable("Proyectos");
                });

            modelBuilder.Entity("TechOil.Models.Servicio", b =>
                {
                    b.Property<int?>("codServicio")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int?>("codServicio"));

                    b.Property<string>("descr")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("estado")
                        .HasColumnType("bit");

                    b.Property<decimal>("valorHora")
                        .HasColumnType("decimal(18,2)");

                    b.HasKey("codServicio");

                    b.ToTable("Servicios");
                });

            modelBuilder.Entity("TechOil.Models.Trabajo", b =>
                {
                    b.Property<int>("codTrabajo")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("codTrabajo"));

                    b.Property<int>("cantHoras")
                        .HasColumnType("int");

                    b.Property<int?>("codProyecto")
                        .HasColumnType("int");

                    b.Property<int?>("codServicio")
                        .HasColumnType("int");

                    b.Property<decimal>("costo")
                        .HasColumnType("decimal(18,2)");

                    b.Property<DateTime>("fecha")
                        .HasColumnType("datetime2");

                    b.Property<int>("proyectocodProyecto")
                        .HasColumnType("int");

                    b.Property<int>("serviciocodServicio")
                        .HasColumnType("int");

                    b.Property<decimal>("valorHora")
                        .HasColumnType("decimal(18,2)");

                    b.HasKey("codTrabajo");

                    b.HasIndex("proyectocodProyecto");

                    b.HasIndex("serviciocodServicio");

                    b.ToTable("Trabajos");
                });

            modelBuilder.Entity("TechOil.Models.Usuario", b =>
                {
                    b.Property<int>("codUsuario")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("codUsuario"));

                    b.Property<string>("contrasena")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("dni")
                        .HasColumnType("int");

                    b.Property<string>("nombre")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("tipo")
                        .HasColumnType("int");

                    b.HasKey("codUsuario");

                    b.ToTable("Usuarios");
                });

            modelBuilder.Entity("TechOil.Models.Trabajo", b =>
                {
                    b.HasOne("TechOil.Models.Proyecto", "proyecto")
                        .WithMany()
                        .HasForeignKey("proyectocodProyecto")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("TechOil.Models.Servicio", "servicio")
                        .WithMany()
                        .HasForeignKey("serviciocodServicio")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("proyecto");

                    b.Navigation("servicio");
                });
#pragma warning restore 612, 618
        }
    }
}
