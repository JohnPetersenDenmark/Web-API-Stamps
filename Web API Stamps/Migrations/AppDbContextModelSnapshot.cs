﻿// <auto-generated />
using System;
using API_upload.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace Web_API_Stamps.Migrations
{
    [DbContext(typeof(AppDbContext))]
    partial class AppDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "9.0.4")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("API_upload.Models.ImageData", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<byte[]>("FileData")
                        .IsRequired()
                        .HasColumnType("varbinary(max)");

                    b.Property<int>("StampId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.ToTable("ImagesData");
                });

            modelBuilder.Entity("API_upload.Models.Stamp", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("AdditionalNotes")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("CatalogNumber")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Color")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Condition")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ContentType")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Country")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("FaceValue")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("FileName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("FilePath")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("HistoricalSignificance")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PrintMethod")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Provenance")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Rarity")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Size")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("SpecialFeatures")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("StampCategoryId")
                        .HasColumnType("int");

                    b.Property<string>("StampName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("StampSeries")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ThumbnailDataBase64")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime?>("UploadedAt")
                        .HasColumnType("datetime2");

                    b.Property<string>("Watermark")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("YearOfIssue")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("StampCategoryId");

                    b.ToTable("Stamps");
                });

            modelBuilder.Entity("API_upload.Models.ThumbnailData", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<byte[]>("FileData")
                        .IsRequired()
                        .HasColumnType("varbinary(max)");

                    b.Property<int>("StampId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.ToTable("ThumbnailsData");
                });

            modelBuilder.Entity("Web_API_Stamps.Models.StampCategory", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Category")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Categories");
                });

            modelBuilder.Entity("API_upload.Models.Stamp", b =>
                {
                    b.HasOne("Web_API_Stamps.Models.StampCategory", "StampCategory")
                        .WithMany()
                        .HasForeignKey("StampCategoryId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("StampCategory");
                });
#pragma warning restore 612, 618
        }
    }
}
