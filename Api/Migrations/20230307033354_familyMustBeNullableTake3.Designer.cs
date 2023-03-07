﻿// <auto-generated />
using System;
using Domain.EFSetup;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace Api.Migrations
{
    [DbContext(typeof(EFDbContext))]
    [Migration("20230307033354_familyMustBeNullableTake3")]
    partial class familyMustBeNullableTake3
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.3")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            NpgsqlModelBuilderExtensions.UseIdentityByDefaultColumns(modelBuilder);

            modelBuilder.Entity("Domain.EFSetup.Entities.FamilyEntity", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("timestamp with time zone");

                    b.Property<string>("Description")
                        .HasColumnType("text");

                    b.Property<bool>("Enabled")
                        .HasColumnType("boolean");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<Guid>("OwnerId")
                        .HasColumnType("uuid");

                    b.Property<DateTime>("UpdatedAt")
                        .HasColumnType("timestamp with time zone");

                    b.HasKey("Id");

                    b.HasIndex("OwnerId");

                    b.ToTable("Family");
                });

            modelBuilder.Entity("Domain.EFSetup.Entities.LocationEntity", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("timestamp with time zone");

                    b.Property<string>("Latitude")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("Longitude")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<DateTime>("UpdatedAt")
                        .HasColumnType("timestamp with time zone");

                    b.HasKey("Id");

                    b.ToTable("Location");
                });

            modelBuilder.Entity("Domain.EFSetup.Entities.MarketEntity", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("timestamp with time zone");

                    b.Property<string>("Description")
                        .HasColumnType("text");

                    b.Property<bool>("Enabled")
                        .HasColumnType("boolean");

                    b.Property<bool>("IsWholeSale")
                        .HasColumnType("boolean");

                    b.Property<Guid>("LocationId")
                        .HasColumnType("uuid");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<DateTime>("UpdatedAt")
                        .HasColumnType("timestamp with time zone");

                    b.HasKey("Id");

                    b.HasIndex("LocationId")
                        .IsUnique();

                    b.ToTable("Market");
                });

            modelBuilder.Entity("Domain.EFSetup.Entities.MergedProductEntity", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("timestamp with time zone");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<DateTime>("UpdatedAt")
                        .HasColumnType("timestamp with time zone");

                    b.HasKey("Id");

                    b.ToTable("MergedProduct");
                });

            modelBuilder.Entity("Domain.EFSetup.Entities.ProductEntity", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<string>("BarCode")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("timestamp with time zone");

                    b.Property<string>("Description")
                        .HasColumnType("text");

                    b.Property<bool>("Enabled")
                        .HasColumnType("boolean");

                    b.Property<string>("ImgUrl")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<Guid>("MergedProductId")
                        .HasColumnType("uuid");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<DateTime>("UpdatedAt")
                        .HasColumnType("timestamp with time zone");

                    b.HasKey("Id");

                    b.HasIndex("BarCode")
                        .IsUnique();

                    b.HasIndex("MergedProductId");

                    b.ToTable("Product");
                });

            modelBuilder.Entity("Domain.EFSetup.Entities.ShoppingEventEntity", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("timestamp with time zone");

                    b.Property<Guid>("FamilyId")
                        .HasColumnType("uuid");

                    b.Property<Guid>("MarketId")
                        .HasColumnType("uuid");

                    b.Property<DateTime>("StartDateTime")
                        .HasColumnType("timestamp with time zone");

                    b.Property<Guid>("StartedById")
                        .HasColumnType("uuid");

                    b.Property<DateTime>("UpdatedAt")
                        .HasColumnType("timestamp with time zone");

                    b.HasKey("Id");

                    b.HasIndex("FamilyId");

                    b.HasIndex("MarketId");

                    b.HasIndex("StartedById");

                    b.ToTable("ShoppingEvent");
                });

            modelBuilder.Entity("Domain.EFSetup.Entities.ShoppingListEntity", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("timestamp with time zone");

                    b.Property<double>("FaceValue")
                        .HasColumnType("double precision");

                    b.Property<bool>("Grabbed")
                        .HasColumnType("boolean");

                    b.Property<int>("MinWholesaleQuantity")
                        .HasColumnType("integer");

                    b.Property<Guid>("ProductId")
                        .HasColumnType("uuid");

                    b.Property<int>("Quantity")
                        .HasColumnType("integer");

                    b.Property<Guid>("ShoppingEventId")
                        .HasColumnType("uuid");

                    b.Property<DateTime>("UpdatedAt")
                        .HasColumnType("timestamp with time zone");

                    b.Property<double>("WholesaleFaceValue")
                        .HasColumnType("double precision");

                    b.HasKey("Id");

                    b.HasIndex("ProductId");

                    b.HasIndex("ShoppingEventId");

                    b.ToTable("ShoppingList");
                });

            modelBuilder.Entity("Domain.EFSetup.Entities.UserEntity", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("timestamp with time zone");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<bool>("Enabled")
                        .HasColumnType("boolean");

                    b.Property<Guid?>("FamilyId")
                        .HasColumnType("uuid");

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("SocialSecurityNumber")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<DateTime>("UpdatedAt")
                        .HasColumnType("timestamp with time zone");

                    b.HasKey("Id");

                    b.HasIndex("FamilyId");

                    b.ToTable("User");
                });

            modelBuilder.Entity("Domain.EFSetup.Entities.FamilyEntity", b =>
                {
                    b.HasOne("Domain.EFSetup.Entities.UserEntity", "Owner")
                        .WithMany()
                        .HasForeignKey("OwnerId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Owner");
                });

            modelBuilder.Entity("Domain.EFSetup.Entities.MarketEntity", b =>
                {
                    b.HasOne("Domain.EFSetup.Entities.LocationEntity", "Location")
                        .WithOne("Market")
                        .HasForeignKey("Domain.EFSetup.Entities.MarketEntity", "LocationId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Location");
                });

            modelBuilder.Entity("Domain.EFSetup.Entities.ProductEntity", b =>
                {
                    b.HasOne("Domain.EFSetup.Entities.MergedProductEntity", "MergedProduct")
                        .WithMany("Products")
                        .HasForeignKey("MergedProductId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("MergedProduct");
                });

            modelBuilder.Entity("Domain.EFSetup.Entities.ShoppingEventEntity", b =>
                {
                    b.HasOne("Domain.EFSetup.Entities.FamilyEntity", "Family")
                        .WithMany("ShoppingEventEntities")
                        .HasForeignKey("FamilyId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Domain.EFSetup.Entities.MarketEntity", "Market")
                        .WithMany("ShoppingEventEntities")
                        .HasForeignKey("MarketId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Domain.EFSetup.Entities.UserEntity", "StartedBy")
                        .WithMany("ShoppingEventEntities")
                        .HasForeignKey("StartedById")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Family");

                    b.Navigation("Market");

                    b.Navigation("StartedBy");
                });

            modelBuilder.Entity("Domain.EFSetup.Entities.ShoppingListEntity", b =>
                {
                    b.HasOne("Domain.EFSetup.Entities.ProductEntity", "Product")
                        .WithMany("ShoppingList")
                        .HasForeignKey("ProductId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Domain.EFSetup.Entities.ShoppingEventEntity", "ShoppingEvent")
                        .WithMany("ShoppingListEntities")
                        .HasForeignKey("ShoppingEventId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Product");

                    b.Navigation("ShoppingEvent");
                });

            modelBuilder.Entity("Domain.EFSetup.Entities.UserEntity", b =>
                {
                    b.HasOne("Domain.EFSetup.Entities.FamilyEntity", "FamilyEntity")
                        .WithMany("Members")
                        .HasForeignKey("FamilyId");

                    b.Navigation("FamilyEntity");
                });

            modelBuilder.Entity("Domain.EFSetup.Entities.FamilyEntity", b =>
                {
                    b.Navigation("Members");

                    b.Navigation("ShoppingEventEntities");
                });

            modelBuilder.Entity("Domain.EFSetup.Entities.LocationEntity", b =>
                {
                    b.Navigation("Market")
                        .IsRequired();
                });

            modelBuilder.Entity("Domain.EFSetup.Entities.MarketEntity", b =>
                {
                    b.Navigation("ShoppingEventEntities");
                });

            modelBuilder.Entity("Domain.EFSetup.Entities.MergedProductEntity", b =>
                {
                    b.Navigation("Products");
                });

            modelBuilder.Entity("Domain.EFSetup.Entities.ProductEntity", b =>
                {
                    b.Navigation("ShoppingList");
                });

            modelBuilder.Entity("Domain.EFSetup.Entities.ShoppingEventEntity", b =>
                {
                    b.Navigation("ShoppingListEntities");
                });

            modelBuilder.Entity("Domain.EFSetup.Entities.UserEntity", b =>
                {
                    b.Navigation("ShoppingEventEntities");
                });
#pragma warning restore 612, 618
        }
    }
}
