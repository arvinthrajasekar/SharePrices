﻿// <auto-generated />
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using SharePrices.Models;

namespace SharePrices.Migrations
{
    [DbContext(typeof(ShareDbContext))]
    partial class ShareDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "3.1.24")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("SharePrices.Models.Shares", b =>
                {
                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(450)");

                    b.Property<double>("Price")
                        .HasColumnType("float");

                    b.HasKey("Name");

                    b.ToTable("Share");

                    b.HasData(
                        new
                        {
                            Name = "3M India Ltd",
                            Price = 21145.0
                        },
                        new
                        {
                            Name = "Aarti Drugs Ltd",
                            Price = 519.0
                        },
                        new
                        {
                            Name = "Tata Power",
                            Price = 277.80000000000001
                        },
                        new
                        {
                            Name = "HDFC Bank",
                            Price = 1516.75
                        },
                        new
                        {
                            Name = "Zee Entertainment",
                            Price = 284.75
                        });
                });
#pragma warning restore 612, 618
        }
    }
}
