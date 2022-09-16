﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Repository;

#nullable disable

namespace Survey.Migrations
{
    [DbContext(typeof(RepositoryContext))]
    [Migration("20220915021634_InitialData")]
    partial class InitialData
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.9")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("Entities.Models.Choice", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<Guid>("QuestionId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.HasKey("Id");

                    b.HasIndex("QuestionId");

                    b.ToTable("Choices");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            QuestionId = new Guid("80abbca8-664d-4b20-b5de-024705497d4a"),
                            Title = "0"
                        },
                        new
                        {
                            Id = 2,
                            QuestionId = new Guid("80abbca8-664d-4b20-b5de-024705497d4a"),
                            Title = "1"
                        },
                        new
                        {
                            Id = 3,
                            QuestionId = new Guid("80abbca8-664d-4b20-b5de-024705497d4a"),
                            Title = "2"
                        },
                        new
                        {
                            Id = 4,
                            QuestionId = new Guid("80abbca8-664d-4b20-b5de-024705497d4a"),
                            Title = "3"
                        },
                        new
                        {
                            Id = 5,
                            QuestionId = new Guid("80abbca8-664d-4b20-b5de-024705497d4a"),
                            Title = "4"
                        },
                        new
                        {
                            Id = 6,
                            QuestionId = new Guid("80abbca8-664d-4b20-b5de-024705497d4a"),
                            Title = "5"
                        },
                        new
                        {
                            Id = 7,
                            QuestionId = new Guid("86dba8c0-d178-41e7-938c-ed49778fb52a"),
                            Title = "Taco Bell"
                        },
                        new
                        {
                            Id = 8,
                            QuestionId = new Guid("86dba8c0-d178-41e7-938c-ed49778fb52a"),
                            Title = "McDonald's"
                        },
                        new
                        {
                            Id = 9,
                            QuestionId = new Guid("86dba8c0-d178-41e7-938c-ed49778fb52a"),
                            Title = "Burger King"
                        },
                        new
                        {
                            Id = 10,
                            QuestionId = new Guid("86dba8c0-d178-41e7-938c-ed49778fb52a"),
                            Title = "Sonic"
                        },
                        new
                        {
                            Id = 11,
                            QuestionId = new Guid("021ca3c1-0deb-4afd-ae94-2159a8479811"),
                            Title = "Not very confident"
                        },
                        new
                        {
                            Id = 12,
                            QuestionId = new Guid("021ca3c1-0deb-4afd-ae94-2159a8479811"),
                            Title = "Somewhat confident"
                        },
                        new
                        {
                            Id = 13,
                            QuestionId = new Guid("021ca3c1-0deb-4afd-ae94-2159a8479811"),
                            Title = "Very confident"
                        });
                });

            modelBuilder.Entity("Entities.Models.Question", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier")
                        .HasColumnName("QuestionId");

                    b.Property<byte[]>("OptionalImage")
                        .HasColumnType("varbinary(max)");

                    b.Property<Guid>("SurveyId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.HasKey("Id");

                    b.HasIndex("SurveyId");

                    b.ToTable("Questions");

                    b.HasData(
                        new
                        {
                            Id = new Guid("80abbca8-664d-4b20-b5de-024705497d4a"),
                            SurveyId = new Guid("c9d4c053-49b6-410c-bc78-2d54a9991870"),
                            Title = "How would you rate McDonalds? (1-5)"
                        },
                        new
                        {
                            Id = new Guid("86dba8c0-d178-41e7-938c-ed49778fb52a"),
                            SurveyId = new Guid("c9d4c053-49b6-410c-bc78-2d54a9991870"),
                            Title = "Out of these fast food, which have you visited the most?"
                        },
                        new
                        {
                            Id = new Guid("021ca3c1-0deb-4afd-ae94-2159a8479811"),
                            SurveyId = new Guid("3d490a70-94ce-4d15-9494-5248280c2ce3"),
                            Title = "How confident are you on binary trees?"
                        });
                });

            modelBuilder.Entity("Entities.Models.Survey", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier")
                        .HasColumnName("SurveyId");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasMaxLength(60)
                        .HasColumnType("nvarchar(60)");

                    b.Property<string>("Topic")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Surveys");

                    b.HasData(
                        new
                        {
                            Id = new Guid("c9d4c053-49b6-410c-bc78-2d54a9991870"),
                            Title = "Top Fast Food in the United States",
                            Topic = "Health Science"
                        },
                        new
                        {
                            Id = new Guid("3d490a70-94ce-4d15-9494-5248280c2ce3"),
                            Title = "COSC 3212: Survey for Exam 1",
                            Topic = "Education"
                        });
                });

            modelBuilder.Entity("Entities.Models.Choice", b =>
                {
                    b.HasOne("Entities.Models.Question", "Question")
                        .WithMany("Choices")
                        .HasForeignKey("QuestionId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Question");
                });

            modelBuilder.Entity("Entities.Models.Question", b =>
                {
                    b.HasOne("Entities.Models.Survey", "Survey")
                        .WithMany("Questions")
                        .HasForeignKey("SurveyId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Survey");
                });

            modelBuilder.Entity("Entities.Models.Question", b =>
                {
                    b.Navigation("Choices");
                });

            modelBuilder.Entity("Entities.Models.Survey", b =>
                {
                    b.Navigation("Questions");
                });
#pragma warning restore 612, 618
        }
    }
}