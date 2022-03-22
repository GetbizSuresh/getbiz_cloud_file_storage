﻿// <auto-generated />
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using getbiz_cloud_file_storage_app.Getbiz_DbContext;

namespace getbiz_cloud_file_storage_app.Migrations
{
    [DbContext(typeof(CloudFileStorageAppDB_DbContext))]
    [Migration("20211211072039_init")]
    partial class init
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 64)
                .HasAnnotation("ProductVersion", "5.0.11");

            modelBuilder.Entity("getbiz_cloud_file_storage_app.Models.cloud_file_storage_app_login", b =>
                {
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<string>("Authkey")
                        .HasColumnType("longtext");

                    b.Property<bool>("block_app_access")
                        .HasColumnType("tinyint(1)");

                    b.Property<string>("customer_id")
                        .HasColumnType("longtext");

                    b.Property<string>("mobile_no")
                        .HasColumnType("longtext");

                    b.Property<string>("password")
                        .HasColumnType("longtext");

                    b.Property<string>("photo_id")
                        .HasColumnType("longtext");

                    b.Property<int>("storage_limit_in_mb")
                        .HasColumnType("int");

                    b.Property<int>("user_id")
                        .HasColumnType("int");

                    b.Property<string>("user_name")
                        .HasColumnType("longtext");

                    b.HasKey("id");

                    b.ToTable("cloud_file_storage_app_logins");
                });

            modelBuilder.Entity("getbiz_cloud_file_storage_app.Models.gps_table", b =>
                {
                    b.Property<int>("gps_coordinate_id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<string>("gps_coordinates")
                        .HasColumnType("longtext");

                    b.Property<string>("timestamp")
                        .HasColumnType("longtext");

                    b.HasKey("gps_coordinate_id");

                    b.ToTable("gps_tables");
                });

            modelBuilder.Entity("getbiz_cloud_file_storage_app.Models.userapp_folder_path", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<string>("cust_id")
                        .HasColumnType("longtext");

                    b.Property<string>("folder_path")
                        .HasColumnType("longtext");

                    b.Property<long>("user_id")
                        .HasColumnType("bigint");

                    b.HasKey("Id");

                    b.ToTable("userapp_folder_paths");
                });

            modelBuilder.Entity("getbiz_cloud_file_storage_app.Models.userapp_new_user_default_storage_limit", b =>
                {
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<string>("cust_id")
                        .HasColumnType("longtext");

                    b.Property<int>("new_user_storage_limit")
                        .HasColumnType("int");

                    b.Property<int>("user_id")
                        .HasColumnType("int");

                    b.HasKey("id");

                    b.ToTable("userapp_new_user_default_storage_limits");
                });
#pragma warning restore 612, 618
        }
    }
}