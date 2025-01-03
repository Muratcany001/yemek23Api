﻿// <auto-generated />
using ApiYemek23.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace ApiYemek23.Migrations
{
    [DbContext(typeof(Context))]
    [Migration("20241217201543_mig_6")]
    partial class mig_6
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.10")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("ApiYemek23.Entities.AppEntities.Restaurant", b =>
                {
                    b.Property<int>("Restaurant_Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Restaurant_Id"));

                    b.Property<string>("Restaurant_Coordinates")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Restaurant_Location")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Restaurant_Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Restaurant_Phone_Number")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Restaurant_Rating")
                        .HasColumnType("int");

                    b.Property<string>("Restaurant_code")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Restaurant_Id");

                    b.ToTable("Restaurants");
                });

            modelBuilder.Entity("ApiYemek23.Entities.AppEntities.User", b =>
                {
                    b.Property<int>("User_Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("User_Id"));

                    b.Property<string>("FavoriteRestaurantIds")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("User_Email")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("User_Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("User_Password")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("User_Id");

                    b.ToTable("Users");
                });
#pragma warning restore 612, 618
        }
    }
}
