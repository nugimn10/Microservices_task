﻿// <auto-generated />
using MerchantServices.Infrastructure.Presistences;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

namespace MerchantServices.Migrations
{
    [DbContext(typeof(dbContext))]
    [Migration("20200313090851_asfasdfasdf")]
    partial class asfasdfasdf
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn)
                .HasAnnotation("ProductVersion", "3.1.2")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            modelBuilder.Entity("MerchantServices.Domain.Models.MerchantD", b =>
                {
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

                    b.Property<string>("address")
                        .HasColumnType("text");

                    b.Property<long>("created_at")
                        .HasColumnType("bigint");

                    b.Property<string>("image")
                        .HasColumnType("text");

                    b.Property<string>("name")
                        .HasColumnType("text");

                    b.Property<double>("rating")
                        .HasColumnType("double precision");

                    b.Property<long>("updated_at")
                        .HasColumnType("bigint");

                    b.HasKey("id");

                    b.ToTable("Merchant");
                });
#pragma warning restore 612, 618
        }
    }
}
