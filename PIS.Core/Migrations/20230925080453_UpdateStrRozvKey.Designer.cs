﻿// <auto-generated />
using ECommerce.Api.Core.Database;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace PIS.Core.Migrations
{
    [DbContext(typeof(AppDbContext))]
    [Migration("20230925080453_UpdateStrRozvKey")]
    partial class UpdateStrRozvKey
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.9")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("ECommerce.Api.Core.Database.Entities.GLPR", b =>
                {
                    b.Property<string>("CdPr")
                        .HasColumnType("nvarchar(5)");

                    b.Property<int>("CdTp")
                        .HasColumnType("int");

                    b.Property<string>("NmPr")
                        .IsRequired()
                        .HasColumnType("nvarchar(150)");

                    b.HasKey("CdPr");

                    b.HasIndex("CdTp");

                    b.ToTable("GLPRs");
                });

            modelBuilder.Entity("ECommerce.Api.Core.Database.Entities.Spec", b =>
                {
                    b.Property<string>("CdSb")
                        .HasColumnType("nvarchar(5)");

                    b.Property<string>("CdKp")
                        .HasColumnType("nvarchar(5)");

                    b.Property<int>("QtyKp")
                        .HasColumnType("int");

                    b.HasKey("CdSb", "CdKp");

                    b.HasIndex("CdKp");

                    b.ToTable("Specs");
                });

            modelBuilder.Entity("ECommerce.Api.Core.Database.Entities.TypePr", b =>
                {
                    b.Property<int>("CdTp")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("CdTp"));

                    b.Property<string>("NmTp")
                        .IsRequired()
                        .HasColumnType("nvarchar(150)");

                    b.HasKey("CdTp");

                    b.ToTable("TypePrs");

                    b.HasData(
                        new
                        {
                            CdTp = 1,
                            NmTp = "виріб"
                        },
                        new
                        {
                            CdTp = 2,
                            NmTp = "вузол (агрегат, збірка)"
                        },
                        new
                        {
                            CdTp = 3,
                            NmTp = "деталь власного виробництва"
                        },
                        new
                        {
                            CdTp = 4,
                            NmTp = "покупний (комплектувальний) предмет"
                        });
                });

            modelBuilder.Entity("PIS.Core.Database.Entities.StrRozv", b =>
                {
                    b.Property<string>("CdKp")
                        .HasColumnType("nvarchar(5)");

                    b.Property<string>("CdSb")
                        .HasColumnType("nvarchar(5)");

                    b.Property<string>("CdVyr")
                        .HasColumnType("nvarchar(5)");

                    b.Property<int>("RivNb")
                        .HasColumnType("int");

                    b.Property<int>("QtyKp")
                        .HasColumnType("int");

                    b.HasKey("CdKp", "CdSb", "CdVyr", "RivNb");

                    b.HasIndex("CdSb");

                    b.HasIndex("CdVyr");

                    b.ToTable("StrRozvs");
                });

            modelBuilder.Entity("ECommerce.Api.Core.Database.Entities.GLPR", b =>
                {
                    b.HasOne("ECommerce.Api.Core.Database.Entities.TypePr", "Tp")
                        .WithMany()
                        .HasForeignKey("CdTp")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.Navigation("Tp");
                });

            modelBuilder.Entity("ECommerce.Api.Core.Database.Entities.Spec", b =>
                {
                    b.HasOne("ECommerce.Api.Core.Database.Entities.GLPR", "Kp")
                        .WithMany()
                        .HasForeignKey("CdKp")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.HasOne("ECommerce.Api.Core.Database.Entities.GLPR", "Sb")
                        .WithMany()
                        .HasForeignKey("CdSb")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.Navigation("Kp");

                    b.Navigation("Sb");
                });

            modelBuilder.Entity("PIS.Core.Database.Entities.StrRozv", b =>
                {
                    b.HasOne("ECommerce.Api.Core.Database.Entities.GLPR", "Kp")
                        .WithMany()
                        .HasForeignKey("CdKp")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.HasOne("ECommerce.Api.Core.Database.Entities.GLPR", "Sb")
                        .WithMany()
                        .HasForeignKey("CdSb")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.HasOne("ECommerce.Api.Core.Database.Entities.GLPR", "Vyr")
                        .WithMany()
                        .HasForeignKey("CdVyr")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.Navigation("Kp");

                    b.Navigation("Sb");

                    b.Navigation("Vyr");
                });
#pragma warning restore 612, 618
        }
    }
}
