using System;
using Microsoft.Data.Entity;
using Microsoft.Data.Entity.Infrastructure;
using Microsoft.Data.Entity.Metadata;
using Microsoft.Data.Entity.Migrations;
using RmaManager.Data;

namespace RmaManager.Migrations
{
    [DbContext(typeof(RmaContext))]
    [Migration("20151201023922_Initial")]
    partial class Initial
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.0-rc1-16348");

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

                    b.HasAnnotation("Relational:TableName", "HardwareTypes");
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

                    b.HasAnnotation("Relational:TableName", "Rmas");
                });

            modelBuilder.Entity("RmaManager.Models.Rma", b =>
                {
                    b.HasOne("RmaManager.Models.HardwareType")
                        .WithMany()
                        .HasForeignKey("HardwareTypeId");
                });
        }
    }
}
