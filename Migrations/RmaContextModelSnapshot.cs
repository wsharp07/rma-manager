using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using RmaManager.Data;

namespace RmaManager.Migrations
{
    [DbContext(typeof(RmaContext))]
    partial class RmaContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
            modelBuilder
                .HasAnnotation("ProductVersion", "1.0.1");

            modelBuilder.Entity("RmaManager.Models.HardwareType", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<DateTime>("CreatedAt");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasAnnotation("MaxLength", 50);

                    b.Property<DateTime>("UpdatedAt");

                    b.HasKey("Id");

                    b.ToTable("HardwareTypes");
                });

            modelBuilder.Entity("RmaManager.Models.Rma", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<DateTime>("CreatedAt");

                    b.Property<int?>("HardwareTypeId");

                    b.Property<string>("RmaNumber")
                        .IsRequired()
                        .HasAnnotation("MaxLength", 50);

                    b.Property<DateTime>("UpdatedAt");

                    b.HasKey("Id");

                    b.HasIndex("HardwareTypeId");

                    b.ToTable("Rmas");
                });

            modelBuilder.Entity("RmaManager.Models.Rma", b =>
                {
                    b.HasOne("RmaManager.Models.HardwareType", "HardwareType")
                        .WithMany("Rmas")
                        .HasForeignKey("HardwareTypeId");
                });
        }
    }
}
