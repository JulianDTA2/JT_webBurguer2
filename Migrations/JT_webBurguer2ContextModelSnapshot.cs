﻿// <auto-generated />
using System;
using JT_webBurguer2.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace JT_webBurguer2.Migrations
{
    [DbContext(typeof(JT_webBurguer2Context))]
    partial class JT_webBurguer2ContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.10")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("JT_webBurguer2.Models.Burguer", b =>
                {
                    b.Property<int>("BurguerId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("BurguerId"));

                    b.Property<string>("BurguerName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<decimal>("price")
                        .HasColumnType("decimal(18,2)");

                    b.Property<decimal>("priceCeiling")
                        .HasColumnType("decimal(18,2)");

                    b.Property<bool>("withCheese")
                        .HasColumnType("bit");

                    b.HasKey("BurguerId");

                    b.ToTable("Burguer");
                });

            modelBuilder.Entity("JT_webBurguer2.Models.Promos", b =>
                {
                    b.Property<int>("PromosId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("PromosId"));

                    b.Property<int>("BurguerId")
                        .HasColumnType("int");

                    b.Property<string>("Description")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("FechaPromo")
                        .HasColumnType("datetime2");

                    b.HasKey("PromosId");

                    b.HasIndex("BurguerId");

                    b.ToTable("Promos");
                });

            modelBuilder.Entity("JT_webBurguer2.Models.Promos", b =>
                {
                    b.HasOne("JT_webBurguer2.Models.Burguer", "Burguer")
                        .WithMany("Promos")
                        .HasForeignKey("BurguerId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Burguer");
                });

            modelBuilder.Entity("JT_webBurguer2.Models.Burguer", b =>
                {
                    b.Navigation("Promos");
                });
#pragma warning restore 612, 618
        }
    }
}
