﻿// <auto-generated />
using MBApplication.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using MySql.Data.EntityFrameworkCore.Storage.Internal;
using System;

namespace MBApplication.Migrations
{
    [DbContext(typeof(MBAppDBContext))]
    partial class MBAppDBContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.0.1-rtm-125");

            modelBuilder.Entity("MBApplication.Data.Family", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("City")
                        .IsRequired();

                    b.Property<string>("FamilyName")
                        .IsRequired();

                    b.Property<string>("House")
                        .IsRequired();

                    b.Property<string>("State")
                        .IsRequired();

                    b.Property<string>("Street")
                        .IsRequired();

                    b.Property<int>("Zip");

                    b.HasKey("Id");

                    b.ToTable("Families");
                });

            modelBuilder.Entity("MBApplication.Data.Member", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<DateTime>("CreatedDate");

                    b.Property<DateTime>("DateOfBirth");

                    b.Property<string>("Email")
                        .IsRequired();

                    b.Property<int>("FamilyId");

                    b.Property<string>("FirstName")
                        .IsRequired();

                    b.Property<string>("Gender")
                        .IsRequired();

                    b.Property<DateTime>("LastModifiedDate");

                    b.Property<string>("LastName")
                        .IsRequired();

                    b.Property<string>("MaritalStatus")
                        .IsRequired();

                    b.Property<string>("MiddleName")
                        .IsRequired();

                    b.Property<string>("Telephone")
                        .IsRequired();

                    b.HasKey("Id");

                    b.HasIndex("FamilyId");

                    b.ToTable("Members");
                });

            modelBuilder.Entity("MBApplication.Data.Membership", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<DateTime>("CreatedDate");

                    b.Property<DateTime>("LastModifiedDate");

                    b.Property<int>("MemberId");

                    b.Property<string>("MembershipBy")
                        .IsRequired();

                    b.Property<int>("PremiseId");

                    b.Property<string>("Status")
                        .IsRequired();

                    b.HasKey("Id");

                    b.HasIndex("MemberId")
                        .IsUnique();

                    b.HasIndex("PremiseId");

                    b.ToTable("Memberships");
                });

            modelBuilder.Entity("MBApplication.Data.Premise", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("City")
                        .IsRequired();

                    b.Property<DateTime>("CreatedDate");

                    b.Property<string>("Email")
                        .IsRequired();

                    b.Property<string>("House")
                        .IsRequired();

                    b.Property<DateTime>("LastModifiedDate");

                    b.Property<string>("Name")
                        .IsRequired();

                    b.Property<string>("State")
                        .IsRequired();

                    b.Property<string>("Street")
                        .IsRequired();

                    b.Property<string>("Telephone")
                        .IsRequired();

                    b.Property<string>("Type")
                        .IsRequired();

                    b.Property<string>("Website");

                    b.Property<int>("Zip");

                    b.HasKey("Id");

                    b.ToTable("Premises");
                });

            modelBuilder.Entity("MBApplication.Data.Member", b =>
                {
                    b.HasOne("MBApplication.Data.Family", "Family")
                        .WithMany("Members")
                        .HasForeignKey("FamilyId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("MBApplication.Data.Membership", b =>
                {
                    b.HasOne("MBApplication.Data.Member", "Member")
                        .WithOne("Membership")
                        .HasForeignKey("MBApplication.Data.Membership", "MemberId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("MBApplication.Data.Premise", "Premise")
                        .WithMany("Membership")
                        .HasForeignKey("PremiseId")
                        .OnDelete(DeleteBehavior.Cascade);
                });
#pragma warning restore 612, 618
        }
    }
}
