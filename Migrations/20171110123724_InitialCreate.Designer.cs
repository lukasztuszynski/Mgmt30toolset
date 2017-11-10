﻿// <auto-generated />
using Mgmt30toolset.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage;
using Microsoft.EntityFrameworkCore.Storage.Internal;
using System;

namespace Mgmt30toolset.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    [Migration("20171110123724_InitialCreate")]
    partial class InitialCreate
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.0.0-rtm-26452");

            modelBuilder.Entity("Mgmt30toolset.Models.Kudo", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<int?>("CategoryId");

                    b.Property<string>("Content");

                    b.Property<DateTime>("DateCreated");

                    b.Property<DateTime?>("DateDeleted");

                    b.Property<DateTime>("DateUpdated");

                    b.Property<int?>("ReceiverId");

                    b.Property<int?>("SenderId");

                    b.Property<int?>("UserCreatedId");

                    b.Property<int?>("UserUpdatedId");

                    b.HasKey("Id");

                    b.HasIndex("CategoryId");

                    b.HasIndex("ReceiverId");

                    b.HasIndex("SenderId");

                    b.HasIndex("UserCreatedId");

                    b.HasIndex("UserUpdatedId");

                    b.ToTable("Kudos");
                });

            modelBuilder.Entity("Mgmt30toolset.Models.KudoCategory", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<DateTime>("DateCreated");

                    b.Property<DateTime?>("DateDeleted");

                    b.Property<DateTime>("DateUpdated");

                    b.Property<string>("Description");

                    b.Property<string>("Name");

                    b.Property<int?>("UserCreatedId");

                    b.Property<int?>("UserUpdatedId");

                    b.HasKey("Id");

                    b.HasIndex("UserCreatedId");

                    b.HasIndex("UserUpdatedId");

                    b.ToTable("KudoCategories");
                });

            modelBuilder.Entity("Mgmt30toolset.Models.User", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<DateTime>("DateCreated");

                    b.Property<DateTime?>("DateDeleted");

                    b.Property<DateTime>("DateUpdated");

                    b.Property<string>("Email");

                    b.Property<string>("FirstName");

                    b.Property<string>("LastName");

                    b.Property<string>("Password");

                    b.Property<int?>("UserCreatedId");

                    b.Property<int?>("UserUpdatedId");

                    b.Property<string>("Username");

                    b.HasKey("Id");

                    b.HasIndex("UserCreatedId");

                    b.HasIndex("UserUpdatedId");

                    b.ToTable("Users");
                });

            modelBuilder.Entity("Mgmt30toolset.Models.Kudo", b =>
                {
                    b.HasOne("Mgmt30toolset.Models.KudoCategory", "Category")
                        .WithMany()
                        .HasForeignKey("CategoryId");

                    b.HasOne("Mgmt30toolset.Models.User", "Receiver")
                        .WithMany()
                        .HasForeignKey("ReceiverId");

                    b.HasOne("Mgmt30toolset.Models.User", "Sender")
                        .WithMany()
                        .HasForeignKey("SenderId");

                    b.HasOne("Mgmt30toolset.Models.User", "UserCreated")
                        .WithMany()
                        .HasForeignKey("UserCreatedId");

                    b.HasOne("Mgmt30toolset.Models.User", "UserUpdated")
                        .WithMany()
                        .HasForeignKey("UserUpdatedId");
                });

            modelBuilder.Entity("Mgmt30toolset.Models.KudoCategory", b =>
                {
                    b.HasOne("Mgmt30toolset.Models.User", "UserCreated")
                        .WithMany()
                        .HasForeignKey("UserCreatedId");

                    b.HasOne("Mgmt30toolset.Models.User", "UserUpdated")
                        .WithMany()
                        .HasForeignKey("UserUpdatedId");
                });

            modelBuilder.Entity("Mgmt30toolset.Models.User", b =>
                {
                    b.HasOne("Mgmt30toolset.Models.User", "UserCreated")
                        .WithMany()
                        .HasForeignKey("UserCreatedId");

                    b.HasOne("Mgmt30toolset.Models.User", "UserUpdated")
                        .WithMany()
                        .HasForeignKey("UserUpdatedId");
                });
#pragma warning restore 612, 618
        }
    }
}
