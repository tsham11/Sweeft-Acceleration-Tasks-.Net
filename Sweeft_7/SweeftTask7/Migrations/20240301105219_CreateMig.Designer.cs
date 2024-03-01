﻿// <auto-generated />
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Task7;

#nullable disable

namespace SweeftTask7.Migrations
{
    [DbContext(typeof(SDBContext))]
    [Migration("20240301105219_CreateMig")]
    partial class CreateMig
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.2")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("Task7.Pupil", b =>
                {
                    b.Property<int>("Pupil_ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Pupil_ID"));

                    b.Property<string>("Class")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("FName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Gender")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("LName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Pupil_ID");

                    b.ToTable("Pupils");
                });

            modelBuilder.Entity("Task7.Teacher", b =>
                {
                    b.Property<int>("Teacher_ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Teacher_ID"));

                    b.Property<string>("FName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Gender")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("LName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Subject")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Teacher_ID");

                    b.ToTable("Teachers");
                });

            modelBuilder.Entity("Task7.TeacherPupil", b =>
                {
                    b.Property<int>("Teacher_Id")
                        .HasColumnType("int");

                    b.Property<int>("Pupil_Id")
                        .HasColumnType("int");

                    b.HasKey("Teacher_Id", "Pupil_Id");

                    b.HasIndex("Pupil_Id");

                    b.ToTable("TeacherPupils");
                });

            modelBuilder.Entity("Task7.TeacherPupil", b =>
                {
                    b.HasOne("Task7.Pupil", "Pupil")
                        .WithMany("TeacherPupils")
                        .HasForeignKey("Pupil_Id")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Task7.Teacher", "Teacher")
                        .WithMany("TeacherPupils")
                        .HasForeignKey("Teacher_Id")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Pupil");

                    b.Navigation("Teacher");
                });

            modelBuilder.Entity("Task7.Pupil", b =>
                {
                    b.Navigation("TeacherPupils");
                });

            modelBuilder.Entity("Task7.Teacher", b =>
                {
                    b.Navigation("TeacherPupils");
                });
#pragma warning restore 612, 618
        }
    }
}
