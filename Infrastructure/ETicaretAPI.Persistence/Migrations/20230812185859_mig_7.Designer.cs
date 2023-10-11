﻿// <auto-generated />
using System;
using ETicaretAPI.Persistence.Contexts;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace ETicaretAPI.Persistence.Migrations
{
    [DbContext(typeof(ETicaretAPIDbContext))]
    [Migration("20230812185859_mig_7")]
    partial class mig_7
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.8")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            NpgsqlModelBuilderExtensions.UseIdentityByDefaultColumns(modelBuilder);

            modelBuilder.Entity("ETicaretAPI.Domain.Entities.EntityCustomer", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<DateTime>("CreatedDate")
                        .HasColumnType("timestamp with time zone");

                    b.Property<string>("CustomerName")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<DateTime>("UpdatedDate")
                        .HasColumnType("timestamp with time zone");

                    b.HasKey("Id");

                    b.ToTable("Customers");
                });

            modelBuilder.Entity("ETicaretAPI.Domain.Entities.EntityOrder", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<string>("Address")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<DateTime>("CreatedDate")
                        .HasColumnType("timestamp with time zone");

                    b.Property<Guid>("CustomerId")
                        .HasColumnType("uuid");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<DateTime>("UpdatedDate")
                        .HasColumnType("timestamp with time zone");

                    b.HasKey("Id");

                    b.HasIndex("CustomerId");

                    b.ToTable("Orders");
                });

            modelBuilder.Entity("ETicaretAPI.Domain.Entities.EntityProduct", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<DateTime>("CreatedDate")
                        .HasColumnType("timestamp with time zone");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<float>("Price")
                        .HasColumnType("real");

                    b.Property<int>("Stock")
                        .HasColumnType("integer");

                    b.Property<DateTime>("UpdatedDate")
                        .HasColumnType("timestamp with time zone");

                    b.HasKey("Id");

                    b.ToTable("Products");
                });

            modelBuilder.Entity("ETicaretAPI.Domain.Entities.File", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<DateTime>("CreatedDate")
                        .HasColumnType("timestamp with time zone");

                    b.Property<string>("Discriminator")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("Storage")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("fileName")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("filePath")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.ToTable("Files");

                    b.HasDiscriminator<string>("Discriminator").HasValue("File");

                    b.UseTphMappingStrategy();
                });

            modelBuilder.Entity("EntityOrderEntityProduct", b =>
                {
                    b.Property<Guid>("OrdersId")
                        .HasColumnType("uuid");

                    b.Property<Guid>("ProductsId")
                        .HasColumnType("uuid");

                    b.HasKey("OrdersId", "ProductsId");

                    b.HasIndex("ProductsId");

                    b.ToTable("EntityOrderEntityProduct");
                });

            modelBuilder.Entity("EntityProductProductImagesFile", b =>
                {
                    b.Property<Guid>("ProductImageFilesId")
                        .HasColumnType("uuid");

                    b.Property<Guid>("ProductsId")
                        .HasColumnType("uuid");

                    b.HasKey("ProductImageFilesId", "ProductsId");

                    b.HasIndex("ProductsId");

                    b.ToTable("EntityProductProductImagesFile");
                });

            modelBuilder.Entity("ETicaretAPI.Domain.Entities.InvoiceFile", b =>
                {
                    b.HasBaseType("ETicaretAPI.Domain.Entities.File");

                    b.Property<decimal>("Price")
                        .HasColumnType("numeric");

                    b.HasDiscriminator().HasValue("InvoiceFile");
                });

            modelBuilder.Entity("ETicaretAPI.Domain.Entities.ProductImagesFile", b =>
                {
                    b.HasBaseType("ETicaretAPI.Domain.Entities.File");

                    b.HasDiscriminator().HasValue("ProductImagesFile");
                });

            modelBuilder.Entity("ETicaretAPI.Domain.Entities.EntityOrder", b =>
                {
                    b.HasOne("ETicaretAPI.Domain.Entities.EntityCustomer", "Customer")
                        .WithMany("Orders")
                        .HasForeignKey("CustomerId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Customer");
                });

            modelBuilder.Entity("EntityOrderEntityProduct", b =>
                {
                    b.HasOne("ETicaretAPI.Domain.Entities.EntityOrder", null)
                        .WithMany()
                        .HasForeignKey("OrdersId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("ETicaretAPI.Domain.Entities.EntityProduct", null)
                        .WithMany()
                        .HasForeignKey("ProductsId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("EntityProductProductImagesFile", b =>
                {
                    b.HasOne("ETicaretAPI.Domain.Entities.ProductImagesFile", null)
                        .WithMany()
                        .HasForeignKey("ProductImageFilesId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("ETicaretAPI.Domain.Entities.EntityProduct", null)
                        .WithMany()
                        .HasForeignKey("ProductsId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("ETicaretAPI.Domain.Entities.EntityCustomer", b =>
                {
                    b.Navigation("Orders");
                });
#pragma warning restore 612, 618
        }
    }
}
