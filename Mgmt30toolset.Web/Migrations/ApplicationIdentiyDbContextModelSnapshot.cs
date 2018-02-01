﻿// <auto-generated />
using Mgmt30toolset.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage;
using Microsoft.EntityFrameworkCore.Storage.Internal;
using System;

namespace Mgmt30toolset.Web.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    partial class ApplicationIdentiyDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.0.1-rtm-125");

            modelBuilder.Entity("Mgmt30toolset.Model.Bonus", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<DateTime>("DateCreated");

                    b.Property<DateTime?>("DateDeleted");

                    b.Property<DateTime>("DateUpdated");

                    b.Property<string>("Description");

                    b.Property<string>("ReceiverId");

                    b.Property<string>("SenderId");

                    b.Property<string>("UserCreatedId");

                    b.Property<string>("UserUpdatedId");

                    b.Property<int>("Value");

                    b.HasKey("Id");

                    b.HasIndex("ReceiverId");

                    b.HasIndex("SenderId");

                    b.HasIndex("UserCreatedId");

                    b.HasIndex("UserUpdatedId");

                    b.ToTable("Bonuses");
                });

            modelBuilder.Entity("Mgmt30toolset.Model.BonusTag", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<int?>("BonusId");

                    b.Property<DateTime>("DateCreated");

                    b.Property<DateTime?>("DateDeleted");

                    b.Property<DateTime>("DateUpdated");

                    b.Property<string>("UserCreatedId");

                    b.Property<string>("UserUpdatedId");

                    b.HasKey("Id");

                    b.HasIndex("BonusId");

                    b.HasIndex("UserCreatedId");

                    b.HasIndex("UserUpdatedId");

                    b.ToTable("BonusTags");
                });

            modelBuilder.Entity("Mgmt30toolset.Model.EduPoint", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<decimal>("Amount");

                    b.Property<int?>("CategoryId");

                    b.Property<DateTime>("DateCreated");

                    b.Property<DateTime?>("DateDeleted");

                    b.Property<DateTime>("DateUpdated");

                    b.Property<string>("Description");

                    b.Property<string>("ReceiverId");

                    b.Property<string>("SenderId");

                    b.Property<string>("UserCreatedId");

                    b.Property<string>("UserUpdatedId");

                    b.HasKey("Id");

                    b.HasIndex("CategoryId");

                    b.HasIndex("ReceiverId");

                    b.HasIndex("SenderId");

                    b.HasIndex("UserCreatedId");

                    b.HasIndex("UserUpdatedId");

                    b.ToTable("EduPoints");
                });

            modelBuilder.Entity("Mgmt30toolset.Model.EduPointCategory", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<DateTime>("DateCreated");

                    b.Property<DateTime?>("DateDeleted");

                    b.Property<DateTime>("DateUpdated");

                    b.Property<string>("Description");

                    b.Property<string>("Name");

                    b.Property<string>("UserCreatedId");

                    b.Property<string>("UserUpdatedId");

                    b.HasKey("Id");

                    b.HasIndex("UserCreatedId");

                    b.HasIndex("UserUpdatedId");

                    b.ToTable("EduPointCategories");
                });

            modelBuilder.Entity("Mgmt30toolset.Model.Kudo", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<int?>("CategoryId");

                    b.Property<string>("Content");

                    b.Property<DateTime>("DateCreated");

                    b.Property<DateTime?>("DateDeleted");

                    b.Property<DateTime>("DateUpdated");

                    b.Property<string>("ReceiverId");

                    b.Property<string>("SenderId");

                    b.Property<string>("UserCreatedId");

                    b.Property<string>("UserUpdatedId");

                    b.HasKey("Id");

                    b.HasIndex("CategoryId");

                    b.HasIndex("ReceiverId");

                    b.HasIndex("SenderId");

                    b.HasIndex("UserCreatedId");

                    b.HasIndex("UserUpdatedId");

                    b.ToTable("Kudos");
                });

            modelBuilder.Entity("Mgmt30toolset.Model.KudoCategory", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<DateTime>("DateCreated");

                    b.Property<DateTime?>("DateDeleted");

                    b.Property<DateTime>("DateUpdated");

                    b.Property<string>("Description");

                    b.Property<string>("Name");

                    b.Property<string>("UserCreatedId");

                    b.Property<string>("UserUpdatedId");

                    b.HasKey("Id");

                    b.HasIndex("UserCreatedId");

                    b.HasIndex("UserUpdatedId");

                    b.ToTable("KudoCategories");
                });

            modelBuilder.Entity("Mgmt30toolset.Model.User", b =>
                {
                    b.Property<string>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("AccessFailedCount");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken();

                    b.Property<string>("Email")
                        .HasMaxLength(256);

                    b.Property<bool>("EmailConfirmed");

                    b.Property<string>("FirstName");

                    b.Property<string>("LastName");

                    b.Property<bool>("LockoutEnabled");

                    b.Property<DateTimeOffset?>("LockoutEnd");

                    b.Property<string>("NormalizedEmail")
                        .HasMaxLength(256);

                    b.Property<string>("NormalizedUserName")
                        .HasMaxLength(256);

                    b.Property<string>("PasswordHash");

                    b.Property<string>("PhoneNumber");

                    b.Property<bool>("PhoneNumberConfirmed");

                    b.Property<string>("SecurityStamp");

                    b.Property<bool>("TwoFactorEnabled");

                    b.Property<string>("UserName")
                        .HasMaxLength(256);

                    b.HasKey("Id");

                    b.HasIndex("NormalizedEmail")
                        .HasName("EmailIndex");

                    b.HasIndex("NormalizedUserName")
                        .IsUnique()
                        .HasName("UserNameIndex");

                    b.ToTable("AspNetUsers");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRole", b =>
                {
                    b.Property<string>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken();

                    b.Property<string>("Name")
                        .HasMaxLength(256);

                    b.Property<string>("NormalizedName")
                        .HasMaxLength(256);

                    b.HasKey("Id");

                    b.HasIndex("NormalizedName")
                        .IsUnique()
                        .HasName("RoleNameIndex");

                    b.ToTable("AspNetRoles");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<string>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("ClaimType");

                    b.Property<string>("ClaimValue");

                    b.Property<string>("RoleId")
                        .IsRequired();

                    b.HasKey("Id");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetRoleClaims");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<string>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("ClaimType");

                    b.Property<string>("ClaimValue");

                    b.Property<string>("UserId")
                        .IsRequired();

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserClaims");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<string>", b =>
                {
                    b.Property<string>("LoginProvider");

                    b.Property<string>("ProviderKey");

                    b.Property<string>("ProviderDisplayName");

                    b.Property<string>("UserId")
                        .IsRequired();

                    b.HasKey("LoginProvider", "ProviderKey");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserLogins");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<string>", b =>
                {
                    b.Property<string>("UserId");

                    b.Property<string>("RoleId");

                    b.HasKey("UserId", "RoleId");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetUserRoles");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<string>", b =>
                {
                    b.Property<string>("UserId");

                    b.Property<string>("LoginProvider");

                    b.Property<string>("Name");

                    b.Property<string>("Value");

                    b.HasKey("UserId", "LoginProvider", "Name");

                    b.ToTable("AspNetUserTokens");
                });

            modelBuilder.Entity("Mgmt30toolset.Model.Bonus", b =>
                {
                    b.HasOne("Mgmt30toolset.Model.User", "Receiver")
                        .WithMany()
                        .HasForeignKey("ReceiverId");

                    b.HasOne("Mgmt30toolset.Model.User", "Sender")
                        .WithMany()
                        .HasForeignKey("SenderId");

                    b.HasOne("Mgmt30toolset.Model.User", "UserCreated")
                        .WithMany()
                        .HasForeignKey("UserCreatedId");

                    b.HasOne("Mgmt30toolset.Model.User", "UserUpdated")
                        .WithMany()
                        .HasForeignKey("UserUpdatedId");
                });

            modelBuilder.Entity("Mgmt30toolset.Model.BonusTag", b =>
                {
                    b.HasOne("Mgmt30toolset.Model.Bonus")
                        .WithMany("Tags")
                        .HasForeignKey("BonusId");

                    b.HasOne("Mgmt30toolset.Model.User", "UserCreated")
                        .WithMany()
                        .HasForeignKey("UserCreatedId");

                    b.HasOne("Mgmt30toolset.Model.User", "UserUpdated")
                        .WithMany()
                        .HasForeignKey("UserUpdatedId");
                });

            modelBuilder.Entity("Mgmt30toolset.Model.EduPoint", b =>
                {
                    b.HasOne("Mgmt30toolset.Model.EduPointCategory", "Category")
                        .WithMany()
                        .HasForeignKey("CategoryId");

                    b.HasOne("Mgmt30toolset.Model.User", "Receiver")
                        .WithMany()
                        .HasForeignKey("ReceiverId");

                    b.HasOne("Mgmt30toolset.Model.User", "Sender")
                        .WithMany()
                        .HasForeignKey("SenderId");

                    b.HasOne("Mgmt30toolset.Model.User", "UserCreated")
                        .WithMany()
                        .HasForeignKey("UserCreatedId");

                    b.HasOne("Mgmt30toolset.Model.User", "UserUpdated")
                        .WithMany()
                        .HasForeignKey("UserUpdatedId");
                });

            modelBuilder.Entity("Mgmt30toolset.Model.EduPointCategory", b =>
                {
                    b.HasOne("Mgmt30toolset.Model.User", "UserCreated")
                        .WithMany()
                        .HasForeignKey("UserCreatedId");

                    b.HasOne("Mgmt30toolset.Model.User", "UserUpdated")
                        .WithMany()
                        .HasForeignKey("UserUpdatedId");
                });

            modelBuilder.Entity("Mgmt30toolset.Model.Kudo", b =>
                {
                    b.HasOne("Mgmt30toolset.Model.KudoCategory", "Category")
                        .WithMany()
                        .HasForeignKey("CategoryId");

                    b.HasOne("Mgmt30toolset.Model.User", "Receiver")
                        .WithMany()
                        .HasForeignKey("ReceiverId");

                    b.HasOne("Mgmt30toolset.Model.User", "Sender")
                        .WithMany()
                        .HasForeignKey("SenderId");

                    b.HasOne("Mgmt30toolset.Model.User", "UserCreated")
                        .WithMany()
                        .HasForeignKey("UserCreatedId");

                    b.HasOne("Mgmt30toolset.Model.User", "UserUpdated")
                        .WithMany()
                        .HasForeignKey("UserUpdatedId");
                });

            modelBuilder.Entity("Mgmt30toolset.Model.KudoCategory", b =>
                {
                    b.HasOne("Mgmt30toolset.Model.User", "UserCreated")
                        .WithMany()
                        .HasForeignKey("UserCreatedId");

                    b.HasOne("Mgmt30toolset.Model.User", "UserUpdated")
                        .WithMany()
                        .HasForeignKey("UserUpdatedId");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityRole")
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<string>", b =>
                {
                    b.HasOne("Mgmt30toolset.Model.User")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<string>", b =>
                {
                    b.HasOne("Mgmt30toolset.Model.User")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityRole")
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("Mgmt30toolset.Model.User")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<string>", b =>
                {
                    b.HasOne("Mgmt30toolset.Model.User")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade);
                });
#pragma warning restore 612, 618
        }
    }
}
