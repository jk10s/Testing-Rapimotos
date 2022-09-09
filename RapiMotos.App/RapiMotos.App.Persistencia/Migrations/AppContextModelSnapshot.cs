﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using RapiMotos.App.Persistencia;

namespace RapiMotos.App.Persistencia.Migrations
{
    [DbContext(typeof(AppContext))]
    partial class AppContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .UseIdentityColumns()
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.0");

            modelBuilder.Entity("RapiMotos.App.Dominio.HistorialCliente", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .UseIdentityColumn();

                    b.HasKey("Id");

                    b.ToTable("HistorialCliente");
                });

            modelBuilder.Entity("RapiMotos.App.Dominio.HitorialTecnico", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .UseIdentityColumn();

                    b.Property<string>("DescripcionMantenimiento")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("FechaHora")
                        .HasColumnType("datetime2");

                    b.HasKey("Id");

                    b.ToTable("HitorialTecnico");
                });

            modelBuilder.Entity("RapiMotos.App.Dominio.Persona", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .UseIdentityColumn();

                    b.Property<string>("Apellidos")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Discriminator")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Nombre")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("NumeroTelefono")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Persona");

                    b.HasDiscriminator<string>("Discriminator").HasValue("Persona");
                });

            modelBuilder.Entity("RapiMotos.App.Dominio.Servicio", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .UseIdentityColumn();

                    b.Property<DateTime>("FechaHora")
                        .HasColumnType("datetime2");

                    b.Property<int?>("TecnicoId")
                        .HasColumnType("int");

                    b.Property<int?>("TipoServicioId")
                        .HasColumnType("int");

                    b.Property<float>("Valor")
                        .HasColumnType("real");

                    b.HasKey("Id");

                    b.HasIndex("TecnicoId");

                    b.HasIndex("TipoServicioId");

                    b.ToTable("Servicio");
                });

            modelBuilder.Entity("RapiMotos.App.Dominio.TipoServicio", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .UseIdentityColumn();

                    b.Property<string>("Servicio")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("precio")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.ToTable("TipoServicio");
                });

            modelBuilder.Entity("RapiMotos.App.Dominio.Administrador", b =>
                {
                    b.HasBaseType("RapiMotos.App.Dominio.Persona");

                    b.Property<string>("correo")
                        .HasColumnType("nvarchar(max)");

                    b.HasDiscriminator().HasValue("Administrador");
                });

            modelBuilder.Entity("RapiMotos.App.Dominio.Cliente", b =>
                {
                    b.HasBaseType("RapiMotos.App.Dominio.Persona");

                    b.Property<string>("Direccion")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("HistorialClienteId")
                        .HasColumnType("int");

                    b.Property<float>("Latitud")
                        .HasColumnType("real");

                    b.Property<float>("Longitud")
                        .HasColumnType("real");

                    b.Property<int?>("ServicioId")
                        .HasColumnType("int");

                    b.HasIndex("HistorialClienteId");

                    b.HasIndex("ServicioId");

                    b.HasDiscriminator().HasValue("Cliente");
                });

            modelBuilder.Entity("RapiMotos.App.Dominio.Tecnico", b =>
                {
                    b.HasBaseType("RapiMotos.App.Dominio.Persona");

                    b.Property<string>("Disponibilidad")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Registro")
                        .HasColumnType("int");

                    b.HasDiscriminator().HasValue("Tecnico");
                });

            modelBuilder.Entity("RapiMotos.App.Dominio.Servicio", b =>
                {
                    b.HasOne("RapiMotos.App.Dominio.Tecnico", "Tecnico")
                        .WithMany()
                        .HasForeignKey("TecnicoId");

                    b.HasOne("RapiMotos.App.Dominio.TipoServicio", "TipoServicio")
                        .WithMany()
                        .HasForeignKey("TipoServicioId");

                    b.Navigation("Tecnico");

                    b.Navigation("TipoServicio");
                });

            modelBuilder.Entity("RapiMotos.App.Dominio.Cliente", b =>
                {
                    b.HasOne("RapiMotos.App.Dominio.HistorialCliente", "HistorialCliente")
                        .WithMany()
                        .HasForeignKey("HistorialClienteId");

                    b.HasOne("RapiMotos.App.Dominio.Servicio", "Servicio")
                        .WithMany()
                        .HasForeignKey("ServicioId");

                    b.Navigation("HistorialCliente");

                    b.Navigation("Servicio");
                });
#pragma warning restore 612, 618
        }
    }
}
