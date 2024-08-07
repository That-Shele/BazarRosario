﻿// <auto-generated />
using System;
using BazarApi.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace BazarApi.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    partial class ApplicationDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.7")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("BazarApi.Models.Facturas", b =>
                {
                    b.Property<int>("CodFac")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("CodFac"));

                    b.Property<DateTime>("Fecha")
                        .HasColumnType("datetime2");

                    b.Property<string>("NombreUsu")
                        .IsRequired()
                        .HasMaxLength(80)
                        .HasColumnType("nvarchar(80)");

                    b.Property<decimal>("Pago")
                        .HasColumnType("decimal(18,2)");

                    b.HasKey("CodFac");

                    b.ToTable("FACTURAS");
                });

            modelBuilder.Entity("BazarApi.Models.FacturasDetalle", b =>
                {
                    b.Property<int>("Cantidad")
                        .HasColumnType("int");

                    b.Property<int>("CodFac")
                        .HasColumnType("int");

                    b.Property<string>("NombreProdu")
                        .IsRequired()
                        .HasMaxLength(250)
                        .HasColumnType("nvarchar(250)");

                    b.Property<string>("NombreUsu")
                        .IsRequired()
                        .HasMaxLength(80)
                        .HasColumnType("nvarchar(80)");

                    b.Property<decimal>("Pago")
                        .HasColumnType("decimal(18,2)");

                    b.ToTable("FACTURAS_DETALLE");
                });

            modelBuilder.Entity("BazarApi.Models.Productos", b =>
                {
                    b.Property<int>("ProduId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ProduId"));

                    b.Property<string>("Categoria")
                        .IsRequired()
                        .HasMaxLength(18)
                        .HasColumnType("nvarchar(18)");

                    b.Property<byte[]>("ImgProdu")
                        .IsRequired()
                        .HasColumnType("varbinary(max)");

                    b.Property<bool>("IsOferta")
                        .HasColumnType("bit");

                    b.Property<string>("NombreProdu")
                        .IsRequired()
                        .HasMaxLength(250)
                        .HasColumnType("nvarchar(250)");

                    b.Property<decimal>("Precio")
                        .HasColumnType("decimal(18,2)");

                    b.Property<int>("Stock")
                        .HasColumnType("int");

                    b.Property<string>("TipoProdu")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.HasKey("ProduId");

                    b.ToTable("PRODUCTOS");
                });

            modelBuilder.Entity("BazarApi.Models.Usuarios", b =>
                {
                    b.Property<int>("UsuId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("UsuId"));

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasMaxLength(90)
                        .HasColumnType("nvarchar(90)");

                    b.Property<bool?>("IsAdmin")
                        .IsRequired()
                        .HasColumnType("bit");

                    b.Property<string>("NombreUsu")
                        .IsRequired()
                        .HasMaxLength(80)
                        .HasColumnType("nvarchar(80)");

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.HasKey("UsuId");

                    b.ToTable("USUARIOS");
                });
#pragma warning restore 612, 618
        }
    }
}
