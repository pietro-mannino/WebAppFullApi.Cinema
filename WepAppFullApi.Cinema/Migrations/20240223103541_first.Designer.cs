﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using WepAppFullApi.Cinema.Data;

#nullable disable

namespace WepAppFullApi.Cinema.Migrations
{
    [DbContext(typeof(CinemaDbContext))]
    [Migration("20240223103541_first")]
    partial class first
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.2")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("MovieTechnology", b =>
                {
                    b.Property<int>("MoviesMovieId")
                        .HasColumnType("int");

                    b.Property<int>("TechnologiesTechnologyId")
                        .HasColumnType("int");

                    b.HasKey("MoviesMovieId", "TechnologiesTechnologyId");

                    b.HasIndex("TechnologiesTechnologyId");

                    b.ToTable("MovieTechnology");
                });

            modelBuilder.Entity("RoomTechnology", b =>
                {
                    b.Property<int>("RoomsRoomId")
                        .HasColumnType("int");

                    b.Property<int>("TechnologiesTechnologyId")
                        .HasColumnType("int");

                    b.HasKey("RoomsRoomId", "TechnologiesTechnologyId");

                    b.HasIndex("TechnologiesTechnologyId");

                    b.ToTable("RoomTechnology");
                });

            modelBuilder.Entity("WepAppFullApi.Cinema.Data.ActivityRole", b =>
                {
                    b.Property<int>("ActivityRoleId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ActivityRoleId"));

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("IsDeleted")
                        .HasColumnType("bit");

                    b.HasKey("ActivityRoleId");

                    b.ToTable("Roles");
                });

            modelBuilder.Entity("WepAppFullApi.Cinema.Data.AgeLimit", b =>
                {
                    b.Property<int>("AgeLimitId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("AgeLimitId"));

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("IsDeleted")
                        .HasColumnType("bit");

                    b.HasKey("AgeLimitId");

                    b.ToTable("AgeLimits");
                });

            modelBuilder.Entity("WepAppFullApi.Cinema.Data.Employee", b =>
                {
                    b.Property<int>("EmployeeId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("EmployeeId"));

                    b.Property<bool>("IsDeleted")
                        .HasColumnType("bit");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Surname")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("EmployeeId");

                    b.ToTable("Employees");
                });

            modelBuilder.Entity("WepAppFullApi.Cinema.Data.Movie", b =>
                {
                    b.Property<int>("MovieId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("MovieId"));

                    b.Property<int>("AgeLimitId")
                        .HasColumnType("int");

                    b.Property<int>("DurationMins")
                        .HasColumnType("int");

                    b.Property<string>("ImdbId")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("IsDeleted")
                        .HasColumnType("bit");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("MovieId");

                    b.HasIndex("AgeLimitId");

                    b.ToTable("Movies");
                });

            modelBuilder.Entity("WepAppFullApi.Cinema.Data.Projection", b =>
                {
                    b.Property<int>("ProjectionId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ProjectionId"));

                    b.Property<DateTime>("FreeBy")
                        .HasColumnType("datetime2");

                    b.Property<bool>("IsDeleted")
                        .HasColumnType("bit");

                    b.Property<int>("MovieId")
                        .HasColumnType("int");

                    b.Property<int>("RoomId")
                        .HasColumnType("int");

                    b.Property<DateTime>("Start")
                        .HasColumnType("datetime2");

                    b.HasKey("ProjectionId");

                    b.HasIndex("MovieId");

                    b.HasIndex("RoomId");

                    b.ToTable("Projections");
                });

            modelBuilder.Entity("WepAppFullApi.Cinema.Data.ProjectionActivity", b =>
                {
                    b.Property<int>("EmployeeId")
                        .HasColumnType("int");

                    b.Property<int>("ActivityRoleId")
                        .HasColumnType("int");

                    b.Property<int>("ProjectionId")
                        .HasColumnType("int");

                    b.HasKey("EmployeeId", "ActivityRoleId", "ProjectionId");

                    b.HasIndex("ActivityRoleId");

                    b.HasIndex("ProjectionId");

                    b.ToTable("Activities");
                });

            modelBuilder.Entity("WepAppFullApi.Cinema.Data.Room", b =>
                {
                    b.Property<int>("RoomId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("RoomId"));

                    b.Property<int>("CleanTimeMins")
                        .HasColumnType("int");

                    b.Property<bool>("IsDeleted")
                        .HasColumnType("bit");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("RoomId");

                    b.ToTable("Rooms");
                });

            modelBuilder.Entity("WepAppFullApi.Cinema.Data.Technology", b =>
                {
                    b.Property<int>("TechnologyId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("TechnologyId"));

                    b.Property<bool>("IsDeleted")
                        .HasColumnType("bit");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("TechnologyType")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("TechnologyId");

                    b.ToTable("Tecnologies");
                });

            modelBuilder.Entity("MovieTechnology", b =>
                {
                    b.HasOne("WepAppFullApi.Cinema.Data.Movie", null)
                        .WithMany()
                        .HasForeignKey("MoviesMovieId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("WepAppFullApi.Cinema.Data.Technology", null)
                        .WithMany()
                        .HasForeignKey("TechnologiesTechnologyId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("RoomTechnology", b =>
                {
                    b.HasOne("WepAppFullApi.Cinema.Data.Room", null)
                        .WithMany()
                        .HasForeignKey("RoomsRoomId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("WepAppFullApi.Cinema.Data.Technology", null)
                        .WithMany()
                        .HasForeignKey("TechnologiesTechnologyId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("WepAppFullApi.Cinema.Data.Movie", b =>
                {
                    b.HasOne("WepAppFullApi.Cinema.Data.AgeLimit", "AgeLimit")
                        .WithMany("Movies")
                        .HasForeignKey("AgeLimitId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("AgeLimit");
                });

            modelBuilder.Entity("WepAppFullApi.Cinema.Data.Projection", b =>
                {
                    b.HasOne("WepAppFullApi.Cinema.Data.Movie", "Movie")
                        .WithMany("Projections")
                        .HasForeignKey("MovieId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("WepAppFullApi.Cinema.Data.Room", "Room")
                        .WithMany("Projections")
                        .HasForeignKey("RoomId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Movie");

                    b.Navigation("Room");
                });

            modelBuilder.Entity("WepAppFullApi.Cinema.Data.ProjectionActivity", b =>
                {
                    b.HasOne("WepAppFullApi.Cinema.Data.ActivityRole", "ActivityRole")
                        .WithMany("ProjectionActivities")
                        .HasForeignKey("ActivityRoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("WepAppFullApi.Cinema.Data.Employee", "Employee")
                        .WithMany("ProjectionActivities")
                        .HasForeignKey("EmployeeId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("WepAppFullApi.Cinema.Data.Projection", "Projection")
                        .WithMany("Activities")
                        .HasForeignKey("ProjectionId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("ActivityRole");

                    b.Navigation("Employee");

                    b.Navigation("Projection");
                });

            modelBuilder.Entity("WepAppFullApi.Cinema.Data.ActivityRole", b =>
                {
                    b.Navigation("ProjectionActivities");
                });

            modelBuilder.Entity("WepAppFullApi.Cinema.Data.AgeLimit", b =>
                {
                    b.Navigation("Movies");
                });

            modelBuilder.Entity("WepAppFullApi.Cinema.Data.Employee", b =>
                {
                    b.Navigation("ProjectionActivities");
                });

            modelBuilder.Entity("WepAppFullApi.Cinema.Data.Movie", b =>
                {
                    b.Navigation("Projections");
                });

            modelBuilder.Entity("WepAppFullApi.Cinema.Data.Projection", b =>
                {
                    b.Navigation("Activities");
                });

            modelBuilder.Entity("WepAppFullApi.Cinema.Data.Room", b =>
                {
                    b.Navigation("Projections");
                });
#pragma warning restore 612, 618
        }
    }
}
