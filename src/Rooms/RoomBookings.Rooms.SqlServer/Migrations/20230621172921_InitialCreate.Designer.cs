﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using RoomBookings.Rooms.SqlServer;

#nullable disable

namespace RoomBookings.Rooms.SqlServer.Migrations
{
    [DbContext(typeof(RoomsDbContext))]
    [Migration("20230621172921_InitialCreate")]
    partial class InitialCreate
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.7")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("RoomBookings.Rooms.Domain.Booking", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<bool>("IsCancelled")
                        .HasColumnType("bit");

                    b.Property<int>("RoomId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("RoomId");

                    b.ToTable("Booking");
                });

            modelBuilder.Entity("RoomBookings.Rooms.Domain.Room", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<double>("DailyPrice")
                        .HasColumnType("float");

                    b.Property<int?>("MaximumBookingDurationDays")
                        .HasColumnType("int");

                    b.Property<int>("MinimumBookingDurationDays")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.ToTable("Rooms");
                });

            modelBuilder.Entity("RoomBookings.Rooms.Domain.Booking", b =>
                {
                    b.HasOne("RoomBookings.Rooms.Domain.Room", null)
                        .WithMany("Bookings")
                        .HasForeignKey("RoomId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("RoomBookings.Rooms.Domain.Room", b =>
                {
                    b.OwnsOne("RoomBookings.Rooms.Domain.ValueObjects.Address", "Address", b1 =>
                        {
                            b1.Property<int>("RoomId")
                                .HasColumnType("int");

                            b1.Property<string>("Address1")
                                .IsRequired()
                                .HasColumnType("nvarchar(max)");

                            b1.Property<string>("City")
                                .IsRequired()
                                .HasColumnType("nvarchar(max)");

                            b1.Property<string>("Country")
                                .IsRequired()
                                .HasColumnType("nvarchar(max)");

                            b1.Property<string>("PostalCode")
                                .IsRequired()
                                .HasColumnType("nvarchar(max)");

                            b1.Property<string>("Region")
                                .IsRequired()
                                .HasColumnType("nvarchar(max)");

                            b1.HasKey("RoomId");

                            b1.ToTable("Rooms");

                            b1.ToJson("Address");

                            b1.WithOwner()
                                .HasForeignKey("RoomId");
                        });

                    b.OwnsMany("RoomBookings.Rooms.Domain.ValueObjects.Bed", "Beds", b1 =>
                        {
                            b1.Property<int>("RoomId")
                                .HasColumnType("int");

                            b1.Property<int>("Id")
                                .ValueGeneratedOnAdd()
                                .HasColumnType("int");

                            b1.Property<string>("BedType")
                                .IsRequired()
                                .HasColumnType("nvarchar(max)");

                            b1.HasKey("RoomId", "Id");

                            b1.ToTable("Rooms");

                            b1.ToJson("Beds");

                            b1.WithOwner()
                                .HasForeignKey("RoomId");
                        });

                    b.OwnsMany("RoomBookings.Rooms.Domain.ValueObjects.BookingDurationDiscount", "BookingDurationDiscounts", b1 =>
                        {
                            b1.Property<int>("RoomId")
                                .HasColumnType("int");

                            b1.Property<int>("Id")
                                .ValueGeneratedOnAdd()
                                .HasColumnType("int");

                            b1.Property<int>("DiscountPercentage")
                                .HasColumnType("int");

                            b1.Property<int>("DurationDays")
                                .HasColumnType("int");

                            b1.HasKey("RoomId", "Id");

                            b1.ToTable("Rooms");

                            b1.ToJson("BookingDurationDiscounts");

                            b1.WithOwner()
                                .HasForeignKey("RoomId");
                        });

                    b.OwnsOne("RoomBookings.Rooms.Domain.ValueObjects.Facilities", "Facilities", b1 =>
                        {
                            b1.Property<int>("RoomId")
                                .HasColumnType("int");

                            b1.Property<bool>("HasAirCon")
                                .HasColumnType("bit");

                            b1.Property<bool>("HasFreeParking")
                                .HasColumnType("bit");

                            b1.Property<bool>("HasFreeWifi")
                                .HasColumnType("bit");

                            b1.Property<bool>("HasSatelliteTv")
                                .HasColumnType("bit");

                            b1.HasKey("RoomId");

                            b1.ToTable("Rooms");

                            b1.ToJson("Facilities");

                            b1.WithOwner()
                                .HasForeignKey("RoomId");
                        });

                    b.Navigation("Address")
                        .IsRequired();

                    b.Navigation("Beds");

                    b.Navigation("BookingDurationDiscounts");

                    b.Navigation("Facilities")
                        .IsRequired();
                });

            modelBuilder.Entity("RoomBookings.Rooms.Domain.Room", b =>
                {
                    b.Navigation("Bookings");
                });
#pragma warning restore 612, 618
        }
    }
}