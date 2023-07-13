﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using _3rd_TEAM_PROJECT.Data;

#nullable disable

namespace _3rd_TEAM_PROJECT.Migrations.MProcessDbcontextMigrations
{
    [DbContext(typeof(MProcessDbcontext))]
    [Migration("20230713040355_mprocess")]
    partial class mprocess
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.9")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("_3rd_TEAM_PROJECT.Models.Process.CreateLot", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("ActionCode")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("ActionTime")
                        .HasColumnType("datetime2");

                    b.Property<int>("Amount")
                        .HasColumnType("int");

                    b.Property<string>("Code")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("Constructor")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("HisNum")
                        .HasColumnType("int");

                    b.Property<string>("ItemCode")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("ItemId")
                        .HasColumnType("int");

                    b.Property<DateTime?>("ModDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("Modifier")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ProcessCode")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("ProcessId")
                        .HasColumnType("int");

                    b.Property<DateTime>("RegDate")
                        .HasColumnType("datetime2");

                    b.HasKey("Id");

                    b.HasIndex("Code")
                        .IsUnique();

                    b.HasIndex("ItemId");

                    b.HasIndex("ProcessId");

                    b.ToTable("T1_CreateLot");
                });

            modelBuilder.Entity("_3rd_TEAM_PROJECT.Models.Process.Equipment", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Code")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("Comment")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Constructor")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Event")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime?>("ModDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("Modifier")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("RegDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("Status")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("Code")
                        .IsUnique();

                    b.ToTable("T1_Equipment");
                });

            modelBuilder.Entity("_3rd_TEAM_PROJECT.Models.Process.Factory", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Code")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("Constructor")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime?>("ModDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("Modifier")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("RegDate")
                        .HasColumnType("datetime2");

                    b.HasKey("Id");

                    b.HasIndex("Code")
                        .IsUnique();

                    b.ToTable("T1_Factory");
                });

            modelBuilder.Entity("_3rd_TEAM_PROJECT.Models.Process.Item", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Code")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("Constructor")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime?>("ModDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("Modifier")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("RegDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("Type")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("Code")
                        .IsUnique();

                    b.ToTable("T1_Item");
                });

            modelBuilder.Entity("_3rd_TEAM_PROJECT.Models.Process.LotHis", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int?>("CreateLotId")
                        .HasColumnType("int");

                    b.Property<DateTime?>("ModDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("Modifier")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("CreateLotId");

                    b.ToTable("T1_LotHis");
                });

            modelBuilder.Entity("_3rd_TEAM_PROJECT.Models.Process.MProcess", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Code")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("Coment")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Constructor")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("EquipCode")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("EquipmentId")
                        .HasColumnType("int");

                    b.Property<int?>("FactoriesId")
                        .HasColumnType("int");

                    b.Property<DateTime?>("ModDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("Modifier")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("RegDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("StockUnit1")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("StockUnit2")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("Code")
                        .IsUnique();

                    b.HasIndex("EquipmentId");

                    b.HasIndex("FactoriesId");

                    b.ToTable("T1_MProcess");
                });

            modelBuilder.Entity("_3rd_TEAM_PROJECT.Models.WareHouse.InBound", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<long>("Id"));

                    b.Property<int>("Amount")
                        .HasColumnType("int");

                    b.Property<string>("Contact")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Product")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("RegDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("Vendor")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("WareHouseId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("WareHouseId");

                    b.ToTable("T1_InBound");
                });

            modelBuilder.Entity("_3rd_TEAM_PROJECT.Models.WareHouse.OutBound", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<long>("Id"));

                    b.Property<int>("Amount")
                        .HasColumnType("int");

                    b.Property<string>("Contact")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("MProcessId")
                        .HasColumnType("int");

                    b.Property<string>("Product")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("RegDate")
                        .HasColumnType("datetime2");

                    b.Property<int?>("WareHouseId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("MProcessId");

                    b.HasIndex("WareHouseId");

                    b.ToTable("T1_OutBound");
                });

            modelBuilder.Entity("_3rd_TEAM_PROJECT.Models.WareHouse.WareHouse", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("Amount")
                        .HasColumnType("int");

                    b.Property<string>("Item")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Product")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("Id");

                    b.HasIndex("Product")
                        .IsUnique();

                    b.ToTable("T1_WareHouse");
                });

            modelBuilder.Entity("_3rd_TEAM_PROJECT.Models.Process.CreateLot", b =>
                {
                    b.HasOne("_3rd_TEAM_PROJECT.Models.Process.Item", "Item")
                        .WithMany()
                        .HasForeignKey("ItemId");

                    b.HasOne("_3rd_TEAM_PROJECT.Models.Process.MProcess", "Process")
                        .WithMany()
                        .HasForeignKey("ProcessId");

                    b.Navigation("Item");

                    b.Navigation("Process");
                });

            modelBuilder.Entity("_3rd_TEAM_PROJECT.Models.Process.LotHis", b =>
                {
                    b.HasOne("_3rd_TEAM_PROJECT.Models.Process.CreateLot", "CreateLot")
                        .WithMany()
                        .HasForeignKey("CreateLotId");

                    b.Navigation("CreateLot");
                });

            modelBuilder.Entity("_3rd_TEAM_PROJECT.Models.Process.MProcess", b =>
                {
                    b.HasOne("_3rd_TEAM_PROJECT.Models.Process.Equipment", "Equipment")
                        .WithMany()
                        .HasForeignKey("EquipmentId");

                    b.HasOne("_3rd_TEAM_PROJECT.Models.Process.Factory", "Factories")
                        .WithMany()
                        .HasForeignKey("FactoriesId");

                    b.Navigation("Equipment");

                    b.Navigation("Factories");
                });

            modelBuilder.Entity("_3rd_TEAM_PROJECT.Models.WareHouse.InBound", b =>
                {
                    b.HasOne("_3rd_TEAM_PROJECT.Models.WareHouse.WareHouse", "WareHouse")
                        .WithMany()
                        .HasForeignKey("WareHouseId");

                    b.Navigation("WareHouse");
                });

            modelBuilder.Entity("_3rd_TEAM_PROJECT.Models.WareHouse.OutBound", b =>
                {
                    b.HasOne("_3rd_TEAM_PROJECT.Models.Process.MProcess", "MProcess")
                        .WithMany()
                        .HasForeignKey("MProcessId");

                    b.HasOne("_3rd_TEAM_PROJECT.Models.WareHouse.WareHouse", "WareHouse")
                        .WithMany()
                        .HasForeignKey("WareHouseId");

                    b.Navigation("MProcess");

                    b.Navigation("WareHouse");
                });
#pragma warning restore 612, 618
        }
    }
}
