﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using MyCommunitySite.Models;

#nullable disable

namespace MyCommunitySite.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    [Migration("20241121224025_Hike")]
    partial class Hike
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.28")
                .HasAnnotation("Relational:MaxIdentifierLength", 64);

            modelBuilder.Entity("MyCommunitySite.Models.AppUser", b =>
                {
                    b.Property<int>("AppUserId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .HasColumnType("longtext");

                    b.Property<DateTime>("SignupDate")
                        .HasColumnType("datetime(6)");

                    b.HasKey("AppUserId");

                    b.ToTable("AppUsers");

                    b.HasData(
                        new
                        {
                            AppUserId = 1,
                            Name = "Ellen Ripley",
                            SignupDate = new DateTime(2024, 11, 21, 14, 40, 25, 785, DateTimeKind.Local).AddTicks(3909)
                        },
                        new
                        {
                            AppUserId = 2,
                            Name = "Laurie Strode",
                            SignupDate = new DateTime(2024, 11, 21, 14, 40, 25, 785, DateTimeKind.Local).AddTicks(3912)
                        },
                        new
                        {
                            AppUserId = 3,
                            Name = "Pamela Vorhees",
                            SignupDate = new DateTime(2024, 11, 21, 14, 40, 25, 785, DateTimeKind.Local).AddTicks(3915)
                        });
                });

            modelBuilder.Entity("MyCommunitySite.Models.Hike", b =>
                {
                    b.Property<int>("HikeId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<string>("Date")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("Location")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.HasKey("HikeId");

                    b.ToTable("Hikes");

                    b.HasData(
                        new
                        {
                            HikeId = 1,
                            Date = "11/08/2024",
                            Location = "Spencer Butte"
                        },
                        new
                        {
                            HikeId = 2,
                            Date = "10/13/2024",
                            Location = "Ridgeline Trail - Fox Hollow to Mt. Baldy"
                        });
                });

            modelBuilder.Entity("MyCommunitySite.Models.Message", b =>
                {
                    b.Property<int>("MessageId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<string>("Content")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<int>("Priority")
                        .HasColumnType("int");

                    b.Property<int>("RecipientId")
                        .HasColumnType("int");

                    b.Property<int>("SenderId")
                        .HasColumnType("int");

                    b.Property<string>("Subject")
                        .HasColumnType("longtext");

                    b.Property<DateTime>("TimeSent")
                        .HasColumnType("datetime(6)");

                    b.HasKey("MessageId");

                    b.HasIndex("RecipientId");

                    b.HasIndex("SenderId");

                    b.ToTable("Messages");

                    b.HasData(
                        new
                        {
                            MessageId = 1,
                            Content = "This is a test message",
                            Priority = 0,
                            RecipientId = 2,
                            SenderId = 1,
                            Subject = "Test1",
                            TimeSent = new DateTime(2024, 11, 21, 14, 40, 25, 785, DateTimeKind.Local).AddTicks(3737)
                        },
                        new
                        {
                            MessageId = 2,
                            Content = "This is a 2nd test message",
                            Priority = 0,
                            RecipientId = 3,
                            SenderId = 2,
                            Subject = "Test2",
                            TimeSent = new DateTime(2024, 11, 21, 14, 40, 25, 785, DateTimeKind.Local).AddTicks(3773)
                        });
                });

            modelBuilder.Entity("MyCommunitySite.Models.Message", b =>
                {
                    b.HasOne("MyCommunitySite.Models.AppUser", "Recipient")
                        .WithMany()
                        .HasForeignKey("RecipientId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("MyCommunitySite.Models.AppUser", "Sender")
                        .WithMany()
                        .HasForeignKey("SenderId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Recipient");

                    b.Navigation("Sender");
                });
#pragma warning restore 612, 618
        }
    }
}
