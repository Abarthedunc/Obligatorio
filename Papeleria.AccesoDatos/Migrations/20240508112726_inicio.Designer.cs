﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Papeleria.AccesoDatos.EntityFramework;

#nullable disable

namespace Papeleria.AccesoDatos.Migrations
{
    [DbContext(typeof(PapeleriaContext))]
    [Migration("20240508112726_inicio")]
    partial class inicio
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.4")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("Papeleria.LogicaNegocio.Entidades.Articulo", b =>
                {
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("id"));

                    b.Property<string>("codProveedor")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("descripcion")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("nombre")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<double>("precioActual")
                        .HasColumnType("float");

                    b.Property<int>("stock")
                        .HasColumnType("int");

                    b.HasKey("id");

                    b.ToTable("Articulo");
                });

            modelBuilder.Entity("Papeleria.LogicaNegocio.Entidades.Cliente", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ID"));

                    b.Property<double>("distancia")
                        .HasColumnType("float");

                    b.Property<string>("razonSocial")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("rut")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("ID");

                    b.ToTable("Clientes");
                });

            modelBuilder.Entity("Papeleria.LogicaNegocio.Entidades.Linea", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int?>("Pedidoid")
                        .HasColumnType("int");

                    b.Property<int>("articuloId")
                        .HasColumnType("int");

                    b.Property<int>("cantUnidades")
                        .HasColumnType("int");

                    b.Property<double>("precioUnitario")
                        .HasColumnType("float");

                    b.HasKey("Id");

                    b.HasIndex("Pedidoid");

                    b.HasIndex("articuloId");

                    b.ToTable("Lineas");
                });

            modelBuilder.Entity("Papeleria.LogicaNegocio.Entidades.Pedido", b =>
                {
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("id"));

                    b.Property<string>("Discriminator")
                        .IsRequired()
                        .HasMaxLength(13)
                        .HasColumnType("nvarchar(13)");

                    b.Property<int>("clienteID")
                        .HasColumnType("int");

                    b.Property<double>("descuento")
                        .HasColumnType("float");

                    b.Property<int>("estadoPedido")
                        .HasColumnType("int");

                    b.Property<DateTime>("fechaPedido")
                        .HasColumnType("datetime2");

                    b.Property<double>("precioTotal")
                        .HasColumnType("float");

                    b.HasKey("id");

                    b.HasIndex("clienteID");

                    b.ToTable("Pedidos");

                    b.HasDiscriminator<string>("Discriminator").HasValue("Pedido");

                    b.UseTphMappingStrategy();
                });

            modelBuilder.Entity("Papeleria.LogicaNegocio.Entidades.Usuario", b =>
                {
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("id"));

                    b.Property<string>("email")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.Property<bool>("esAdmin")
                        .HasColumnType("bit");

                    b.Property<string>("password")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("id");

                    b.HasIndex("email")
                        .IsUnique();

                    b.ToTable("Usuarios");
                });

            modelBuilder.Entity("Papeleria.LogicaNegocio.Entidades.PedidoComun", b =>
                {
                    b.HasBaseType("Papeleria.LogicaNegocio.Entidades.Pedido");

                    b.HasDiscriminator().HasValue("PedidoComun");
                });

            modelBuilder.Entity("Papeleria.LogicaNegocio.Entidades.PedidoExpress", b =>
                {
                    b.HasBaseType("Papeleria.LogicaNegocio.Entidades.Pedido");

                    b.HasDiscriminator().HasValue("PedidoExpress");
                });

            modelBuilder.Entity("Papeleria.LogicaNegocio.Entidades.Cliente", b =>
                {
                    b.OwnsOne("Papeleria.BusinessLogic.ValueObjects.NombreCompletoClientes", "nombreCompleto", b1 =>
                        {
                            b1.Property<int>("ClienteID")
                                .HasColumnType("int");

                            b1.Property<string>("apellido")
                                .IsRequired()
                                .HasColumnType("nvarchar(max)");

                            b1.Property<string>("nombre")
                                .IsRequired()
                                .HasColumnType("nvarchar(max)");

                            b1.HasKey("ClienteID");

                            b1.ToTable("Clientes");

                            b1.WithOwner()
                                .HasForeignKey("ClienteID");
                        });

                    b.OwnsOne("Papeleria.LogicaNegocio.ValueObjects.Direccion", "adress", b1 =>
                        {
                            b1.Property<int>("ClienteID")
                                .HasColumnType("int");

                            b1.Property<string>("calle")
                                .IsRequired()
                                .HasColumnType("nvarchar(max)");

                            b1.Property<string>("ciudad")
                                .IsRequired()
                                .HasColumnType("nvarchar(max)");

                            b1.Property<string>("numeroPuerta")
                                .IsRequired()
                                .HasColumnType("nvarchar(max)");

                            b1.HasKey("ClienteID");

                            b1.ToTable("Clientes");

                            b1.WithOwner()
                                .HasForeignKey("ClienteID");
                        });

                    b.Navigation("adress")
                        .IsRequired();

                    b.Navigation("nombreCompleto")
                        .IsRequired();
                });

            modelBuilder.Entity("Papeleria.LogicaNegocio.Entidades.Linea", b =>
                {
                    b.HasOne("Papeleria.LogicaNegocio.Entidades.Pedido", null)
                        .WithMany("_lineas")
                        .HasForeignKey("Pedidoid");

                    b.HasOne("Papeleria.LogicaNegocio.Entidades.Articulo", "articulo")
                        .WithMany()
                        .HasForeignKey("articuloId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("articulo");
                });

            modelBuilder.Entity("Papeleria.LogicaNegocio.Entidades.Pedido", b =>
                {
                    b.HasOne("Papeleria.LogicaNegocio.Entidades.Cliente", "cliente")
                        .WithMany()
                        .HasForeignKey("clienteID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("cliente");
                });

            modelBuilder.Entity("Papeleria.LogicaNegocio.Entidades.Usuario", b =>
                {
                    b.OwnsOne("Papeleria.BusinessLogic.ValueObjects.NombreCompleto", "nombreCompleto", b1 =>
                        {
                            b1.Property<int>("Usuarioid")
                                .HasColumnType("int");

                            b1.Property<string>("apellido")
                                .IsRequired()
                                .HasColumnType("nvarchar(max)");

                            b1.Property<string>("nombre")
                                .IsRequired()
                                .HasColumnType("nvarchar(max)");

                            b1.HasKey("Usuarioid");

                            b1.ToTable("Usuarios");

                            b1.WithOwner()
                                .HasForeignKey("Usuarioid");
                        });

                    b.Navigation("nombreCompleto")
                        .IsRequired();
                });

            modelBuilder.Entity("Papeleria.LogicaNegocio.Entidades.Pedido", b =>
                {
                    b.Navigation("_lineas");
                });
#pragma warning restore 612, 618
        }
    }
}
